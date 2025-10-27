public class Usuario
{
    private string nomeCompleto;
    private string CPF;
    private string email;
    private string senha;
    private string telefone;
    private Cargo cargo;
    private Tela tela;

    public Usuario(string nomeCompleto, string CPF, string email, string senha, string telefone)
    {
        this.nomeCompleto = nomeCompleto;
        this.senha = senha;
        this.tela = new Tela(46, 12, 15, 12);
    }
    public Usuario()
    {
        this.nomeCompleto = "";
        this.senha = "";
    }

    static public Usuario Logar(string nome, string senha)
    {
        Usuario usuario = new Usuario("","","","","");
        return usuario;
    }

}