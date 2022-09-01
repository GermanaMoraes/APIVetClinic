using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IVeterinarios
    {
        //Read
        ICollection<Veterinarios> GetAll();
        Veterinarios GetbyId(int id);
        //Create
        Veterinarios Inserir(Veterinarios veterinario);


        //UpdateVeterinario
        Veterinarios Update(int id, Veterinarios veterinario);

        //Delete
        bool Delete(int id);
    }
}

