using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IExames
    {
        //Read
        ICollection<Exames> GetAll();
        Exames GetbyId(int id);
        //Create
        Exames Inserir(Exames exame);


        //UpdateConsultas
        Exames Update(int id, Exames exame);

        //Delete
        bool Delete(int id);
    }
}

