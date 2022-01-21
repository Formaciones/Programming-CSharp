using System;
using System.Data;
using System.Data.SqlClient;


namespace Formacion.CSharp.ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccessWithADO();
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
        { }


    }
}
