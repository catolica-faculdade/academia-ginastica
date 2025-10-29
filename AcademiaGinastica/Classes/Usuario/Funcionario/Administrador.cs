public class Administrador : Funcionario
{
    public Administrador() { }
    public Administrador(
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        decimal cargo,
        decimal salario) : base(nomeCompleto, cpf, email, senha, telefone, enderecoCompleto, salario, cargo)
    {
    }

    public void GerarRelatorio()
    {

    }

    public void GerarRelatorioPorCliente()
    {

    }
}