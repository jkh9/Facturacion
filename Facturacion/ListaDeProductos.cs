using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion
{
    [Serializable]
    class ListaDeProductos
    {
        public List<Producto> Productos { get; set; }
        public int Count { get; set; }

        public ListaDeProductos()
        {
            Load();
            Count = Productos.Count;
        }

        public void Add(Producto productoToAdd)
        {
            Productos.Add(productoToAdd);
            Count++;
        }

        public Producto Get(int index)
        {
            return Productos[index - 1];
        }

        public void Load()
        {
            if (File.Exists("productos.dat"))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("productos.dat",
                        FileMode.Open);
                    Productos = (List<Producto>)formatter.Deserialize(stream);
                    stream.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Read fail");
                }
            }
            else
            {
                Productos = new List<Producto>();
            }
        }

        public void Save()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("productos.dat",
                    FileMode.Create);
                formatter.Serialize(stream, Productos);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Write fail ERROR: "+e.Message);
            }
        }
    }
}
