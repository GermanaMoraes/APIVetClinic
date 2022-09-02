using APIVetClinic.Interfaces;
using APIVetClinic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIVetClinic.Repositories
{
    public class AnimalRepository : Animais
    {
        readonly string connectionString = "data source = (localdb)\\MSSQLLocalDB;Integrated Security = true; Initial Catalog= VetClinic ";

        //Deletar algum Animal
        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Animal WHERE IdAnimal= @IdAnimal";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = id;


                    cmd.CommandType = CommandType.Text;
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    { return false; }
                }
            }
            return true;
        }

        //Listar todos os Animais
        public ICollection<Animais> GetAll()
        {   var animal = new List<Animais>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM [Animal]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animal.Add(new Animais
                            {
                                IdAnimal = (int)reader[0],
                                Nome = (string)reader[1],
                                Raca = (string)reader[2],
                                Peso = (decimal)reader[3],
                                Sexo = (string)reader[4],
                                Idade = (int)reader[5],
                                IdProprietario = (int)reader[6],
                                IdEspecie = (int)reader[7],
                                Imagem = (string)reader[8].ToString()

                            });
                        }
                    }

                }

            }
            return animal;
        }

        //Listar um Animal específico pelo Id
        public Animais GetbyId(int id)
        {
            var animal = new Animais();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM Animal WHERE IdAnimal = @IdAnimal";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = id;
                    // Ler a Lista
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animal.IdEspecie = (int)reader[0];
                            animal.Nome = (string)reader[1];
                            animal.Raca = (string)reader[2];
                            animal.Peso = (int)reader[3];
                            animal.Sexo = (string)reader[4];
                            animal.Idade = (int)reader[5];
                            animal.IdProprietario = (int)reader[6];
                            animal.IdEspecie = (int)reader[7];
                        }
                    }

                }

            }
            return animal;
        }

        //Adciona os Animais no banco de dados
        public Animais Insert(Animais animal)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Animal (Nome, Raca, Peso, Sexo, Idade, IdProprietario, IdEspecie, Imagem) " +
                    "VALUES (@Nome, @Raca, @Peso, @Sexo,@Idade, @IdProprietario, @IdEspecie, @Imagem)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = animal.IdAnimal;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = animal.Nome;
                    cmd.Parameters.Add("@Raca", SqlDbType.NVarChar).Value = animal.Raca;
                    cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = animal.Peso;
                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = animal.Sexo;
                    cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = animal.Idade;
                    cmd.Parameters.Add("@IdProprietario", SqlDbType.Int).Value = animal.IdProprietario;
                    cmd.Parameters.Add("@IdEspecie", SqlDbType.Int).Value = animal.IdEspecie;
                    cmd.Parameters.Add("@Imagem", SqlDbType.NChar).Value = animal.Imagem;


                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return animal;
        }

        //Alterar um animal da Lista
        public Animais Update(int id, Animais animal)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Animal SET Nome= @Nome,Raca= @Raca, Peso= @Peso," +
                    " Sexo= @Sexo, Idade= @Idade, IdProprietario=@IdProprietario, IdEspecie=@IdEspecie" +
                    " WHERE IdAnimal= @IdAnimal";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@IdAnimal", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = animal.Nome;
                    cmd.Parameters.Add("@Raca", SqlDbType.NChar).Value = animal.Raca;
                    cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = animal.Peso;
                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = animal.Sexo;
                    cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = animal.Idade;
                    cmd.Parameters.Add("@IdProprietario", SqlDbType.Int).Value = animal.IdProprietario;
                    cmd.Parameters.Add("@IdEspecie", SqlDbType.Int).Value = animal.IdEspecie;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    animal.IdAnimal = id;
                }
            }
            return animal;

        }
    }
}
