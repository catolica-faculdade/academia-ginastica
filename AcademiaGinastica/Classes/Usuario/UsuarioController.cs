public class UsuarioController
{
    public List<Usuario> usuarios;
    private Usuario usuario;
    private int posicao;
    private List<string> dados = new List<string>();
    private Tela tela;

    public UsuarioController()
    {
        this.usuarios = new List<Usuario>();
        this.usuario = new Usuario();
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

        Usuario novoUsuario = null;

        switch (tipoCargo)
        {
            case "1":
                novoUsuario = new Cliente()
                {
                    nomeCompleto = nomeCompleto,
                    CPF = CPF,
                    email = email,
                    telefone = telefone,
                    enderecoCompleto = enderecoCompleto,
                    senha = senha,
                };
                break;

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

        this.usuarios.Add(novoUsuario);
        return true;
    }
    public void ListarUsuarios()
    {

        if (this.usuarios.Count == 0)
        {
            Console.Write("Não há usuários cadastrados.");
            Console.ReadKey();
            return;
        }
        this.tela.MostrarMensagem(3, 3, "USUARIOS : ");

        for (int i = 0; i < usuarios.Count; i++)
        {
            this.tela.MostrarMensagem(4, 5 + i * 2, $"{i + 1}. {usuarios[i].nomeCompleto}");
        }

        Console.ReadKey();
    }

}