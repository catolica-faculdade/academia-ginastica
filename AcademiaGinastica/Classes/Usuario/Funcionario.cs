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
        Cargo cargo
    ) : base(nomeCompleto, cpf, email, senha, telefone, enderecoCompleto)
    {
        this.salario = salario;
        this.cargo = cargo;
    }

}

