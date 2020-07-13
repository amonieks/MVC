using System;
using System.Collections.Generic;
using System.IO;
using EMPLAYERS.INTERFAC;

namespace EMPLAYERS.Models
{
    public class Noticias:EPlayersBase,INoticias
    {
        public int IdNoticias { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string Imagem { get; set; }

        private const string PATH= "Database/noticia.csv";
        

        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }

        private string Prepare(Noticias n){
            return $"{n.IdNoticias};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        public void Create(Noticias e)
        {
            string[] linha = { Prepare(e) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Noticias> ReadAll()
        {
            List<Noticias> noticia = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias news = new Noticias();
                news.IdNoticias = Int32.Parse(linha[0]);
                news.Titulo = linha[1];
                news.Texto=linha[2];
                news.Imagem = linha[3];

                noticia.Add(news);
            }
            return noticia;
        }

        public void UpDate(Noticias e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdNoticias.ToString());
            linhas.Add( Prepare(e) );
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int idNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}