using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinks.Models
{
    class Cerveza : Bebida, IBebidaAlcoholica
    {
        public int Alcohol { get; set; }
        public string Marca { get; set; }
        //public Cerveza() : base("Cerveza", 500)
        public void MaxRecomendado() {
            Console.WriteLine("El máximo permitido son 10");
        }
        public Cerveza(int Cantidad,string Nombre="Cerveza")
            : base(Nombre, Cantidad)
        {

        }
    }
}
