using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Atualizar(Guid id, TipoUsuario tipoUsuario);

        void Cadastrar(TipoUsuario tipoUsuario);

        TipoUsuario BuscarPorId(Guid id);

        void Deletar(Guid id);

        List<TipoUsuario> Listar();
    }
}
