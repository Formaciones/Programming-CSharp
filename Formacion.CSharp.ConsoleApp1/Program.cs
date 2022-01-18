using System;
using Formacion.CSharp.Objects;
using System.Linq;

namespace Formacion.CSharp.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("".PadRight(56, '*'));
                Console.WriteLine("*  DEMO Y EJERCICIOS".PadRight(55) + "*");
                Console.WriteLine("".PadRight(56, '*'));
                Console.WriteLine("*".PadRight(55) + "*");
                Console.WriteLine("*  1. Declaración de Variables".PadRight(55) + "*");
                Console.WriteLine("*  2. Conversión de Variables".PadRight(55) + "*");
                Console.WriteLine("*  3. Variables Númericas Nulleables".PadRight(55) + "*");
                Console.WriteLine("*  4. Propiedades de los Objetos".PadRight(55) + "*");
                Console.WriteLine("*  9. Salir".PadRight(55) + "*");
                Console.WriteLine("*".PadRight(55) + "*");
                Console.WriteLine("".PadRight(56, '*'));

                Console.WriteLine(Environment.NewLine);
                Console.Write("   Opción: ");

                Console.ForegroundColor = ConsoleColor.Cyan;

                int.TryParse(Console.ReadLine(), out int opcion);
                switch (opcion)
                {
                    case 1:
                        DeclaracionVariables();
                        break;
                    case 2:
                        ConversionVariables();
                        break;
                    case 3:
                        VariablesNumericasNuleables();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Revisa el código del Objeto Persona." + Environment.NewLine);
                        break;
                    case 9:
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Environment.NewLine + $"La opción {opcion} no es valida.");
                        break;
                }

                Console.WriteLine(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Pulsa una tecla para continuar...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Declaración de variables
        /// </summary>
        static void DeclaracionVariables()
        {
            ///////////////////////////////////////////////////////////////
            //
            //  Declaración de variables
            //  [tipo] [nombre variable] = [valor inicial (opcional)]
            //
            //  Valor por defecto para variables de tipo valor (númericas), 0
            //  Valor por defecto para variables de tipo referencía Null
            //
            ///////////////////////////////////////////////////////////////

            string texto = "Hola Mundo !!!";
            string otroTexto;
            int numero = 10;
            System.Int32 numero2 = 10;
            int otroNumero;
            decimal a, b, c;


            ///////////////////////////////////////////////////////////////
            //
            //  Declaración de variables que contienen objetos
            //  [tipo] [nombre variable] = [new constructor (opcional)]
            //
            ///////////////////////////////////////////////////////////////

            //Instanciamos un objeto y modificamos sus propiedades o variables
            Alumno alumno = new Alumno()
            {
                Nombre = "Julian",
                Apellidos = "Sánchez",
                Edad = 24
            };

            //Instanciamos un objeto y modificamos sus propiedades o variables
            Alumno alumno1 = new Alumno();
            alumno1.Nombre = "Julian";
            alumno1.Nombre = "Sánchez";
            alumno1.Edad = 24;

            //Instaciamos un objeto con VAR, OBJECT y DYNAMIC
            var alumno2 = new Alumno();
            Object alumno3 = new Alumno();
            dynamic alumno4 = new Alumno();

            Console.WriteLine("Tipo Variable 1: " + alumno1.GetType());
            Console.WriteLine("Nombre: {0}", alumno1.Nombre);

            Console.WriteLine("Tipo Variable 2: {0}", alumno2.GetType());
            Console.WriteLine("Nombre: {0}", alumno2.Nombre);

            Console.WriteLine($"Tipo Variable 3: {alumno3.GetType()}");
            //Console.WriteLine("Nombre: {0}", alumno3.Nombre));
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno3).Nombre);

            Console.WriteLine("Tipo Variable 4: " + alumno4.GetType());
            Console.WriteLine("Nombre: {0}", alumno4.Nombre);
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno4).Nombre);


            ///////////////////////////////////////////////////////////////
            //
            //  Declaración de un Array
            //  [tipo][] [nombre variable] = [valor inicial]
            //
            ///////////////////////////////////////////////////////////////

            int[] numeros = new int[10];
            int[] numeros2 = { 10, 5, 345, 55, 13, 1000, 83 };

            numeros[7] = 32;
            Console.WriteLine(numeros2[5]);

            Alumno[] alumnos = new Alumno[20];
            alumnos[0] = new Alumno();
            alumnos[1] = new Alumno();

            Alumno[] alumnos2 = { 
                new Alumno() { Nombre = "Julian", Apellidos = "Sánchez", Edad = 24 }, 
                new Alumno(), 
                new Alumno() 
            };

            Alumno[] alumnos3 = { new Alumno(), new Alumno(), new Alumno() };

            alumnos3[1].Nombre = "Ana María";
            alumnos3[1].Apellidos = "Sánchez";
            alumnos3[1].Edad = 24;
            Console.WriteLine(alumnos3[1].Nombre);
        }

        /// <summary>
        /// Conversión de variables
        /// </summary>
        static void ConversionVariables()
        {
            ///////////////////////////////////////////////////////////////
            //
            //  Conversión de variables
            //
            ///////////////////////////////////////////////////////////////

            byte num1 = 10;        //8 bits
            int num2 = 32;         //32 bits
            string num3 = "42";

            Console.WriteLine("A: {0} - B: {1}", num1, num2);

            //Conversión implicita, SI es posible porque el receptor es de mayor tamaño en bits
            num2 = num1;

            //Conversión implicita, NO es posible porque el receptor es de menor tamaño en bits
            //num1 = num2;      

            //Conversión explicita, indicada por el programador
            num1 = (byte)num2;

            //Conversion explicita, con el objeto CONVERT
            num1 = Convert.ToByte(num2);
            num1 = Convert.ToByte(num3);

            //Conversión explicita utilizando el método Parse
            num1 = byte.Parse(num3);

            //Conversión explicita utilizando el método TryParse
            byte.TryParse(num3, out num1);

            int.TryParse(num3, out int num4);
            var num5 = int.TryParse(num3, out _);

            Console.WriteLine("A: {0} - B: {1}", num1, num2);
        }

        /// <summary>
        /// Variables númericas nuleables (que pueden contener Null)
        /// </summary>
        static void VariablesNumericasNuleables()
        {
            ///////////////////////////////////////////////////////////////
            //
            //  Variables númericas nuleables (que pueden contener Null)
            //
            ///////////////////////////////////////////////////////////////

            //La variables númerica no puede almacenar Null
            int n1 = 10;

            //Cuando añadimos ? al tipo, transformamos la variable en nuleable y puede contener Null
            int? n2 = null;

            int r1;

            //La varibles nuleables son de un tipo diferente a las no nulebales
            //Ejemplo: una variable INT es de un tipo diferente a una INT?
            r1 = n1;
            //r1 = n2;
            r1 = Convert.ToInt32(n2);

            //Validación de la conversión mediante un IF
            if (n2 == null) r1 = 0;
            else r1 = Convert.ToInt32(n2);

            //Validación de la conversión mediante una operador condicional
            //https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/operators/conditional-operator
            r1 = (n2 == null) ? r1 = 0 : r1 = Convert.ToInt32(n2);

            //Validación de la  conversión mediante operadores null
            //https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/operators/null-coalescing-operator
            r1 = Convert.ToInt32(n2 ?? 0);
        }
    }
}

namespace Formacion.CSharp.Objects
{
    /// <summary>
    /// Objeto Alumno para los ejercicios de demostración
    /// </summary>
    public class Alumno
    {
        public string Nombre;
        public string Apellidos;
        public int Edad;
    }

    /// <summary>
    /// Objeto Persona para los ejercicios de demostración
    /// </summary>
    public class Persona
    {
        ///////////////////////////////////////////////////////////////
        //
        //  Propiedades de los objetos en C#
        //
        ///////////////////////////////////////////////////////////////

        //Definición de una propiedad equivalente a una variable pública, que necesita de un variable privada
        //Se puede simplificar mendiante: public string Nombre { get; set; }

        //Variable privada
        private string nombre;

        //Propiedad pública
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //////////////////////////////////////////////////////////////


        //Definición de una propiedad equivalente a una variable pública, pero no necesita una variable privada
        public string Apellidos { get; set; }

        //////////////////////////////////////////////////////////////


        //Definición de una propiedad, utiliza una variable privada e implementa una validación en la modificación de edad
        //Variable privada
        private int edad;

        //Propiedad pública
        public int Edad
        {
            get { return edad; }
            set
            {
                if (value < 0) edad = 0;
                else if (value > 125) edad = 0;
                else edad = value;
            }
        }

        //////////////////////////////////////////////////////////////
        

        //Métodos son equivalentes al uso de propiedades, se trata de una forma menos estándar y más compleja
        public int GetEdad()
        {
            return edad;
        }
        public void SetEdad(int edad)
        {
            if (edad < 0) this.edad = 0;
            else if (edad > 125) this.edad = 0;
            else this.edad = edad;
        }

        //////////////////////////////////////////////////////////////

        public Persona()
        {
            this.nombre = "";
            this.Apellidos = "";
            this.edad = 0;
        }
    }
}
