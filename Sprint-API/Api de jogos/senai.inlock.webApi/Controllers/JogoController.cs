using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }


        public JogoController()
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> listaJogos = _JogoRepository.ListarTodos();

                return Ok(listaJogos);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(JogoDomain NovoJogo)
        {
            try
            {

                _JogoRepository.Cadastrar(NovoJogo);

                return StatusCode(201);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {

                _JogoRepository.Deletar(id);

                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
