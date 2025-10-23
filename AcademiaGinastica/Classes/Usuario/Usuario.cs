public class Usuario
{
    private int id;
    private string nome;
    private string senha;
    private Tela tela;

    public Usuario()
    {
        this.tela = new Tela(46, 9, 15, 12); 
    }

    public void Login(){
        tela.PrepararTela("LOGIN");
        tela.Perguntar(17, 15, "Nome de usuario: ");
        this.nome = Console.ReadLine();
        tela.Perguntar(17, 17, "Senha do usuario: ");
        this.senha = Console.ReadLine();

        //this.tela.Home();
    }

    public void Cadastrar(){
        tela.PrepararTela("CADASTRAR");
        tela.Perguntar(17, 15, "Nome de usuario: ");
        this.nome = Console.ReadLine();
        tela.Perguntar(17, 17, "Senha do usuario: ");
        this.senha = Console.ReadLine();
    }
}