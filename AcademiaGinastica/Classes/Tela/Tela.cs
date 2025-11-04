using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
    private ClienteController clienteController;
    private FuncionarioController funcionarioController;
    private Agenda agenda;
    private ModalidadeController modalidadeController;

    //
    // métodos
    //
    public Tela(){}
    public Tela(int largura, int altura, int coluna, int linha)
    {
        this.largura = largura;
        this.altura = altura;
        this.colunaInicial = 0;
        this.linhaInicial = 0;
        
    }
    public Tela(int largura, int altura, Agenda agenda, ModalidadeController modalidadeController, FuncionarioController funcionarioController, ClienteController clienteController)
    {
        this.largura = largura;
        this.altura = altura;
        this.agenda = agenda;
        this.modalidadeController = modalidadeController;
        this.clienteController = clienteController;
        this.funcionarioController = funcionarioController;
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
        MostrarMensagem(ci + 1, li, titulo);
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
        int maxLinhas = Console.BufferHeight - 1;
        int maxColunas = Console.BufferWidth - 1;

        for (int i = li; i <= lf && i <= maxLinhas; i++)
        {
            int coluna = Math.Min(ci, maxColunas);
            Console.SetCursorPosition(coluna, i);
            Console.Write(new string(' ', Math.Min(cf - ci, maxColunas - coluna)));
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
    public void ReconstruirMoldura(int ci, int li, int cf, int lf)
    {
        int col, lin;

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
    static public void MostrarMensagem(int col, int lin, string msg)
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

    

    public bool Login()
    {
        bool entrou = false;
        while (!entrou)
        {
            this.PrepararTela("LOGIN");
            this.MontarMoldura(24, 5, 64, 10);
            MostrarMensagem(32, 12, "Digite 'Sair' para voltar...");
            var nome = Perguntar(25, 6, "Nome de usuario: ");
            if (string.Equals(nome.ToLower(), "sair")) return false;
            var senha = PerguntarSenha(25, 8, "Senha do usuario: ");
            if (string.Equals(senha.ToLower(), "sair")) return false;

            //provisório
            if (nome != "" && senha != "")
            {
                entrou = true;
            }
            else
            {
                MostrarMensagem(17, 19, "Dados incorretos, deseja tentar novamente?");
                MostrarMensagem(17, 20, "[1] - Sim");
                MostrarMensagem(17, 21, "[2] - Nao");
                var novamente = Perguntar(17, 22, "");
                if (novamente == "2")
                {
                    return false;
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
                MostrarMensagem(17, 19, "Dados incorretos, deseja tentar novamente?");
                MostrarMensagem(17, 20, "[1] - Sim");
                MostrarMensagem(17, 21, "[2] - Nao");
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
        this.agenda = agenda;
        string opcao;
        List<string> opcoes = new List<string>();
        List<string> agendamentos = agenda.Agendamentos(3);
        List<string> acontecendoAgora = agenda.AcontecendoAgora();
        
        opcoes.Add("[1] - Cadastrar novo Usuario    ");
        opcoes.Add("[2] - Cadastrar nova Aula       ");
        opcoes.Add("[3] - Verificar Modalidades     ");
        opcoes.Add("[4] - Verificar Agendas         ");
        opcoes.Add("[5] - Verificar Clientes        ");
        opcoes.Add("[6] - Verificar Funcionarios    ");
        opcoes.Add("Digite 'Sair' para sair         ");
        PrepararTela("MENU");
        MostrarSubMenu(59, 2, 88, 10, "AGENDAMENTOS", agendamentos);
        MostrarSubMenu(59, 12, 88, 17, "ACONTECENDO AGORA", acontecendoAgora);
        return opcao = MostrarMenu(opcoes, 2, 2, "[NAVEGAR]");
    }

    public void MostrarSubMenu(int ci, int li, int cf, int lf, string nomeMenu, List<string> dados)
    {
        MontarMoldura(ci, li, cf, lf);
        MostrarMensagem(ci + 2, li, $"[{nomeMenu}]");

        int linha = li + 2;
        if (dados == null || dados.Count == 0)
        {
            MostrarMensagem(ci + 2, linha, "[Nenhum dado encontrado]");
            return;
        }

        foreach (var item in dados)
        {
            if (linha >= lf - 1) break;
            MostrarMensagem(ci + 2, linha, item);
            linha++;
        }
    }

    public string CadastrarUsuario()
    {
        string opcao;
        List<string> opcoes = [
            "[1] - Cliente           ",
            "[2] - Administrador     ",
            "[3] - Atendente         ",
            "[4] - Auditoria         ",
            "[5] - Gerente           ",
            "[6] - Instrutor         ",
            "Digite 'Sair' para sair "
        ];

        PrepararTela("CADASTRO DE USUARIOS");
        MostrarMensagem(2, 2, "Selecione a categoria do novo usuario:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
    }
    public void CadastrarAula(int coluna, int li)
    {
        string nomeAula = Perguntar(coluna, li, "Nome da aula : ");
        if (string.Equals(nomeAula.ToLower(), "sair")) return;
        while (modalidadeController.modalidades.Count == 0)
        {
            string op = Perguntar(coluna, li + 2, "Nenhuma modalidade encontrada. Deseja cadastrar? (S/N): ");
            if (string.Equals(op.ToLower(), "sair")) return;
            if (string.Equals(op.ToLower(), "s"))
            {
                try
                {
                    modalidadeController.CadastrarModalidade(coluna, li + 4);
                    MostrarMensagem(coluna, li + 8, "Cadastro realizado com sucesso!");
                    Console.ReadKey();
                    ApagarArea(coluna, li+4, 64, li+8);
                }
                catch (Exception error)
                {
                    Console.WriteLine("Alguma coisa deu errado, erro:", error.Message);
                }

            }

            if (string.Equals(op.ToLower(), "n"))
            {
                MostrarMensagem(coluna, li + 2, "Aperte qualquer tecla para retornar ao menu...");
                Console.ReadKey();

                return;
            }
        }

        ApagarArea(coluna, li+2, 64, li+2);
        Modalidade modalidade = PerguntarModalidade(coluna, li + 2, "ID da Modalidade : ");
        if (modalidade == null) return;
        Funcionario instrutor = PerguntarFuncionario(coluna, li + 3, "ID do(a) Instrutor : ");
        if (instrutor == null) return;
        string lotacao = Perguntar(coluna, li + 4, "Lotacao máxima da aula : ");
        if(string.Equals(lotacao.ToLower(), "sair")) return;

        MontarMoldura(61, 2, 88, 3+int.Parse(lotacao));
        MostrarMensagem(62, 2, "[CLIENTES]");
        List<Cliente> clientes = PerguntarClientes(62, 3, "ID do Cliente : ");
        if (clientes == null) return;

        string data = Perguntar(coluna, li + 5, "Data (DD/MM/AAAA): ");
        if(string.Equals(data.ToLower(), "sair")) return;

        string horaInicio = Perguntar(coluna, li + 6, "Horário de início (HH:MM): ");
        if(string.Equals(horaInicio.ToLower(), "sair")) return;

        string horaFim = Perguntar(coluna, li + 7, "Horário de término (HH:MM): ");
        if(string.Equals(horaFim.ToLower(), "sair")) return;


        DateTime dataInicio = DateTime.Parse($"{data} {horaInicio}");
        DateTime dataFim = DateTime.Parse($"{data} {horaFim}");



        Aula novaAula = new Aula(nomeAula, modalidade, instrutor, dataInicio, dataFim, clientes, int.Parse(lotacao));

        agenda.CadastrarAula(novaAula);
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
            "Digite 'Sair' para sair...    ",
        ];

        PrepararTela("VERIFICAR CLIENTES");
        MostrarMensagem(2, 2, "Selecione a operacao:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
    }

    public string VerificarAgenda()
    {
        string opcao;
        List<string> opcoes =
        [
            "[1] - Listar               ",
            "[2] - Apagar               ",
            "[3] - Ver                  ",
            "[4] - Alterar              ",
            "Digite 'Sair' para sair... ",
        ];

        PrepararTela("VERIFICAR AGENDA");
        MostrarMensagem(2, 2, "Selecione a operacao:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
    }

    public string VerificarFuncionarios()
    {
        string opcao;
        List<string> opcoes =
        [
            "[1] - Listar               ",
            "[2] - Apagar               ",
            "[3] - Ver                  ",
            "[4] - Alterar              ",
            "Digite 'Sair' para sair... ",
        ];

        PrepararTela("VERIFICAR FUNCIONARIOS");
        MostrarMensagem(2, 2, "Selecione a operacao:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
    }

    public string VerificarModalidades()
    {
        string opcao;
        List<string> opcoes =
        [
            "[1] - Criar                ",
            "[2] - Apagar               ",
            "[3] - Ver                  ",
            "[4] - Listar Modalidades   ",
            "[5] - Alterar              ",
            "Digite 'Sair' para sair... ",
        ];

        PrepararTela("VERIFICAR MODALIDADES");
        MostrarMensagem(2, 2, "Selecione a operacao:");
        opcao = MostrarMenu(opcoes, 2, 4);

        return opcao;
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

    public Modalidade PerguntarModalidade(int col, int lin, string pergunta)
    {
        bool retorno = false;
        Modalidade modalidadeRetorno = null;
        string idModalidade = "";
        while (!retorno)
        {
            Console.SetCursorPosition(col, lin);
            Console.Write(pergunta);
            
            try
            {
                idModalidade = Console.ReadLine();
                if (string.Equals(idModalidade, "sair")) return null;

                int id = int.Parse(idModalidade);

                if (id <= this.modalidadeController.modalidades.Count || id > 0)
                {
                    modalidadeRetorno = this.modalidadeController.modalidades[id - 1];
                    retorno = true;
                }
            }
            catch
            {
                Console.SetCursorPosition(col, lin + 10);
                Console.Write("ID inválido, deseja ver todas as modalidades? [1] - Sim | [2] - Não : ");
                string verTodas = Console.ReadLine();

                if (verTodas == "1")
                    this.modalidadeController.VerModalidades(60, 4);

                this.ApagarArea(col, lin + 10, col + "ID inválido, deseja ver todas as modalidades? [1] - Sim | [2] - Não : ".Length + verTodas.Length, lin + 10);
                this.ApagarArea(col + pergunta.Length, lin, col + pergunta.Length + idModalidade.Length, lin);
            }
        }

        return modalidadeRetorno;
    }


    public List<Cliente> PerguntarClientes(int col, int lin, string pergunta)
    {
        List<Cliente> clienteRetorno = new List<Cliente>();
        bool retorno = false;

        while (!retorno)
        {
            Console.SetCursorPosition(col, lin);
            Console.Write(pergunta);

            string idCliente = Console.ReadLine();
            if (string.Equals(idCliente.ToLower(), "sair")) return null;
            int id = int.Parse(idCliente);

            if (id <= this.clienteController.clientes.Count && id > 0)
            {
                clienteRetorno.Add(this.clienteController.clientes[id - 1]);

                string continuar = Perguntar(15, 20, "Deseja incluir mais um cliente? [1] - Sim | [2] - Não: ");
                if (continuar != "1")
                    retorno = true;
                lin++;
            }
            else
            {
                Console.SetCursorPosition(col, lin + 2);
                Console.Write("ID inválido, deseja ver todos os clientes? [1] - Sim | [2] - Não | [3] - Cadastrar novo: ");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                    this.clienteController.ListarClientes();
                else if (opcao == "3")
                    this.clienteController.Cadastrar(2, 2, "0");
                else
                    break;
            }
        }

        return clienteRetorno;
    }


    public Funcionario PerguntarFuncionario(int col, int lin, string pergunta)
    {
        Funcionario funcionarioRetorno = null;
        bool retorno = false;

        while (!retorno)
        {
            Console.SetCursorPosition(col, lin);
            Console.Write(pergunta);

            string idFuncionario = Console.ReadLine();
            if (string.Equals(idFuncionario, "sair")) return null;
            int id = int.Parse(idFuncionario);

            if (id <= this.funcionarioController.funcionarios.Count || id > 0)
            {
                funcionarioRetorno = this.funcionarioController.funcionarios[id - 1];
                retorno = true;
            }
            else
            {
                Console.SetCursorPosition(col, lin + 2);
                Console.Write("ID inválido, deseja ver todos os funcionários? [1] - Sim | [2] - Não | [3] - Cadastrar novo: ");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                    this.funcionarioController.ListarFuncionarios();
                else if (opcao == "3")
                {
                    string cargo = CadastrarUsuario();
                    this.funcionarioController.Cadastrar(2, 2, cargo);
                }
                else
                    break;
            }
        }

        return funcionarioRetorno;
    }

}