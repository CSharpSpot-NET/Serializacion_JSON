using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace Serializacion_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona yo = new Persona
            {
                nombre = "Richard",
                apellidos = "Watterson",
                genero = "Masculino",
                edad = 23,
                nacimiento = DateTime.Parse("1997-10-10")
            };
            Console.WriteLine("Serialización"); 
            Console.WriteLine("La persona {0} {1} serializada a JSON es:\n{2}",yo.nombre,yo.apellidos, JsonSerializer.Serialize<Persona>(yo));

            
            using (WebClient wc = new WebClient()){
                string jsonStr = wc.DownloadString("https://copypaste.codes/raw/vbarxpjk6d");
                yo = Deserializer(jsonStr);
                if (yo != null)
                {
                    Console.WriteLine("Deserialización");
                    Console.WriteLine("Mi nombre es: {0} {1}, tengo {2} años\nsoy del genero {3} y nací el {4}",yo.nombre,yo.apellidos,yo.edad,yo.genero,yo.nacimiento);
                }
            }
        }
        static Persona Deserializer(string jsonString)
        {
            Persona temp;
            try
            {
                JsonDocument.Parse(jsonString, options: default);
                return JsonSerializer.Deserialize<Persona>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error con el JSON String");
                return null;
            }
        }
    }
}
