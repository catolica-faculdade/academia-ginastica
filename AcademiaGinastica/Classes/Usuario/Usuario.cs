using System.Reflection.Metadata;
public class Usuario
{
    public string nomeCompleto;
    public string CPF;
    public string email;
    public string senha;
    public string telefone;
    public string enderecoCompleto;
    public Tela tela;

    public Usuario(string nomeCompleto, string cpf, string email, string senha, string telefone, string enderecoCompleto)
    {
        this.nomeCompleto = nomeCompleto;
        this.CPF = cpf;
        this.email = email;
        this.senha = senha;
        this.telefone = telefone;
        this.enderecoCompleto = enderecoCompleto;
        this.tela = new Tela(46, 12, 15, 12);
    }

    public Usuario()
    {
    }


}