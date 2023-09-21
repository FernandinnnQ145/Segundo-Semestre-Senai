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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }


        /// <summary>
        /// EndPoint que acessa o metodo de listar todos os tipos usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo de cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de deletar tipo evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);
                if (tipoEventoBuscado == null)
                {
                    return NotFound("Tipo evento nao encontrado");
                }


                _tipoEventoRepository.Deletar(id);

                return NoContent();




            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de atualizar tipo evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoEvento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                if (tipoEventoBuscado == null)
                {
                    return NotFound("Tipo evento nao encontrado");
                }

                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de buscar por id de tipo evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
