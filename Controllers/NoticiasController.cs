using Microsoft.AspNetCore.Mvc;
using API_PRACTICA3_MVC.Models;
using API_PRACTICA3_MVC.Servicios;
using API_PRACTICA3_MVC.Datos;

namespace API_PRACTICA3_MVC.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly ServicioPostal _servicio;
        private readonly FeedbackDbContext _context;

        public NoticiasController(ServicioPostal servicio, FeedbackDbContext context)
        {
            _servicio = servicio;
            _context = context;
        }

        public async Task<IActionResult> Indice()
        {
            var posts = await _servicio.ObtenerPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Detalle(int id)
        {
            var post = await _servicio.ObtenerPost(id);
            var usuario = await _servicio.ObtenerUsuario(post.UserId);
            var comentarios = await _servicio.ObtenerComentarios(id);
            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.PostId == id);

            ViewData["Usuario"] = usuario;
            ViewData["Comentarios"] = comentarios;
            ViewData["Feedback"] = feedback?.Sentimiento;

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Reaccionar(int postId, string tipo)
        {
            var existe = await _context.Feedbacks.AnyAsync(f => f.PostId == postId);
            if (!existe)
            {
                var feedback = new Feedback
                {
                    PostId = postId,
                    Sentimiento = tipo,
                    Fecha = DateTime.Now
                };
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Detalle", new { id = postId });
        }
    }
}