using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinks.Models
{
    public class Cerveza : Bebida, IBebidaAlcoholica
    {
        public int Alcohol { get; set; }
        public string Marca { get; set; }

        public int id { get; set; }
        //ña minuscula es mala practica
        //public Cerveza() : base("Cerveza", 500)
        public void MaxRecomendado() {
            Console.WriteLine("El máximo permitido son 10");
        }
/*        public Cerveza()
            : base(null, 0)
        {

        }
        public Cerveza(string Nombre, int Alcohol) : base()
        {
            this.Nombre = Nombre;
            this.Alcohol = Alcohol;
        }*/

    }
}
