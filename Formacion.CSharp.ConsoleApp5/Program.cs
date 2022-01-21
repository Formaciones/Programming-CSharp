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
            DataAccessWithEFCore();
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

            // Modificar un registro.
            // SQL: SELECT * FROM dbo.Customers WHERE CustomerID = 'ANATR'

            var cliente1a = context.Customers
                .Where(r => r.CustomerID == "ANATR")
                .ToList();

            cliente1a[0].CompanyName = "";

            var cliente1c = context.Customers
                .Where(r => r.CustomerID == "ANATR")
                .FirstOrDefault();

            Console.WriteLine($"Contacto: {cliente1c.ContactName}");
            cliente1c.ContactName = "Borja Cabeza";
            context.SaveChanges();


            var cliente1b = from r in context.Customers
                            where r.CustomerID == "ANATR"
                            select r;

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


    }
}
