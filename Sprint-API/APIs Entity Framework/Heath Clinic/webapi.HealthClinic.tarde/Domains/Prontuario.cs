using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.tarde.Domains
{

    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        [Key]
        public Guid IdPronturario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do prontuário é obrigatória !")]
        public string? Descricao { get; set; }



        //ref.Tabela Medico
        [Required(ErrorMessage = "O id do médico é obrigatório !")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }


        //ref.Tabela Consulta
        [Required(ErrorMessage = "O id da consulta é obrigatório !")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
