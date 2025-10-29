public class Cliente : Usuario
{
    public string? metodoPagamento { get; set; }
    public Modalidade? modalidadeFavorita { get; set; }
    public string? status { get; set; }

    public Cliente() { }
    public Cliente(
           string nomeCompleto,
           string cpf,
           string email,
           string senha,
           string telefone,
           string enderecoCompleto
       )
           : base(nomeCompleto, cpf, email, senha, telefone, enderecoCompleto)
    {
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
