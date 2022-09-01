using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IEspecies
    {
        //Read
        ICollection<Especies> GetAll();
        Especies GetbyId(int id);
        //Create
        Especies Insert(Especies especie);

        //Update
        Especies Update(int id, Especies especie);

        //Delete
        bool Delete(int id);
    }
}

