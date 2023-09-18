using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Repositories;
using webapi.inlock_codefirst.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.inlock_codefirst.Controllers
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

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha);

                if(usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha invalidos");
                }

                var claims = new[]
            {
                    //Formato da Claim (tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                   new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    

                    
                    new Claim("Claim personalizada", "Valor personalizado")
                };

                
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-webapi-dev"));

                
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                 
                var token = new JwtSecurityToken
                    (
                        
                        issuer: "Webapi.jogo",

                        
                        audience: "Webapi.jogo",

                        
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
