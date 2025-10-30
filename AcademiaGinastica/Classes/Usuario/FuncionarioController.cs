public class FuncionarioController
{
    public List<Funcionario> funcionarios;
    private Funcionario funcionario;
    private int posicao;
    private List<string> dados = new List<string>();
    private Tela tela;

    public FuncionarioController()
    {
        this.funcionarios = new List<Funcionario>();
        this.funcionario = new Funcionario();
        this.posicao = -1;
        this.dados.Add("Nome completo   :");
        this.dados.Add("CPF             :");
        this.dados.Add("Email           :");
        this.dados.Add("Telefone        :");
        this.dados.Add("Cargo           :");
        this.dados.Add("Salario         :");

        this.tela = new Tela();
    }

    public bool Cadastrar(int li, int coluna, string tipoCargo)
    {
        string nomeCompleto = Tela.Perguntar(coluna, li, "Nome Completo : ");
        string CPF = Tela.Perguntar(coluna, li + 2, "CPF : ");
        string email = Tela.Perguntar(coluna, li + 4, "Email : ");
        string telefone = Tela.Perguntar(coluna, li + 6, "Telefone : ");
        string enderecoCompleto = Tela.Perguntar(coluna, li + 8, "Endereço Completo : ");
        string senha = Tela.PerguntarSenha(coluna, li + 10, "Senha : ");

        decimal salario = 0;
        string salarioStr = Tela.Perguntar(coluna, li + 12, "Salário : ");
        decimal.TryParse(salarioStr, out salario);

        Cargo novoCargo = Cargo.admin;

        switch (tipoCargo)
        {
            case "2":
                novoCargo = Cargo.admin;
                break;
            case "3":
                novoCargo = Cargo.atendente;
                break;
            case "4":
                novoCargo = Cargo.auditoria;
                break;
            case "5":
                novoCargo = Cargo.gerente;
                break;
            case "6":
                novoCargo = Cargo.instrutor;
                break;
            default:
                tela.MostrarMensagem(coluna, li + 14, "Tipo de cargo inválido!");
                return false;
        }


        Funcionario novoUsuario = new Funcionario(
            nomeCompleto,
            CPF,
            email,
            senha,
            telefone,
            enderecoCompleto,
            salario,
            novoCargo
        );

        this.funcionarios.Add(novoUsuario);
        return true;
    }
    public void ListarFuncionarios()
    {
        if (this.funcionarios.Count == 0)
        {
            tela.PrepararTela("LISTA DE FUNCIONÁRIOS");
            tela.MontarMoldura(2, 2, 80, 10);
            tela.MostrarMensagem(5, 5, "Não há funcionários cadastrados.");
            Console.ReadKey();
            return;
        }

        int ci = 2;
        int li = 2; 
        int larguraMoldura = 90;
        int cf = ci + larguraMoldura;

        int alturaPorFuncionario = 6; 
        int espacamento = 1;         
        int margemRodape = 4;         
        int lf = li + (funcionarios.Count * (alturaPorFuncionario + espacamento)) + margemRodape; 

        Console.Clear();

        tela.MontarMoldura(ci, li, cf, lf);

        string titulo = "LISTA DE FUNCIONÁRIOS";
        int colTitulo = ci + (larguraMoldura - titulo.Length) / 2;
        tela.MostrarMensagem(colTitulo, li + 1, titulo);

        int linhaAtual = li + 3; 
        for (int i = 0; i < funcionarios.Count; i++)
        {
            var f = funcionarios[i];
            tela.MostrarMensagem(ci + 2, linhaAtual, $"{i + 1}. {f.nomeCompleto}");
            tela.MostrarMensagem(ci + 2, linhaAtual + 1, $"CPF: {f.CPF}");
            tela.MostrarMensagem(ci + 2, linhaAtual + 2, $"Telefone: {f.telefone}");
            tela.MostrarMensagem(ci + 2, linhaAtual + 3, $"Email: {f.email}");
            tela.MostrarMensagem(ci + 2, linhaAtual + 4, $"Cargo: {f.cargo}");
            tela.MostrarMensagem(ci + 2, linhaAtual + 5, $"Salário: R$ {f.salario:F2}");

            linhaAtual += alturaPorFuncionario + espacamento;
        }

        tela.MostrarMensagem(ci + 2, lf, "[Pressione qualquer tecla para voltar]");
        Console.ReadKey();
        Console.Clear();

    }

    public void VerFuncionario(int indice)
    {
        if (indice < 0 || indice >= funcionarios.Count)
        {
            tela.MostrarMensagem(4, 4, "Funcionário inválido!");
            Console.ReadKey();
            return;
        }

        Funcionario f = funcionarios[indice];

        tela.PrepararTela("DETALHES DO FUNCIONÁRIO");
        tela.MontarMoldura(3, 3, 70, 20);

        int col = 5;
        int lin = 5;

        tela.MostrarMensagem(col, lin, $"Nome completo  : {f.nomeCompleto}");
        tela.MostrarMensagem(col, lin + 2, $"CPF             : {f.CPF}");
        tela.MostrarMensagem(col, lin + 4, $"Telefone        : {f.telefone}");
        tela.MostrarMensagem(col, lin + 6, $"E-mail          : {f.email}");
        tela.MostrarMensagem(col, lin + 8, $"Endereço        : {f.enderecoCompleto}");
        tela.MostrarMensagem(col, lin + 10, $"Cargo           : {f.cargo}");
        tela.MostrarMensagem(col, lin + 12, $"Salário         : R$ {f.salario:F2}");

        tela.MostrarMensagem(col, lin + 15, "[Pressione qualquer tecla para voltar]");
        Console.ReadKey();
    }
    public void ApagarFuncionario(int id)
    {
        this.funcionarios.RemoveAt(id - 1);
    }
    public void AlterarFuncionario(int id)
    {
        Console.Clear();
        if (id < 0 || id > funcionarios.Count)
        {
            tela.MostrarMensagem(4, 4, "Cliente invalido!");
            Console.ReadKey();
            return;
        }

        this.funcionario = this.funcionarios[id - 1];

        tela.MontarMoldura(3, 3, 70, 20);

        int col = 5;
        int lin = 5;

        tela.MostrarMensagem(col, lin,      $"Nome completo   : {this.funcionario.nomeCompleto}");
        tela.MostrarMensagem(col, lin + 2,  $"CPF             : {this.funcionario.CPF}");
        tela.MostrarMensagem(col, lin + 4,  $"Telefone        : {this.funcionario.telefone}");
        tela.MostrarMensagem(col, lin + 6,  $"E-mail          : {this.funcionario.email}");
        tela.MostrarMensagem(col, lin + 8,  $"Endereço        : {this.funcionario.enderecoCompleto}");
        tela.MostrarMensagem(col, lin + 10,  $"Cargo           : {this.funcionario.cargo}");
        tela.MostrarMensagem(col, lin + 12,  $"Salario         : {this.funcionario.salario}");


        Console.SetCursorPosition(col + "Nome completo   : ".Length, lin);
        this.funcionario.nomeCompleto = Console.ReadLine();
        Console.SetCursorPosition(col + "CPF             : ".Length, lin+2);
        this.funcionario.CPF = Console.ReadLine();
        Console.SetCursorPosition(col + "Telefone        : ".Length, lin+4);
        this.funcionario.telefone = Console.ReadLine();
        Console.SetCursorPosition(col + "E-mail          : ".Length, lin+6);
        this.funcionario.email = Console.ReadLine();
        Console.SetCursorPosition(col + "Endereço        : ".Length, lin+8);
        this.funcionario.enderecoCompleto = Console.ReadLine();


        tela.MontarMoldura(81, 2, 107, 11);
        tela.MostrarMensagem(82, 2, $"[SELECIONE O CARGO]");

        tela.MostrarMensagem(82, 3, "Cargo (digite o nome ou número):");
        int cargoLinha = 3;
        int i = 1;
        foreach (var nome in Enum.GetNames(typeof(Cargo)))
        {
            tela.MostrarMensagem(82 + 3, cargoLinha + i, $"{i-1} - {nome}");
            i++;
        }

        tela.MostrarMensagem(82, cargoLinha + i + 1, "Escolha: ");
        Console.SetCursorPosition(82 + "Escolha: ".Length, cargoLinha + i + 1);
        string entradaCargo = Console.ReadLine();

        try
        {
            if (int.TryParse(entradaCargo, out int indiceCargo))
            {
                this.funcionario.cargo = (Cargo)indiceCargo;
            }
            else
            {
                this.funcionario.cargo = (Cargo)Enum.Parse(typeof(Cargo), entradaCargo, true);
            }
        }
        catch
        {
            tela.MostrarMensagem(82, cargoLinha + i + 3, "Cargo inválido! Mantido o valor anterior.");
            Console.ReadKey();
        }

        tela.MostrarMensagem(col, lin + 10, $"Cargo           : {this.funcionario.cargo}");
        tela.MostrarMensagem(col, lin + 12, $"Salário         : ");
        Console.SetCursorPosition(col + "Salário         : ".Length, lin + 12);
        if (decimal.TryParse(Console.ReadLine(), out decimal novoSalario))
            this.funcionario.salario = novoSalario;

        this.funcionarios[id - 1] = this.funcionario;
    }
}