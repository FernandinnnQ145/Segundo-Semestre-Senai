using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(JogoDomain NovoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                
                string queryInsert = "INSERT INTO Jogo(IdEstudio, Nome, Valor, Descricao, DataLancamento) VALUES(@IdEstudio, @Nome, @Valor, @Descricao, @DataLancamento)";


                
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", NovoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", NovoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Valor", NovoJogo.Valor);
                    cmd.Parameters.AddWithValue("@Descricao", NovoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", NovoJogo.DataLancamento);


                    con.Open();

                    
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";

               
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                
                string querySelectAll = " SELECT IdJogo, Jogo.Nome, Jogo.Valor, Jogo.Descricao, Jogo.DataLancamento, Estudio.IdEstudio, Estudio.Nome " +
                    " FROM Jogo " +
                    " LEFT JOIN Estudio " +
                    " ON Estudio.IdEstudio = Jogo.IdEstudio ";


                
                con.Open();

                
                SqlDataReader rdr;


                
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    
                    rdr = cmd.ExecuteReader();

                    
                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            Nome = Convert.ToString(rdr["Nome"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Valor = Convert.ToInt32(rdr["Valor"]),
                            Descricao = Convert.ToString(rdr["Descricao"]),
                            DataLancamento = Convert.ToString(rdr["DataLancamento"]),


                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = Convert.ToString(rdr["Nome"]),
                            }
                            

                        };
                        
                        listaJogos.Add(jogo);

                    }
                }
            }
            
            return listaJogos;
        }
    }
    
}
