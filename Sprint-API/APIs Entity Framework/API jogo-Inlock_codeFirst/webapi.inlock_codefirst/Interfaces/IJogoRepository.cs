using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Interfaces
{
    public interface IJogoRepository
    {
        void Cadastrar(Jogo NovoJogo);

        void Deletar(Guid id);

        List<Jogo> ListarTodos();
    }
}
