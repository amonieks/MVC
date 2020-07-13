using System.Collections.Generic;
using EMPLAYERS.Models;

namespace EMPLAYERS.INTEFAC
{
    public interface IEquipe
    {
         void Create(Equipe e);
         
         List<Equipe> ReadAll();

         void UpDate(Equipe e);

         void Delete(int id);
    }
}