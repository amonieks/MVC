using System.Collections.Generic;
using EMPLAYERS.Models;

namespace EMPLAYERS.INTERFAC
{
    public interface INoticias
    {
         void Create(Noticias e);
         
         List<Noticias> ReadAll();

         void UpDate(Noticias e);

         void Delete(int idNoticia);
    }
}