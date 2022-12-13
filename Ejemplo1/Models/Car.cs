using System.ComponentModel.DataAnnotations;

namespace Ejemplo1.Model
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required(ErrorMessage = "La marcaes requerida")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "El modelo es requerido")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "La matricula es requerida")]
        public string? Matricula { get; set; }
        
        [Range(minimum: 0, maximum: 10000000000, ErrorMessage = "Debe ingresar el precio")]
        public int Precio { get; set; }
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string? Descripcion { get; set; }
    }
}