using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado");
                }

                //Caso encontre o usuario buscado, prossegue para criacao do token

                //1 - definir as informacoes(Claims) que serao fornecidos do token (PayLoad)
                var claims = new[]
                {
                    //Formato da Claim (tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                   new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    

                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim personalizada", "Valor personalizado")
                };

                //2 - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-webapi-dev"));

                //3 - Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - Gerar o token 
                var token = new JwtSecurityToken
                    (
                        //Emissor do token
                        issuer: "Webapi.jogo",

                        //Destinatario
                        audience: "Webapi.jogo",

                        //Dados definidos nas claims (PayLoad)
                        claims: claims,

                        //Tempo de expiracao
                        expires: DateTime.Now.AddMinutes(5),

                        //Credenciais
                        signingCredentials: creds
                    );

                //5 - Retornar o token criado
                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });

                // return Ok(usuarioBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}

