using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {

        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento buscaEvento = _eventContext.PresencaEvento.Find(id)!;

                if (buscaEvento != null)
                {
                    buscaEvento!.IdEvento = presencaEvento.IdEvento;
                    buscaEvento!.IdUsuario = presencaEvento.IdUsuario;
                    buscaEvento!.Situacao = presencaEvento.Situacao;
                }
                _eventContext.PresencaEvento.Update(buscaEvento!);
                _eventContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public PresencaEvento BuscarPorId(Guid id)
        {

            PresencaEvento buscaPresenca = _eventContext.PresencaEvento.FirstOrDefault(u => u.IdPresencaEvento == id)!;
            return buscaPresenca;
        }

        public void Deletar(Guid id)
        {
            PresencaEvento buscaPresenca = _eventContext.PresencaEvento.Find(id)!;
            if (buscaPresenca != null)
            {
                _eventContext.PresencaEvento.Remove(buscaPresenca);
            }
            _eventContext.SaveChanges();
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                _eventContext.PresencaEvento.Add(inscricao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            return _eventContext.PresencaEvento.ToList();
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            List<PresencaEvento> presencaEvento = _eventContext.PresencaEvento.Where(u => u.IdPresencaEvento == id).ToList();

            return presencaEvento;
        }
    }
}
