using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }


        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuarioDomain> listaTipoUsuario = _TipoUsuarioRepository.ListarTodos();

                return Ok(listaTipoUsuario);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }
    }
}
