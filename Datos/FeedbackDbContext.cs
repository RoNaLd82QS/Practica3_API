using Microsoft.EntityFrameworkCore;
using API_PRACTICA3_MVC.Models;

namespace API_PRACTICA3_MVC.Datos
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
