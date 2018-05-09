using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion
{
    [Serializable]
    class LineaDetalle
    {
        public Producto ProductoActual { get; set; }
        public int Cantidad { get; set; }

        public LineaDetalle()
        {

        }
    }
}
