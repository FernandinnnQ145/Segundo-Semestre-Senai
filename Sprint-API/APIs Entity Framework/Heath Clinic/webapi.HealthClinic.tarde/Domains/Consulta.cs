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
        [Required(ErrorMessage = "A data da consulta é necessária")]
        public DateTime? Data { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário da consulta é necessário")]
        public TimeOnly? Hora { get; set; }


        //ref.Tabela Paciente
        [Required(ErrorMessage = "O id do paciente é obrigatório !")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


        //Ref.Tabela Medico

        [Required(ErrorMessage = "O id do médico é obrigatório !")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }





    }
}
