using System;
using System.Collections.Generic;
using drinks.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace drinks
{
    class Program
    {
/*        static void Main(string[] args)
        {
            *//*            Cerveza cerveza = new Cerveza(500);
                        cerveza.Beberse(10);
                        Console.WriteLine(cerveza.Cantidad);*/
/*            int[] numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            foreach (var numero in numeros)
            {
                Console.WriteLine("iteración: " + numero);
            }
            Console.WriteLine("*****************************");

            List<int> lista = new List<int>() {1,2,3,4,5,6,7,8};
            lista.Add(9);
            lista.Add(0);
            lista.Remove(2);

            foreach (var numero in lista)
            {
                Console.WriteLine("elemento = " + numero);
            }
            Console.WriteLine("*****************************");

            List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza(10, "Cerveza Premium") };
            cervezas.Add(new Cerveza(500));
            Cerveza erdinger = new Cerveza(500, "Cerveza de trigo");
            cervezas.Add(erdinger);

            foreach (var cerveza in cervezas)
            {
                Console.WriteLine("cerveza = " + cerveza.Nombre);
            }*/

/*            var bebidaAlcoholica = new Cerveza(100);
            MostrarRecomendacion(bebidaAlcoholica);*//*

CervezaBD cervezaBD = new CervezaBD();

//insertamos nueva cerveza
*//*            {
                Cerveza cerveza = new Cerveza(15, "Pale Ale");
                cerveza.Marca = "Minerva";
                cerveza.Alcohol = 6;
                cervezaBD.Add(cerveza);
            }*//*

//ontener todas cervezas

*//*            {
                Cerveza cerveza = new Cerveza(5, "Pale Ale");
                cerveza.Marca = "Minerva";
                cerveza.Alcohol = 5;
                cervezaBD.Edit(cerveza, 3);
            }*/


/*            {

                cervezaBD.Delete(3);
            }

            var cervezas = cervezaBD.Get();

            foreach (var cerveza in cervezas)
            {
                Console.WriteLine(cerveza.Nombre);
                Console.WriteLine(cerveza.Alcohol);

            }*/

/*            Cerveza cerveza = new Cerveza(10, "Cerveza");
            string miJson = JsonSerializer.Serialize(cerveza);
            File.WriteAllText("objeto.txt", miJson);
            Console.WriteLine(miJson);*//*
string miJson = File.ReadAllText("objeto.txt");
Cerveza cerveza = JsonSerializer.Deserialize<Cerveza>(miJson);
Console.WriteLine(miJson);
}*/
/*        static void MostrarRecomendacion(IBebidaAlcoholica bebida)
        {
            bebida.MaxRecomendado();
        }*/

//Solicitudes a servicios hhtp get

/*        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            *//*            var res = client.GetAsync(url);

                        Console.WriteLine("mordí el nuget");

                        await res;

                        Console.WriteLine("beber cerveza")*//*

            var httpResponse = await client.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                List<Models.Post> posts =
                    JsonSerializer.Deserialize<List<Models.Post>>(content);


            }


        }*/

//Solicitudes a servicios hhtp post
        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var client = new HttpClient();

            Post post = new Post()
            {
                userId = 50,
                body = "titulin",
                title = "salu2"
            };
            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync(url, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                var postResult = JsonSerializer.Deserialize<Post>(result);

                //put edita un elemento segun el id en la url ej: posts/50 y lo demas igual
                //delete es igual que put pero sin content ni variable, algunos te devuelven el contenido
            }
        }

    }
}
