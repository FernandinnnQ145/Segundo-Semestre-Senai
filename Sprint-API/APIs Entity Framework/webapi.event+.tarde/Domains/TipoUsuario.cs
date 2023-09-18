using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do tipo de usuario obrigatorio")]
        public string Titulo { get; set; }  
    }
}
