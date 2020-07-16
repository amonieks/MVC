using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMPLAYERS.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EMPLAYERS.Models
{
    public class EquipeController:Controller
    {
       
       Equipe equipeModel1 = new Equipe();

        public IActionResult Index()
        {
            ViewBag.Equipe = equipeModel1.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {

            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe =Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome =form["Nome"];
            
            // Upload Início
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/Equipe");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/",folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaEquipe.Imagem   = file.FileName;
            }
            else
            {
                novaEquipe.Imagem   = "padrao.png";
            }
            // Upload Final

            equipeModel1.Create(novaEquipe);

            ViewBag.Equipes = equipeModel1.ReadAll();



            return LocalRedirect("~/Equipe");
        }

        [Route("Equipe/id")]
        public IActionResult Excluir(int id)
        {
           
            equipeModel1.Delete(id);
            ViewBag.Equipe=equipeModel1.ReadAll();
            return LocalRedirect("~/Equipe");
        }

        
    }
}