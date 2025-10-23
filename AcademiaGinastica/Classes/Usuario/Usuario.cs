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
        bool entrou = false;
        while (!entrou){
            tela.PrepararTela("LOGIN");
            this.nome = tela.Perguntar(17, 15, "Nome de usuario: ");
            this.senha = tela.Perguntar(17, 17, "Senha do usuario: ");

            //provisório
            if(nome == "admin" && senha == "admin"){
                entrou = true;
            } else {
                tela.Perguntar(17, 15, "Dados incorretos, deseja tentar novamente? [1] - Sim [1] - Nao: ");
                if(novamente == 2){
                    return;
                }
            }
        }
        tela.Home();
    }

    public void Cadastrar(){
        bool dadosCorretos = false;
        while(dadosCorretos){
            tela.PrepararTela("CADASTRAR");
            tela.Perguntar(17, 15, "Nome de usuario: ");
            this.nome = Console.ReadLine();
            tela.Perguntar(17, 17, "Senha do usuario: ");
            this.senha = Console.ReadLine();

            if(this.nome != "" || this.senha != ""){
                dadosCorretos = true;
            } else{
                tela.MostrarMensagem(10, 10, "Dados invalidos, tente novamente");
            }
        }
        tela.Home();
    }
}