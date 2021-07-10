using System;
using System.Collections.Generic;
using drinks.Models;


namespace drinks
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            Cerveza cerveza = new Cerveza(500);
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
                        MostrarRecomendacion(bebidaAlcoholica);*/

            CervezaBD cervezaBD = new CervezaBD();

            //insertamos nueva cerveza
            /*            {
                            Cerveza cerveza = new Cerveza(15, "Pale Ale");
                            cerveza.Marca = "Minerva";
                            cerveza.Alcohol = 6;
                            cervezaBD.Add(cerveza);
                        }*/

            //ontener todas cervezas

/*            {
                Cerveza cerveza = new Cerveza(5, "Pale Ale");
                cerveza.Marca = "Minerva";
                cerveza.Alcohol = 5;
                cervezaBD.Edit(cerveza, 3);
            }*/


            {

                cervezaBD.Delete(3);
            }

            var cervezas = cervezaBD.Get();
            
            foreach (var cerveza in cervezas)
            {
                Console.WriteLine(cerveza.Nombre);
                Console.WriteLine(cerveza.Alcohol);

            }


        }
/*        static void MostrarRecomendacion(IBebidaAlcoholica bebida)
        {
            bebida.MaxRecomendado();
        }*/
    }
}
