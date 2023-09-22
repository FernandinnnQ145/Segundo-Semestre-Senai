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


        /// <summary>
        /// EndPoint que acessa o metodo de deletar comentario evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                ComentarioEvento eventoBuscado = _comentarioEventoRepository.BuscarPorId(id);
                if (eventoBuscado == null)
                {
                    return NotFound("Tipo evento nao encontrado");
                }


                _comentarioEventoRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de buscar por id do comentario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
