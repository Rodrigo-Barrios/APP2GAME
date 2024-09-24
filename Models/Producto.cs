using System.ComponentModel.DataAnnotations.Schema;

namespace APP2GAME.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Nombre { get; set; }
        
        public string? Descripcion { get; set; }

        public Decimal Precio { get; set; }

        public DateTime FechaLanzamiento { get; set;}
        
        public int Calificacion { get; set; }

        public bool Multijugador { get; set; }

        public string? Status { get; set; }

        public string? ImageURL { get; set; }

        public Categoria? Categoria { get; set; }

    }
}