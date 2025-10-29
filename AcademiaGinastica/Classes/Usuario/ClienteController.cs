public class ClienteController
{
    public List<Cliente> clientes;
    private Cliente cliente;
    private int posicao;
    private List<string> dados = new List<string>();
    private Tela tela;

    public ClienteController()
    {
        this.clientes = new List<Cliente>();
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
        string nomeCompleto = Tela.Perguntar(coluna, li, "Nome Completo : ");
        string CPF = Tela.Perguntar(coluna, li + 2, "CPF : ");
        string email = Tela.Perguntar(coluna, li + 4, "Email : ");
        string telefone = Tela.Perguntar(coluna, li + 6, "Telefone : ");
        string enderecoCompleto = Tela.Perguntar(coluna, li + 8, "Endereço Completo : ");
        string senha = Tela.PerguntarSenha(coluna, li + 10, "Senha : ");

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
            Console.Write("Não há usuários cadastrados.");
            Console.ReadKey();
            return;
        }
        this.tela.MostrarMensagem(3, 3, "USUARIOS : ");

        for (int i = 0; i < clientes.Count; i++)
        {
            this.tela.MostrarMensagem(4, 5 + i * 2, $"{i + 1}. {clientes[i].nomeCompleto}");
            this.tela.MostrarMensagem(4, 5 + i * 2, clientes[i].CPF);
            this.tela.MostrarMensagem(4, 5 + i * 2, clientes[i].telefone);
            this.tela.MostrarMensagem(4, 5 + i * 2, clientes[i].email);
            this.tela.MostrarMensagem(4, 5 + i * 2, clientes[i].enderecoCompleto);
        }

        Console.ReadKey();
    }
    public void VerCliente(int i)
    {
        this.cliente = clientes[i];
        this.tela.MostrarMensagem(4, 5, $"{i + 1}. {clientes[i].nomeCompleto}");
        this.tela.MostrarMensagem(4, 6, clientes[i].CPF);
        this.tela.MostrarMensagem(4, 7, clientes[i].telefone);
        this.tela.MostrarMensagem(4, 8, clientes[i].email);
        this.tela.MostrarMensagem(4, 9, clientes[i].enderecoCompleto);
    }
    public void ApagarCliente(int id)
    {
        this.clientes.RemoveAt(id-1);
    }
    public void AlterarCliente()
    {

    }
}