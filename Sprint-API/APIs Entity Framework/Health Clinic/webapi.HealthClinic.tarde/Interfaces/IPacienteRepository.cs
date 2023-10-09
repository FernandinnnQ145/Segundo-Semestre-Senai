using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        List<Paciente> Listar();

        Paciente BuscarPorId(Guid id);

        public void Deletar(Guid id);

        public void Atualizar(Guid id, Paciente paciente);
    }
}
