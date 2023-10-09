using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Interfaces
{
    public interface IClinicaRepository
    {
         void Cadastrar(Clinica clinica);

         List<Clinica> Listar();

         Clinica BuscarPorId(Guid id);

         void Atualizar(Guid id, Clinica clinica);
    }
}
