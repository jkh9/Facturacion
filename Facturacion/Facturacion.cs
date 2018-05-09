﻿using System;

namespace Facturacion
{
    class Facturacion
    {
        static void Main(string[] args)
        {
            ConfigureConsole();

            bool exit = false;

            do
            {
                Printframe();

                int option = 1;
                bool optionSelected = false;
                do
                {
                    PrintMenu(option);
                    Move(ref option, ref optionSelected);
                } while (!optionSelected);

                switch (option)
                {
                    case 1:
                        VisorDeClientes visorClientes = new VisorDeClientes();
                        visorClientes.Ejecutar();
                        break;
                    case 2:
                        VisorDeProductos visorProductos = new VisorDeProductos();
                        visorProductos.Ejecutar();
                        break;
                    case 3:
                        VisorDeFacturas visorFacturas = new VisorDeFacturas();
                        visorFacturas.Ejecutar();
                        break;
                    case 0: exit = true; break;
                    default: break;
                }
            } while (!exit);
        }

        public static void ConfigureConsole()
        {
            Console.Title = "Facturación de Moisex";
            Console.SetWindowSize(80,25);
            Console.SetBufferSize(80,25);
            Console.CursorVisible = false;
        }

        public static void Printframe()
        {
            Console.Clear();
            string line = new string(' ', Console.WindowWidth);
            string emptyLine = new string(' ', Console.WindowWidth - 4);

            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write(line);
            for (int i = 1; i < Console.WindowHeight; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, i);
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(emptyLine);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("  ");
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(line);

            Console.SetCursorPosition(4, Console.WindowHeight - 3);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Press ESC to Exit");
            Console.ResetColor();
        }

        public static void PrintMenu(int cursorOption)
        {
            int x = Console.WindowWidth / 2 - 7;
            int y = Console.WindowHeight / 2 -2;
            string[] options =
            {
                "Visor de clientes",
                "Visor de productos",
                "Visor de facturas"
            };
            
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.ForegroundColor = ConsoleColor.White;
                if (i == cursorOption - 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(options[i]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(options[i]);
                }
                Console.ResetColor();
            }
        }

        public static void Move(ref int option, ref bool optionSelected)
        {
            ConsoleKeyInfo key;

            if (Console.KeyAvailable)
            {
                do
                {
                    key = Console.ReadKey(true);
                } while (Console.KeyAvailable);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        optionSelected = true;
                        break;
                    case ConsoleKey.Escape:
                        option = 0;
                        optionSelected = true;
                        break;
                    case ConsoleKey.UpArrow:
                        if (option > 1)
                        {
                            option--;
                        }
                        else
                        {
                            option = 3;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (option < 3)
                        {
                            option++;
                        }
                        else
                        {
                            option = 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
