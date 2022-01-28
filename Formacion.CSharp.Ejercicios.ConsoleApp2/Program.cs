using System;
using System.Collections.Generic;
using System.Linq;

namespace Formacion.CSharp.Ejercicios.ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Busquedas();
            Console.ReadKey(); 
        }

        /// <summary>
        /// Operaciones de búsqueda básicas
        /// </summary>
        static void BusquedasBasicas()
        {
            //SQL: SELECT * FROM dbo.ListaProductos

            //Métodos de LINQ
            var resultado1a = DataLists.ListaClientes
                .Select(r => r);
            
            //Expresión LINQ
            var resultado1b = from r in DataLists.ListaClientes
                              select r;

            foreach (Cliente item in resultado1b)
            {
                Console.WriteLine($"{item.Id}# {item.Nombre} - {item.FechaNac.ToShortDateString()}");
            }
            Console.WriteLine(Environment.NewLine);


            //SQL: SELECT Id, Nombre FROM dbo.ListaProductos

            //Métodos de LINQ
            var resultado2a = DataLists.ListaClientes
                .Select(r => new { r.Id, r.Nombre });

            //Expresión LINQ
            var resultado2b = from r in DataLists.ListaClientes
                              select new { r.Id, r.Nombre };

            foreach (var item in resultado2b) Console.WriteLine($"{item.Id}# {item.Nombre}");
            Console.WriteLine(Environment.NewLine);


            //SQL: SELECT Nombre FROM dbo.ListaProductos

            //Métodos de LINQ
            var resultado3a = DataLists.ListaClientes
                .Select(r => r.Nombre);

            //Expresión LINQ
            var resultado3b = from r in DataLists.ListaClientes
                              select r.Nombre;

            foreach (var item in resultado3b) Console.WriteLine($"{item}");
            Console.WriteLine(Environment.NewLine);


            //SQL: SELECT * FROM dbo.ListaProductos ORDER BY Nombre

            //Métodos de LINQ
            var resultado4a = DataLists.ListaClientes
                .OrderByDescending(r => r.Nombre) 
                .Select(r => r);

            //Expresión LINQ
            var resultado4b = from r in DataLists.ListaClientes
                              orderby r.Nombre descending
                              select r;

            //Ordena el PC 
            var resultado4c = DataLists.ListaClientes
                .Select(r => r)
                .ToList()
                .OrderByDescending(r => r.Nombre);

            //Ordena la BD
            var resultado4d = DataLists.ListaClientes
                .OrderByDescending(r => r.Nombre)
                .Select(r => r)
                .ToList();

            //Ordenar PC
            var resultado4e = (from r in DataLists.ListaClientes
                               select r)
                              .ToList()
                              .OrderByDescending(r => r.Nombre);

            foreach (var item in resultado4b) Console.WriteLine($"{item.Nombre}");
            Console.WriteLine(Environment.NewLine);


            //SQL: SELECT * FROM dbo.ListaProductos WHERE precio < 0.90

            //Métodos de LINQ
            var resultado5a = DataLists.ListaProductos
                .Where(r => r.Precio < 0.90f)
                .Select(r => r);

            //Expresión LINQ
            var resultado5b = from r in DataLists.ListaProductos
                              where r.Precio < 0.90f
                              select r;

            foreach (var item in resultado5b) Console.WriteLine($"{item.Descripcion} {item.Precio.ToString("N2")}");
            Console.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// Otras operaciones de búqueda
        /// </summary>
        static void Busquedas()
        {
            //Listado de Pedidos por cliente
            //Con Agrupación
            var pedidos2a = DataLists.ListaPedidos
                .GroupBy(r => r.IdCliente)
                .ToList();

            var pedidos2b = from r in DataLists.ListaPedidos
                            group r by r.IdCliente;


            foreach (var item in pedidos2a)
            {
                Console.WriteLine($"Cliente: {item.Key}");
                //Console.WriteLine($"Cliente: {DataLists.ListaClientes.Where(r => r.Id == item.Key).Select(r => r.Nombre).FirstOrDefault()}");
                Console.WriteLine("=========================================================");
                
                foreach (var pedido in item) Console.WriteLine($"{pedido.Id} - {pedido.FechaPedido.ToShortDateString()}");
                Console.WriteLine(Environment.NewLine);
            }
            Console.ReadKey();

            //Listado de Pedidos por cliente
            //Sin Agrupación

            var clientes = DataLists.ListaClientes.ToList();
            var clientes2 = from r in DataLists.ListaClientes
                            select r;

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente: {cliente.Id}# {cliente.Nombre}");
                Console.WriteLine("=========================================================");

                var pedidos = DataLists.ListaPedidos
                    .Where(r => r.IdCliente == cliente.Id)
                    .ToList();

                foreach (var pedido in pedidos) Console.WriteLine($"{pedido.Id} - {pedido.FechaPedido.ToShortDateString()}");
                Console.WriteLine(Environment.NewLine);
            }

            Console.ReadKey();

            //Contains -> continene
            //StartsWith -> comienza por
            //EndsWith -> finaliza por

            var resultado1a = DataLists.ListaProductos
                .Where(r => r.Descripcion.ToLower().Contains("cuaderno"))
                .Select(r => r)
                .ToList();

            var resultado1b = from r in DataLists.ListaProductos
                              where r.Descripcion.ToLower().Contains("cuaderno")
                              select r;

            foreach (var item in resultado1a) Console.WriteLine(item.Descripcion);
            Console.WriteLine($"Número de Productos: {resultado1a.Count}");

            //Funciones de Agregación
            //Count -> Cuentas elementos
            //Max -> Máximo valor
            //Min -> Minimo valor
            //Average -> Media de los valores
            //Sum -> Suma valores
            //Aggregate -> Aplicar formula (función o método) personalizada a los valores

            var resultado2a = DataLists.ListaProductos
                .Count(r => r.Descripcion.ToLower().Contains("cuaderno"));

            var resultado2b = (from r in DataLists.ListaProductos
                              where r.Descripcion.ToLower().Contains("cuaderno")
                              select r).Count();

            Console.WriteLine($"Número de Productos: {resultado2a}");

            // El primer registro con el precio más alto
            var resultado3a = DataLists.ListaProductos
                .OrderByDescending(r => r.Precio)
                .FirstOrDefault();

            // Todos productos con el precio igual al precio más alto
            var resultado3c = DataLists.ListaProductos
                .Where(r => r.Precio == DataLists.ListaProductos.Max(r => r.Precio))
                .ToList();

            // El precio más alto de todos los productos
            var resultado3b = DataLists.ListaProductos
                .Max(r => r.Precio);

            Console.WriteLine("END");
        }

        /// <summary>
        /// Ejercicios de LINQ
        /// </summary>
        static void Ejercicios()
        {
            //Buscar Productos con un precio mayor a 2
            //Ordenar DESC por Descripción
            var resultado1a = DataLists.ListaProductos
                .Where(r => r.Precio > 2)
                .OrderByDescending(r => r.Descripcion)  
                .Select(r => r.Descripcion);

            var resultado1b = from r in DataLists.ListaProductos
                              where r.Precio > 2
                              orderby r.Descripcion descending
                              select r.Descripcion;

            foreach (var item in resultado1a) Console.WriteLine($"{item}");

            Console.ReadKey();

            //Buscar Clientes con más de 50 años
            //DateTime.Now.Year - FechaNac.Year = Edad


            //Listado de Clientes ordenador por Fecha de Nacimiento


            //Listado de Pedidos donde se compran el producto 2 (Cuaderno Grande)


            //Pedidos realizados en el mes de Octubre (10)
        }


        /// <summary>
        /// Representa el Objeto Cliente
        /// </summary>
        public class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaNac { get; set; }
        }

        /// <summary>
        /// Representa el Objeto Producto
        /// </summary>
        public class Producto
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public float Precio { get; set; }
        }

        /// <summary>
        /// Representa el Objeto Pedido
        /// </summary>
        public class Pedido
        {
            public int Id { get; set; }
            public int IdCliente { get; set; }
            public DateTime FechaPedido { get; set; }
        }

        /// <summary>
        /// Representa el Objeto Linea de Pedido
        /// </summary>
        public class LineaPedido
        {
            public int Id { get; set; }
            public int IdPedido { get; set; }
            public int IdProducto { get; set; }
            public int Cantidad { get; set; }
        }

        /// <summary>
        /// Representa una Base de datos en memoria utilizando LIST
        /// </summary>
        public static class DataLists
        {
            private static List<Cliente> _listaClientes = new List<Cliente>() 
            {
                new Cliente { Id = 1,   Nombre = "Carlos Gonzalez Rodriguez",   FechaNac = new DateTime(1980, 10, 10) },
                new Cliente { Id = 2,   Nombre = "Luis Gomez Fernandez",        FechaNac = new DateTime(1961, 4, 20) },
                new Cliente { Id = 3,   Nombre = "Ana Lopez Diaz ",             FechaNac = new DateTime(1947, 1, 15) },
                new Cliente { Id = 4,   Nombre = "Fernando Martinez Perez",     FechaNac = new DateTime(1981, 8, 5) },
                new Cliente { Id = 5,   Nombre = "Lucia Garcia Sanchez",        FechaNac = new DateTime(1973, 11, 3) }
            };

            private static List<Producto> _listaProductos = new List<Producto>()
            {
                new Producto { Id = 1,      Descripcion = "Boligrafo",          Precio = 0.35f },
                new Producto { Id = 2,      Descripcion = "Cuaderno grande",    Precio = 1.5f },
                new Producto { Id = 3,      Descripcion = "Cuaderno pequeño",   Precio = 1 },
                new Producto { Id = 4,      Descripcion = "Folios 500 uds.",    Precio = 3.55f },
                new Producto { Id = 5,      Descripcion = "Grapadora",          Precio = 5.25f },
                new Producto { Id = 6,      Descripcion = "Tijeras",            Precio = 2 },
                new Producto { Id = 7,      Descripcion = "Cinta adhesiva",     Precio = 1.10f },
                new Producto { Id = 8,      Descripcion = "Rotulador",          Precio = 0.75f },
                new Producto { Id = 9,      Descripcion = "Mochila escolar",    Precio = 12.90f },
                new Producto { Id = 10,     Descripcion = "Pegamento barra",    Precio = 1.15f },
                new Producto { Id = 11,     Descripcion = "Lapicero",           Precio = 0.55f },
                new Producto { Id = 12,     Descripcion = "Grapas",             Precio = 0.90f }
            };

            private static List<Pedido> _listaPedidos = new List<Pedido>()
            {
                new Pedido { Id = 1,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 1) },
                new Pedido { Id = 2,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 8) },
                new Pedido { Id = 3,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 12) },
                new Pedido { Id = 4,     IdCliente = 1,  FechaPedido = new DateTime(2013, 11, 5) },
                new Pedido { Id = 5,     IdCliente = 2,  FechaPedido = new DateTime(2013, 10, 4) },
                new Pedido { Id = 6,     IdCliente = 3,  FechaPedido = new DateTime(2013, 7, 9) },
                new Pedido { Id = 7,     IdCliente = 3,  FechaPedido = new DateTime(2013, 10, 1) },
                new Pedido { Id = 8,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 8) },
                new Pedido { Id = 9,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 22) },
                new Pedido { Id = 10,    IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 29) },
                new Pedido { Id = 11,    IdCliente = 4,  FechaPedido = new DateTime(2013, 10, 19) },
                new Pedido { Id = 12,    IdCliente = 4,  FechaPedido = new DateTime(2013, 11, 11) }
            };

            private static List<LineaPedido> _listaLineasPedido = new List<LineaPedido>()
            {
                new LineaPedido() { Id = 1,  IdPedido = 1,  IdProducto = 1,     Cantidad = 9 },
                new LineaPedido() { Id = 2,  IdPedido = 1,  IdProducto = 3,     Cantidad = 7 },
                new LineaPedido() { Id = 3,  IdPedido = 1,  IdProducto = 5,     Cantidad = 2 },
                new LineaPedido() { Id = 4,  IdPedido = 1,  IdProducto = 7,     Cantidad = 2 },
                new LineaPedido() { Id = 5,  IdPedido = 2,  IdProducto = 9,     Cantidad = 1 },
                new LineaPedido() { Id = 6,  IdPedido = 2,  IdProducto = 11,    Cantidad = 15 },
                new LineaPedido() { Id = 7,  IdPedido = 3,  IdProducto = 12,    Cantidad = 2 },
                new LineaPedido() { Id = 8,  IdPedido = 3,  IdProducto = 1,     Cantidad = 4 },
                new LineaPedido() { Id = 9,  IdPedido = 4,  IdProducto = 2,     Cantidad = 3 },
                new LineaPedido() { Id = 10, IdPedido = 5,  IdProducto = 4,     Cantidad = 2 },
                new LineaPedido() { Id = 11, IdPedido = 6,  IdProducto = 1,     Cantidad = 20 },
                new LineaPedido() { Id = 12, IdPedido = 6,  IdProducto = 2,     Cantidad = 7 },
                new LineaPedido() { Id = 13, IdPedido = 7,  IdProducto = 1,     Cantidad = 4 },
                new LineaPedido() { Id = 14, IdPedido = 7,  IdProducto = 2,     Cantidad = 10 },
                new LineaPedido() { Id = 15, IdPedido = 7,  IdProducto = 11,    Cantidad = 2 },
                new LineaPedido() { Id = 16, IdPedido = 8,  IdProducto = 12,    Cantidad = 2 },
                new LineaPedido() { Id = 17, IdPedido = 8,  IdProducto = 3,     Cantidad = 9 },
                new LineaPedido() { Id = 18, IdPedido = 9,  IdProducto = 5,     Cantidad = 11 },
                new LineaPedido() { Id = 19, IdPedido = 9,  IdProducto = 6,     Cantidad = 9 },
                new LineaPedido() { Id = 20, IdPedido = 9,  IdProducto = 1,     Cantidad = 4 },
                new LineaPedido() { Id = 21, IdPedido = 10, IdProducto = 2,     Cantidad = 7 },
                new LineaPedido() { Id = 22, IdPedido = 10, IdProducto = 3,     Cantidad = 2 },
                new LineaPedido() { Id = 23, IdPedido = 10, IdProducto = 11,    Cantidad = 10 },
                new LineaPedido() { Id = 24, IdPedido = 11, IdProducto = 12,    Cantidad = 2 },
                new LineaPedido() { Id = 25, IdPedido = 12, IdProducto = 1,     Cantidad = 20 }
            };

            // Propiedades de los elementos privados
            public static List<Cliente> ListaClientes { get { return _listaClientes; } }
            public static List<Producto> ListaProductos { get { return _listaProductos; } }
            public static List<Pedido> ListaPedidos { get { return _listaPedidos; } }
            public static List<LineaPedido> ListaLineasPedido { get { return _listaLineasPedido; } }
        }
    }
}
