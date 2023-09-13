using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{

    [Table("Usuario")]
    [Index(nameof(Email), IsUnique =true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email e obrigatorio")]
        []
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "Senha e obrigatorio")]
        [StringLength(20, MinimumLength =6, ErrorMessage = "Senha deve conter de 6 a 20 caracteres")]
        public string Senha { get; set; }

    }
}
