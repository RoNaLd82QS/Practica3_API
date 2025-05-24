using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PRACTICA3_MVC.Models
{
    public class Comentario
    {
        public int PostId { get; set; }
        public string? Name { get; set; }
        public string? Body { get; set; }
    }
}