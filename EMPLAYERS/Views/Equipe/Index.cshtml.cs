namespace EMPLAYERS.Views.Equipe
{
    public class Index.cshtml
    {
        ViewData["Title"]="Equipe";
        
    }

    <div>Teste</div>

    <form action="@url.action("Cadastrar")" method="post">

    <Labe for="IdEquipe"> IdEquipe</Labe>

    <Input type="Text" name="IdEquipe" id="IdEqupe">

    <button type="submit">Cadastar</button>
}