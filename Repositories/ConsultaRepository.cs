using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{
    public class ConsultaRepository : Consultas
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";

        //Deletar uma Consulta
        public bool Delete(int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Consulta WHERE IdConsulta= @IdConsulta";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdConsulta", SqlDbType.Int).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;
        }

        //Listar todos as Consultas
        public ICollection<Consultas> GetAll()
        {
            var consulta = new List<Consultas>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Consulta";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consulta.Add(new Consultas
                            {
                                IdConsulta = (int)reader[0],
                                Horario = (DateTime)reader[1],
                                IdAnimal = (int)reader[2],
                                IdVeterinario = (int)reader[3]

                            });
                        }
                    }

                }

            }
            return consulta;

        }

        //Listar Consulta por Id
        public Consultas GetbyId(int id)
        {
            var consulta = new Consultas();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Consulta WHERE IdConsulta = @IdConsulta";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdConsulta", SqlDbType.Int).Value = id;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consulta.IdConsulta = (int)reader[0];
                            consulta.Horario = (DateTime)reader[1];
                            consulta.IdAnimal = (int)reader[2];
                            consulta.IdVeterinario = (int)reader[3];
                        }
                    }

                }

            }
            return consulta;

        }

        //Inserir Consultas no Banco de Dados
        public Consultas Inserir(Consultas consultas)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Consulta (Horario, IdAnimal, IdVeterinario) " +
                    "VALUES (@Horario, @IdAnimal, @IdVeterinario)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdConsulta", SqlDbType.Int).Value = consultas.IdConsulta;
                    cmd.Parameters.Add("@Horario", System.Data.SqlDbType.DateTime).Value = consultas.Horario;
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = consultas.IdAnimal;
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = consultas.IdVeterinario;


                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return consultas;
        }

        //Alterar alguma consulta
        public Consultas Update(int id, Consultas consulta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Consulta SET Horario= @Horario,IdAnimal= @IdAnimal, IdVeterinario= @IdVeterinario" +
                    " WHERE IdConsulta= @IdConsulta";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdConsulta", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = consulta.IdAnimal;
                    cmd.Parameters.Add("@Horario", System.Data.SqlDbType.DateTime).Value = consulta.Horario;
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = consulta.IdAnimal;
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = consulta.IdVeterinario;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    consulta.IdConsulta = id;
                }
            }
            return consulta;
        }
    }
}
