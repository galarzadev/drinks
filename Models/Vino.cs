using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinks.Models
{

    class Vino : Bebida, IBebidaAlcoholica
    {
        public int Alcohol { get; set; }
        //public Cerveza() : base("Cerveza", 500)
        public void MaxRecomendado()
        {
            Console.WriteLine("El máximo permitido son 3 copas");
        }
        public Vino(int Cantidad, string Nombre = "Vino")
            : base(Nombre, Cantidad)
        {

        }
    }

}
