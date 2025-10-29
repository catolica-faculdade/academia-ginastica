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
        if (tipoCargo != "1")
        {
            string salarioStr = Tela.Perguntar(coluna, li + 12, "Salário : ");
            decimal.TryParse(salarioStr, out salario);
        }

        Funcionario novoUsuario = null;

        switch (tipoCargo)
        {
            case "2":
                novoUsuario = new Administrador()
                {
                    nomeCompleto = nomeCompleto,
                    CPF = CPF,
                    email = email,
                    telefone = telefone,
                    enderecoCompleto = enderecoCompleto,
                    senha = senha,
                    cargo = Cargo.admin,
                    salario = salario
                };
                break;

            case "3":
                novoUsuario = new Atendente()
                {
                    nomeCompleto = nomeCompleto,
                    CPF = CPF,
                    email = email,
                    telefone = telefone,
                    enderecoCompleto = enderecoCompleto,
                    senha = senha,
                    cargo = Cargo.atendente,
                    salario = salario
                };
                break;

            case "4":
                novoUsuario = new Auditoria()
                {
                    nomeCompleto = nomeCompleto,
                    CPF = CPF,
                    email = email,
                    telefone = telefone,
                    enderecoCompleto = enderecoCompleto,
                    senha = senha,
                    cargo = Cargo.auditoria,
                    salario = salario
                };
                break;

            case "5":
                novoUsuario = new Gerente()
                {
                    nomeCompleto = nomeCompleto,
                    CPF = CPF,
                    email = email,
                    telefone = telefone,
                    enderecoCompleto = enderecoCompleto,
                    senha = senha,
                    cargo = Cargo.gerente,
                    salario = salario
                };
                break;

            case "6":
                novoUsuario = new Instrutor()
                {
                    nomeCompleto = nomeCompleto,
                    CPF = CPF,
                    email = email,
                    telefone = telefone,
                    enderecoCompleto = enderecoCompleto,
                    senha = senha,
                    cargo = Cargo.instrutor,
                    salario = salario
                };
                break;

            default:
                tela.MostrarMensagem(coluna, li + 14, "Tipo de cargo inválido!");
                return false;
        }

        this.funcionarios.Add(novoUsuario);
        return true;
    }
    public void ListarFuncionarios()
    {

        if (this.funcionarios.Count == 0)
        {
            Console.Write("Não há usuários cadastrados.");
            Console.ReadKey();
            return;
        }
        this.tela.MostrarMensagem(3, 3, "USUARIOS : ");

        for (int i = 0; i < funcionarios.Count; i++)
        {
            this.tela.MostrarMensagem(4, 5 + i * 2, $"{i + 1}. {funcionarios[i].nomeCompleto}");
            this.tela.MostrarMensagem(4, 5 + i * 2, funcionarios[i].CPF);
            this.tela.MostrarMensagem(4, 5 + i * 2, funcionarios[i].telefone);
            this.tela.MostrarMensagem(4, 5 + i * 2, funcionarios[i].email);
            this.tela.MostrarMensagem(4, 5 + i * 2, funcionarios[i].enderecoCompleto);
            this.tela.MostrarMensagem(4, 5 + i * 2, funcionarios[i].cargo.ToString());
            this.tela.MostrarMensagem(4, 5 + i * 2, funcionarios[i].salario.ToString());
        }

        Console.ReadKey();
    }
    public void VerFuncionario(int i)
    {
        this.funcionario = funcionarios[i];
        this.tela.MostrarMensagem(4, 5, $"{i + 1}. {funcionarios[i].nomeCompleto}");
        this.tela.MostrarMensagem(4, 6, funcionarios[i].CPF);
        this.tela.MostrarMensagem(4, 7, funcionarios[i].telefone);
        this.tela.MostrarMensagem(4, 8, funcionarios[i].email);
        this.tela.MostrarMensagem(4, 9, funcionarios[i].enderecoCompleto);
        this.tela.MostrarMensagem(4, 10, funcionarios[i].cargo.ToString());
        this.tela.MostrarMensagem(4, 11, funcionarios[i].salario.ToString());
    }
    public void ApagarFuncionario(int id)
    {
        this.funcionarios.RemoveAt(id-1);
    }
    public void AlterarFuncionario()
    {

    }
}