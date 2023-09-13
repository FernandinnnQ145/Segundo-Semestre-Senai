using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> listaTipoUsuario= new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "SELECT TiposUsuario.IdTipoUsuario, TiposUsuario.Titulo FROM TiposUsuario";



                con.Open();


                SqlDataReader rdr;



                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        TipoUsuarioDomain TipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = Convert.ToString(rdr["Titulo"]),

                        };

                        listaTipoUsuario.Add(TipoUsuario);

                    }
                }
            }

            return listaTipoUsuario;
        }
    }
   }

