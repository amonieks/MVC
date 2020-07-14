namespace EMPLAYERS.Models
{
    public class EquipeController:Controller
    {
       
       Equipe equipeModel1 = new Equipe

        public IActionResult Index()
        {
            Viewbag.Equipe = equipeModel1.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IformCollection form)
        {

            Equipe novaEquipe = new equipe();
            novaEquipe.IdEquipe =int32.Parse(form("IdEquipe"));
            novaEquipe.Nome =form("Nome"));
            novaEquipe.Image =form("Imagem"));

            equipeModel1.Create(novaEquipe);

            Viewbag.Equipes = equipeModel1.ReadALL();



            return LocalRe();
        }

        
    }
}