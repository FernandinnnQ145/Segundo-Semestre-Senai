using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.HealthClinic.tarde.Domains
{

    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string? Endereco { get; set; }



        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horario de abertura é necessária")]
        public TimeOnly? HoraAbre { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horario de fechamento é necessário")]
        public TimeOnly? HoraFecha { get; set; }




        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "o CNPJ é obrigatório")]
        public string? CNPJ { get; set; }





        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "o nome fantasia é obrigatória")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "a razao social é obrigatória")]
        public string? RazaoSocial { get; set; }
    }
}
