public class Usuario
{
    private int id;
    private string nome;
    private string senha;
    private Tela tela;

    public Usuario()
    {
        this.tela = new Tela(46, 12, 15, 12); 
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
                tela.MostrarMensagem(17, 19, "Dados incorretos, deseja tentar novamente?");
                var novamente = tela.Perguntar(17, 20, "[1] - Sim \n [2] - Nao: ");
                if(novamente == "2"){
                    return;
                }
            }
        }
        tela.Home(10, 10);
    }

    public void Cadastrar(){
        bool dadosCorretos = false;
        while(!dadosCorretos){
            tela.PrepararTela("CADASTRAR");
            this.nome = tela.Perguntar(17, 15, "Nome de usuario: ");
            this.senha = tela.PerguntarSenha(17, 17, "Senha do usuario: ");

            if(this.nome != "" && this.senha != ""){
                dadosCorretos = true;
            } else{
                tela.MostrarMensagem(17, 19, "Dados incorretos, deseja tentar novamente?");
                tela.MostrarMensagem(17, 20, "[1] - Sim");
                tela.MostrarMensagem(17, 21, "[2] - Nao");
                var novamente = tela.Perguntar(17, 22, "");
                if(novamente == "2"){
                    return;
                }
            }
        }

        tela.Home(10, 10);
    }

}