using webapi.inlock_codefirst.Contexts;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;

namespace webapi.inlock_codefirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private readonly InlockContext ctx;
        public JogoRepository()
        {
            ctx = new InlockContext();
        }
        public void Cadastrar(Jogo NovoJogo)
        {
            ctx.Jogo.Add(NovoJogo);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Jogo? jogoBuscado = ctx.Jogo.Find(id);

            if (jogoBuscado != null)
            {
                ctx.Jogo.Remove(jogoBuscado);
            }
            ctx.SaveChanges();
        }

        public List<Jogo> ListarTodos()
        {
            return ctx.Jogo.ToList();
        }
    }
}
