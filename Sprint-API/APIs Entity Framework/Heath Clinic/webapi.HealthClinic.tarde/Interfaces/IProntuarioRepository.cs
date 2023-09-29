using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);

        List<Prontuario> Listar();

        Prontuario BuscarPorId(Guid id);

         void Atualizar(Guid id, Prontuario prontuario);
    }
}
