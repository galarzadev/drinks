using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using drinks.Models;
using drinks.Errors;


namespace drinks.Service
{
    public class SearcherBeer
    {
        List<Cerveza> cervezas = new List<Cerveza>()
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
    };

        public int GetCantidad(string Nombre)
        {
            var cerveza = (from d in cervezas
                          where d.Nombre == Nombre
                          select d).FirstOrDefault();
            if (cerveza == null)
                throw new BeerNotFoundException("Se acabó la pola");
            return cerveza.Cantidad;
        }
    }
}

