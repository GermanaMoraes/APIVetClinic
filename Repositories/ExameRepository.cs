using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{
    public class ExameRepository : Exames
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";

        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Exame WHERE IdExame= @IdExame";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdExame", SqlDbType.Int).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;

        }

        public ICollection<Exames> GetAll()
        {
            var exame = new List<Exames>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM [Exame]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exame.Add(new Exames
                            {
                                IdExame = (int)reader[0],
                                Nome = (string)reader[1],
                                Valor = (decimal)reader[2],
                                IdAnimal = (int)reader[3],
                                IdVeterinario = (int)reader[4]

                            });
                        }
                    }

                }

            }
            return exame;
        }

        public Exames GetbyId(int id)
        {
            var exame = new Exames();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Exame WHERE IdExame = @IdExame";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdExame", SqlDbType.Int).Value = id;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exame.IdExame = (int)reader[0];
                            exame.Nome = (string)reader[1];
                            exame.Valor = (decimal)reader[2];
                            exame.IdAnimal = (int)reader[3];
                            exame.IdVeterinario = (int)reader[4];
                        }
                    }

                }

            }
            return exame;
        }

        public Exames Inserir(Exames exame)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Exame (Nome, Valor, IdAnimal, IdVeterinario) " +
                    "VALUES (@Nome, @Valor, @IdAnimal, @IdVeterinario)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdExame", SqlDbType.Int).Value = exame.IdExame;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = exame.Nome;
                    cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = exame.Valor;
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = exame.IdAnimal;
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = exame.IdVeterinario;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return exame;

        }

        public Exames Update(int id, Exames exames)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Exame SET Nome= @Nome,Valor= @Valor, IdAnimal= @IdAnimal," +
                    " IdVeterinario= @IdVeterinario WHERE IdExame= @IdExame";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdExame", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = exames.Nome;
                    cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = exames.Valor;
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = exames.IdAnimal;
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = exames.IdVeterinario;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    exames.IdExame = id;
                }
               
            }

            return exames;
        }
    }
}

        
    

