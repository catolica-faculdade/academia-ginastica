public class Instrutor : Funcionario
{

    public Instrutor()
    {

    }
    
    public void ConsultarAgenda()
    {
        var dataLimite = DateTime.Parse(Tela.Perguntar(17, 22, ""));
        bool mostrarClientes = bool.Parse(Tela.Perguntar(17, 22, ""));

        //Agenda.MostrarAgenda(dataLimite, mostrarClientes)
    }
}