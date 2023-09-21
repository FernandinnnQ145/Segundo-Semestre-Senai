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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// EndPoint que acessa o metodo de listas todos os eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de cadastrar novo evento
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo de deletar eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);
                if (eventoBuscado == null)
                {
                    return NotFound("Tipo evento nao encontrado");
                }


                _eventoRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de atualizar eventos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if (eventoBuscado == null)
                {
                    return NotFound("evento nao encontrado");
                }

                _eventoRepository.Atualizar(id, evento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo de buscar por id de evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
