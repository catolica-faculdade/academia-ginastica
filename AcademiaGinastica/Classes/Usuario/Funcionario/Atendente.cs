public class Atendente : Funcionario
{
    public Atendente() { }
    public Atendente(
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
    public void RegistrarMatricula()
    {

    }
    public void DeletarMatricula()
    {

    }
    public void VerMatriculas()
    {
        
    }
    public void VerMatriculasPorId()
    {
        
    }
}