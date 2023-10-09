using webapi.HealthClinic.tarde.Contexts;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;

namespace webapi.HealthClinic.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ClinicaRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }


        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaBuscada = _healthClinicContext.Clinica.Find(id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada!.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada!.Endereco = clinica.Endereco;
                clinicaBuscada!.HoraAbre = clinica.HoraAbre;
                clinicaBuscada!.HoraFecha = clinica.HoraFecha;
             
            }

            _healthClinicContext.Clinica.Update(clinicaBuscada!);
            _healthClinicContext.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            return _healthClinicContext.Clinica.FirstOrDefault(u => u.IdClinica == id)!;
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _healthClinicContext.Clinica.Add(clinica);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> Listar()
        {
            return _healthClinicContext.Clinica.ToList();
        }
    }
}
