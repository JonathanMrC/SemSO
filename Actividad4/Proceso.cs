using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1
{
    public class Proceso
    {
        public Proceso(string id, long tme, string operador, long op1, long op2)
        {
            this.id = id;
            this.tme = tme;
            this.ttranscurrido = 0;
            this.operador = operador;
            this.operando1 = op1;
            this.operando2 = op2;
        }
        string id, operador, respuesta;
        long tme, operando1, operando2, ttranscurrido;

        public string Operador { get => operador; set => operador = value; }
        public long Operando1 { get => operando1; set => operando1 = value; }
        public long Operando2 { get => operando2; set => operando2 = value; }
        public string Id { get => id; set => id = value; }
        public long Tme { get => tme; set => tme = value; }
        public long Ttranscurrido { get => ttranscurrido; set => ttranscurrido = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
        public string ToString(int opc)
        {
            if (opc == 0) return "ID: " + id;
            else if (opc == 1) return "ID : " + id + "\r\nTiempo\r\nMaximo estimado: " + tme + "\r\nTiempo transcurrido: " + ttranscurrido + "\r\n";
            else if (opc == 2) return "ID : " + id + "\r\nOperacion : " + operando1 + operador + operando2 + "\r\nTME : " + tme + "\r\n";
            else if (opc == 3) return "ID : " + id + "\r\nOperacion : " + operando1 + operador + operando2 + "\r\nRespuesta : " + respuesta + "\r\n-------------------------------------\r\n";
            return this.ToString();
        }
    }
}
