using Microsoft.EntityFrameworkCore;
using webapi.HealthClinic.tarde.Contexts;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;

namespace webapi.HealthClinic.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public PacienteRepository()
        {
            _healthClinicContext = new HealthClinicContext();

        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = _healthClinicContext.Paciente.Find(id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.NomeConvenio = paciente.NomeConvenio;
                pacienteBuscado.Telefone = paciente.Telefone;

            }

            _healthClinicContext.Paciente.Update(pacienteBuscado!);
            _healthClinicContext.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Paciente.FirstOrDefault(e => e.IdPaciente == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthClinicContext.Paciente.Add(paciente);
                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = _healthClinicContext.Paciente.Find(id)!;

                if (pacienteBuscado != null)
                {
                    _healthClinicContext.Paciente.Remove(pacienteBuscado);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> Listar()
        {
            List<Paciente> paciente = _healthClinicContext.Paciente.Include(e => e.Usuario).ToList();

            return paciente;
        }
    }
}
