using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);

        void Deletar(Guid id);

        List<Especialidade> Listar();

        void Atualizar(Guid id, Especialidade especialidade);

        Especialidade BuscarPorId(Guid id);
    }
}
