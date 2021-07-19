﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinks.Models
{
    public class Post : IRequestable
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        //deben estar en mayuscula o si no es mala practica, y los convierto cuando lo rciba

    }
}
