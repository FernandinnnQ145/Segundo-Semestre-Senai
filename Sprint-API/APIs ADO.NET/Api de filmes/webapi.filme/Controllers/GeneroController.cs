using Microsoft.AspNetCore.Authorization;
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
        [Authorize]//Precisa estar logado para
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
        [Authorize(Roles = "Administrador")]//Precisa estar logado para
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



        /// <summary>
        /// Endpoint que acessa o metodo de deletar os generos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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





        /// <summary>
        /// Endpoit que acessa o metodo de atualizar o genero passando o Id pelo corpo da requisição.
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(GeneroDomain genero)
        {
            try
            {

                _generoRepository.AtualizarIdCorpo(genero);

                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o metodo de buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                GeneroDomain generoEncontrado = _generoRepository.BuscarPorId(id);

                if(generoEncontrado == null)
                {
                    return NotFound("O genero buscado nao foi encontrado");
                }

                else
                {
                    return Ok(generoEncontrado);
                }
                
               
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }

        }



        [HttpPut]
        public IActionResult PutUrl(int id, GeneroDomain genero)
        {
            try
            {

                _generoRepository.AtualizarIdUrl(id, genero);

                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }



    }
}
