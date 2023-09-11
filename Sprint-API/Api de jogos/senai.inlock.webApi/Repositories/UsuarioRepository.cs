using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = Filmes_tarde; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querryLogin = "SELECT IdUsuario, IdTipoUsuario, Email, Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = rdr["Email"].ToString()
                           

                        };
                        return usuario;

                    }
                    return null;
                }
            }
        }
    }
}

