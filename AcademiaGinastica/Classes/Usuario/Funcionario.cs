public class Funcionario : Usuario
{
    public decimal salario;
    public Cargo cargo;


    public Funcionario() { }
    public Funcionario(
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        decimal salario,
        decimal cargo
    ) : base(nomeCompleto, cpf, email, senha, telefone, enderecoCompleto)
    {

    }

}

