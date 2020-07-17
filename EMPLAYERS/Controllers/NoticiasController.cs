using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMPLAYERS.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EMPLAYERS.Controllers
{
    public class NoticiasController:Controller
    {
         Noticias noticiaModel1 = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel1.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {

            Noticias novaNoticia = new Noticias();
            novaNoticia.IdNoticias =Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo =form["Titulo"];
            novaNoticia.Texto =form["Texto"];
            
                // Upload Início
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/",folder,file.FileName);
                      using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload Final

            noticiaModel1.Create(novaNoticia);

            ViewBag.Noticias = noticiaModel1.ReadAll();



            return LocalRedirect("~/Noticias");
        }

         [Route("Noticias/id")]
        public IActionResult Excluir(int Id)
        {
           
            noticiaModel1.Delete(Id);
            ViewBag.Noticias = noticiaModel1.ReadAll();
            return LocalRedirect("~/Noticias");
        }

        
    }
}