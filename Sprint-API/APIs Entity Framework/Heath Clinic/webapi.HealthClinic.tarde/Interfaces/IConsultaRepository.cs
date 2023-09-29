using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface IConsultaRepository
    {
         void Cadastrar(Consulta consulta);

        void Cancelar(Guid id);

        List<Consulta> Listar();

         void Atualizar(Guid id, Consulta consulta);

         Consulta BuscarPorId(Guid id);

        List<Consulta> ListarParaMedico(Guid id);

        List<Consulta> ListarParaPaciente(Guid id);
    }
}
