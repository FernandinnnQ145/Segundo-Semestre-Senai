using webapi.HealthClinic.tarde.Contexts;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;

namespace webapi.HealthClinic.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ConsultaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }





        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = _healthClinicContext.Consulta.Find(id)!;

            if (consultaBuscada != null)
            {

                consultaBuscada.Data = consulta.Data;
                consultaBuscada.Hora = consulta.Hora;

            }

            _healthClinicContext.Consulta.Update(consultaBuscada!);
            _healthClinicContext.SaveChanges();
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Consulta.FirstOrDefault(e => e.IdConsulta == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _healthClinicContext.Consulta.Add(consulta);
                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cancelar(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _healthClinicContext.Consulta.Find(id)!;

                if (consultaBuscada != null)
                {
                    _healthClinicContext.Consulta.Remove(consultaBuscada);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> Listar()
        {
            return _healthClinicContext.Consulta.ToList();
        }

        public List<Consulta> ListarParaMedico(Guid id)
        {
            try
            {
                return _healthClinicContext.Consulta.Where(x => x.IdMedico == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> ListarParaPaciente(Guid id)
        {
            try
            {
                return _healthClinicContext.Consulta.Where(x => x.IdPaciente == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
