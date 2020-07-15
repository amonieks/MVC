using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMPLAYERS.Models;
using Microsoft.AspNetCore.Http;

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
            novaEquipe.Imagem =form["Imagem"];

            equipeModel1.Create(novaEquipe);

            ViewBag.Equipes = equipeModel1.ReadAll();



            return LocalRedirect("~/Equipe");
        }

        
    }
}