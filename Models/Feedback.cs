using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PRACTICA3_MVC.Models
{
    public class Feedback
    {
    public int Id { get; set; }
    public int PostId { get; set; }
    public string? Sentimiento { get; set; } // "like" o "dislike"
    public DateTime Fecha { get; set; }
    }
}