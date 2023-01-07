using System;
using System.Collections.Generic;

namespace CambioBase
{
    class Program
    {
        static int tableWidth = 73;
        public static void Main()
        {
            //Parametros de entrada
            //
            Console.WriteLine("Ingrese el numero");
            var sNumero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese una base entre 2 y 9");
            var _base = Convert.ToInt32(Console.ReadLine());            

            //Validacion del campo _base
            //
            if (_base < 2 || _base > 9)
            {
                Console.WriteLine("Los valores ingresados no son correctos por favor intente Nuevamente");
                Console.WriteLine("Ingrese una base entre 2 y 9");
                _base = Convert.ToInt32(Console.ReadLine());
                if (_base < 2 || _base > 9)
                {
                    Console.WriteLine("Los valores ingresados no son correctos la aplicacion se cerrara");
                    Environment.Exit(0);
                }
            }

            // creacion de encabezado de la tabla
            //
            PrintLine();
            PrintRow("Operacion", "Cociente", "Residuo");

            // Craecion de variables
            //
            var auxiliar = sNumero;
            var NumeroOriginal = sNumero;
            var lResiduo = new List<int>();
            var sGuardaCoeficientes = "";

            while (true)
            {   // Procesos algoritmicos para obtener el residuo y cociente
                var sQuociente = auxiliar / _base;

                var sResiduo = auxiliar - (_base * sQuociente);
                lResiduo.Add(sResiduo);
                auxiliar = sQuociente;

                // dibujado en la tabla 
                PrintLine();
                PrintRow(sNumero.ToString()+":"+_base,sQuociente.ToString(), sResiduo.ToString());

                // concatenacion del resultado final
                sNumero = auxiliar;
                if (auxiliar < _base)
                {                    
                    lResiduo.Add(auxiliar);
                    for (var i = 0; i < lResiduo.Count; i++)
                    {
                        sGuardaCoeficientes = sGuardaCoeficientes + lResiduo[i].ToString();
                    }
                    break;
                }
            }
            //retorno del resultado final reversado
            //
            Console.WriteLine("\n Por tanto " + NumeroOriginal + " en base 10 = " + Reverse(sGuardaCoeficientes) + " en base " + _base);
        }

        //dibujado de las filas
        //
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        //dibujado de la columnas 
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            foreach (string column in columns)

            {
                row += Aligncenter(column, width) + "|";
            }

            Console.WriteLine(row);

        }
        //aliniacion de la tabla
        //
        static string Aligncenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }

            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        //metodo usado para reversar el resultado final 
        //
        static string Reverse(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}