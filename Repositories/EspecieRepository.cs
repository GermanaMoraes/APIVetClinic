using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{
    public class EspecieRepository : IEspecies
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";
        
        //Deletar uma espécie
        public bool Delete(int IdEspecie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Especie WHERE IdEspecie= @IdEspecie";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdEspecie", SqlDbType.Int).Value = IdEspecie;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;
        }

        //Lista todas as Especies- OK
        public ICollection<Especies> GetAll()
        {
            var especie = new List<Especies>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM [Especie]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            especie.Add(new Especies
                            {
                                IdEspecie = (int)reader[0],
                                Nome = (string)reader[1],
                                                              
                            });
                        }
                    }

                }

            }
            return especie;
        }

        //Listar uma espécie específica por meio do Id
        public Especies GetbyId(int IdEspecie)
        {
            var especie = new Especies();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Especie WHERE IdEspecie = @IdEspecie";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdEspecie", SqlDbType.Int).Value = IdEspecie;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            especie.IdEspecie = (int)reader[0];
                            especie.Nome = (string)reader[1];
                            
                        }
                    }

                }

            }
            return especie;
        }

        //Adicionar o nome da Espécie 
        public Especies Insert(Especies especie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Especie ( Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = especie.Nome;
                    

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return especie;
        }
        //Alterar alguma espécie por meio do Id
        public Especies Update(int IdEspecie, Especies especie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Especie SET Nome= @Nome WHERE IdEspecie= @IdEspecie";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdEspecie", SqlDbType.Int).Value = IdEspecie;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = especie.Nome;
                  
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    especie.IdEspecie = IdEspecie;
                }
            }
            return especie;
        }
    }
}
