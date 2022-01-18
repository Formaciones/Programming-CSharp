using System;
using System.Linq;
using Formacion.CSharp.Ejercicios.Models;
using Formacion.CSharp.Ejercicios.Core;

namespace Formacion.CSharp.Ejercicios.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("".PadRight(60, '*'));
            Console.WriteLine("*  EJERCICIOS DE CSHARP".PadRight(59) + "*");
            Console.WriteLine("*".PadRight(59, '*') + "*");
            Console.WriteLine("*".PadRight(59, ' ') + "*");
            Console.WriteLine("*  1. Calculo de la letra del DNI".PadRight(59) + "*");
            Console.WriteLine("*  2. Trabajar con STRING".PadRight(59) + "*");
            Console.WriteLine("*  3. Trabajar con INT".PadRight(59) + "*");
            Console.WriteLine("*".PadRight(59, ' ') + "*");
            Console.WriteLine("*".PadRight(59, '*') + "*");

            Console.WriteLine(Environment.NewLine);
            Console.Write("   Opción: ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            string opcion = Console.ReadLine();

            switch (opcion.ToLower())
            {
                case "1":
                    CalcularLetraDNI();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine($"La opción {opcion} no es valida.");
                    break;
            }

            Console.ReadKey();
        }

        static void CalcularLetraDNI()
        {
            var persona = new Persona("12345678", "Borja", "Cabeza", 46);
            Console.WriteLine($"DNI: {persona.DNI}");
        }
    }
}

namespace Formacion.CSharp.Ejercicios.Models
{
    public class Persona
    {
        private string[] letras = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
        private string dni;
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string DNI
        {
            //Calculamos el modulo (resto de la división), al dividir el dni entre 23
            //El modulo indica la posición del array, donde esta la letra del DNI
            get 
            {
                int dniNum = 0;

                if (int.TryParse(dni, out dniNum)) return dni + letras[dniNum % 23];
                else return "Error al calcular el DNI";
            }

            set 
            { 
                dni = value; 
            }
        }

        public Persona()
        {
            this.dni = null;
            Nombre = "";
            Apellidos = "";
            Edad = 0;
        }
        public Persona(string dni, string nombre, string apellidos, int edad)
        {
            this.dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
        }
    }
}

namespace Formacion.CSharp.Ejercicios.Core
{
    public static class Tools
    { 
        // 2.   Preguntar una franse
        //      Printar la frase, la frase en mayúsculas y en minúsculas
        //      Pintar el número de letras
        //      Pintar cada letra con su posición

        // 3.   Preguntar un número
        //      Pintar raíz cuadrado, arco seno, la multiplicación pir PI utilizando el objeto Math.*
        //      Explorar la documentación de Math
    }

}