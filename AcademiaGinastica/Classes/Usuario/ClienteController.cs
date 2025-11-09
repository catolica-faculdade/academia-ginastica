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
        bool dadosCorretos = false;

        while (!dadosCorretos)
        {
            Tela.MostrarMensagem(18, 23, "Digite 'Sair' para voltar...");
            string nomeCompleto = Tela.Perguntar(coluna, li, "Nome Completo : ");
            if (string.Equals(nomeCompleto, "sair")) return false;

            string CPF = Tela.Perguntar(coluna, li + 2, "CPF : ");
            if (string.Equals(CPF, "sair")) return false;

            string email = Tela.Perguntar(coluna, li + 4, "Email : ");
            if (string.Equals(email, "sair")) return false;

            string telefone = Tela.Perguntar(coluna, li + 6, "Telefone : ");
            if (string.Equals(telefone, "sair")) return false;

            string enderecoCompleto = Tela.Perguntar(coluna, li + 8, "Endereço Completo : ");
            if (string.Equals(enderecoCompleto, "sair")) return false;

            string senha = Tela.PerguntarSenha(coluna, li + 10, "Senha : ");
            if (string.Equals(senha, "sair")) return false;

            if (!string.IsNullOrWhiteSpace(nomeCompleto)
                && !string.IsNullOrWhiteSpace(CPF)
                && !string.IsNullOrWhiteSpace(email)
                && !string.IsNullOrWhiteSpace(telefone)
                && !string.IsNullOrWhiteSpace(enderecoCompleto)
                && !string.IsNullOrWhiteSpace(senha))
            {
                var novoUsuario = new Cliente()
                {
                    nomeCompleto = nomeCompleto,
                    CPF = CPF,
                    email = email,
                    telefone = telefone,
                    enderecoCompleto = enderecoCompleto,
                    senha = senha,
                };

                this.clientes.Add(novoUsuario);
                dadosCorretos = true;
                return dadosCorretos;
            } else
            {
                Tela tela = new Tela();
                Tela.MostrarMensagem(5, 18, "Algum dos dados é inválido. Deseja tentar novamente?");
                Tela.MostrarMensagem(5, 19, "[1] - Sim");
                Tela.MostrarMensagem(5, 20, "[2] - Não");
                string novamente = Tela.Perguntar(5, 21, "");
                tela.ApagarArea(5, 18, 59, 18);
                while (!string.Equals(novamente, "2") && !string.Equals(novamente, "1") && !string.Equals(novamente.ToLower(), "sair"))
                {
                    tela.ApagarArea(5, 21, 59, 21);
                    Tela.MostrarMensagem(5, 18, "Opção inválida. Digite novamente: ");
                    Tela.MostrarMensagem(5, 19, "[1] - Sim");
                    Tela.MostrarMensagem(5, 20, "[2] - Não");
                    novamente = Tela.Perguntar(5, 21, "");
                }
                if (string.Equals(novamente, "2") || string.Equals(novamente.ToLower(), "sair"))
                {
                    return false;
                }
                tela.ApagarArea(coluna, li, 59, 22);
            }
            
        }

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
        int margemRodape = 7;     
        int lf = li + (3 * (alturaPorCliente + espacamento)) + margemRodape; 

        Console.Clear();


        tela.MontarMoldura(ci, li, cf, lf);

        string titulo = "LISTA DE CLIENTES";
        int colTitulo = ci + 1 + (larguraMoldura - titulo.Length) / 2;
        Tela.MostrarMensagem(colTitulo, li + 1, titulo);

        int linhaAtual = li + 3;
        int maxNumClientes = 3;
        int numAtualClientes = 0;
        for (int i = 0; i < clientes.Count; i++)
        {
            var c = clientes[i];

            Tela.MostrarMensagem(ci + 2, linhaAtual, $"{i + 1}. {c.nomeCompleto}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 1, $"CPF: {c.CPF}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 2, $"Telefone: {c.telefone}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 3, $"Email: {c.email}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 4, $"Endereço: {c.enderecoCompleto}");

            linhaAtual += alturaPorCliente + espacamento;
            numAtualClientes++;
            if (numAtualClientes == maxNumClientes)
            {
                Tela.MostrarMensagem(ci + 4, linhaAtual, "Deseja visualizar mais clientes?");
                Tela.MostrarMensagem(ci + 4, linhaAtual + 1, "[1] - Sim");
                Tela.MostrarMensagem(ci + 4, linhaAtual + 2, "[2] - Não");
                string resposta = Tela.Perguntar(ci + 4, linhaAtual + 3, "");
                if (string.Equals(resposta, "2") || string.Equals(resposta.ToLower(), "sair"))
                {
                    Console.Clear();
                    return;
                }

                numAtualClientes = 0;
                linhaAtual = li + 3;
                Console.Clear();
                tela.MontarMoldura(ci, li, cf, lf);      
            }          
        }

        Tela.MostrarMensagem(ci + 2, lf, "[Pressione qualquer tecla para voltar]");
        Console.ReadKey();
        Console.Clear();
    }

    public void VerCliente(int indice)
    {
       if (indice <= 0 || indice >= clientes.Count)
        {
            Tela.MostrarMensagem(4, 4, "[Cliente invalido!] PRESSIONE QUALQUER TECLA PARA VOLTAR");
            Console.ReadKey();
            return;
        }

        Cliente c = clientes[indice-1];

        tela.MontarMoldura(2, 2, 80, 20);

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
        bool apagarValido = false;
        while (!apagarValido)
        {
            Tela.MostrarMensagem(4, 8, "Deseja realmente apagar?");
            Tela.MostrarMensagem(4, 9, "[1] - Sim");
            Tela.MostrarMensagem(4, 10, "[2] - Não");
            string opcao = Tela.Perguntar(4, 11, "");
            if(opcao == "2" || string.Equals(opcao.ToLower(), "sair"))
            {
                return;
            }
            if (opcao == "1")
            {
                this.clientes.RemoveAt(id - 1);
                apagarValido = true;
            } else
            {
                Tela.MostrarMensagem(4, 12, "Opção inválida.");
            }
        }
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
        string nomeCompleto = Console.ReadLine();
        if (string.Equals(nomeCompleto.ToLower(), "sair")) return;

        Console.SetCursorPosition(col + "CPF             : ".Length, lin+2);
        string CPF = Console.ReadLine();
        if (string.Equals(CPF.ToLower(), "sair")) return;

        Console.SetCursorPosition(col + "Telefone        : ".Length, lin+4);
        string telefone = Console.ReadLine();
        if (string.Equals(telefone.ToLower(), "sair")) return;

        Console.SetCursorPosition(col + "E-mail          : ".Length, lin+6);
        string email = Console.ReadLine();
        if (string.Equals(email.ToLower(), "sair")) return;

        Console.SetCursorPosition(col + "Endereço        : ".Length, lin+8);
        string enderecoCompleto = Console.ReadLine();
        if (string.Equals(enderecoCompleto.ToLower(), "sair")) return;

        this.cliente.nomeCompleto = nomeCompleto;
        this.cliente.CPF = CPF;
        this.cliente.telefone = telefone;
        this.cliente.email = email;
        this.cliente.enderecoCompleto = enderecoCompleto;
        this.clientes[id - 1] = this.cliente;
    }
}