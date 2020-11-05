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
        long proc_terminados, tt, totalproc, id = 1;
        const int TIEMPO = 1000, MAX_MEM = 4, TIEMPO_BLOQUEADO = 8;
        Queue<Proceso_Long> bloqueados;
        Queue<Proceso> nuevos, listos;
        List<Proceso> Procesosterminados;
        Proceso procesotemp;
        List<BCP> bcps, bcps_terminados;
        Thread hilo;
        Random r;

        public Form()
        {
            hilo = new Thread(Administrador);
            CheckForIllegalCrossThreadCalls = false;
            nuevos = new Queue<Proceso>();
            Procesosterminados = new List<Proceso>();
            bcps_terminados = new List<BCP>();
            r = new Random();
            tt = proc_terminados = 0;

            InitializeComponent();
            panelInicial.Dock = DockStyle.Fill;
            Formatodgv();
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
            if (temp.Respuesta != -1) contenido += temp.Respuesta;
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
            pnlproceso.Visible = false;
            pnlproceso.Enabled = false;
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
            return new Proceso("" + id++, 7 + (GenRandom() % 10), op, GenRandom(limder), GenRandom(limiz, limder));
        }

        #region Simulacion
        void Administrador()
        {
            listos = new Queue<Proceso>();
            bloqueados = new Queue<Proceso_Long>();
            bcps = new List<BCP>();
            long aux = MAX_MEM;
            while (aux-- > 0 && nuevos.Count() > 0) NuevosAlistos(); //pongo en listos los procesos posibles
            while (proc_terminados != totalproc) {
                ListosAEjecucion();
                if (procesotemp.Id == "PN") EsperarProceso();
                else
                {
                    if (EjecutarProceso(procesotemp)) EjecucionATerminados(procesotemp, procesotemp.Tme == procesotemp.Ttranscurrido);
                    else EjecucionABloqueado();
                }
            }
            Act_txtboxEjecucion(new Proceso("PN", 0, "+", 0, 0));
            MessageBox.Show("Resultados listos");

            ComenzarProceso.Text = "Mostrar Tabla";
            ComenzarProceso.Visible = true;
            procesotemp = new Proceso("PN", 0, "+", 0, 0);
        }
        void EsperarProceso()//solo se llama si no hay procesos en listos ni ejecutandose
        {
            esperando_p = true;
            /* Cuando no hay procesos en listos debido a que no hay procesos en nuevos
             * se llama a esta funcion si todos los procesos en memoria estan en bloqueados,
             * pero si se crea un proceso durante este paso especifico
             * debe terminar esta funcion y mandar el nuevo a listos y de listos a ejecucion.
             * */
            if (bloqueados.Count == MAX_MEM)//si el max de procesos esta en bloqueados 
            {
                while (bloqueados.Count == MAX_MEM)//esperar hasta que salga un proceso de bloqueado
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
        bool EjecutarProceso(Proceso p) 
        {
            bool termino = false;
            while (p.Tme != p.Ttranscurrido)
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
                Act_txtboxEjecucion(p);
                AdminstradorBloqueados();
            }
            if(termino) return termino;//termino por error
            return p.Tme == p.Ttranscurrido;//termino por tiempo o no termino
        }
        #endregion

        #region Transiciones
        void AdminstradorBloqueados()
        {
            if (bloqueados.Count() == 0) return;
            Queue<Proceso_Long> aux = new Queue<Proceso_Long>();
            while (bloqueados.Count() > 0)
            {
                Proceso_Long ptemp = bloqueados.Dequeue();
                if (ptemp.tiempo++ == TIEMPO_BLOQUEADO) listos.Enqueue(ptemp.proceso);
                else aux.Enqueue(ptemp);
            }
            bloqueados = aux;
            Act_txtboxListos();
            Act_txtboxBloqueados();
        }
        void NuevosAlistos()
        {
            if (nuevos.Count == 0) return;
            bcps.Add(new BCP(nuevos.Peek().Id, tt, -1, -1, -1, -1, -1));
            listos.Enqueue(nuevos.Dequeue());
            lblnuevos.Text = "Nuevos: " + nuevos.Count();
            lblnuevos.Refresh();
            Act_txtboxListos();
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
            else procesotemp = new Proceso("PN", 0, "+", 0, 0);
            Act_txtboxListos();
            Act_txtboxEjecucion(procesotemp);
        }
        void EjecucionABloqueado()
        {
            bloqueados.Enqueue(new Proceso_Long(procesotemp, 0));
            Act_txtboxBloqueados();
            Act_txtboxEjecucion(procesotemp);
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
            NuevosAlistos();
        }
        #endregion

        #region Actualizar contenidos de texbox
        void Act_txtboxEjecucion(Proceso p)//Actualiza con los datos de p, en caso de ser PN vacia el txtbox
        {
            txtboxproceso_act.Text = "";
            if (p.Id != "PN")
            {
                txtboxproceso_act.Text = p.ToString(2) + "\r\nTiempo\r\nTranscurrido : "
                + p.Ttranscurrido + "\r\nRestante : "
                + (p.Tme - p.Ttranscurrido);
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
            txtbox_terminados.Text += "\r\n" + p.ToString(3);
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
                        pnlproceso.Enabled = true;
                        pnlproceso.Visible = true;
                        pnlproceso.Dock = DockStyle.Fill;
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
                    if (c == 'p')   //puedo leer pausar
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
                        lblnuevos.Text = "Nuevos: " + nuevos.Count();
                        lblnuevos.Refresh();
                        int procesos_en_mem = bloqueados.Count + listos.Count;
                        if (procesotemp.Id != "PN") procesos_en_mem++;
                        if (procesos_en_mem < MAX_MEM) NuevosAlistos();
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
            pnlproceso.Visible = true;
            pnlproceso.Dock = DockStyle.Fill;
            long temp = totalproc = (long)nudCantProcesos.Value;
            while (temp-- > 0) nuevos.Enqueue(CrearProceso(id++));
            lblnuevos.Text += "" + nuevos.Count();
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
                pnlproceso.Visible = false;
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