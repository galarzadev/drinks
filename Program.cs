using System;
using System.Collections.Generic;
using drinks.Models;
using drinks.Errors;
using drinks.Service;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace drinks
{
    static class Program //para usar ka extension del metodo
    {
        static async Task Main(string[] args)
        {
            //generics class
            /*            var cerveza = new Cerveza()
                        {
                            Alcohol = 5,
                            Cantidad = 500,
                            Marca = "Colina",
                            Nombre = "Ticús"
                        }; 
                        var post = new Post()
                        {
                            title = "SapoPrro"
                        };

                        Service.SendRequest<Post> service = new Service.SendRequest<Post>();
                        var CervezaRespuesta = await service.Send(post);*/


            //LINQ PRIMERA PARTE

            /*List<int> numeros = new List<int>() { 1, 4, 5, 6, 7, 2, 3 };
            //var numero7 = numeros.Where(d => d == 9).FirstOrDefault();
            var numerosOrdenados = numeros.OrderBy(d => d);

            foreach (var numero in numerosOrdenados){
            Console.WriteLine(numero);

            }

            var numerosSumados = numeros.Sum(d => d); //average tambien
            Console.WriteLine(numerosSumados);

            //Console.WriteLine(numero7);

            //ejemplo cervezas
            List<Cerveza> cervezas = new List<Cerveza>()
            {
                new Cerveza()
            {
                Alcohol = 5,
                            Cantidad = 500,
                            Marca = "Colina",
                            Nombre = "Ticús"
             },
                new Cerveza()
            {
                Alcohol = 0,
                            Cantidad = 330,
                            Marca = "Aguila",
                            Nombre = "Cero"
             },
                new Cerveza()
            {
                Alcohol = 4,
                            Cantidad = 700,
                            Marca = "Poker",
                            Nombre = "Pokeron"
             },
                new Cerveza()
            {
                Alcohol = 5,
                            Cantidad = 330,
                            Marca = "BBC",
                            Nombre = "Candelaria"
             },

            };

            var cervezasOrdenadas = from d in cervezas
                                    where d.Cantidad == 330 //&& MArca ==Aguila
                                    orderby d.Marca
                                    select d;
            foreach(var cerveza in cervezasOrdenadas)
            {
                Console.WriteLine($"{cerveza.Nombre} de la marca {cerveza.Marca}");
            }*/

            //LINQ SEGUNDA PARTE

            List<Bar> bares = new List<Bar>()
            {
                new Bar("El bar")
                {
                    cervezas = new List<Cerveza>()
                    {
                    new Cerveza()
                        {
                            Alcohol = 5, Cantidad = 500, Marca = "Colina", Nombre = "Ticús"
                         },
                            new Cerveza()
                        {
                            Alcohol = 0, Cantidad = 330, Marca = "Aguila", Nombre = "Cero"
                         }
                    }
                },

                new Bar("El bar 2")
                {
                    cervezas = new List<Cerveza>()
                    {
                    new Cerveza()
                        {
                            Alcohol = 5,  Cantidad = 500, Marca = "Colina 2", Nombre = "Ticús 2"
                         },
                            new Cerveza()
                        {
                            Alcohol = 0,
                                        Cantidad = 330, Marca = "Aguila 2", Nombre = "Cero"
                         }
                    }
                 },
                                new Bar("El bar nuevo")
            };

            var bar = (from d in bares
                       where d.cervezas.Where(c => c.Nombre == "Cero").Count() > 0
//                       select d).ToList();
                       select new BarData(d.Nombre)
                       {
                           bebidas = (from c in d.cervezas
                                      select new Bebida(c.Nombre,c.Cantidad)
                                      ).ToList()
                       }
                       ).ToList();

            //MANEJO DE EXCEPCIONES

            /*            try
                        {
                            using (var archivo = new StreamWriter(@"C:\hola.txt")) //aqui funciona para crear un objeto
                            {
                                archivo.WriteLine("patio");
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }*/

            try
            {
                var searcherBeer = new SearcherBeer();
                var cantidad = searcherBeer.GetCantidad("Ceroti");
            }
            catch (BeerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)//puedo poner varios caches con los diferentes tipos de excepcion y al final esta generica
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Esto siempre se ejecutará");

            }

            // DELEGADOS FUNC ASYNC

            // este es static async task main

            Func<string, int> mostrar = Show; //el ultimo argumento es el return, todos los demas son entradas
            Action<string, string> mostrar2 = Show; //action no regresa nada, solo ejecuta algo

            HacerAlgo(mostrar);
            HacerAlgoAction(mostrar2);


            //15. PREDICADOS

            var numbers = new List<int> { 1, 56, 2, 3, 3, 45, 6 };
            var predicate = new Predicate<int>(x => x % 2 == 0);
            var dividers2 = numbers.FindAll(predicate);
            Predicate<int> negativePredicate = x => !predicate(x);
            dividers2.ForEach(d => { Console.WriteLine(d); });

            //BeerFinal

            var beers = new List<BeerFinal>()
            {
                new BeerFinal() {Name = "Ipa", Alcohol = 7},
                new BeerFinal() {Name = "Pale ale", Alcohol = 8},
                new BeerFinal() {Name = "Stout", Alcohol = 9},
                new BeerFinal() {Name = "Tripel", Alcohol = 15}
            };

            beers.ShowBeerThatIGetDrunk(x=>x.Alcohol>=8);



        }
            static void ShowBeerThatIGetDrunk(this List<BeerFinal> beers, Predicate<BeerFinal> condition) //this agrega una extension al metodo
            {
                var evilBeers = beers.FindAll(condition);
                evilBeers.ForEach(d => Console.WriteLine(d.Name));
            }


        public class BeerFinal
        {
            public string Name { get; set; }
            public int Alcohol { get; set; }
        }

        static bool IsDivider2(int x) => x % 2 == 0;

        //public delegate string Mostrar(string cadena);
        public static void HacerAlgo(Func<string, int> funcionFinal)
        {
            Console.WriteLine("hago algo");
            Console.WriteLine(funcionFinal("se envio desde otra funcion mama"));//se ejecuta antes cuando lo envio aca para inprimir
        }
        public static void HacerAlgoAction(Action<string, string> funcionFinal) //hasta 16 parametros
        {
            Console.WriteLine("hago algo en el action y no regreso nada");
            funcionFinal("se envio desde otra funcion en un action", " segunda cadena");
        }
        public static int Show(string cad)
        {
            Console.WriteLine("hola soy un delegado se mostrará?" + cad);
            return cad.Count();
        }

        public static void Show(string cad, string cad2)
        {
            Console.WriteLine(cad+cad2);

        }

    }
}
