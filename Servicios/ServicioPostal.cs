using System.Text.Json;
using API_PRACTICA3_MVC.Models;

namespace API_PRACTICA3_MVC.Servicios
{
    public class ServicioPostal
    {
        private readonly HttpClient _http;

        public ServicioPostal(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Post>> ObtenerPostsAsync()
        {
            var response = await _http.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            return JsonSerializer.Deserialize<List<Post>>(response) ?? new();
        }

        public async Task<Post> ObtenerPost(int id)
        {
            var response = await _http.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            return JsonSerializer.Deserialize<Post>(response);
        }

        public async Task<List<Comentario>> ObtenerComentarios(int postId)
        {
            var response = await _http.GetStringAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            return JsonSerializer.Deserialize<List<Comentario>>(response);
        }

        public async Task<Usuario> ObtenerUsuario(int userId)
        {
            var response = await _http.GetStringAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            return JsonSerializer.Deserialize<Usuario>(response);
        }
    }
}
