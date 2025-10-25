using System.ComponentModel;
using System.Security.Cryptography;

public class Tela
{
    //
    // propriedades
    //
    private int largura;
    private int altura;
    private int colunaInicial;
    private int linhaInicial;

    //
    // métodos
    //
    public Tela(int largura, int altura)
    {
        this.largura = largura;
        this.altura = altura;
        this.colunaInicial = 0;
        this.linhaInicial = 0;
    }
    public Tela(int largura, int altura, int coluna, int linha)
    {
        this.largura = largura;
        this.altura = altura;
        this.colunaInicial = coluna;
        this.linhaInicial = linha;
    }

    public void PrepararTela(string titulo = "")
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        this.MontarMoldura(
            this.colunaInicial,
            this.linhaInicial,
            this.colunaInicial + this.largura,
            this.linhaInicial + this.altura);

        this.Centralizar(this.colunaInicial,
        this.colunaInicial + this.largura,
        this.linhaInicial + 1, titulo);
    }


    public string MostrarMenu(List<string> ops, int ci, int li)
    {
        int cf, lf, linha;
        cf = ci + ops[0].Length + 1;
        lf = li + ops.Count + 2;
        this.MontarMoldura(ci, li, cf, lf);
        linha = li + 1;
        for (int i = 0; i < ops.Count; i++)
        {
            Console.SetCursorPosition(ci + 1, linha);
            Console.Write(ops[i]);
            linha++;
        }
        Console.SetCursorPosition(ci + 1, linha);
        Console.Write("Opção : ");
        string op = Console.ReadLine();
        return op;
    }


    public void Centralizar(int ci, int cf, int lin, string msg)
    {
        int col = (cf - ci - msg.Length) / 2 + ci;
        Console.SetCursorPosition(col, lin);
        Console.Write(msg);
    }

    public void ApagarArea(int ci, int li, int cf, int lf)
    {
        for (int coluna = ci; coluna <= cf; coluna++)
        {
            for (int linha = li; linha <= lf; linha++)
            {
                Console.SetCursorPosition(coluna, linha);
                Console.Write(" ");
            }
        }
    }

    public void MontarMoldura(int ci, int li, int cf, int lf)
    {
        int col, lin;

        this.ApagarArea(ci, li, cf, lf);

        for (col = ci; col < cf; col++)
        {
            Console.SetCursorPosition(col, li);
            Console.Write("═");
            Console.SetCursorPosition(col, lf);
            Console.Write("═");
        }

        for (lin = li; lin < lf; lin++)
        {
            Console.SetCursorPosition(ci, lin);
            Console.Write("║");
            Console.SetCursorPosition(cf, lin);
            Console.Write("║");
        }

        Console.SetCursorPosition(ci, li);
        Console.Write("╔");

        Console.SetCursorPosition(ci, lf);
        Console.Write("╚");

        Console.SetCursorPosition(cf, li);
        Console.Write("╗");

        Console.SetCursorPosition(cf, lf);
        Console.Write("╝");
    }

    public void MontarTela(List<string> dados, int col, int lin)
    {
        for (int i = 0; i < dados.Count; i++)
        {
            Console.SetCursorPosition(col, lin);
            Console.Write(dados[i]);
            lin++;
        }
    }
    public void MostrarMensagem(int col, int lin, string msg)
    {
        Console.SetCursorPosition(col, lin);
        Console.Write(msg);
    }
    static public string Perguntar(int col, int lin, string pergunta)
    {
        string resp = "";
        Console.SetCursorPosition(col, lin);
        Console.Write(pergunta);
        resp = Console.ReadLine();
        return resp;
    }

    public string PerguntarSenha(int col, int lin, string texto){
        Console.SetCursorPosition(col, lin);
        Console.Write(texto);
        string senha = "";

        ConsoleKeyInfo tecla;

        do
        {
            tecla = Console.ReadKey(true);
            if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
            {
                senha += tecla.KeyChar;
                Console.Write("*");
            }
            else if (tecla.Key == ConsoleKey.Backspace && senha.Length > 0)
            {
                senha = senha.Substring(0, senha.Length - 1);
                Console.Write("\b \b");
            }
        } while (tecla.Key != ConsoleKey.Enter);
        return senha;
    }

    public void Login(){
        bool entrou = false;
        while (!entrou){
            this.PrepararTela("LOGIN");
            var nome = Perguntar(17, 15, "Nome de usuario: ");
            var senha = Perguntar(17, 17, "Senha do usuario: ");

            //provisório
            if (nome != "" && senha != "")
            {
                Usuario usuario = Usuario.Logar(nome, senha);
            }
            else
            {
                this.MostrarMensagem(17, 19, "Dados incorretos, deseja tentar novamente?");
                this.MostrarMensagem(17, 20, "[1] - Sim");
                this.MostrarMensagem(17, 21, "[2] - Nao");
                var novamente = Perguntar(17, 22, "");
                if (novamente == "2")
                {
                    return;
                }
            }
        }
        this.Home(10, 10);
    }

    public void Cadastrar(){
        bool dadosCorretos = false;
        var nome = "";
        var senha = "";

        while(!dadosCorretos){
            this.PrepararTela("CADASTRAR");
            nome = Perguntar(17, 15, "Nome de usuario: ");
            senha = this.PerguntarSenha(17, 17, "Senha do usuario: ");

            if(nome != "" && senha != ""){
                dadosCorretos = true;
            } else{
                this.MostrarMensagem(17, 19, "Dados incorretos, deseja tentar novamente?");
                this.MostrarMensagem(17, 20, "[1] - Sim");
                this.MostrarMensagem(17, 21, "[2] - Nao");
                var novamente = Perguntar(17, 22, "");
                if(novamente == "2"){
                    return;
                }
            }
        }

        this.Home(10, 10);
    }

    public void Home(int col, int lin)
    {
    }

}