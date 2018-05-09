using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion
{
    [Serializable]
    class Factura
    {
        public Cabecera CabeceraActual {get; set;}
        public List<LineaDetalle> Lineas { get; set; }

        public Factura()
        {
            CabeceraActual = new Cabecera();
            Lineas = new List<LineaDetalle>();
        }
    }
}
