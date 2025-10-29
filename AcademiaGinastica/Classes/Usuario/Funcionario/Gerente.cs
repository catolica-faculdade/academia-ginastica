public class Gerente : Funcionario
{
    public Gerente(){}
    public Gerente(
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

    public void GerarListaModalidade()
    {

    }
    public void AgendarAula()
    {
        
    }
}