using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";

        public void Cadastrar(EstudioDomain NovoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada nesse caso de insercao
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES(@Nome)";


                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", NovoEstudio.Nome);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                //Declara a query que sera executada nesse caso de insercao
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "SELECT Estudio.IdEstudio, Estudio.Nome, Jogo.Nome FROM Estudio LEFT JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio";


               
                con.Open();

                
                SqlDataReader rdr;


                
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    
                    rdr = cmd.ExecuteReader();

                   
                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = Convert.ToString(rdr["Nome"]),
                            
                        };
                        
                        listaEstudio.Add(estudio);

                    }
                }
            }
            
            return listaEstudio;
        }
    }
    
}
