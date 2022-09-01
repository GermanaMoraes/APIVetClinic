using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{
    public class ProprietarioRepository : IProprietarios
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";

        // Deletar um proprietário
        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Proprietario WHERE IdProprietario= @IdProprietario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdProprietario", SqlDbType.Int).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;
        }

        //Listar todos os proprietários
        public ICollection<Proprietarios> GetAll()
        {
            var proprietario = new List<Proprietarios>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM [Proprietario]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proprietario.Add(new Proprietarios
                            {
                                IdProprietario = (int)reader[0],
                                Telefone = (string)reader[1],
                                Nome = (string)reader[2],
                                Endereco = (string)reader[3],
                                RG = (string)reader[4],
                                CPF = (string)reader[5]

                            });
                        }
                    }

                }

            }
            return proprietario;
        }

        //Listar um proprietário específico pelo id
        public Proprietarios GetbyId(int id)
        {
            var proprietario = new Proprietarios();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Proprietario WHERE IdProprietario = @IdProprietario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdProprietario", SqlDbType.Int).Value = id;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proprietario.IdProprietario=(int)reader[0];
                            proprietario.Telefone = (string)reader[1];
                            proprietario.Nome = (string)reader[2];
                            proprietario.Endereco = (string)reader[3];
                            proprietario.RG = (string)reader[4];
                            proprietario.CPF = (string)reader[5];

                        }
                    }

                }

            }
            return proprietario;

        }

        //Inserir um propritário no banco de dados
        public Proprietarios Insert(Proprietarios proprietario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Proprietario ( Telefone, Nome, Endereco, RG, CPF) " +
                    "VALUES ( @Telefone, @Nome, @Endereco, @RG, @CPF)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdProprietario", System.Data.SqlDbType.Int).Value = proprietario.IdProprietario;
                    cmd.Parameters.Add("@Telefone", System.Data.SqlDbType.VarChar).Value = proprietario.Telefone;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar).Value = proprietario.Nome;
                    cmd.Parameters.Add("@Endereco", System.Data.SqlDbType.NVarChar).Value = proprietario.Endereco;
                    cmd.Parameters.Add("@RG", System.Data.SqlDbType.VarChar).Value = proprietario.RG;
                    cmd.Parameters.Add("@CPF", System.Data.SqlDbType.VarChar).Value = proprietario.CPF;



                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return proprietario;
        }

        //Alterar algum proprietário atravéz do id
        public Proprietarios Update(int id, Proprietarios proprietario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Proprietario SET Telefone= @Telefone,Nome= @Nome, Endereco= @Endereco," +
                    " RG= @RG, CPF= @CPF WHERE IdProprietario= @IdProprietario";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdProprietario", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Telefone", System.Data.SqlDbType.VarChar).Value = proprietario.Telefone;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar).Value = proprietario.Nome;
                    cmd.Parameters.Add("@Endereco", System.Data.SqlDbType.NVarChar).Value = proprietario.Endereco;
                    cmd.Parameters.Add("@RG", System.Data.SqlDbType.VarChar).Value = proprietario.RG;
                    cmd.Parameters.Add("@CPF", System.Data.SqlDbType.VarChar).Value = proprietario.CPF;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    proprietario.IdProprietario = id;
                }
            }
            return proprietario;
        }
    }
    
}
