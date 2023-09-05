using System.Data.SqlClient;
using webapi.filme.Domains;
using webapi.filme.Interfaces;

namespace webapi.filme.Repositories
{
    public class FilmeReposiroy : IFilmeRepository
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

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                //Declara a query que sera executada nesse caso de insercao
                string queryUpdate = "UPDATE Filme SET Titulo = @NomeNovo,  IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@NomeNovo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.Genero.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);
                    //Executa a query
                    cmd.ExecuteNonQuery();


                }
            }
        }
        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                //Declara a query que sera executada nesse caso de insercao

                string queryUpdate = "UPDATE Filme SET Titulo = @Titulo IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.Genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                //Declara a query que sera executada nesse caso de insercao
                string querySelect = "SELECT IdFilme, Titulo, Genero.IdGenero, Nome" +
                    "  FROM Filme" +
                    " INNER JOIN Genero ON Genero.IdGenero = Filme.IdGenero" +
                    " WHERE IdFilme = @IdFilme";


                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    //Declara o SqlDataReader para percorrer(ler) no banco de dados
                    SqlDataReader rdr;
                    //Esse comando executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Titulo = Convert.ToString(rdr["Titulo"]),
                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = Convert.ToString(rdr["Nome"]),
                            }

                        };
                        return filme;
                    }
                    else
                    {
                        return null;
                    }

                }



            }
        }

        public void Cadastrar(FilmeDomain NovoFilme)
        {
            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada nesse caso de insercao
                string queryInsert = "INSERT INTO Filme(IdGenero, Titulo) VALUES(@IdGenero, @Titulo)";


                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Titulo", NovoFilme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", NovoFilme.IdGenero);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }

        }

        public void Deletar(int id)
        {
            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                //Declara a query que sera executada nesse caso de insercao
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilme";

                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "SELECT IdFilme, Titulo, Genero.IdGenero, Nome FROM Filme LEFT JOIN Genero ON Genero.IdGenero = Filme.IdGenero ";


                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer(ler) no banco de dados
                SqlDataReader rdr;


                //Declara o SqlCommand passando a query que sera executada e a conexao
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Esse comando executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr 
                    //o laco se repetira
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = Convert.ToString(rdr["Titulo"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = Convert.ToString(rdr["Nome"]),
                            }
                               
                            
                        };
                        //Adiciona objeto criado dentro da lista
                        listaFilmes.Add(filme);

                    }
                }
            }
            //Retorna a lista de filmes
            return listaFilmes;
        }
    }
}
