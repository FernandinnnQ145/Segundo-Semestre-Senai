using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;

            if (evento != null)
            {
                eventoBuscado!.NomeEvento = evento.NomeEvento;
            }

            _eventContext.Evento.Update(eventoBuscado);
            _eventContext.SaveChanges(); ;
        }

        public Evento BuscarPorId(Guid id)
        {
            Evento evento = _eventContext.Evento.Include(e => e.TipoEvento).Include(e => e.Instituicao).FirstOrDefault(u => u.IdEvento == id);
            return evento;
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id)!;
            if (eventoBuscado != null)
            {
                _eventContext.Evento.Remove(eventoBuscado);
            }
            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            
            List<Evento> evento = _eventContext.Evento.Include(e => e.TipoEvento).Include(e => e.Instituicao).ToList();

            return evento;
        }
    }
}
