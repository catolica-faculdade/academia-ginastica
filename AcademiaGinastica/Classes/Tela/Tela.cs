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
    private Usuario usuarioLogado;

    //
    // métodos
    //
    public Tela(){}
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


    public string MostrarMenu(List<string> ops, int ci, int li, string titulo = "═")
    {
        int cf, lf, linha;
        cf = ci + ops[0].Length + 1;
        lf = li + ops.Count + 2;
        this.MontarMoldura(ci, li, cf, lf);
        this.MostrarMensagem(ci + 1, li, titulo);
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
    int largura = cf - ci;
    int col = (largura - msg.Length) / 2 + ci;

    if (col < 0) col = 0; 
    if (col > Console.BufferWidth - msg.Length) 
        col = Math.Max(0, Console.BufferWidth - msg.Length - 1); 

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

    static public string PerguntarSenha(int col, int lin, string texto)
    {
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

    public bool Login()
    {
        bool entrou = false;
        while (!entrou)
        {
            this.PrepararTela("LOGIN");
            this.MontarMoldura(24, 5, 64, 10);
            var nome = Perguntar(25, 6, "Nome de usuario: ");
            var senha = Perguntar(25, 8, "Senha do usuario: ");

            //provisório
            if (nome != "" && senha != "")
            {
                entrou = true;
            }
            else
            {
                this.MostrarMensagem(17, 19, "Dados incorretos, deseja tentar novamente?");
                this.MostrarMensagem(17, 20, "[1] - Sim");
                this.MostrarMensagem(17, 21, "[2] - Nao");
                var novamente = Perguntar(17, 22, "");
                if (novamente == "2")
                {
                    return true;
                }
            }
        }
        return entrou;
    }

    public void Cadastrar()
    {
        bool dadosCorretos = false;
        var nome = "";
        var senha = "";

        while (!dadosCorretos)
        {
            this.PrepararTela("CADASTRAR");
            nome = Perguntar(17, 15, "Nome de usuario: ");
            senha = PerguntarSenha(17, 17, "Senha do usuario: ");

            if (nome != "" && senha != "")
            {
                dadosCorretos = true;
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

        this.Home();
    }

    public string Home()
    {
        string opcao;
        List<string> opcoes = new List<string>();
        List<string> dadosAgendamentos = new List<string>();
        List<string> acontecendoAgora = new List<string>();
        opcoes.Add("[1] - Cadastrar novo Usuario  ");
        opcoes.Add("[2] - Cadastrar nova Aula     ");
        opcoes.Add("[3] - Verificar Agendas       ");
        opcoes.Add("[4] - Verificar Clientes      ");
        opcoes.Add("[5] - Verificar Funcionarios  ");
        opcoes.Add("[0] - SAIR                    ");
        PrepararTela("MENU");
        MostrarSubMenu(59, 2, 88, 10, "AGENDAMENTOS", dadosAgendamentos);
        MostrarSubMenu(59, 12, 88, 15, "ACONTECENDO AGORA", acontecendoAgora);
        return opcao = MostrarMenu(opcoes, 2, 2, "[NAVEGAR]");
    }

    public void MostrarSubMenu(int ci, int li, int cf, int lf, string nomeMenu, List<string> dados)
    {
        MontarMoldura(ci, li, cf, lf);
        this.MostrarMensagem(ci + 1, li, $"[{nomeMenu}]");
    }

    public string CadastrarUsuario()
    {
        string opcao;
        List<string> opcoes = [
            "[1] - Cliente       ",
            "[2] - Administrador ",
            "[3] - Atendente     ",
            "[4] - Auditoria     ",
            "[5] - Gerente       ",
            "[6] - Instrutor     ",
            "[0] - Voltar        ",
        ];

        PrepararTela("CADASTRO DE USUARIOS");
        MostrarMensagem(2, 2, "Selecione a categoria do novo usuario:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
    }
    public void CadastrarAula()
    {
    }
    public void VerificarAgendas()
    {

    }
    public string VerificarClientes()
    {
        string opcao;
        List<string> opcoes =
        [
            "[1] - Listar    ",
            "[2] - Apagar    ",
            "[3] - Ver       ",
            "[4] - Alterar   ",
            "[0] - Voltar    ",
        ];

        PrepararTela("VERIFICAR CLIENTES");
        MostrarMensagem(2, 2, "Selecione a operacao:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
    }
    public string VerificarFuncionarios()
    {
        string opcao;
        List<string> opcoes =
        [
            "[1] - Listar    ",
            "[1] - Apagar    ",
            "[1] - Ver       ",
            "[1] - Alterar   ",
            "[0] - Voltar    ",
        ];

        PrepararTela("VERIFICAR FUNCIONARIOS");
        MostrarMensagem(2, 2, "Selecione a operacao:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
    }
}