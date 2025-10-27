public class Funcionario : Usuario
{
    private decimal salario;
    public Funcionario(
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        decimal salario
    ) : base(nomeCompleto, cpf, email, senha, telefone)
    {
        
    }

}

