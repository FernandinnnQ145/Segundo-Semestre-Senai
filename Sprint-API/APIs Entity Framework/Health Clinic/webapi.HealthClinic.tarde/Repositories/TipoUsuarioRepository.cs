using webapi.HealthClinic.tarde.Contexts;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;

namespace webapi.HealthClinic.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public TipoUsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = _healthClinicContext.TipoUsuario.Find(id)!;

            if (tipoUsuario != null)
            {
                tipoUsuarioBuscado!.Titulo = tipoUsuario.Titulo;
            }

            _healthClinicContext.TipoUsuario.Update(tipoUsuarioBuscado!);
            _healthClinicContext.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _healthClinicContext.TipoUsuario.FirstOrDefault(u => u.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _healthClinicContext.TipoUsuario.Add(tipoUsuario);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TipoUsuario tipoUsuarioBuscado = _healthClinicContext.TipoUsuario.Find(id)!;
            if (tipoUsuarioBuscado != null)
            {
                _healthClinicContext.TipoUsuario.Remove(tipoUsuarioBuscado);
            }
            _healthClinicContext.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return _healthClinicContext.TipoUsuario.ToList();
        }


    }
}
