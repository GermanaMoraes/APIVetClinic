using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IAnimais
    {
        //Read
        ICollection<Animais> GetAll();
        Animais GetbyId(int id);
        //Create
        Animais Insert(Animais animal);

        //Update
        Animais Update(int id, Animais animal);

        //Delete
        bool Delete(int id);
    }
}
