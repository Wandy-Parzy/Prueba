using System.ComponentModel.DataAnnotations;

namespace Ejemplo1.Model{
    public class Car {
        [Key]
        public int CarId { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Matricula { get; set; }
        public DateTime Fecha { get; set; }
         public string? Descripcion { get; set; }
     }
}