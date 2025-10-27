public class Auditoria : Funcionario
{
    public Auditoria(
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        decimal salario) : base(nomeCompleto, cpf, email, senha, telefone, enderecoCompleto, salario) 
    {

    }

    public void VerificarPagamentos()
    {

    }
    
    public void VerificarPagamentoPorCliente()
    {
        
    }
}