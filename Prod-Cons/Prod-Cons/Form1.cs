using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prod_Cons
{
    public partial class Form1 : Form
    {
        Image lleno, vacio;
        Random tiempo_consumidor, tiempo_productor; 
        List<PictureBox> espacios = new List<PictureBox>();
        Thread proceso1, proceso2;
        int espacios_llenos, pos_cons, pos_prod;
        bool carrera, prod_trabajando, cons_trabajando;
        readonly int TIEMPO = 1000;
        public Form1()
        {
            if (!File.Exists(@"Lleno.png") || !File.Exists(@"Vacio.png") )
            {
                MessageBox.Show("Las imagenes 'LLeno.png' y 'Vacio.png', no se encuentran en la misma carpeta" +
                    "\r\nPor favor Agreguelas para poder continuar"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InitializeComponent();
                lleno = Image.FromFile(@"Lleno.png");
                vacio = Image.FromFile(@"Vacio.png");
                espacios_llenos = pos_cons = pos_prod = 0;
                prod_trabajando = cons_trabajando = false;
                tiempo_productor = new Random(new Random().Next(1, 10000000));
                tiempo_consumidor = new Random(tiempo_productor.Next(0,10000000));
                carrera = true;
                AgregarPictureboxes();
                proceso1 = new Thread(Productor);
                proceso2 = new Thread(Consumidor);
                CheckForIllegalCrossThreadCalls = false;
                proceso1.Start();
                proceso2.Start();
            }
        }
        void AgregarPictureboxes()
        {
            espacios.Add(pictureBox0);
            espacios.Add(pictureBox1);
            espacios.Add(pictureBox2);
            espacios.Add(pictureBox3);
            espacios.Add(pictureBox4);
            espacios.Add(pictureBox5);
            espacios.Add(pictureBox6);
            espacios.Add(pictureBox7);
            espacios.Add(pictureBox8);
            espacios.Add(pictureBox9);
            espacios.Add(pictureBox10);
            espacios.Add(pictureBox11);
            espacios.Add(pictureBox12);
            espacios.Add(pictureBox13);
            espacios.Add(pictureBox14);
            espacios.Add(pictureBox15);
            espacios.Add(pictureBox16);
            espacios.Add(pictureBox17);
            espacios.Add(pictureBox18);
            espacios.Add(pictureBox19);
            espacios.Add(pictureBox20);
            espacios.Add(pictureBox21);
            espacios.Add(pictureBox22);
            espacios.Add(pictureBox23);
            espacios.Add(pictureBox24);
        }

        public void CambiarEstado(PictureBox espacio)
        {
            if (espacio.Image == lleno)
            {
                espacio.Image = vacio;
                espacios_llenos--;
            }
            else
            {
                espacio.Image = lleno;
                espacios_llenos++;
            }
        }

        void Productor()
        {
            //Dormido
            prod_trabajando = false;
            txt_eprod.Text = "Dormido"; 
            txt_eprod.BackColor = Color.Gray;
                
            while (carrera)
            {
                Thread.Sleep(tiempo_productor.Next(1, 4)*TIEMPO);       //duerme entre 1 y (4-1)
                //Despierto
                int cantidad = tiempo_productor.Next(3, 11);    //cantidad que producira
                while (cantidad-- > 0) {                        //tiempo que intentara trabajar
                    Thread.Sleep(TIEMPO);                                       //simulando el tiempo                                                                               
                    if (!HayProducto(espacios[pos_prod]) && !cons_trabajando)   //hay espacio y no esta trabajando el consumidor
                    {
                        prod_trabajando = true;                                 //bandera del productor
                        txt_eprod.Text = "Trabajando: " + cantidad;                          //estado del prod en pantalla
                        txt_eprod.BackColor = Color.LightGreen;                 //poner en verde el estado
                        CambiarEstado(espacios[pos_prod++]);                    //mostrar graficamente el estado de un espacio
                        pos_prod %= 25;                                         //mod 25 para que no se pase 
                    }
                    else                                                        //esta trabajando el consumidor o esta lleno
                    {
                        prod_trabajando = false;                                 //bandera del productor
                        txt_eprod.BackColor = Color.Orange;                     //color del estado
                        txt_eprod.Text = "Intentando Trabajar";                 //estado productor                                                                          
                    }
                }
                //Dormido
                prod_trabajando = false;
                txt_eprod.Text = "Dormido"; 
                txt_eprod.BackColor = Color.Gray;
            }
        }
        void Consumidor()
        {
            //Dormido
            cons_trabajando = false;
            txt_econs.Text = "Dormido";
            txt_econs.BackColor = Color.Gray;
            while (carrera)
            {
                Thread.Sleep(tiempo_consumidor.Next(1, 4) * TIEMPO);       //duerme entre 1 y (4-1)
                //Despierto
                int cantidad = tiempo_consumidor.Next(3, 11);    //cantidad que producira
                while (cantidad-- > 0)
                {                        //tiempo que intentara trabajar
                    Thread.Sleep(TIEMPO);                                       //simulando el tiempo
                    if (HayProducto(espacios[pos_cons]) && !prod_trabajando)   //hay prod y no esta trabajando el consumidor
                    {
                        cons_trabajando = true;                                 //bandera del productor
                        txt_econs.Text = "Trabajando: "+cantidad;                          //estado del prod en pantalla
                        txt_econs.BackColor = Color.LightGreen;                 //poner en verde el estado
                        CambiarEstado(espacios[pos_cons++]);                    //mostrar graficamente el estado de un espacio
                        pos_cons %= 25;                                         //mod 25 para que no se pase 
                    }
                    else                                                        //esta trabajando el consumidor o esta lleno
                    {
                        cons_trabajando = false;                                 //bandera del productor
                        txt_econs.BackColor = Color.Orange;                     //color del estado
                        txt_econs.Text = "Intentando Trabajar";                 //estado productor
                    }
                }
                cons_trabajando = false;
                txt_econs.Text = "Dormido";
                txt_econs.BackColor = Color.Gray;
            }
        }

        public bool HayProducto(PictureBox espacio)
        {
            if (espacio.Image == lleno)
                return true;
            return false;
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (proceso1.IsAlive) proceso1.Abort();
            if (proceso2.IsAlive) proceso2.Abort();
            Application.Exit();
        }
    }
}
