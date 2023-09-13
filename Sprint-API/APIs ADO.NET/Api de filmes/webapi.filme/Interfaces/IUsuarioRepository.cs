using webapi.filme.Domains;

namespace webapi.filme.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Metodo que busca um usuario por email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>O objeto que foi buscado</returns>
        UsuarioDomain Login(string email, string senha);
    }
}
