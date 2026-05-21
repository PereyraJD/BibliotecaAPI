using BibliotecaAPI.Models;


namespace BibliotecaAPI.Repositories
{
    public interface ILibroRepository
    {
        Task<PaginacionResultado<Libro>> ObtenerLibrosAsync(int pagina, int cantidad);
        Task<Libro?> ObtenerLibroPorIdAsync(int id);
        Task<IEnumerable<Libro>> BuscarLibrosPorAutorAsync(string autor);
        Task<Libro> AgregarLibroAsync(Libro libro);
        Task<Libro?> ActualizarLibroAsync(int id, Libro libroActualizado);
        Task<bool> EliminarLibroAsync(int id);
    }
}
