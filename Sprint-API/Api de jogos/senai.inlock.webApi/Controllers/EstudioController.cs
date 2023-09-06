using Microsoft.AspNetCore.Authorization;
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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaEstudio = _estudioRepository.ListarTodos();

                return Ok(listaEstudio);
            }
            catch (Exception erro)
            {
                
                return BadRequest(erro.Message);
            }


        }

        [HttpPost]
        public IActionResult Post(EstudioDomain NovoEstudio)
        {
            try
            {

                _estudioRepository.Cadastrar(NovoEstudio);

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

                _estudioRepository.Deletar(id);

                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
