using Microsoft.EntityFrameworkCore;
using webapi.inlock_codefirst.Contexts;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;

namespace webapi.inlock_codefirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly InlockContext ctx;
        public EstudioRepository()
        {
            ctx = new InlockContext();
        }
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = ctx.Estudio.Find(id);

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }
            ctx.Estudio.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudio)
        {
            ctx.Estudio.Add(estudio);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudio.Find(id);

            if (estudioBuscado != null)
            {
                ctx.Estudio.Remove(estudioBuscado);
            }
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudio.ToList();
        }

        public List<Estudio> ListarComJigos()
        {
            return ctx.Estudio.Include(e => e.Jogos).ToList();
        }
    }
}
