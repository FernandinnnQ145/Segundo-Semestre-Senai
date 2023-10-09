using webapi.HealthClinic.tarde.Contexts;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;

namespace webapi.HealthClinic.tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public ComentarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }

        public void Atualizar(Guid id, Comentario comentario)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.Find(id)!;

            if (comentarioBuscado != null)
            {

                comentarioBuscado.Descricao = comentario.Descricao;

            }

            _healthClinicContext.Comentario.Update(comentarioBuscado!);
            _healthClinicContext.SaveChanges();
        }

        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                return _healthClinicContext.Comentario.FirstOrDefault(x => x.IdComentario == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                _healthClinicContext.Comentario.Add(comentario);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Comentario comentarioBuscado = _healthClinicContext.Comentario.Find(id)!;

            if (comentarioBuscado != null)
            {
                _healthClinicContext.Comentario.Remove(comentarioBuscado);
            }

            _healthClinicContext.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            try
            {
                return _healthClinicContext.Comentario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
