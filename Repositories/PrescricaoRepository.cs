using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{
    public class PrescricaoRepository : IPrescricao
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";

        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Prescricao WHERE IdPrescricao= @IdPrescricao";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdPrescricao", SqlDbType.Int).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;

        }

        public ICollection<Prescricoes> GetAll()
        {
            var prescricao = new List<Prescricoes>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM [Prescricao]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prescricao.Add(new Prescricoes
                            {
                                IdPrescricao = (int)reader[0],
                                Descricao = (string)reader[1],
                                IdAnimal=(int)reader[2],
                                IdMedicamento=(int)reader[3],
                                IdVeterinario=(int)reader[4]
                             });
                        }
                    }

                }

            }
            return prescricao;
        }

        public Prescricoes GetbyId(int id)
        {
            var prescricao = new Prescricoes();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Prescricao WHERE IdPrescricao = @IdPrescricao";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdPrescricao", SqlDbType.Int).Value = id;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prescricao.IdPrescricao = (int)reader[0];
                            prescricao.Descricao = (string)reader[1];
                            prescricao.IdAnimal = (int)reader[2];
                            prescricao.IdMedicamento = (int)reader[3];
                            prescricao.IdVeterinario = (int)reader[4];


                        }
                    }

                }

            }
            return prescricao;

        }

        public Prescricoes Inserir(Prescricoes prescricao)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Prescricao (Descricao, IdAnimal, IdMedicamento, IdVeterinario) " +
                    "VALUES (@Descricao, @IdAnimal,@IdMedicamento, @IdVeterinario)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdPrescricao", SqlDbType.Int).Value = prescricao.IdPrescricao;
                    cmd.Parameters.Add("@Descricao", System.Data.SqlDbType.VarChar).Value = prescricao.Descricao;
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = prescricao.IdAnimal;
                    cmd.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = prescricao.IdMedicamento;
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = prescricao.IdVeterinario;
                   
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return prescricao;

        }

        public Prescricoes Update(int id, Prescricoes prescricao)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Prescricao SET Descricao= @Descricao,IdAnimal= @IdAnimal," +
                    " IdMedicamento= @IdMedicamento," +
                    " WHERE IdPrescricao= @IdPrescricao";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    //Talvez de erro nessa linha 137
                    cmd.Parameters.Add("@IdPrescricao", SqlDbType.Int).Value = prescricao.IdPrescricao;
                    cmd.Parameters.Add("@Descricao", System.Data.SqlDbType.VarChar).Value = prescricao.Descricao;
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = prescricao.IdAnimal;
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = prescricao.IdVeterinario;


                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    prescricao.IdPrescricao = id;
                }
            }
            return prescricao;
        }
    }
}
