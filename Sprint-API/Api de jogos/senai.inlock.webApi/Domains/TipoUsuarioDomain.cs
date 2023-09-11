using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }


        [Required(ErrorMessage = "O nome do tipo de usuario é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
