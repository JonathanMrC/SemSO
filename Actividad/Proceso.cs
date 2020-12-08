using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1
{
    public class Proceso
    {
        public string Id { get; set; }
        public string Operador { get; set; }
        public string Respuesta { get; set; }
        public long Tme { get; set; }
        public long Operando1 { get; set; }
        public long Operando2 { get; set; }
        public long Ttranscurrido { get; set; }
        public long Tamanio { get; set; }
        public Proceso(string id, long tme, string operador, long op1, long op2, long tamanio)
        {
            Id = id;
            Tme = tme;
            Ttranscurrido = 0;
            Operador = operador;
            Operando1 = op1;
            Operando2 = op2;
            Tamanio = tamanio;
        }
        public Proceso(string s)
        {
            Id = s;
            Operador = "+";
            Tme = 0;
            Ttranscurrido = 0;
            Operando1 = 0;
            Operando2 = 0;
            Tamanio = 0;
        }
        public string ToString(int opc)
        {
            if (opc == 0) return "ID: " + Id;
            else if (opc == 1) return "ID : " + Id + "\r\nTiempo\r\nMax Estimado: " + Tme + "\r\nRestante: " + (Tme-Ttranscurrido) + "\r\n";
            else if (opc == 2) return "ID : " + Id + "\r\nOperacion : " + Operando1 + Operador + Operando2 + "\r\nTME : " + Tme + "\r\n";
            else if (opc == 3) return "ID : " + Id + "\r\nOperacion : " + Operando1 + Operador + Operando2 + "\r\nRespuesta : " + Respuesta + "\r\n-------------------------------------\r\n";
            return this.ToString();
        }
    }
}
