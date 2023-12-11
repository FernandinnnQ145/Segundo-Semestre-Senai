using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {


        //Acesso aos metodos do repositorio
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        //Armazena dados da API externa (IA - AZURE) 
        private readonly ContentModeratorClient _contentModeratorClient;



        /// <summary>
        /// Construtor que recebe os dados necessarios para o acesso ao servico externo
        /// </summary>
        /// <param name="contentModeratorClient">Objeto do tipo ContentModeratorClient</param>
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient= contentModeratorClient;
        }


        [HttpPost("CadastroIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento comentariosEvento)
        {
            try
            {
                //Se a descricao do comentario nao for passado no objeto
                if(string.IsNullOrEmpty(comentariosEvento.Descricao))
                {
                    BadRequest("O comentario nao pode ser vazio");
                }

                //Converte a descricao em um MemorySream
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentariosEvento.Descricao));

                //Realiza a moderacao do conteudo
                var moderationResult = await
                    _contentModeratorClient.TextModeration.ScreenTextAsync(
                        "text/plain", stream, "por", false, false, null, true
                        );



                //Se existir comentarios ofensivos 
                if(moderationResult.Terms != null)
                {
                    //Atribuir false para "Exibe"
                    comentariosEvento.Exibe = false;

                    //Cadastra comentario mesmo assim
                    comentario.Cadastrar(comentariosEvento);

                }
                else
                {
                    //Atribuir true para "Exibe"
                    comentariosEvento.Exibe= true;

                    comentario.Cadastrar(comentariosEvento);

                }

                return StatusCode(201, comentariosEvento);

                


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);   
            }
        }

















        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetIA()
        {
            try
            {
                return Ok(comentario.ListarSomenteExibe());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByIdUser(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(ComentariosEvento novoComentario)
        {
            try
            {
                comentario.Cadastrar(novoComentario);
                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                comentario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
    }
}
