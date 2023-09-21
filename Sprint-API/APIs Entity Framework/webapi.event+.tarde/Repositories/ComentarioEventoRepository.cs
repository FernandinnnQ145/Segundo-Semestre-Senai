using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            return _eventContext.ComentarioEvento.FirstOrDefault(u => u.IdComentarioEvento == id)!;
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comentarioEventoBuscado = _eventContext.ComentarioEvento.Find(id)!;
            if (comentarioEventoBuscado != null)
            {
                _eventContext.Evento.Remove(comentarioEventoBuscado);
            }
            _eventContext.SaveChanges();
        }

        public List<ComentarioEvento> Listar()
        {
            List<ComentarioEvento> comentarioEvento = _eventContext.ComentarioEvento.Include(e => e.Evento).Include(e => e.Usuario).ToList();

            return comentarioEvento;
        }
    }
}
