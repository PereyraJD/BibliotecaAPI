using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;
using BibliotecaAPI.Data;


namespace BibliotecaAPI.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly BibliotecaContext _context;

        public LibroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<PaginacionResultado<Libro>> ObtenerLibrosAsync(int pagina, int cantidad)
        {
            int totalLibros = await _context.Libros.CountAsync();
            int librosASaltar = (pagina - 1) * cantidad;

            var libros = await _context.Libros
                .Skip(librosASaltar)
                .Take(cantidad)
                .ToListAsync();

            return new PaginacionResultado<Libro>
            {
                Pagina = pagina,
                Cantidad = cantidad,
                TotalElementos = totalLibros,
                TotalPaginas = (int)Math.Ceiling((double)totalLibros / cantidad),
                Datos = libros
            };
        }

        public async Task<Libro?> ObtenerLibroPorIdAsync(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task<IEnumerable<Libro>> BuscarLibrosPorAutorAsync(string autor)
        {
            return await _context.Libros
                .Where(l => l.Autor.Contains(autor))
                .ToListAsync();
        }

        public async Task<Libro> AgregarLibroAsync(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task<Libro?> ActualizarLibroAsync(int id, Libro libroActualizado)
        {
            var libroExistente = await _context.Libros.FindAsync(id);
            if (libroExistente == null)
            {
                return null;
            }
            libroExistente.Titulo = libroActualizado.Titulo;
            libroExistente.Autor = libroActualizado.Autor;
            libroExistente.Genero = libroActualizado.Genero;
            libroExistente.Precio = libroActualizado.Precio;
            libroExistente.Disponible = libroActualizado.Disponible;

            await _context.SaveChangesAsync();
            return libroExistente;
        }

        public async Task<bool> EliminarLibroAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return false;
            }
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
