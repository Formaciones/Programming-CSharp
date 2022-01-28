using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Formacion.CSharp.ConsoleApp6
{
    internal class Program
    {
        static readonly HttpClient http = new HttpClient();  
        static void Main(string[] args)
        {
            DemoGetWithTypeStudent();
        }

        /// <summary>
        /// Ejemplo cliente APIRest, consulta listado de estudiantes
        /// Deserializamos con el tipo Student
        /// </summary>
        static void DemoGetWithTypeStudent() 
        {
            HttpResponseMessage response;
            http.BaseAddress = new Uri("http://school.labs.com.es/api/");

            response = http.GetAsync("students").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            { 
                //Leer el contenido del Body del mensaje
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Contenido en JSON");
                Console.WriteLine(content);

                //Deserializar. Convertir el JSON en un Objeto (Lista de estudiantes)
                var estudiantes = JsonConvert.DeserializeObject<List<Student>>(content);
                foreach (var item in estudiantes)
                {
                    Console.WriteLine($"{item.Id}# {item.Firstname} {item.Lastname}");
                }
            }
            else 
            {
                Console.WriteLine($"Error {response.StatusCode.ToString()}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Ejemplo cliente APIRest, consulta listado de estudiantes
        /// Deseralizamos con con el tipo Dynamic
        /// </summary>
        static void DemoGetWithTypeDynamic()
        {
            HttpResponseMessage response;
            http.BaseAddress = new Uri("http://school.labs.com.es/api/");

            response = http.GetAsync("students").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Leer el contenido del Body del mensaje
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Contenido en JSON");
                Console.WriteLine(content);

                //Deserializar. Convertir el JSON en un Objeto (Lista de estudiantes)
                var estudiantes = JsonConvert.DeserializeObject<List<dynamic>>(content);
                foreach (var item in estudiantes)
                {
                    Console.WriteLine($"{item.id}# {item.firstName} {item.lastName}");
                }
            }
            else
            {
                Console.WriteLine($"Error {response.StatusCode.ToString()}");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Ejemplo cliente APIRest, consulta listado de estudiantes
        /// En este ejemplo el método realiza una llamada GET y entrega el objeto deserializado
        /// </summary>
        static void DemoGetWithFormatting()
        {
            http.BaseAddress = new Uri("http://school.labs.com.es/api/");

            var estudiantes = http.GetFromJsonAsync<List<Student>>("students").Result;
            foreach (var item in estudiantes) Console.WriteLine($"{item.Id}# {item.Firstname} {item.Lastname}");
        }

        /// <summary>
        /// Ejemplo cliente APIRest, trabajando con cabeceras (HEADERS) y mensaje en el cuerpo (BODY)
        /// </summary>
        static void DemoPostWithParamsHeadersBody()
        {
            HttpResponseMessage response;
            http.BaseAddress = new Uri("https://postman-echo.com/");

            //Headers
            http.DefaultRequestHeaders.Clear();            

            http.DefaultRequestHeaders.Add("x-param2", "D E M O");
            http.DefaultRequestHeaders.Add("User-Agent", "Ejercicio Demo");

            http.DefaultRequestHeaders.Add("ContentType", "application/json");

            http.DefaultRequestHeaders.Add("Accept", "application/json");
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Body
            var estudiante = new Student()
            {
                Id = 1, Firstname = "Borja", 
                Lastname = "Cabeza", 
                DateOfBirth = Convert.ToDateTime("01-01-1980"), 
                ClassId = 2
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(estudiante), System.Text.Encoding.UTF8, "application/json");

            response = http.PostAsync("post?param1=demo&param2=valor&param3=85", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var body = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(body);
            }
            else Console.WriteLine($"Error: {response.StatusCode}");

        }

        /// <summary>
        /// Ejemplo GET con un cliente APIRest 
        /// </summary>
        static void DemoGet()
        {
            HttpResponseMessage response;
            http.BaseAddress = new Uri("https://localhost:44326/api/");

            Console.Clear();
            Console.Write("ID Cliente: ");
            string id = Console.ReadLine();

            response = http.GetAsync($"customers/{id}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Customer cliente = JsonConvert.DeserializeObject<Customer>(content);

                Console.WriteLine($"{cliente.CustomerID}# {cliente.CompanyName} - {cliente.Country}");
            }
            else Console.WriteLine($"Status Code: {response.StatusCode.ToString()}");
            Console.ReadKey();
        }

        /// <summary>
        /// Ejemplo POST con un cliente APIRest 
        /// </summary>
        static void DemoPost()
        {
            HttpResponseMessage response;
            http.BaseAddress = new Uri("https://localhost:44326/api/");

            var cliente = new Customer()
            {
                CustomerID = "DEMO3",
                CompanyName = "Emperesa Tres, SL",
                Country = "Spain",
                City = "Madrid",
                ContactName = "Borja"
            };

            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");

            response = http.PostAsync("customers", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.WriteLine("Cliente creado correctamente");
            }
            else Console.WriteLine($"Status Code: {response.StatusCode.ToString()}");
        }

        /// <summary>
        /// Ejemplo PUT con un cliente APIRest 
        /// </summary>
        static void DemoPut()
        {
            HttpResponseMessage response;
            http.BaseAddress = new Uri("https://localhost:44326/api/");

            var cliente = http.GetFromJsonAsync<Customer>("customers/DEMO3").Result;
            cliente.ContactName = "Borja Cabeza";
            cliente.ContactTitle = "Propietario";
            cliente.Phone = "300-300-300";

            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");

            response = http.PutAsync($"customers/{cliente.CustomerID}", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                Console.WriteLine("Cliente modificado correctamente");
            }
            else Console.WriteLine($"Status Code: {response.StatusCode.ToString()}");
        }

        /// <summary>
        /// Ejemplo DELETE con un cliente APIRest 
        /// </summary>
        static void DemoDelete()
        {
            HttpResponseMessage response;
            http.BaseAddress = new Uri("https://localhost:44326/api/");

            Console.Clear();
            Console.Write("ID Cliente: ");
            string id = Console.ReadLine();

            response = http.DeleteAsync($"customers/{id}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                Console.WriteLine("Cliente eliminado correctamente");
            }
            else Console.WriteLine($"Status Code: {response.StatusCode.ToString()}");
            Console.ReadKey();
        }

        /// <summary>
        /// Ejercicio Código Postal
        /// </summary>
        static void EjercicioPostalCode()
        {
            Console.Clear();
            Console.Write("Código Postal: ");
            string code = Console.ReadLine();

            //var response = http.GetAsync($"https://api.zippopotam.us/es/{code}").Result;

            http.BaseAddress = new Uri("https://api.zippopotam.us/es/");        
            var response = http.GetAsync(code).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<dynamic>(json);

                Console.Clear();
                Console.WriteLine($"{data["post code"]} de {data["country"]}");
                Console.WriteLine("================================================");
                foreach(var place in data.places)
                {
                    Console.WriteLine($" - {place["place name"]} ({place.state})");
                }
            }
            else Console.WriteLine($"Status Code: {response.StatusCode}");


        }

        /// <summary>
        /// Ejercicio Localización de la dirección IP
        /// </summary>
        static void GeoLocationByIP()
        {
            Console.Clear();
            Console.Write("Dirección IP: ");
            string ip = Console.ReadLine();

            http.BaseAddress = new Uri("http://ip-api.com/json/");

            var data = http.GetFromJsonAsync<dynamic>(ip).Result;
            Console.WriteLine($"{data.isp}");
            Console.WriteLine($"{data.query}: {data.city} ({data.country})");

        }
    }

    /// <summary>
    /// Clase Estudiante
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
    }

    /// <summary>
    /// Clase Cliente
    /// </summary>
    public  class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}