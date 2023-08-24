using System.Data.SqlClient;
using webapi.filme.Domains;
using webapi.filme.Interfaces;

namespace webapi.filme.Repositories
{
    
    
        // Herança:
        public class GeneroRepository : IGeneroRepository
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

            public void AtualizarIdCorpo(GeneroDomain genero)
            {
                throw new NotImplementedException();
            }

            public void AtualizarIdUrl(int id, GeneroDomain genero)
            {
                throw new NotImplementedException();
            }

            public GeneroDomain BuscarPorId(int id)
            {
                throw new NotImplementedException();
            }


        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="NovoGenero">Objeto com as informacoes que serao cadastrada</param>
            public void Cadastrar(GeneroDomain NovoGenero)
            {
            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada nesse caso de insercao
                string queryInsert = "INSERT INTO Genero(Nome) VALUES(' " + NovoGenero.Nome + " ')";

                
                //Declara o SqlCommand passando a query que sera executada e a conexao com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Abre a conexao com o banco de dados
                    con.Open();
                    
                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }  

            }

            public void Deletar(int id)
            {
                throw new NotImplementedException();
            }


            /// <summary>
            /// Listar todos os objetos do tipo genero
            /// </summary>
            /// <returns>Lista de objetos do tipo genero</returns>
            public List<GeneroDomain> ListarTodos()
            {
                List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

                //Declara a SqlConnection passando a string de conexao como parametro
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    //Declara a instrucao a ser executada
                    string querySelectAll = "SELECT IdGenero, Nome FROM Genero";


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
                            GeneroDomain genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[0]),
                                Nome = Convert.ToString(rdr["Nome"])
                            };
                            //Adiciona objeto criado dentro da lista
                            listaGeneros.Add(genero);

                        }
                    }
                }
                //Retorna a lista de generos
                return listaGeneros;
            }
        }
    }

