using System;

namespace Formacion.CSharp.ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Calculadora calculadora = new Calculadora(65, 0);

                calculadora.Suma();
                Console.WriteLine($"Suma: {calculadora.Resultado}");

                calculadora.Resta();
                Console.WriteLine($"Resta: {calculadora.Resultado}");

                calculadora.Multiplicacion();
                Console.WriteLine($"Multiplicación: {calculadora.Resultado}");

                calculadora.Division();
                Console.WriteLine($"División: {calculadora.Resultado}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Main: {e.Message}");
            }
        }
    }

    public class Calculadora
    {
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public int Resultado { get; set; }

        public void Suma() 
        { 
            Resultado = Numero1 + Numero2;
        }
        public void Resta() 
        {
            Resultado = Numero1 - Numero2;
        }
        public void Multiplicacion()
        {
            Resultado = Numero1 * Numero2;
        }
        public void Division() 
        {
            try
            {
                Resultado = Numero1 / Numero2;
            }
            catch (DivideByZeroException e)
            {
                Resultado = 0;
                Console.WriteLine($"Info: Error al dividir entre cero. {e.Message}");

                //throw;
                //throw e;
                throw new Exception($"Error al dividir entre cero, Número1={Numero1}  Número2={Numero2}.");
            }
            catch (Exception e)
            {
                Resultado = 0;
                Console.WriteLine($"Info: Error al dividir. {e.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine("Info: Método división finalizado.");
            }
        }

        public Calculadora()
        {
            Numero1 = 0;
            Numero2 = 0;
            Resultado = 0;
        }
        public Calculadora(int numero1, int numero2)
        {
            Numero1 = numero1;
            Numero2 = numero2;
            Resultado = 0;
        }
    }

}
