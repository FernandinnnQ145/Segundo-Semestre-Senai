using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;
using webapi.HealthClinic.tarde.Repositories;
using webapi.HealthClinic.tarde.ViewModel;

namespace webapi.HealthClinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }



        /// <summary>
        /// EndPoint que acessa o metodo para se logar gerando um token
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha invalidos");
                }
                var claims = new[]
           {
                    //Formato da Claim (tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                   new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!),



                    new Claim("Claim personalizada", "Valor personalizado")
                };


                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health_clinic-chave-autenticacao-webapi-dev"));


                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                var token = new JwtSecurityToken
                    (

                        issuer: "Webapi.health_clinic",


                        audience: "Webapi.health_clinic",


                        claims: claims,


                        expires: DateTime.Now.AddMinutes(5),


                        signingCredentials: creds
                    );


                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
