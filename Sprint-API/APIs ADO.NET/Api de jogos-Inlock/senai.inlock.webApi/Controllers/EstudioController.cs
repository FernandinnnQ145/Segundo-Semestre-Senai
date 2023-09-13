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
        [Authorize(Roles = "1,2")]
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
        [Authorize(Roles = "2")]
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
        [Authorize(Roles = "2")]
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
