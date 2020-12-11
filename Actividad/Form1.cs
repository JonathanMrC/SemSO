using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#region Cosas por hacer
/* buscar una manera de cambiar un bcp de una lista sin necesidad de hacer un temp y todo eso
 */
#endregion

namespace Actividad1
{
    public partial class Form : System.Windows.Forms.Form
    {
        public struct Proceso_Long
        {
            public Proceso proceso;
            public long tiempo;
            public Proceso_Long(Proceso p, long l)
            {
                proceso = p;
                tiempo = l;
            }
        }
        public class Frame{
            public string Id { get; set; }
            public string Estado { get; set; }
            public long Tam { get; set; }
            public Frame()
            {
                Id = "";
                Estado = "";
                Tam = 0;
            }
            public Frame(string id, string estado, long tam)
            {
                Id = id;
                Estado = estado;
                Tam = tam;
            }
        }
        public struct BCP
        {
            string _id;
            long _llegada, _finalizacion, _retorno, _respuesta, _espera, _servicio;
            public BCP(string id, long llegada, long finalizacion, long retorno, long respuesta, long espera, long servicio)
            {
                _id = id;
                _llegada = llegada;
                _finalizacion = finalizacion;
                _retorno = retorno;
                _respuesta = respuesta;
                _espera = espera;
                _servicio = servicio;
            }

            public string Id { get => _id; set => _id = value; }
            public long Llegada { get => _llegada; set => _llegada = value; }
            public long Finalizacion { get => _finalizacion; set => _finalizacion = value; }
            public long Retorno { get => _retorno; set => _retorno = value; }
            public long Respuesta { get => _respuesta; set => _respuesta = value; }
            public long Espera { get => _espera; set => _espera = value; }
            public long Servicio { get => _servicio; set => _servicio = value; }
        }

        bool inte = false, intw = false, intp = false, esperando_p = false;
        long proc_terminados, tt, totalproc, id, quantum, memoria, procesosEnMem;
        const int TIEMPO = 1000, TIEMPO_BLOQUEADO = 7, TAM_MEM = 200;
        Queue<Proceso_Long> bloqueados;
        Queue<Proceso> nuevos, listos;
        List<Proceso> Procesosterminados;
        List<Frame> frames;
        Proceso procesotemp;
        List<BCP> bcps, bcps_terminados;
        Thread hilo;
        Random r;

        public Form()
        {
            hilo = new Thread(Administrador);
            CheckForIllegalCrossThreadCalls = false;
            Procesosterminados = new List<Proceso>();
            bcps_terminados = new List<BCP>();
            nuevos = new Queue<Proceso>();
            frames = new List<Frame>();
            r = new Random();
            tt = proc_terminados = procesosEnMem = 0;
            memoria = TAM_MEM;
            quantum = -1;
            id = 1;
            for (int frames_t = TAM_MEM / 5; frames_t > 0; --frames_t) frames.Add(new Frame());
            frames[0].Id = "SO";
            frames[1].Id = "SO";
            memoria -= 10;
            InitializeComponent();
            panelInicial.Dock = DockStyle.Fill;
            Formatodgv();
            InicializarDGVFrames();
        }

        #region Datagrid
        void Formatodgv()
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("casilla_nombre", "Id");
            dgv.Columns.Add("estado", "Estado");
            dgv.Columns.Add("tme","Tiempo Maximo Estimado");
            dgv.Columns.Add("ttranscurrido", "Tiempo Transcurrido");
            dgv.Columns.Add("operacion", "Operacion");
            dgv.Columns.Add("respuesta", "Respuesta");
            dgv.Columns.Add("tll", "Tiempo LLegada");
            dgv.Columns.Add("tf", "Tiempo Finalizacion");
            dgv.Columns.Add("tr", "Tiempo Retorno");
            dgv.Columns.Add("te", "Tiempo Espera");
            dgv.Columns.Add("ts", "Tiempo Servicio");
            dgv.Columns.Add("tres_cpu", "Tiempo Restante CPU");
            dgv.Columns.Add("tres","Tiempo Respuesta");
            dgv.Refresh();
        }
        void InsertarEndgv(Proceso p, string s, long tbloqueado)
        {
            if (p.Id == "PN") return;
            int pos = dgv.Rows.Add();
            dgv[0, pos].Value = p.Id;
            dgv[1, pos].Value = s;
            if (s == "Bloqueado") dgv[1, pos].Value += " " + tbloqueado;
            dgv[2, pos].Value = p.Tme;
            dgv[3, pos].Value = p.Ttranscurrido;
            dgv[4, pos].Value = p.Operando1+p.Operador+p.Operando2;
            dgv[5, pos].Value = p.Respuesta;
            int i = BuscarBCP(p.Id);
            BCP temp = new BCP("", -1, -1, -1, -1, -1, -1);
            if (s == "Terminado") temp = bcps_terminados.Find(x => x.Id == p.Id);
            else if (s == "Ejecucion" || s == "Bloqueado" || s == "Listo") {
                temp = bcps[i];
                temp.Servicio = p.Ttranscurrido;
                temp.Espera = tt-temp.Llegada - temp.Servicio;
            }
            else if (s == "Nuevo")  temp = new BCP(p.Id, -1, -1, -1, -1, -1, -1);
            string contenido = "";
            if (temp.Llegada != -1) contenido += temp.Llegada;
            dgv[6, pos].Value = contenido;
            contenido = "";
            if (temp.Finalizacion != -1) contenido += temp.Finalizacion;
            dgv[7, pos].Value = contenido;
            contenido = "";
            if (temp.Retorno != -1) contenido += temp.Retorno;
            dgv[8, pos].Value = contenido;
            contenido = "";
            if (temp.Espera != -1) contenido += temp.Espera;
            dgv[9, pos].Value = contenido;
            contenido = "";
            if (temp.Servicio != -1) contenido += temp.Servicio;
            dgv[10, pos].Value = contenido;
            dgv[11, pos].Value = p.Tme - p.Ttranscurrido; 
            contenido = "";
            if (temp.Respuesta != -1) contenido += (temp.Respuesta - temp.Llegada);
            dgv[12, pos].Value = contenido;
        }
        public int BuscarBCP(string id)
        {
            for (int i = 0; i < bcps.Count; ++i)
            {
                if (bcps[i].Id == id) return i;
            }
            return -1;
        }
        void MostrarTabla()
        {
            pnl_simulacion.Visible = false;
            pnl_simulacion.Enabled = false;
            pnl_datgrid.Visible = true;
            pnl_datgrid.Dock = DockStyle.Fill;

            Formatodgv();

            foreach(Proceso p in Procesosterminados) InsertarEndgv(p, "Terminado", -1);                 //finalizados
            InsertarEndgv(procesotemp, "Ejecucion", -1);                                                //ejecucion
            foreach(Proceso_Long p in bloqueados) InsertarEndgv(p.proceso, "Bloqueado", p.tiempo);      //bloqueados
            foreach(Proceso p in listos) InsertarEndgv(p, "Listo", -1);                                 //listos
            foreach (Proceso p in nuevos) InsertarEndgv(p, "Nuevo", -1);                                //nuevos
            lbltt_pnlfin.Text = "Tiempo total: " + tt;                                                  //tiempo
        }
        void InicializarDGVFrames()
        {
            dgvFrames.Columns.Clear();
            dgvFrames.Columns.Add("frame1", "No.Frame");
            dgvFrames.Columns.Add("espacios1-7", "Proceso/Ocupado");
            dgvFrames.Columns.Add("frame2", "No.Frame");
            dgvFrames.Columns.Add("espacios8-15", "Proceso/Ocupado");
            dgvFrames.Columns.Add("frame3", "No.Frame");
            dgvFrames.Columns.Add("espacios16-23", "Proceso/Ocupado");
            dgvFrames.Columns.Add("frame4", "No.Frame");
            dgvFrames.Columns.Add("espacios24-31", "Proceso/Ocupado");
            dgvFrames.Columns.Add("frame5", "No.Frame");
            dgvFrames.Columns.Add("espacios32-40", "Proceso/Ocupado");
            for (int i = 0; i < 8;++i) dgvFrames.Rows.Add();
            for (int x = 0; x < 10; x+=2)
            {
                dgvFrames.Columns[x].Width = 60;
                for (int y = 0; y < 8; ++y)
                    dgvFrames[x, y].Value = y+1+((x>>1)*8);
            }
            dgvFrames.Refresh();
            ActualizarTablaFrames();
        }
        void ActualizarTablaFrames()
        {
            for (int x = 0; x < 10; x += 2)
            {
                for (int y = 0; y < 8; ++y)
                {
                    Frame f = frames[y + ((x >> 1) * 8)];
                    if (f.Id == "SO")
                    {
                        dgvFrames[x + 1, y].Style.BackColor = Color.Silver;
                        dgvFrames[x + 1, y].Value = "SO";
                    }
                    else if (f.Id == "")
                    {
                        dgvFrames[x + 1, y].Style.BackColor = Color.White;
                        dgvFrames[x + 1, y].Value = "";
                    }
                    else
                    {
                        dgvFrames[x + 1, y].Value = "ID: "+f.Id + " -> " + f.Tam + " / 5";
                        if (f.Estado == "Listo") dgvFrames[x + 1, y].Style.BackColor = Color.FromArgb(255, 252, 150);
                        else if (f.Estado == "Ejecucion") dgvFrames[x + 1, y].Style.BackColor = Color.FromArgb(150, 255, 176);
                        else if (f.Estado == "Bloqueado") dgvFrames[x + 1, y].Style.BackColor = Color.FromArgb(192, 150, 255);//bloqueados
                        else dgvFrames[x + 1, y].Style.BackColor = Color.Orange;
                    }
                }
            }
        }
        #endregion

        #region Calcular Resultados
        long BinPow(long b, long e)//si el exponente es solo postivo o igual a 0
        {
            if (e == 0) return 1;
            if (e == 1) return b;
            long temp = BinPow(b, e / 2);
            if (e % 2 == 0) return temp * temp;
            return temp * temp * b;
        }
        long Calc(long a, string op, long b)
        {
            if (op == "+") return a + b;
            else if (op == "-") return a - b;
            else if (op == "*") return a * b;
            else if (op == "/") return a / b;
            else if (op == "%") return a % b;
            return BinPow(a, b);
        }
        #endregion

        #region Generar Numeros Aleatorios
        int GenRandom(int iz, int der)
        {
            return r.Next(iz, der);
        }
        int GenRandom(int der)
        {
            return r.Next(der);
        }
        int GenRandom()
        {
            return r.Next();
        }
        #endregion

        Proceso CrearProceso(long id)
        {
            int limiz = 0, limder = 100001;
            string op = "";
            switch (GenRandom(6))//crear una operacion valida
            {
                case 0://suma
                    op = "+";
                    break;
                case 1://resta
                    op = "-";
                    break;
                case 2://multiplicacion
                    op = "*";
                    break;
                case 3://div
                    op = "/";
                    limiz++;
                    break;
                case 4://mod
                    op = "%";
                    limiz++;
                    break;
                case 5://exp
                    op = "^";
                    limder = 13;
                    break;

            }
            return new Proceso("" + id++, 7 + (GenRandom() % 10), op, GenRandom(limder), GenRandom(limiz, limder), GenRandom(6, 29));
        }

        #region Simulacion
        void Administrador()
        {
            listos = new Queue<Proceso>();
            bloqueados = new Queue<Proceso_Long>();
            bcps = new List<BCP>();
            AdministradorMemoria();
            while (proc_terminados != totalproc) {
                ListosAEjecucion();
                if (procesotemp.Id == "PN") EsperarProceso();
                else
                {
                    char resultado = EjecutarProceso(procesotemp);
                    if (resultado == 't') EjecucionATerminados(procesotemp, procesotemp.Tme == procesotemp.Ttranscurrido);
                    else if(resultado == 'b')EjecucionABloqueado();
                    else EjecucionAListos(procesotemp);
                }
            }
            Act_txtboxEjecucion(new Proceso("PN"), 0);
            MessageBox.Show("Resultados listos");

            ComenzarProceso.Text = "Mostrar Tabla";
            ComenzarProceso.Visible = true;
            procesotemp = new Proceso("PN");
        }
        void EsperarProceso()//solo se llama si no hay procesos en listos ni ejecutandose
        {
            esperando_p = true;
            /* Cuando no hay procesos en listos debido a que no hay procesos en nuevos
             * se llama a esta funcion si todos los procesos en memoria estan en bloqueados,
             * pero si se crea un proceso durante este paso especifico
             * debe terminar esta funcion y mandar el nuevo a listos y de listos a ejecucion.
             * */
            if (bloqueados.Count == procesosEnMem)//si el max de procesos esta en bloqueados 
            {
                while (bloqueados.Count == procesosEnMem)//esperar hasta que salga un proceso de bloqueado
                {
                    Thread.Sleep(TIEMPO);
                    lbltt.Text = "Tiempo Total: " + (++tt);
                    AdminstradorBloqueados();
                }
            }
            /* si no estan todos bloqueados, tampoco puede haber mas de max_mem, por lo que bloqueados <= 0
             * y si entre a esta funcion es por que ya no hay procesos en listos, ni en nuevos
             * por lo que debo esperar a que se cree un nuevo proceso o que salga uno de bloqueados.
             * si sale de bloqueados, pasa a listos por lo que listos sera distinto de 0
             * si se crea uno nuevo, la cantidad de nuevos sera distinto de 0
             * 
             * si estoy aqui entonces no hay en ejecucion por tanto la suma de todos es = bloqueados+listos
             */
            else
            {
                while (listos.Count == 0)//esperar hasta que pase un proceso a listos
                {
                    Thread.Sleep(TIEMPO);
                    lbltt.Text = "Tiempo Total: " + (++tt);
                    AdminstradorBloqueados();
                }
            }
            esperando_p = false;
        }
        char EjecutarProceso(Proceso p) 
        {
            bool termino = false;
            long quantum_ind = quantum;
            while (p.Tme != p.Ttranscurrido && quantum_ind > 0)
            {
                if (inte)
                {
                    inte = false;
                    break;
                }
                if (intw)
                {
                    intw = false;
                    termino = true;
                    break;
                }
                Thread.Sleep(TIEMPO);
                lbltt.Text = "Tiempo Total: " + (++tt);
                p.Ttranscurrido++;
                quantum_ind--;
                Act_txtboxEjecucion(p, quantum_ind);
                AdminstradorBloqueados();
            }
            if (termino || p.Tme == p.Ttranscurrido) return 't';
            return quantum_ind == 0 ? 'q' : 'b'; 
        }
        void AdminstradorBloqueados()
        {
            List<Proceso> temp = new List<Proceso>();
            if (bloqueados.Count() == 0) return;
            Queue<Proceso_Long> aux = new Queue<Proceso_Long>();
            while (bloqueados.Count() > 0)
            {
                Proceso_Long ptemp = bloqueados.Dequeue();
                if (ptemp.tiempo++ == TIEMPO_BLOQUEADO)
                {
                    listos.Enqueue(ptemp.proceso);
                    lbllistos.Text = "Listos: " + listos.Count();
                    temp.Add(ptemp.proceso);
                }
                else aux.Enqueue(ptemp);
            }
            bloqueados = aux;
            lblbloq.Text = "Bloqueados: " + bloqueados.Count;
            lbllistos.Text = "Listos: " + listos.Count;
            Act_txtboxListos();
            Act_txtboxBloqueados();
            foreach(Proceso p in temp)
            ActualizarFramesST(p, "Listo");
            ActualizarTablaFrames();
        }
        void AdministradorMemoria()//pasa procesos a nuevos
        {
            while (nuevos.Count > 0)//si hay nuevos
            {
                long tam = nuevos.Peek().Tamanio;
                long aux = tam / 5;
                if (tam % 5 != 0) ++aux;
                List<long> espacioDePaginas = new List<long>();
                for (int i = 1; i < aux; ++i) espacioDePaginas.Add(5);
                if(tam%5 == 0)espacioDePaginas.Add(5);
                else espacioDePaginas.Add(tam%5);
                tam = aux * 5;
                if (memoria >= tam)
                {
                    memoria -= tam;
                    Proceso p = nuevos.Peek();
                    AsignarFrames(p, espacioDePaginas);
                    NuevosAlistos();
                }
                else break;
            }
        }
        void AsignarFrames(Proceso p, List<long> paginas)
        {
            for (int i = 2; i < frames.Count && paginas.Count > 0; ++i)
                if (frames[i].Id == "")
                {
                    frames[i] = new Frame(p.Id, "Listo", paginas[0]);
                    paginas.RemoveAt(0);
                }
        }
        void ActualizarListaFrames(Proceso p, string estado)
        {
            for (int i = 0; i < frames.Count; ++i)
                if (frames[i].Id == p.Id) frames[i].Estado = estado;
            ActualizarTablaFrames();
        }
        void ActualizarFramesST(Proceso p, string estado)
        {
            for (int i = 0; i < frames.Count; ++i)
                if (frames[i].Id == p.Id) frames[i].Estado = estado;
        }
        void LimpiarFrames(Proceso p)
        {
            for (int i = 0; i < frames.Count; ++i)
                if (frames[i].Id == p.Id)
                {
                    frames[i] = new Frame();
                    memoria += 5;
                }
        }
        #endregion

        #region Transiciones
        void NuevosAlistos()
        {
            bcps.Add(new BCP(nuevos.Peek().Id, tt, -1, -1, -1, -1, -1));
            listos.Enqueue(nuevos.Dequeue());
            if (nuevos.Count > 0)
                lblnuevos.Text = "Nuevos: " + nuevos.Count() + " -> Id: " + nuevos.Peek().Id + " Tamaño: " + nuevos.Peek().Tamanio;
            else lblnuevos.Text = "Nuevos: " + nuevos.Count();
            lbllistos.Text = "Listos: " + listos.Count();
            Act_txtboxListos();
            procesosEnMem++;
            ActualizarListaFrames(listos.Peek(), "Listo");
        }
        void ListosAEjecucion()//pone en procesotemp un proceso (nulo o de listos)
        {
            if (listos.Count() > 0)
            {
                int i = BuscarBCP(listos.Peek().Id);
                BCP temp = bcps[i];
                if (temp.Respuesta == -1)//El valor por defecto es -1
                {
                    temp.Respuesta = tt;
                    bcps[i] = temp;
                }
                procesotemp = listos.Dequeue();
            }
            else procesotemp = new Proceso("PN");
            Act_txtboxListos();
            Act_txtboxEjecucion(procesotemp, quantum);
            ActualizarListaFrames(procesotemp, "Ejecucion");
        }
        void EjecucionAListos(Proceso p)
        {
            listos.Enqueue(p);
            lbllistos.Text = "Listos: " + listos.Count();
            Act_txtboxEjecucion(p, 0);
            Act_txtboxListos();
            ActualizarListaFrames(p, "Listo");
        }
        void EjecucionABloqueado()
        {
            bloqueados.Enqueue(new Proceso_Long(procesotemp, 0));
            Act_txtboxBloqueados();
            Act_txtboxEjecucion(procesotemp, 0);
            lblbloq.Text = "Bloqueados: " + bloqueados.Count;
            ActualizarListaFrames(procesotemp, "Bloqueado");
        }
        void EjecucionATerminados(Proceso p, bool termino_c)
        {
            if (termino_c) p.Respuesta = "" + Calc(p.Operando1, p.Operador, p.Operando2);
            else p.Respuesta = "ERROR";

            int i = BuscarBCP(p.Id);
            BCP temp = bcps[i];
            temp.Finalizacion = tt;
            temp.Retorno = temp.Finalizacion - temp.Llegada;
            temp.Servicio = p.Ttranscurrido;
            temp.Espera = temp.Retorno - temp.Servicio;
            bcps_terminados.Add(temp);
            bcps.RemoveAt(i);

            Procesosterminados.Add(p);
            Act_txtboxterminados(p);

            LimpiarFrames(p);
            ActualizarTablaFrames();
            procesosEnMem--;
            AdministradorMemoria();
        }
        #endregion

        #region Actualizar contenidos de texbox
        void Act_txtboxEjecucion(Proceso p, long quantum_ind)//Actualiza con los datos de p, en caso de ser PN vacia el txtbox
        {
            txtboxproceso_act.Text = "";
            if (p.Id != "PN")
            {
                txtboxproceso_act.Text = p.ToString(2) + "\r\nTiempo\r\nTranscurrido : "
                + p.Ttranscurrido + "\r\nRestante : "
                + (p.Tme - p.Ttranscurrido)
                + "\r\n\r\nQuantum: " + quantum_ind;
            }
            txtboxproceso_act.Refresh();
        }
        void Act_txtboxBloqueados()
        {
            txtboxbloqueados.Text = "";
            foreach (Proceso_Long par in bloqueados) txtboxbloqueados.Text += par.proceso.ToString(0) + "\r\nTiempo bloqueado: " + par.tiempo + "\r\n";
            txtboxbloqueados.Refresh();
        }
        void Act_txtboxListos()
        {
            txtbox_listos.Text = "";
            foreach (Proceso p in listos) txtbox_listos.Text += "" + p.ToString(1);
            txtbox_listos.Refresh();
        }
        void Act_txtboxterminados(Proceso p)//Actualizar el contenido del textbox procesos terminados
        {
            lbl_npterminados.Text = "Procesos terminados : " + (++proc_terminados);
            txtbox_terminados.Text = "\r\n" + p.ToString(3) + txtbox_terminados.Text;
            txtbox_terminados.Refresh();
            lbl_npterminados.Refresh();
        }
        #endregion

        private void TeclaenDGV(object sender, KeyPressEventArgs e)
        {
            if (hilo.IsAlive)
            {
                char c = Char.ToLower(e.KeyChar);
                if (intp)           //si estoy en pausa
                {
                    if (c == 'c')   //solo puedo leer la tecla de continuar
                    {
                        pnl_simulacion.Enabled = true;
                        pnl_simulacion.Visible = true;
                        pnl_simulacion.Dock = DockStyle.Fill;
                        pnl_datgrid.Visible = false;
                        hilo.Resume();
                        intp = false;
                    }
                }
            }
        }
        private void TeclaEnProcesoAct(object sender, KeyPressEventArgs e)//Se presiona una tecla para el proceso act
        {
            if (hilo.IsAlive)       //si el hilo esta activo
            {
                char c = Char.ToLower(e.KeyChar);
                if (intp)           //si estoy en pausa
                {
                    if (c == 'c')   //solo puedo leer la tecla de continuar
                    {
                        hilo.Resume();
                        intp = false;
                    }
                }
                else                //si no estoy en pausa
                {
                    if (c == 'p' || c == 'a')   //puedo leer pausar
                    {
                        intp = true;
                        hilo.Suspend();
                    }
                    if (c == 't')//Pausar y mostrar tabla de BCP
                    {
                        intp = true;
                        hilo.Suspend();
                        MostrarTabla();
                    }
                    if (c == 'n')
                    {
                        totalproc++;
                        nuevos.Enqueue(CrearProceso(id++));
                        lblnuevos.Text = "Nuevos: " + nuevos.Count() + " -> Id: " + nuevos.Peek().Id + " Tamaño: " + nuevos.Peek().Tamanio;
                        AdministradorMemoria();
                    }
                    if (!esperando_p) {//si no espero por un proceso
                        if (c == 'e') inte = true;
                        else if (c == 'w') intw = true;
                    }
                }
            }
        }
        private void PrimerEtapa(object sender, EventArgs e)//Leer cuantos procesos crear y pasar a siguiente panel
        {
            panelInicial.Visible = false;
            pnl_simulacion.Visible = true;
            pnl_simulacion.Dock = DockStyle.Fill;
            quantum = (long)nudQ.Value;
            lblquantum.Text += "" + quantum;
            long temp = totalproc = (long)nudCantProcesos.Value;
            while (temp-- > 0) nuevos.Enqueue(CrearProceso(id++));
            lblnuevos.Text = "Nuevos: " + nuevos.Count() + " -> Id: " + nuevos.Peek().Id + " Tamaño: " + nuevos.Peek().Tamanio;
        }
        private void SegundaEtapa(object sender, EventArgs e)//Comenzar la simulacion
        {
            if (ComenzarProceso.Text != "Mostrar Tabla")
            {
                hilo.Start();
                ComenzarProceso.Visible = false;
            }
            else
            {
                pnl_simulacion.Visible = false;
                btnAyudadgv.Visible = false;
                MostrarTabla();
            }
        }
        private void FormCerrado(object sender, FormClosedEventArgs e)
        {
            if (intp) hilo.Resume();
            hilo.Abort();
            Application.Exit();
        }
        private void btnMostrarAyuda_Click(object sender, EventArgs e)
        {
            if (hilo.IsAlive) hilo.Suspend();
            MessageBox.Show("Para llevar a cabo una interrupcion es necesario" +
                            "\r\n\t*Tener el cuadro de texto del " +
                            "\r\n\t proceso en ejecucion seleccionado" +
                            "\r\n\t*La simulacion debe estar ejecutandose" +
                            "\r\nLas funciones y teclas son:" +
                            "\r\n'e' -> mover el proceso en ejecucion a bloqueados" +
                            "\r\n'w' -> terminar el proceso en ejecucion con error" +
                            "\r\n'p' -> pausar la simulacion" +
                            "\r\n'c' -> continuar la simulacion" +
                            "\r\n'n' -> crear un nuevo proceso" +
                            "\r\n't' -> mostrar tabla de BCP de todos los procesos", "Ayuda");
            if (hilo.IsAlive) hilo.Resume();
        }
        private void btnAyudadgv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para cerrar la tabla de BCP de los procesos debe:" +
                            "\r\n*Tener seleccionada la tabla y despues precionar la tecla 'c'", "Ayuda");
        }

    }
}