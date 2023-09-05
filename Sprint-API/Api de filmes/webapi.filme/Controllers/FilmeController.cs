using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filme.Domains;
using webapi.filme.Interfaces;
using webapi.filme.Repositories;

namespace webapi.filme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    /// <summary>
    /// Define que o tipo de resposta da API e JSON
    /// </summary>
    [Produces("application/json")]


    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia do objeto _generoRepository para que haja referencia aos metodos do repositorio
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeReposiroy();
        }


        /// <summary>
        /// Endpoint que acessa o metodo de listar os filmes
        /// </summary>
        /// <returns>Lista de generos em um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                return Ok(listaFilmes);
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
        public IActionResult Post(FilmeDomain NovoFilme)
        {
            try
            {

                _filmeRepository.Cadastrar(NovoFilme);

                return StatusCode(201);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o metodo de deletar os filmes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                _filmeRepository.Deletar(id);

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
        /// <param name="filme"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(FilmeDomain filme)
        {
            try
            {

                _filmeRepository.AtualizarIdCorpo(filme);

                return StatusCode(204);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut]
        public IActionResult PutUrl(int id, FilmeDomain filme)
        {
            try
            {

                _filmeRepository.AtualizarIdUrl(id, filme);

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
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                if (filmeEncontrado == null)
                {
                    return NotFound("O Filme buscado nao foi encontrado");
                }

                else
                {
                    return Ok(filmeEncontrado);
                }


            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }

        }









    }




}
