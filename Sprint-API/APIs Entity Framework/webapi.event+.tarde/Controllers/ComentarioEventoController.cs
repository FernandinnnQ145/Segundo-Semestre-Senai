using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }



        /// <summary>
        /// EndPoint que acessa o metodo de listar comentarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo de cadastrar comentario
        /// </summary>
        /// <param name="comentarioEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentarioEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        
    }
}
