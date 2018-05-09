using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion
{
    [Serializable]
    class Producto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioCompra { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }

        public Producto(int codigo, string descripcion, string categoria, 
            double precioVenta, double precioCompra, int stock, int stockMinimo)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Categoria = categoria;
            PrecioVenta = precioVenta;
            PrecioCompra = precioCompra;
            Stock = stock;
            StockMinimo = stockMinimo;
        }

        public Producto()
        {

        }
    }
}
