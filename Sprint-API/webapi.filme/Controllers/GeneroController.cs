using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filme.Domains;
using webapi.filme.Interfaces;
using webapi.filme.Repositories;

namespace webapi.filme.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisicao sera no seguinte formato
    /// dominio/api/nomeController
    /// exemplo http://localhost:5000/api/genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que e um controlador de api
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API e JSON
    /// </summary>
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto ira receber os metodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia do objeto _generoRepository para que haja referencia aos metodos do repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// Endpoint que acessa o metodo de listar os generos
        /// </summary>
        /// <returns>Lista de generos em um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }

          
        }

        /// <summary>
        /// Endpoint que acessa o metodo de cadastrar os generos
        /// </summary>
        /// <returns>Cadastra um generos em um status code</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                
                _generoRepository.Cadastrar(novoGenero);
                
                return StatusCode(201);

            }
            catch (Exception erro)
            {
                
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                _generoRepository.Deletar(id);

                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
