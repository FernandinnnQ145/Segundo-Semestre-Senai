using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;
using webapi.HealthClinic.tarde.Repositories;

namespace webapi.HealthClinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }


        /// <summary>
        /// Endpoint que acessa o metodo de cadastrar um novo paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201, paciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// EndPoint que acessa o metodo de listar todos os pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }





        /// <summary>
        /// Endpoint que acessa o metodo de deletar paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint que acessa o metodo de atualizar medico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {


                _pacienteRepository.Atualizar(id, paciente);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }



        /// <summary>
        /// EndPoint que acessa o metodo de buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }

    

 }

