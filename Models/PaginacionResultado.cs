namespace BibliotecaAPI.Models
{
    public class PaginacionResultado<T>
    {
        public int Pagina { get; set; }
        public int Cantidad { get; set; }
        public int TotalElementos { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<T> Datos { get; set; }
    }
}
