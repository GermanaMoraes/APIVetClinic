using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IPrescricao
    {
        //Read
        ICollection<Prescricoes> GetAll();
        Prescricoes GetbyId(int id);
        //Create
        Prescricoes Inserir(Prescricoes prescricao);


        //UpdateConsultas
        Prescricoes Update(int id,Prescricoes prescricao);

        //Delete
        bool Delete(int id);
    }
}
