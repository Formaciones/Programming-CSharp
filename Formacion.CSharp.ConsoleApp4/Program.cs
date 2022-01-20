using System;
using System.Collections;
using System.Collections.Generic;

namespace Formacion.CSharp.ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            ///////////////////////////////////////////////////////////////////////////////////


            // Declarar
            ArrayList arrayList = new ArrayList();

            // Elimina todos los elementos de la colección
            arrayList.Clear();

            // Añadir un nuevo elemento
            arrayList.Add("Manzana");
            arrayList.Add("Narajan");

            // Añadir varios elementos
            string[] frutas = { "Fresa", "Melón", "Pomelo" };
            arrayList.AddRange(frutas);

            // Lectura y escritura de la información mediante la posición
            arrayList[1] = "Limón";
            Console.WriteLine(arrayList[4] + Environment.NewLine);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // Ordenar los elementos de la colección
            arrayList.Sort();
            Console.WriteLine(Environment.NewLine);
            foreach (var item in arrayList) Console.WriteLine(item);

            // Eliminar elementos de la colección
            arrayList.Remove("Melón");
            arrayList.RemoveAt(0);

            Console.WriteLine(Environment.NewLine);
            foreach (var item in arrayList) Console.WriteLine(item);

            // Número de elementos en la colección
            Console.WriteLine($"Número de Elementos: {arrayList.Count}");


            //////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("///////////////////////////////////////////");

            
            // Declarar
            Hashtable hashtable = new Hashtable();

            // Elimina todos los elementos de la colección
            hashtable.Clear();

            // Añadir un nuevo elemento, indicando la clave y el valor
            hashtable.Add("M1", "Manzana");
            hashtable.Add("NR", "Narajan");
            hashtable.Add("99", "Melón");
            hashtable.Add("FR", "Fresa");
            hashtable.Add("1P", "Pomelo");


            // Lectura y escritura de la información mediante la clave
            hashtable["NR"] = "Limón";
            Console.WriteLine(hashtable["FR"] + Environment.NewLine);

            foreach (var clave in hashtable.Keys)
            {
                Console.WriteLine($"Clave: {clave} - Valor: {hashtable[clave]}");
            }

            // Eliminar elementos de la colección
            hashtable.Remove("FR");

            Console.WriteLine(Environment.NewLine);
            foreach (var clave in hashtable.Keys) Console.WriteLine($"Clave: {clave} - Valor: {hashtable[clave]}");

            // Número de elementos en la colección
            Console.WriteLine($"Número de Elementos: {hashtable.Count}");

            //////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("///////////////////////////////////////////");

            List<string> list = new List<string>();

            list.Add("Manzana");
            list.Add("Naranja");
            list.AddRange(frutas);

            list[1] = "Limón";
            Console.WriteLine(list[4] + Environment.NewLine);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Sort();
            Console.WriteLine(Environment.NewLine);
            foreach (var item in list) Console.WriteLine(item);

            list.Remove("Melón");
            list.RemoveAt(0);

            Console.WriteLine(Environment.NewLine);
            foreach (var item in list) Console.WriteLine(item);

            Console.WriteLine($"Número de Elementos: {list.Count}");

            //////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("///////////////////////////////////////////");

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Clear();

            dic.Add("M1", "Manzana");
            dic.Add("NR", "Narajan");
            dic.Add("99", "Melón");
            dic.Add("FR", "Fresa");
            dic.Add("1P", "Pomelo");

            dic["NR"] = "Limón";
            Console.WriteLine(dic["FR"] + Environment.NewLine);

            foreach (var clave in dic.Keys)
            {
                Console.WriteLine($"Clave: {clave} - Valor: {dic[clave]}");
            }

            dic.Remove("FR");

            Console.WriteLine(Environment.NewLine);
            foreach (var clave in dic.Keys) Console.WriteLine($"Clave: {clave} - Valor: {dic[clave]}");

            Console.WriteLine($"Número de Elementos: {dic.Count}");
        }
    }

    public class Alumno
    {
        public string Nombre;
        public string Apellidos;
        public int Edad;
    }
}
