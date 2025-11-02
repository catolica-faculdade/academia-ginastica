public class ClienteController
{
    public List<Cliente> clientes = new GeralController().clientes;
    private Cliente cliente;
    private int posicao;
    private List<string> dados = new List<string>();
    private Tela tela;

    public ClienteController(List<Cliente> clientes)
    {
        this.clientes = clientes ?? new List<Cliente>();
        this.cliente = new Cliente();
        this.posicao = -1;
        this.dados.Add("Nome completo   :");
        this.dados.Add("CPF             :");
        this.dados.Add("Email           :");
        this.dados.Add("Telefone        :");
        this.dados.Add("Cargo           :");

        this.tela = new Tela();
    }

    public bool Cadastrar(int li, int coluna, string tipoCargo)
    {
        Tela.MostrarMensagem(26, 20, "[0] - Sair");
        string nomeCompleto = Tela.Perguntar(coluna, li, "Nome Completo : ");
        if (nomeCompleto == "0") return false;
        string CPF = Tela.Perguntar(coluna, li + 2, "CPF : ");
        if (CPF == "0") return false;
        string email = Tela.Perguntar(coluna, li + 4, "Email : ");
        if (email == "0") return false;
        string telefone = Tela.Perguntar(coluna, li + 6, "Telefone : ");
        if (telefone == "0") return false;
        string enderecoCompleto = Tela.Perguntar(coluna, li + 8, "Endereço Completo : ");
        if (enderecoCompleto == "0") return false;
        string senha = Tela.PerguntarSenha(coluna, li + 10, "Senha : ");
        if (senha == "0") return false;

        decimal salario = 0;
        if (tipoCargo != "1")
        {
            string salarioStr = Tela.Perguntar(coluna, li + 12, "Salário : ");
            decimal.TryParse(salarioStr, out salario);
        }


        Cliente novoUsuario = new Cliente()
        {
            nomeCompleto = nomeCompleto,
            CPF = CPF,
            email = email,
            telefone = telefone,
            enderecoCompleto = enderecoCompleto,
            senha = senha,
        };

        this.clientes.Add(novoUsuario);
        return true;
    }
    public void ListarClientes()
    {
        if (this.clientes.Count == 0)
        {
            tela.PrepararTela("LISTA DE CLIENTES");
            tela.MontarMoldura(2, 2, 80, 10);
            Tela.MostrarMensagem(5, 5, "Não há clientes cadastrados.");
            Console.ReadKey();
            return;
        }

        int ci = 2; 
        int li = 2;
        int larguraMoldura = 90;
        
        int cf = ci + larguraMoldura; 
        int alturaPorCliente = 5;
        int espacamento = 1;    
        int margemRodape = 4;     
        int lf = li + (clientes.Count * (alturaPorCliente + espacamento)) + margemRodape; 

        Console.Clear();


        tela.MontarMoldura(ci, li, cf, lf);

        string titulo = "LISTA DE CLIENTES";
        int colTitulo = ci + 1 + (larguraMoldura - titulo.Length) / 2;
        Tela.MostrarMensagem(colTitulo, li + 1, titulo);

        int linhaAtual = li + 3;
        for (int i = 0; i < clientes.Count; i++)
        {
            var c = clientes[i];

            Tela.MostrarMensagem(ci + 2, linhaAtual, $"{i + 1}. {c.nomeCompleto}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 1, $"CPF: {c.CPF}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 2, $"Telefone: {c.telefone}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 3, $"Email: {c.email}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 4, $"Endereço: {c.enderecoCompleto}");

            linhaAtual += alturaPorCliente + espacamento;
        }

        Tela.MostrarMensagem(ci + 2, lf, "[Pressione qualquer tecla para voltar]");
        Console.ReadKey();
        Console.Clear();
    }

    public void VerCliente(int indice)
    {
       if (indice < 0 || indice >= clientes.Count)
        {
            Tela.MostrarMensagem(4, 4, "Cliente invalido!");
            Console.ReadKey();
            return;
        }

        Cliente c = clientes[indice];

        tela.PrepararTela("DETALHES DO CLIENTE");
        tela.MontarMoldura(3, 3, 70, 20);

        int col = 5;
        int lin = 5;

        Tela.MostrarMensagem(col, lin, $"Nome completo  : {c.nomeCompleto}");
        Tela.MostrarMensagem(col, lin + 2, $"CPF             : {c.CPF}");
        Tela.MostrarMensagem(col, lin + 4, $"Telefone        : {c.telefone}");
        Tela.MostrarMensagem(col, lin + 6, $"E-mail          : {c.email}");
        Tela.MostrarMensagem(col, lin + 8, $"Endereço        : {c.enderecoCompleto}");

        Tela.MostrarMensagem(col, lin + 12, "[Pressione qualquer tecla para voltar]");
        Console.ReadKey();
        Console.Clear();
    }
    public void ApagarCliente(int id)
    {
        this.clientes.RemoveAt(id - 1);
    }
    public void AlterarCliente(int id)
    {
        Console.Clear();
        if (id < 0 || id > clientes.Count)
        {
            Tela.MostrarMensagem(4, 4, "Cliente invalido!");
            Console.ReadKey();
            return;
        }

        this.cliente = this.clientes[id - 1];

        tela.MontarMoldura(3, 3, 70, 20);

        int col = 5;
        int lin = 5;

        Tela.MostrarMensagem(col, lin,      $"Nome completo   : {this.cliente.nomeCompleto}");
        Tela.MostrarMensagem(col, lin + 2,  $"CPF             : {this.cliente.CPF}");
        Tela.MostrarMensagem(col, lin + 4,  $"Telefone        : {this.cliente.telefone}");
        Tela.MostrarMensagem(col, lin + 6,  $"E-mail          : {this.cliente.email}");
        Tela.MostrarMensagem(col, lin + 8,  $"Endereço        : {this.cliente.enderecoCompleto}");


        Console.SetCursorPosition(col + "Nome completo   : ".Length, lin);
        this.cliente.nomeCompleto = Console.ReadLine();
        Console.SetCursorPosition(col + "CPF             : ".Length, lin+2);
        this.cliente.CPF = Console.ReadLine();
        Console.SetCursorPosition(col + "Telefone        : ".Length, lin+4);
        this.cliente.telefone = Console.ReadLine();
        Console.SetCursorPosition(col + "E-mail          : ".Length, lin+6);
        this.cliente.email = Console.ReadLine();
        Console.SetCursorPosition(col + "Endereço        : ".Length, lin+8);
        this.cliente.enderecoCompleto = Console.ReadLine();

        this.clientes[id - 1] = this.cliente;
    }
}