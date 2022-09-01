using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IProprietarios
    {
        //Read
        ICollection<Proprietarios> GetAll();
        Proprietarios GetbyId(int id);
        //Create
        Proprietarios Insert(Proprietarios proprietario);

        //Update
        Proprietarios Update(int id, Proprietarios proprietario);

        //Delete
        bool Delete(int id);
    }
}

