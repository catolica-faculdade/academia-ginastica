public class Usuario
{
    private int id;
    private string nomeCompleto;
    private string CPF;
    private string email;
    private string senha;
    private string telefone;
    private Tela tela;

    public Usuario(string nome, string senha, string tipoUsuario)
    {
        this.nome = nome;
        this.senha = senha;
        this.tipoUsuario = tipoUsuario;
        this.tela = new Tela(46, 12, 15, 12); 
    }

    static public Usuario Logar(string nome, string senha)
    {
        Usuario usuario = new Usuario(nome, senha, "cliente");
        return usuario;
    }

}