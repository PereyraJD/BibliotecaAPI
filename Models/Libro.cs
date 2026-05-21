using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 200 caracteres.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El autor no puede tener más de 100 caracteres.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "El género es obligatorio.")]
        [StringLength(100, ErrorMessage = "El género no puede tener más de 100 caracteres.")]
        public string Genero { get; set; }
        [Range(0.01, 99999.99, ErrorMessage = "El precio debe estar entre 0.01 y 99999.99.")]
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }


    }
}
