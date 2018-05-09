using System;
using System.Collections.Generic;

namespace Facturacion
{
    class VisorDeProductos
    {
        public ListaDeProductos Productos { get; set; }
        public int Index { get; set; }

        public VisorDeProductos()
        {
            Productos = new ListaDeProductos();
            Index = 1;
        }

        public void Ejecutar()
        {
            bool exit = false;
            do
            {
                drawActualProduct();
                getUserImput(ref exit);
            } while (!exit);
        }

        private void resetConsole()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth + 1));
            }

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void drawActualProduct()
        {
            resetConsole();

            string line = new string('-', Console.WindowWidth);
            string emptyLine = new string(' ', Console.WindowWidth - 2);
            string helpLine1 = "1-Anterior  2-Posterior  3-Número  4-Buscar  " +
                "5-Añadir  6-Modificar  B-Borrar";
            string helpLine2 = "7-Listados  F1-Ayuda  0-Terminar";
            string topLine = "Productos (ficha actual: " + Index + "/" + Productos.Count + ")";
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
            Console.Write("Codigo: ");
            Console.CursorLeft = 15;
            Console.WriteLine(checkVacio(Productos.Get(Index).Codigo));
            Console.WriteLine();
            Console.Write("Descripcion: ");
            Console.CursorLeft = 15;
            Console.WriteLine(checkVacio(Productos.Get(Index).Descripcion));
            Console.Write("Categoria: ");
            Console.CursorLeft = 15;
            Console.WriteLine(checkVacio(Productos.Get(Index).Categoria));
            Console.WriteLine();
            Console.Write("Precio Venta: ");
            Console.CursorLeft = 15;
            Console.WriteLine(checkVacio(Productos.Get(Index).PrecioVenta));
            Console.Write("Precio Compra: ");
            Console.CursorLeft = 15;
            Console.WriteLine(checkVacio(Productos.Get(Index).PrecioCompra));
            Console.WriteLine();
            Console.Write("Stock: ");
            Console.CursorLeft = 15;
            Console.WriteLine(checkVacio(Productos.Get(Index).Stock));
            Console.Write("Stock mínimo: ");
            Console.CursorLeft = 15;
            Console.WriteLine(checkVacio(Productos.Get(Index).StockMinimo));

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

        private string checkVacio(double lineToCheck)
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

        private Producto newProduct()
        {
            resetConsole();

            Producto ProductToAdd = new Producto();

            Console.Write("Codigo: ");
            try
            {
                ProductToAdd.Codigo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            Console.Write("Descripcion: ");
            ProductToAdd.Descripcion = Console.ReadLine();
            Console.Write("Categoria: ");
            ProductToAdd.Categoria = Console.ReadLine();
            Console.Write("Precio Venta: ");
            try
            {
                ProductToAdd.PrecioVenta = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            Console.Write("Precio Compra: ");
            try
            {
                ProductToAdd.PrecioCompra = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            Console.Write("Stock: ");
            try
            {
                ProductToAdd.Stock = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            Console.Write("Stock mínimo: ");
            try
            {
                ProductToAdd.StockMinimo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }

            return ProductToAdd;
        }

        private int JumpIntoProduct()
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

            if (client > Productos.Count)
            {
                client = Index;
                Console.WriteLine("Doesn't exist");
                Console.WriteLine("Press enter to return");
                Console.ReadLine();
            }

            return client;
        }

        private Producto modifyProduct(Producto actual)
        {
            resetConsole();

            Producto ProductToAdd = actual;
            string cadena;

            Console.WriteLine("Press enter to not modify");

            Console.Write("Código (" + ProductToAdd.Codigo + "): ");
            try
            {
                ProductToAdd.Codigo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
            }
            
            Console.Write("Descripción (" + ProductToAdd.Descripcion + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ProductToAdd.Descripcion = cadena;
            }
            Console.Write("Categoría (" + ProductToAdd.Categoria + "): ");
            cadena = Console.ReadLine();
            if (cadena != "")
            {
                ProductToAdd.Categoria = cadena;
            }
            Console.Write("Precio Venta (" + ProductToAdd.PrecioVenta + "): ");
            try
            {
                ProductToAdd.PrecioVenta = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            Console.Write("Precio Compra (" + ProductToAdd.PrecioCompra + "): ");
            try
            {
                ProductToAdd.PrecioCompra = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            Console.Write("Stock (" + ProductToAdd.Stock + "): ");
            try
            {
                ProductToAdd.Stock = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
            }

            Console.Write("Stock mínimo (" + ProductToAdd.StockMinimo + "): ");
            try
            {
                ProductToAdd.StockMinimo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
            }
            
            return ProductToAdd;
        }

        private int searchText()
        {
            resetConsole();
            Console.Write("Text to search: ");
            string text = Console.ReadLine().ToLower();

            Console.WriteLine("From this file or begining? file/begining");
            string index = Console.ReadLine();

            Console.WriteLine("Stop when finding a product o when finish? finding/finish");
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
                Producto productoActual = Productos.Get(actualPos);
                if (productoActual.Codigo.ToString().ToLower().Contains(text) ||
                    productoActual.Descripcion.ToLower().Contains(text) ||
                    productoActual.Categoria.ToLower().Contains(text) ||
                    productoActual.PrecioVenta.ToString().ToLower().Contains(text) ||
                    productoActual.PrecioCompra.ToString().ToLower().Contains(text) ||
                    productoActual.Stock.ToString().ToLower().Contains(text) ||
                    productoActual.StockMinimo.ToString().ToLower().Contains(text))
                {
                    if (stop == "finding")
                    {
                        find = true;
                    }
                    foundPositions.Add(actualPos);
                }
                if (!find && actualPos < Productos.Count)
                {
                    actualPos++;
                }
            } while (!find && actualPos < Productos.Count);

            if (foundPositions.Count > 1)
            {
                Console.Write("Found at positions: ");
                Console.Write(foundPositions[0]);
                for (int i = 1; i < foundPositions.Count; i++)
                {
                    Console.Write(", " + foundPositions[i]);
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
                    Productos.Save();
                    break;
                case ConsoleKey.D1:
                    if (Index > 1)
                    {
                        Index--;
                    }
                    break;
                case ConsoleKey.D2:
                    if (Index < Productos.Count)
                    {
                        Index++;
                    }
                    break;
                case ConsoleKey.D3:
                    Index = JumpIntoProduct();
                    break;
                case ConsoleKey.D4:
                    Index = searchText();
                    break;
                case ConsoleKey.D5:
                    Productos.Add(newProduct());
                    break;
                case ConsoleKey.D6:
                    Productos.Productos[Index - 1] = modifyProduct(Productos.Get(Index));
                    break;
                default:
                    break;
            }
        }
    }
}
