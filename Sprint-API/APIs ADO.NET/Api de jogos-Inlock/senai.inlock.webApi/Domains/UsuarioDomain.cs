using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email e obrigatorio")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo senha precisa de no minimo 3 caracteres e no maximo 20")]
        [Required(ErrorMessage = "A senha e obrigatoria")]
        public string Senha { get; set; }

        
        public int IdTipoUsuario { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
