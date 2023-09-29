using webapi.HealthClinic.tarde.Contexts;
using webapi.HealthClinic.tarde.Domains;
using webapi.HealthClinic.tarde.Interfaces;
using webapi.HealthClinic.tarde.Utils;

namespace webapi.HealthClinic.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthClinicContext _healthClinicContext;

        public UsuarioRepository()
        {
            _healthClinicContext = new HealthClinicContext();
        }


        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario usuarioBuscado = _healthClinicContext.Usuario
               .Select(u => new Usuario
               {
                   IdUsuario = u.IdUsuario,
                   Nome = u.Nome,
                   Email = u.Email,
                   Senha = u.Senha,
                   TipoUsuario = new TipoUsuario
                   {
                       IdTipoUsuario = u.IdUsuario,
                       Titulo = u.TipoUsuario!.Titulo
                   }
               })
               .FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if (confere)
                {
                    return usuarioBuscado;
                }

            }
            return null!;
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthClinicContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _healthClinicContext.Usuario.Add(usuario);

                _healthClinicContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
