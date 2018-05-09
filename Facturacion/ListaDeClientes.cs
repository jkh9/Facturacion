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
    class ListaDeClientes
    {
        public List<Cliente> Clientes { get; set; }
        public int Count { get; set; }

        public ListaDeClientes()
        {
            Load();
            Count = Clientes.Count;
        }

        public void Add(Cliente clienteToAdd)
        {
            Clientes.Add(clienteToAdd);
            Count++;
        }

        public Cliente Get(int index)
        {
            return Clientes[index-1];
        }

        public void Load()
        {
            if (File.Exists("clientes.dat"))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("clientes.dat",
                        FileMode.Open);
                    Clientes = (List<Cliente>)formatter.Deserialize(stream);
                    stream.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Read fail");
                }
            }
            else
            {
                Clientes = new List<Cliente>();
            }
        }

        public void Save()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("clientes.dat",
                    FileMode.Create);
                formatter.Serialize(stream, Clientes);
                stream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Write fail");
            }
        }
    }
}
