public class Auditoria : Funcionario
{
    public Auditoria(){}
    public Auditoria(
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

    public void VerificarPagamentos()
    {

    }
    
    public void VerificarPagamentoPorCliente()
    {
        
    }
}