public class Instrutor : Funcionario
{

    public Instrutor(
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        decimal salario) : base(nomeCompleto, cpf, email, senha, telefone, enderecoCompleto, salario) 
    {

    }
    
    public void ConsultarAgenda()
    {
        var dataLimite = DateTime.Parse(Tela.Perguntar(17, 22, ""));
        bool mostrarClientes = bool.Parse(Tela.Perguntar(17, 22, ""));

        //Agenda.MostrarAgenda(dataLimite, mostrarClientes)
    }
}