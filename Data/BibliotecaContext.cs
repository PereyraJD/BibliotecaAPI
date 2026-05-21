using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;


namespace BibliotecaAPI.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) 
            : base(options) { }

        public DbSet<Libro> Libros { get; set; }
    }
}
