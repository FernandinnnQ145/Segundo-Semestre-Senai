using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface ITipoDeUsuarioRepository
    {
        List<EstudioDomain> ListarTodos();
    }
}
