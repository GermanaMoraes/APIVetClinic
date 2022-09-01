using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{
    public class MedicamentoRepository : IMedicamentos
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";

        //Deletar 
        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Medicamento WHERE IdMedicamento= @IdMedicamento";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;

        }

        //Listar Todos
        public ICollection<Medicamentos> GetAll()
        {
            var medicamento = new List<Medicamentos>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM [Medicamento]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicamento.Add(new Medicamentos
                            {
                             Id=(int)reader[0],
                             Nome=(string)reader[1],
                            });
                        }
                    }

                }

            }
            return medicamento;
        }

        //Listar por Id
        public Medicamentos GetbyId(int id)
        {
            var medicamento = new Medicamentos();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Medicamento WHERE IdMedicamento = @IdMedicamento";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = id;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicamento.Id = (int)reader[0];
                            medicamento.Nome = (string)reader[1];
                        }
                    }

                }

            }
            return medicamento;

        }

        //Inserir
        public Medicamentos Inserir(Medicamentos medicamento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Medicamento (Nome) " +
                    "VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = medicamento.Id;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = medicamento.Nome;
                    

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return medicamento;
        }

        //Alterar por Id
        public Medicamentos Update(int id, Medicamentos medicamento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Medicamento SET Nome= @Nome" +                   
                    " WHERE IdMedicamento= @IdMedicamento";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = medicamento.Id;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = medicamento.Nome;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    medicamento.Id = id;
                }
            }
            return medicamento;
        }
    }
}
