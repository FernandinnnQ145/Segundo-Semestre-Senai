using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Repositories;

namespace webapi.inlock_codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository;

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogoRepository.ListarTodos());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        [HttpPost]
        public IActionResult Post(Jogo NovoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(NovoJogo);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _jogoRepository.Deletar(id);
                return Ok();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            

        }
    }
}
