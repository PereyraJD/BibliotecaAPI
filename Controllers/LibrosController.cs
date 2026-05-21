using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;


namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroRepository _repository;
        public LibrosController(ILibroRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        
        public async Task<IActionResult> ObtenerTodos(
            [FromQuery] int pagina = 1,
            [FromQuery] int cantidad = 10)
        {
            if(pagina <= 0)
                return BadRequest("La página deben ser mayores a cero.");
            if(cantidad <= 0)
                return BadRequest("La cantidad deben ser mayores a cero.");


            var resultado = await _repository.ObtenerLibrosAsync(pagina, cantidad);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerLibroPorId(int id)
        {
            var libro = await _repository.ObtenerLibroPorIdAsync(id);

            if (libro == null)
                return NotFound($"No existe un libro con el ID {id}");

            return Ok(libro);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarLibrosPorAutor([FromQuery] string autor)
        {

            if (string.IsNullOrWhiteSpace(autor))
                return BadRequest("El parámetro 'autor' no puede estar vacío.");

            var libros = await _repository.BuscarLibrosPorAutorAsync(autor);
            return Ok(libros);

        }

        [HttpPost]
        public async Task<IActionResult> AgregarLibro([FromBody] Libro libro)
        {
            var libroAgregado = await _repository.AgregarLibroAsync(libro);

            return CreatedAtAction(nameof(ObtenerLibroPorId), new { id = libroAgregado.Id }, libroAgregado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarLibro(int id, [FromBody] Libro libroActualizado)
        {
            var libro = await _repository.ActualizarLibroAsync(id, libroActualizado);

            if (libro == null)
                return NotFound($"No existe un libro con el ID {id}");

            return Ok(libro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            var eliminado = await _repository.EliminarLibroAsync(id);

            if (!eliminado)
                return NotFound($"No existe un libro con el ID {id}");

            return Ok("Libro eliminado correctamente.");
        }
    }
}


