using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TipoDeUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }


        [Required(ErrorMessage = "O nome do estudio é obrigatório!")]
        public string? NomeTipoUsuario { get; set; }
    }
}
