public class Funcionario : Usuario
{
    private Cargo cargo;
    private decimal salario;
    public Funcionario(
        int id,
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        Cargo cargo,
        decimal salario
    ) : base(nomeCompleto, cpf, email, senha, telefone)
    {
        
    }

}

