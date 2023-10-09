using webapi.HealthClinic.tarde.Contexts;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;

namespace webapi.HealthClinic.tarde.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public EspecialidadeRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }









        public void Atualizar(Guid id, Especialidade especialidade)
        {
            Especialidade especialidadeBuscada = BuscarPorId(id)!;

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.Titulo = especialidade.Titulo;

                _healthClinicContext.Especialidade.Update(especialidadeBuscada!);
                _healthClinicContext.SaveChanges();

            }

        }

        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Especialidade.FirstOrDefault(e => e.IdEspecialidade == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                _healthClinicContext.Especialidade.Add(especialidade);
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
                Especialidade especialidadeBuscada = _healthClinicContext.Especialidade.Find(id)!;

                if (especialidadeBuscada != null)
                {
                    _healthClinicContext.Especialidade.Remove(especialidadeBuscada);
                }

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Especialidade> Listar()
        {
            return _healthClinicContext.Especialidade.ToList();
        }
    }
}
