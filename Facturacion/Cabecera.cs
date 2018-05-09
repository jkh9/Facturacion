using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion
{
    [Serializable]
    class Cabecera
    {
        public int Numero { get; set; }
        public DateTime Date { get; set; }
        public Cliente ClienteActual { get; set; }

        public Cabecera()
        {

        }
    }
}
