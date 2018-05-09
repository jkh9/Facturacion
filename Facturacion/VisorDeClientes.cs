using System;
using System.Collections.Generic;

namespace Facturacion
{
    class VisorDeClientes
    {
        public ListaDeClientes Clientes { get; set; }
        public int Index { get; set; }

        public VisorDeClientes()
        {
            Clientes = new ListaDeClientes();
            Index = 1;
        }

        public void Ejecutar()
        {
            bool exit = false;
            do
            {
                drawActualClient();
                getUserImput(ref exit);
            } while (!exit);
        }

        private void resetConsole()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth + 1));
            }

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void drawActualClient()
        {
            resetConsole();

            string line = new string('-', Console.WindowWidth);
            string emptyLine = new string(' ', Console.WindowWidth - 2);
            string helpLine1 = "1-Anterior  2-Posterior  3-Número  4-Buscar  " +
                "5-Añadir  6-Modificar  B-Borrar";
            string helpLine2 = "7-Listados  F1-Ayuda  0-Terminar";
            string topLine = "Clientes (ficha actual: "+Index+ "/"+ Clientes.Count+")";
            string date = (DateTime.Now.Date + "").Substring(0, 11) + "       " +
                (DateTime.Now.Date + "").Substring(11);

            //Cuadrado de arriba
            Console.SetCursorPosition(0, 0);
            Console.Write(line);
            Console.Write("|" + emptyLine + "|");
            Console.Write(line);
            Console.SetCursorPosition(1, 1);
            Console.Write(topLine);
            Console.SetCursorPosition(Console.WindowWidth / 2, 1);
            Console.Write(date);

            //Cuerpo del programa
            Console.SetCursorPosition(0, 4);
            Console.Write("Nombre: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Nombre));
            Console.Write("DNI / CIF: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Cif));
            Console.WriteLine();
            Console.Write("Domicilio: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Domicilio));
            Console.Write("Ciudad: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Ciudad));
            Console.Write("Cod.Postal: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).CodigoPostal.ToString("00000")));
            Console.Write("Pais: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Pais));
            Console.Write("Teléfono: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Telefono));
            Console.Write("E-mail: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Email));
            Console.Write("Contacto: ");
            Console.CursorLeft = 11;
            Console.WriteLine(checkVacio(Clientes.Get(Index).Contacto));
            Console.WriteLine();
            Console.WriteLine("Observaciones: ");
            Console.CursorLeft = 11;
            Console.CursorLeft = 3;
            Console.WriteLine(Clientes.Get(Index).Observaciones);

            //Parte de abajo
            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            Console.Write(line);
            Console.SetCursorPosition(Console.WindowWidth / 2 -
                (helpLine1.Length / 2), Console.WindowHeight - 3);
            Console.WriteLine(helpLine1);
            Console.SetCursorPosition(Console.WindowWidth / 2 -
                (helpLine2.Length / 2), Console.WindowHeight - 2);
            Console.WriteLine(helpLine2);


            Console.ResetColor();
        }

        private string checkVacio(string lineToCheck)
        {
            if (lineToCheck == "" || lineToCheck == null)
            {
                return "(Por Confirmar)";
            }
            else
            {
                return lineToCheck.ToString();
            }
        }

        private string checkVacio(int lineToCheck)
        {
            if (lineToCheck == 0)
            {
                return "(Por Confirmar)";
            }
            else
            {
                return lineToCheck.ToString();
            }
        }

        private Cliente newClient()
        {
            resetConsole();

            Cliente ClientToAdd = new Cliente();
            Console.Write("Nombre: ");
            ClientToAdd.Nombre = Console.ReadLine();
            Console.Write("DNI / CIF: ");
            ClientToAdd.Cif = Console.ReadLine();
            Console.Write("Domicilio: ");
            ClientToAdd.Domicilio = Console.ReadLine();
            Console.Write("Ciudad: ");
            ClientToAdd.Ciudad = Console.ReadLine();
            Console.Write("Cod.Postal: ");
            try
            {
                ClientToAdd.CodigoPostal = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            Console.Write("Pais: ");
            ClientToAdd.Pais = Console.ReadLine();
            Console.Write("Teléfono: ");
            try
            {
                ClientToAdd.Telefono = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            Console.Write("E-mail: ");
            ClientToAdd.Email = Console.ReadLine();
            Console.Write("Contacto: ");
            ClientToAdd.Contacto = Console.ReadLine();
            Console.Write("Observaciones: ");
            ClientToAdd.Observaciones = Console.ReadLine();
            if (ClientToAdd.Observaciones == "")
                ClientToAdd.Observaciones = "Sin Comentarios";

            return ClientToAdd;
        }

        private int JumpIntoClient()
        {
            resetConsole();
            int client = Index;
            Console.Write("Index? ");
            try
            {
                client = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
                Console.WriteLine("Press enter to return");
                Console.ReadLine();
            }

            if (client > Clientes.Count)
            {
                client = Index;
                Console.WriteLine("Doesn't exist");
                Console.WriteLine("Press enter to return");
                Console.ReadLine();
            }

            return client;
        }

        private Cliente modifyClient(Cliente actual)
        {
            resetConsole();

            Cliente ClientToAdd = actual;
            string cadena;

            Console.WriteLine("Press enter to not modify");

            Console.Write("Nombre ("+ClientToAdd.Nombre+"): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ClientToAdd.Nombre = cadena;
            }
            Console.Write("DNI / CIF (" + ClientToAdd.Cif + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ClientToAdd.Cif = cadena;
            }
            Console.Write("Domicilio (" + ClientToAdd.Domicilio + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ClientToAdd.Domicilio = cadena;
            }
            Console.Write("Ciudad (" + ClientToAdd.Ciudad + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ClientToAdd.Ciudad = cadena;
            }

            Console.Write("Cod.Postal (" + ClientToAdd.CodigoPostal + "): ");
            try
            {
                ClientToAdd.CodigoPostal = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            Console.Write("Pais (" + ClientToAdd.Pais + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ClientToAdd.Pais = cadena;
            }
            Console.Write("Teléfono (" + ClientToAdd.Telefono + "): ");
            try
            {
                ClientToAdd.Telefono = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            Console.Write("E-mail (" + ClientToAdd.Email + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ClientToAdd.Email = cadena;
            }
            Console.Write("Contacto (" + ClientToAdd.Contacto + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ClientToAdd.Contacto = cadena;
            }
            Console.Write("Observaciones (" + ClientToAdd.Observaciones + "): ");
            cadena = Console.ReadLine();
            if (cadena == "")
                ClientToAdd.Observaciones = "Sin Comentarios";
            else
                ClientToAdd.Observaciones = cadena;

            return ClientToAdd;
        }

        private int searchText()
        {
            resetConsole();
            Console.Write("Text to search: ");
            string text = Console.ReadLine().ToLower();

            Console.WriteLine("From this file or begining? file/begining");
            string index = Console.ReadLine();

            Console.WriteLine("Stop when finding a file o when finish? finding/finish");
            string stop = Console.ReadLine();

            int actualPos = 1;
            List<int> foundPositions = new List<int>();
            if (index == "file")
            {
                actualPos = Index;
            }

            bool find = false;
            do
            {
                Cliente clienteActual = Clientes.Get(actualPos);
                if (clienteActual.Nombre.ToLower().Contains(text) ||
                    clienteActual.Cif.ToLower().Contains(text) ||
                    clienteActual.Ciudad.ToLower().Contains(text) ||
                    clienteActual.CodigoPostal.ToString("00000").ToLower().Contains(text) ||
                    clienteActual.Pais.ToLower().Contains(text) ||
                    clienteActual.Telefono.ToString().ToLower().Contains(text) ||
                    clienteActual.Email.ToLower().Contains(text) ||
                    clienteActual.Contacto.ToLower().Contains(text) ||
                    clienteActual.Observaciones.ToLower().Contains(text))

                {
                    if (stop == "finding")
                    {
                        find = true;
                    }
                    foundPositions.Add(actualPos);
                }
                if (!find && actualPos < Clientes.Count)
                {
                    actualPos++;
                }
            } while (!find && actualPos < Clientes.Count);

            if (foundPositions.Count > 1)
            {
                Console.Write("Found at positions: ");
                Console.Write(foundPositions[0]);
                for (int i = 1; i < foundPositions.Count; i++)
                {
                    Console.Write(", "+foundPositions[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to return");
                Console.ReadLine();
                return Index;
            }

            return actualPos;
        }

        private void getUserImput(ref bool exit)
        {
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
            } while (Console.KeyAvailable);

            switch (key.Key)
            {
                case ConsoleKey.D0:
                    exit = true;
                    Clientes.Save();
                    break;
                case ConsoleKey.D1:
                    if (Index > 1)
                    {
                        Index--;
                    }
                    break;
                case ConsoleKey.D2:
                    if (Index < Clientes.Count)
                    {
                        Index++;
                    }
                    break;
                case ConsoleKey.D3:
                    Index = JumpIntoClient();
                    break;
                case ConsoleKey.D4:
                    Index = searchText();
                    break;
                case ConsoleKey.D5:
                    Clientes.Add(newClient());
                    break;
                case ConsoleKey.D6:
                    Clientes.Clientes[Index - 1] = modifyClient(Clientes.Get(Index));
                    break;
                default:
                    break;
            }
        }
    }
}
