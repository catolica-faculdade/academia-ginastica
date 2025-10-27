public class Cliente : Usuario
{
    private string? metodoPagamento;
    private Modalidade? modalidadeFavorita;
    private string? status;
    private string enderecoCompleto;
    private Cargo cargo;

    public Cliente(
        int id,
        string nomeCompleto,
        string cpf,
        string email,
        string senha,
        string telefone,
        string enderecoCompleto,
        Cargo cargo
    ) 
        : base(nomeCompleto, cpf, email, senha, telefone) 
    {
        this.enderecoCompleto = enderecoCompleto;
        this.cargo = cargo;
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
