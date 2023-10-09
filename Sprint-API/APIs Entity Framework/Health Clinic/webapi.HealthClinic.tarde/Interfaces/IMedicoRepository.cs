using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        List<Medico> Listar();

        Medico BuscarPorId(Guid id);

        public void Deletar(Guid id);

        public void Atualizar(Guid id, Medico medico); 
    }
}
