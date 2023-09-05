using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdFilme { get; set; }


        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string? Titulo { get; set; }

        public int IdEstudio { get; set; }

        public int IdTipoUsuario { get; set; }

        
        public EstudioDomain Estudio { get; set; }

        public TipoDeUsuarioDomain NomeTipoUsuario  { get; set; }
    }
}
