using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.tarde.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(6)")]
        [Required(ErrorMessage = "O numero do CRM é obrigatório")]
        public string? CRM { get; set; }


        //ref.Tabela Usuario
        [Required(ErrorMessage = "O ID do usuario é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        //ref.Tabela Especialidade
        [Required(ErrorMessage = "O ID da especialidade é obrigatória")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }


        //ref.Tabela Especialidade
        [Required(ErrorMessage = "O ID da clinica é obrigatória")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
