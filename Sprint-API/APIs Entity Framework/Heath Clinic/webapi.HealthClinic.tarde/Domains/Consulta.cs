using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.tarde.Domains
{

    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data da consulta é obrigatória")]
        public DateOnly DataConsulta { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário da consulta é obrigatório")]
        public TimeOnly HoraConsulta { get; set; }



        //ref.Tabela Medico
        [Required(ErrorMessage = "O ID do medico é obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }


        //ref.Tabela Paciente
        [Required(ErrorMessage = "O ID do paciente é obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
    }
}
