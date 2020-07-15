using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMPLAYERS.Models;
using Microsoft.AspNetCore.Http;


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
            novaNoticia.Imagem =form["Imagem"];

            noticiaModel1.Create(novaNoticia);

            ViewBag.Equipes = noticiaModel1.ReadAll();



            return LocalRedirect("~/Noticias");
        }
    }
}