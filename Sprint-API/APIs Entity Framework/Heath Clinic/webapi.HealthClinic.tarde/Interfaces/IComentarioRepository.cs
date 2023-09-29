using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);

        void Deletar(Guid id);

        List<Comentario> Listar();

        void Atualizar(Guid id, Comentario comentario);

        Comentario BuscarPorId(Guid id);
    }
}
