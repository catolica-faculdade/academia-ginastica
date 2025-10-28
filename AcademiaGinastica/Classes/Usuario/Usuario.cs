public class Usuario
{
    private string nomeCompleto;
    private string CPF;
    private string email;
    private string senha;
    private string telefone;
    private Tela? tela;

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
        Usuario usuario = new Usuario("", "", "", "", "");
        return usuario;
    }


    static public string[] Cadastrar(string tipoCargo)
    {

        string nomeCompleto = Tela.Perguntar(2, 2, "Digite o nome completo do usuario");
        string CPF = Tela.Perguntar(2, 2, "Digite o CPF do usuario");
        string email = Tela.Perguntar(2, 2, "Digite o email do usuario");
        string senha = Tela.PerguntarSenha(2, 2, "Digite a senha do usuario");

        string[] usuario = [nomeCompleto, CPF, email, senha];

        return usuario;
    }

}