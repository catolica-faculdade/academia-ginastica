public class Administrador : Funcionario
{
    public Administrador(
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        decimal salario) : base(nomeCompleto, cpf, email, senha, telefone, enderecoCompleto, salario)
    {
    }

    public void GerarRelatorio()
    {

    }

    public void GerarRelatorioPorCliente()
    {

    }
}