using System;

namespace Formacion.CSharp.ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Calculadora
    {
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public int Resultado { get; set; }

        public void Suma() 
        { 
        
        }
        public void Resta() 
        { }
        public void Multiplicacion()
        { }
        public void Division() 
        { }


        public Calculadora()
        {
            Numero1 = 0;
            Numero2 = 0;
            Resultado = 0;
        }
        public Calculadora(int numero1, int numero2, int resultado)
        {
            Numero1 = numero1;
            Numero2 = numero2;
            Resultado = resultado;
        }
    }

}
