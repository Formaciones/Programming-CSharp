using System;
using System.Data;
using System.Data.SqlClient;
using Formacion.CSharp.ConsoleApp5.Models;
using System.Linq;


namespace Formacion.CSharp.ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccessWithEFCore2();
        }

        static void DataAccessWithADO()
        {
            // ADO, Access Data Objects

            //Constructor de cadenas de conexión
            var cb = new SqlConnectionStringBuilder();

            cb.DataSource = "LOCALHOST";        //Servidor
            cb.InitialCatalog = "NORTHWIND";    //Base de datos
            cb.UserID = "";                     //Login de la base de datos
            cb.Password = "";                   //Contraseña del Login
            cb.IntegratedSecurity = true;       //true, utiliza el usuario del Sistema Operativo
            
            string conexion = cb.ToString();
            Console.WriteLine($"Cadena de Conexión: {conexion}");

            //Objeto de conexión a Base de Datos
            var cn = new SqlConnection(conexion);
            cn.Open();

            //Objeto comnado para la Base de Datos
            var cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = "SELECT * FROM dbo.Customers WHERE Country = 'Spain' ORDER BY City";

            //Objeto lector de registro de la Base de Datos           
            SqlDataReader reader = cm.ExecuteReader();      //SELECT

            //int registros = cm.ExecuteNonQuery();         //INSERT UPDATE DELETE

            Console.WriteLine($"Existen Registros: {reader.HasRows}");
            if (reader.HasRows)
            {
                //El método .Read() devuelve True si quedan más registros y False si no hay más registros.
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CustomerID"]} {reader["CompanyName"]} - {reader["Country"]}");
                }
            }
            else Console.WriteLine("NO SE HAN ENCONTRADO REGISTROS.");

            cm.Dispose();
            cn.Close();
            cn.Dispose();

            Console.ReadKey();  
        }

        static void DataAccessWithEFCore()
        {
            var context = new ModelNorthwind();

            // Eliminar uno o varios registro

            // Paso 1: Posicionar en uno o varios registros
            // SQL: SELECT * FROM dbo.Customers WHERE CustomerID = 'DEMO2'

            var cliente2a = context.Customers
                .Where(r => r.CustomerID == "DEMO2")
                .FirstOrDefault();

            var cliente2b = (from r in context.Customers
                             where r.CustomerID == "DEMO2"
                             select r).FirstOrDefault();

            //Paso 2: Eliminar datos y guardar cambios
            //DELETE FROM dbo.Customers WHERE CustomerID = "DEMO2"

            context.Customers.Remove(cliente2a);
            context.SaveChanges();

            Console.WriteLine("Registro eliminado correctamente.");
            Console.ReadKey();


            // Insertar un nuevo registro.
            // INSERT INTO dbo.Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
            // VALUES ('DEMO1', 'Uno, SL', 'Borja Cabeza', 'Generente', 'Calle Uno, 1', 'Madrid', '', '28010', 'España', '200100100', '200100101')

            var nuevoCliente = new Customer()
            {
                CustomerID = "DEMO1",
                CompanyName = "Uno, SL",
                ContactName = "Borja Cabeza",
                ContactTitle = "Gerente",
                Address = "Calle Uno, 1",
                City = "Madrid",
                Region = "",
                PostalCode = "28010",
                Country = "España",
                Phone = "200-100-100",
                Fax = "200-100-101"
            };

            context.Customers.Add(nuevoCliente);
            context.SaveChanges();

            Console.WriteLine("Nuevo registro insertado.");
            Console.ReadKey();



            // Modificar un registro.

            // Paso 1: Posicionar en uno o varios registros
            // SQL: SELECT * FROM dbo.Customers WHERE CustomerID = 'ANATR'

            var cliente1a = context.Customers
                .Where(r => r.CustomerID == "ANATR")
                .ToList();

            var cliente1b = context.Customers
                .Where(r => r.CustomerID == "ANATR")
                .FirstOrDefault();

            var cliente1c = (from r in context.Customers
                            where r.CustomerID == "ANATR"
                            select r).FirstOrDefault();


            //Paso 2: Modificar datos y guardar cambios
            //UPDATE dbo.Customers SET ContactName = 'Borja Cabeza' WHERE CustomerID = 'ANATR'

            cliente1c.ContactName = "Borja Cabeza";
            context.SaveChanges();


            Console.ReadKey();

            // Lectura de datos de una Tabla
            // SQL: SELECT * FROM dbo.Customers

            var clientes1a = context.Customers.ToList();

            var clientes1b = from r in context.Customers
                             select r;

            // SQL: SELECT * FROM dbo.Customers WHERE Country = 'Spain' ORDER BY City

            var clientes2a = context.Customers
                .Where(r => r.Country == "Spain")
                .OrderBy(r => r.City)
                .ToList();

            var clientes2b = from r in context.Customers
                             where r.Country == "Spain"
                             orderby r.City
                             select r;

            foreach (var cliente in clientes1a)
                Console.WriteLine($"{cliente.CustomerID} {cliente.CompanyName} - {cliente.City}");


            Console.ReadKey();

        }

        static void DataAccessWithEFCore2()
        {
            //Precio más alto, más bajo y el precio medio de la tabla productos

            //Número de productos donde el precio este por encima de la media

            //Listado de Productos que sean quesos

            //Listado de Productos que sean de la categoria Bebidas 

            //Listado de Productos que sean de la categoria Bebidas cuyo precio este por debajo de la media

        }

    }
}
