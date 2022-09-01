using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{

    public class VeterinarioRepository : IVeterinarios
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";

        //Deletar 
        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Veterinario WHERE IdVeterinario= @IdVeterinario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;

        }

        //Listar todos
        public ICollection<Veterinarios> GetAll()
        {
            var veterinario = new List<Veterinarios>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM [Veterinario]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            veterinario.Add(new Veterinarios
                            {
                                IdVeterinario = (int)reader[0],
                                Nome = (string)reader[1],
                                CPF = (string)reader[2],
                                Telefone = (string)reader[3]
                            });
                        }
                    }

                }

            }
            return veterinario;

        }

        //Lista um por meio de um Id
        public Veterinarios GetbyId(int id)
        {
            var veterinario = new Veterinarios();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Veterinario WHERE IdVeterinario = @IdVeterinario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = id;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            veterinario.IdVeterinario = (int)reader[0];
                            veterinario.Nome = (string)reader[1];
                            veterinario.CPF = (string)reader[2];
                            veterinario.Telefone = (string)reader[3];
                        }
                    }

                }

            }
            return veterinario;

        }

        //Inserir
        public Veterinarios Inserir(Veterinarios veterinario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Veterinario (Nome, CPF, Telefone) " +
                    "VALUES (@Nome, @CPF, @Telefone)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = veterinario.IdVeterinario;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = veterinario.Nome;
                    cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = veterinario.CPF;
                    cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = veterinario.Telefone;
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return veterinario;

        }

        //Alterar por meio de um Id
        public Veterinarios Update(int id, Veterinarios veterinario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Veterinario SET Nome= @Nome,CPF= @CPF, Telefone= @Telefone" +
                    " WHERE IdVeterinario= @IdVeterinario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdVeterinario", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = veterinario.Nome;
                    cmd.Parameters.Add("@CPF", SqlDbType.NChar).Value = veterinario.CPF;
                    cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = veterinario.Telefone;
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    veterinario.IdVeterinario = id;
                }
            }
            return veterinario;
        }
    }
}
