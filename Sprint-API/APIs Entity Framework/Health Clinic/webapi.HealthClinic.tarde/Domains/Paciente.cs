using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key] public Guid IdPaciente { get; set; } = Guid.NewGuid(); 

        [Column(TypeName = "CHAR(13)")]
        [Required(ErrorMessage = "Telefone obrigatório !")]
        public string? Telefone { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        public string? NomeConvenio { get; set; }


        //Ref.Tabela Usuario
        [Required(ErrorMessage = "O id do usuário é obrigatório !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
