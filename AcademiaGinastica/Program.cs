Tela tela = new Tela(90, 25);
FuncionarioController funcionarioController = new FuncionarioController();
ClienteController clienteController = new ClienteController();

string opcao;
List<string> opcoes = new List<string>();
opcoes.Add("1 - Entrar      ");
opcoes.Add("0 - Sair        ");

tela.ApagarArea(0, 0, 119, 49);
while (true)
{
    tela.PrepararTela("BEM VINDO");
    Console.WriteLine("");
    Console.WriteLine(@"
║  █████╗  ██████╗ █████╗ ██████╗ ███████╗███╗   ███╗██╗ █████╗     
║ ██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔════╝████╗ ████║██║██╔══██╗    
║ ███████║██║     ███████║██║  ██║█████╗  ██╔████╔██║██║███████║    
║ ██╔══██║██║     ██╔══██║██║  ██║██╔══╝  ██║╚██╔╝██║██║██╔══██║    
║ ██║  ██║╚██████╗██║  ██║██████╔╝███████╗██║ ╚═╝ ██║██║██║  ██║    
║ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═════╝ ╚══════╝╚═╝     ╚═╝╚═╝╚═╝  ╚═╝    
║                                                                   
║  ██████╗ ███████╗                                                  
║  ██╔══██╗██╔════╝                                                  
║  ██║  ██║█████╗                                                    
║  ██║  ██║██╔══╝                                                    
║  ██████╔╝███████╗                                                  
║  ╚═════╝ ╚══════╝                                                  
║                                                                   
║  ██████╗ ██╗███╗   ██╗ █████╗ ███████╗████████╗██╗ ██████╗ █████╗ 
║ ██╔════╝ ██║████╗  ██║██╔══██╗██╔════╝╚══██╔══╝██║██╔════╝██╔══██╗
║ ██║  ███╗██║██╔██╗ ██║███████║███████╗   ██║   ██║██║     ███████║
║ ██║   ██║██║██║╚██╗██║██╔══██║╚════██║   ██║   ██║██║     ██╔══██║
║ ╚██████╔╝██║██║ ╚████║██║  ██║███████║   ██║   ██║╚██████╗██║  ██║
║  ╚═════╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚═╝ ╚═════╝╚═╝  ╚═╝
║");
    opcao = tela.MostrarMenu(opcoes, 35, 10);

    switch (opcao)
    {
        case "0":
            break;
        case "1":
            bool entrou = tela.Login();

            if (entrou)
            {
                bool sair = false;
                while (!sair)
                {
                    opcao = tela.Home();
                    switch (opcao)
                    {
                        case "1":
                            string opcaoCadastro = tela.CadastrarUsuario();
                            if (int.Parse(opcaoCadastro) >= 0 && int.Parse(opcaoCadastro) <= 6)
                            {
                                switch (opcaoCadastro)
                                {
                                    case "0":
                                        break;
                                    case "1":
                                        tela.PrepararTela("CADASTRO DE USUARIO");
                                        tela.MontarMoldura(2, 2, 60, 15);
                                        tela.MostrarMensagem(4, 2, "Dados do novo usuario");
                                        if (opcaoCadastro == "1") clienteController.Cadastrar(5, 4, opcaoCadastro);
                                        else funcionarioController.Cadastrar(5, 4, opcaoCadastro);
                                        break;
                                }
                            }
                            break;
                        case "2":
                            tela.PrepararTela("CADASTRO DE AULA");
                            tela.MontarMoldura(2, 2, 60, 15);
                            tela.MostrarMensagem(4, 2, "Dados da nova aula");
                            tela.CadastrarAula();
                            break;
                        case "3":
                            tela.PrepararTela("VERIFICAR AGENDA");
                            tela.MontarMoldura(2, 2, 60, 15);
                            tela.VerificarAgendas();
                            break;
                        case "4":
                            string opcaoClientes = tela.VerificarClientes();
                            if (int.Parse(opcaoClientes) >= 0 && int.Parse(opcaoClientes) <= 1)
                            {
                                if (opcaoClientes == "1")
                                {
                                    tela.PrepararTela("LISTAR CLIENTES");
                                    tela.MontarMoldura(2, 2, 15, clienteController.clientes.Count * 2 + 4);
                                    clienteController.ListarClientes();
                                }
                                if (opcaoClientes == "2")
                                {
                                    tela.PrepararTela("APAGAR CLIENTE");
                                    tela.MontarMoldura(2, 2, 15, 25);
                                    string id = Tela.Perguntar(2, 2, "Digite o ID do cliente");
                                    clienteController.ApagarCliente(int.Parse(id));
                                }
                                if (opcaoClientes == "3")
                                {
                                    tela.PrepararTela("VER CLIENTE");
                                    tela.MontarMoldura(2, 2, 15, 25);
                                    string id = Tela.Perguntar(5, 5, "Digite o ID do cliente: ");
                                    clienteController.VerCliente(int.Parse(id));
                                }
                                if (opcaoClientes == "4")
                                {
                                    tela.PrepararTela("ALTERAR CLIENTE");
                                    tela.MontarMoldura(2, 2, 15, 25);
                                    clienteController.AlterarCliente();
                                }
                            }
                            break;
                        case "5":
                            string opcaoFuncionario = tela.VerificarFuncionarios();
                            if (int.Parse(opcaoFuncionario) >= 0 && int.Parse(opcaoFuncionario) <= 1)
                            {
                                if (opcaoFuncionario == "1")
                                {
                                    tela.PrepararTela("LISTAGER FUNCIONARIOS");
                                    tela.MontarMoldura(2, 2, 15, funcionarioController.funcionarios.Count * 2 + 4);
                                    funcionarioController.ListarFuncionarios();
                                }
                                if (opcaoFuncionario == "2")
                                {
                                    tela.PrepararTela("APAGAR FUNCIONARIO");
                                    tela.MontarMoldura(2, 2, 15, 25);
                                    string id = Tela.Perguntar(2, 2, "Digite o ID do cliente");
                                    funcionarioController.ApagarFuncionario(int.Parse(id));
                                }
                                if (opcaoFuncionario == "3")
                                {
                                    tela.PrepararTela("VER FUNCIONARIO");
                                    tela.MontarMoldura(2, 2, 15, 25);
                                    string id = Tela.Perguntar(5, 5, "Digite o ID do funcionario: ");
                                    funcionarioController.VerFuncionario(int.Parse(id));
                                }
                                if (opcaoFuncionario == "4")
                                {
                                    tela.PrepararTela("ALTERAR FUNCIONARIO");
                                    tela.MontarMoldura(2, 2, 15, 25);
                                    funcionarioController.AlterarFuncionario();
                                }
                            }
                            break;
                    }
                    if (opcao == "0")
                    {
                        sair = true;
                    }
                }
            }
            break;
        default:
            tela.MostrarMensagem(15, 25, "[Escolha inválida, pressione qualquer tecla para tentar novamente]");
            Console.ReadKey();
            break;
    }
    if (opcao == "0")
    {
        Console.Clear();
        return;
    }
}