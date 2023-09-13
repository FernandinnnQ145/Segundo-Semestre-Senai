using System.Data.SqlClient;
using webapi.filme.Domains;
using webapi.filme.Interfaces;

namespace webapi.filme.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados  que recebe os seguintes parametros
        /// Data Source: Nome do servidor
        /// Initial Catalog Nome do banco de dados
        /// Autenticacao
        /// -Windows : Integrated Security = true
        /// -SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = Filmes_tarde; User Id = sa; Pwd = Senai@134";


        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querryLogin = "SELECT IdUsuario, Email, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";
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
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["email"].ToString(),
                            

                            Permissao = rdr["Permissao"].ToString()

                        };
                        return usuario;

                    }
                    return null;
                }
            }
        }
    }
}