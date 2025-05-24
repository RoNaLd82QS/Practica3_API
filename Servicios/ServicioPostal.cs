using System.Text.Json;
using API_PRACTICA3_MVC.Models;

namespace API_PRACTICA3_MVC.Servicios
{
    public class ServicioPostal
    {
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ServicioPostal(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Post>> ObtenerPostsAsync()
        {
            try
            {
                var response = await _http.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
                return JsonSerializer.Deserialize<List<Post>>(response, _jsonOptions) ?? new List<Post>();
            }
            catch (Exception ex)
            {
                // Log opcional: Console.WriteLine($"Error al obtener posts: {ex.Message}");
                return new List<Post>();
            }
        }

        public async Task<Post?> ObtenerPost(int id)
        {
            try
            {
                var response = await _http.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
                return JsonSerializer.Deserialize<Post>(response, _jsonOptions);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Comentario>> ObtenerComentarios(int postId)
        {
            try
            {
                var response = await _http.GetStringAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
                return JsonSerializer.Deserialize<List<Comentario>>(response, _jsonOptions) ?? new List<Comentario>();
            }
            catch
            {
                return new List<Comentario>();
            }
        }

        public async Task<Usuario?> ObtenerUsuario(int userId)
        {
            try
            {
                var response = await _http.GetStringAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
                return JsonSerializer.Deserialize<Usuario>(response, _jsonOptions);
            }
            catch
            {
                return null;
            }
        }
    }
}
