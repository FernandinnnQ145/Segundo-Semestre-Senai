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
    public class PresencaEventoController : ControllerBase
    {
        private IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        /// <summary>
        /// EndPoint que acessa o metodo de listas todas as presencas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de cadastrar nova presenca
        /// </summary>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Inscrever(presencaEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo de deletar presenca evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                PresencaEvento buscaPresenca = _presencaEventoRepository.BuscarPorId(id);
                if (buscaPresenca == null)
                {
                    return NotFound("Tipo evento nao encontrado");
                }


                _presencaEventoRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de atualizar prensenca eventos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="presencaEvento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {


                _presencaEventoRepository.Atualizar(id, presencaEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo de buscar por id de prensenca evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencaEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




        /// <summary>
        /// Listar apenas minhas presencas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetMinhaPresenca(Guid id)
        {
            try
            {
                List<PresencaEvento> lista = new List<PresencaEvento>();
                lista = _presencaEventoRepository.ListarMinhas(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
