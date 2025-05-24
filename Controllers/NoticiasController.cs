using Microsoft.AspNetCore.Mvc;
using API_PRACTICA3_MVC.Models;
using API_PRACTICA3_MVC.Servicios;
using API_PRACTICA3_MVC.Datos;
using Microsoft.EntityFrameworkCore;

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

        // GET: /Noticias/Indice
        public async Task<IActionResult> Indice()
        {
            var posts = await _servicio.ObtenerPostsAsync();

            if (posts == null || !posts.Any())
            {
                TempData["Error"] = "No se pudieron cargar las publicaciones.";
                return View(new List<Post>());
            }

            return View(posts);
        }

        // GET: /Noticias/Detalle/{id}
        public async Task<IActionResult> Detalle(int id)
        {
            try
            {
                var post = await _servicio.ObtenerPost(id);
                if (post == null)
                {
                    TempData["Error"] = "La publicación no existe o no se pudo cargar.";
                    return RedirectToAction("Indice");
                }

                var usuario = await _servicio.ObtenerUsuario(post.UserId);
                var comentarios = await _servicio.ObtenerComentarios(id);
                var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.PostId == id);

                ViewData["Usuario"] = usuario;
                ViewData["Comentarios"] = comentarios;
                ViewData["Feedback"] = feedback?.Sentimiento;

                return View(post);
            }
            catch
            {
                TempData["Error"] = "Ocurrió un error al cargar la publicación.";
                return RedirectToAction("Indice");
            }
        }

        // POST: /Noticias/Reaccionar
        [HttpPost]
        public async Task<IActionResult> Reaccionar(int postId, string tipo)
        {
            if (string.IsNullOrEmpty(tipo) || (tipo != "like" && tipo != "dislike"))
            {
                TempData["Error"] = "Reacción inválida.";
                return RedirectToAction("Detalle", new { id = postId });
            }

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
