public class Cliente : Usuario
{
    private string? metodoPagamento;
    private Modalidade? modalidadeFavorita;
    private string? status;
    private string enderecoCompleto;
    public Cliente(
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto
    )
        : base(nomeCompleto, cpf, email, senha, telefone)
    {
        this.enderecoCompleto = enderecoCompleto;
    }

    public void RegistrarPresenca()
    {

    }

    public void AgendarAula(Aula aulaDesejada)
    {

    }

    public void DesmarcarAula(Aula aula)
    {

    }
}
