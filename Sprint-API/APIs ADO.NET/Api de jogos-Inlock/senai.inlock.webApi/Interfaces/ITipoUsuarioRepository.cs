using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTodos();
    }
}
