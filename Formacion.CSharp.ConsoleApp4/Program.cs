﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Formacion.CSharp.ConsoleApp4
{

    public class Program
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
                Console.WriteLine("*  1. Uso de ArrayList".PadRight(55) + "*");
                Console.WriteLine("*  2. Uso de Hashtable".PadRight(55) + "*");
                Console.WriteLine("*  3. Uso de List".PadRight(55) + "*");
                Console.WriteLine("*  4. Uso de Dictionary".PadRight(55) + "*");
                Console.WriteLine("*  5. Items como Referencia".PadRight(55) + "*");
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
                        ArrayList();
                        break;
                    case 2:
                        HashTable();
                        break;
                    case 3:
                        List();
                        break;
                    case 4:
                        Dictionary();
                        break;
                    case 5:
                        AddItemReference();
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
        /// Uso de la lista, ArrayList
        /// </summary>
        static void ArrayList()
        {
            //Instanciar
            var array = new ArrayList();

            //Eliminar todos los elementos
            array.Clear();

            //Añadir elementos
            array.Add("azul");
            array.Add("rojo");
            array.Add("amarillo");
            array.Add("verde");
            array.Add(96);

            //Añadir todos los elementos de otra colección
            var colores = new string[] { "marrón", "naranja", "violeta" };
            array.AddRange(colores);

            //Número de elementos
            Console.WriteLine($"Número de items: {array.Count}");

            //Recorrer colección
            foreach (var item in array)
            {
                Console.WriteLine("Item: {0}", item);
            }
            Console.WriteLine(Environment.NewLine);

            for (var i = 0; i < array.Count; i++)
            {
                Console.WriteLine("Item: {0}", array[i]);
            }

            //Eliminar un elemento
            array.Remove("verde");
            array.RemoveAt(4);

            //Eliminar elementos
            array.RemoveRange(2, 2);

        }

        /// <summary>
        /// Uso del diccionario, Hashtable
        /// </summary>
        static void HashTable()
        {
            //Instanciar
            var dicc = new Hashtable();

            //Eliminar todos los elementos
            dicc.Clear();

            //Añadir elementos
            dicc.Add("ANATR", "Ana Trujillo");
            dicc.Add("ANTON", "Antonio Sanz");
            dicc.Add("CARSA", "Carlos Sánchez");

            //Número de elementos
            Console.WriteLine("Número de elementos {0}", dicc.Count);

            //Recorrer
            foreach (var clave in dicc.Keys)
            {
                Console.WriteLine($"{clave} -> {dicc[clave]}");
            }

            //Eliminar un elemnto
            dicc.Remove("ANTON");
        }

        /// <summary>
        /// Uso de la lista, List
        /// </summary>
        static void List()
        {
            //Instanciar
            var lista = new List<string>();

            //Eliminar todos los elementos
            lista.Clear();

            //Añadir elementos
            lista.Add("azul");
            lista.Add("rojo");
            lista.Add("verde");
            lista.Add("amarillo");
            lista.Add("rosa");
            lista.Add("blanco");

            //Número de elementos
            Console.WriteLine("Número de elementos {0}", lista.Count);

            //Recorrer
            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }

            for (var i = 0; i < lista.Count; i++)
            {
                Console.WriteLine("Item {0}: {1}", i, lista[i]);
            }

            //Eliminar un elemento
            lista.Remove("azul");
            lista.RemoveAt(4);
        }

        /// <summary>
        /// Uso del diccionario, Dictionary
        /// </summary>
        static void Dictionary()
        {
            //Instanciar
            var dicc = new Dictionary<int, string>();

            //Eliminar todos los elementos
            dicc.Clear();

            //Añadir elementos
            dicc.Add(1, "azul");
            dicc.Add(2, "verde");
            dicc.Add(99, "rojo");
            dicc.Add(11, "amarillo");
            dicc.Add(90, "rosa");
            dicc.Add(410, "blanco");

            //Número de elementos
            Console.WriteLine("Número de elementos {0}", dicc.Count);

            //Recorrer
            foreach (var clave in dicc.Keys)
            {
                Console.WriteLine("Clave: {0} - Valor: {1}", clave, dicc[clave]);
            }

            for (var i = 0; i < dicc.Keys.Count; i++)
            {
                Console.WriteLine("Clave: {0} - Valor: {1}", dicc.Keys.ToList()[i], dicc[dicc.Keys.ToList()[i]]);
            }

            //Eliminar un elemento
            dicc.Remove(90);
        }

        /// <summary>
        /// Añadimos elementos a una colección
        /// </summary>
        static void AddItemReference()
        {
            //Comprobamos que al añadir un mismo elemento varias veces todas la posiciones tiene el mismo elemento
            //Un Objeto es un de tipo referencia

            var alumnos = new List<Alumno>();
            var alumno = new Alumno() { Nombre = "Carlos", Apellidos = "Sánchez", Edad = 24 };

            alumnos.Add(alumno);
            alumnos.Add(alumno);
            alumnos.Add(alumno);
            alumnos.Add(alumno);
            alumnos.Add(alumno);

            Console.WriteLine($"{alumnos.Count} elementos");
            alumnos[1].Nombre = "Borja";
            alumnos[2].Nombre = "Ana";
            alumnos[3].Nombre = "José";
            alumnos[4].Nombre = "Silvia";

            foreach (var item in alumnos)
            {
                Console.WriteLine($"{item.Nombre} {item.Apellidos}");
            }

            Console.ReadKey();


            //Para que cada posición tenga un elemento, necesitamos instanciarlo (crear una nueva copia) antes de añadirlo
            //Ejemplo 1
            var alumnos2 = new List<Alumno>();

            alumnos2.Add(new Alumno() { Nombre = "Carlos", Apellidos = "Sánchez", Edad = 24 });
            alumnos2.Add(new Alumno() { Nombre = "Borja", Apellidos = "Cabeza", Edad = 24 });
            alumnos2.Add(new Alumno() { Nombre = "Ana", Apellidos = "Sanz", Edad = 24 });
            alumnos2.Add(new Alumno() { Nombre = "José", Apellidos = "Rozas", Edad = 24 });

            Console.WriteLine($"{alumnos2.Count} elementos");

            foreach (var item in alumnos2)
            {
                Console.WriteLine($"{item.Nombre} {item.Apellidos}");
            }

            Console.ReadKey();

            //Para que cada posición tenga un elemento, necesitamos instanciarlo (crear una nueva copia) antes de añadirlo
            //Ejemplo 2
            var alumnos3 = new List<Alumno>()
            {
                new Alumno() { Nombre = "Carlos", Apellidos = "Sánchez", Edad = 24 },
                new Alumno() { Nombre = "Borja", Apellidos = "Cabeza", Edad = 24 },
                new Alumno() { Nombre = "Ana", Apellidos = "Sanz", Edad = 24 },
                new Alumno() { Nombre = "José", Apellidos = "Rozas", Edad = 24 }
            };

            Console.WriteLine($"{alumnos3.Count} elementos");

            foreach (var item in alumnos3)
            {
                Console.WriteLine($"{item.Nombre} {item.Apellidos}");
            }

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Objeto Alumno
    /// </summary>
    public class Alumno
    {
        public string Nombre;
        public string Apellidos;
        public int Edad;
    }
}
