Tela tela = new Tela(90, 25);
UsuarioController usuarioController = new UsuarioController();

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
                                        usuarioController.Cadastrar(5, 4, opcaoCadastro);
                                        break;
                                }
                            }
                            break;
                        case "2":
                            tela.CadastrarAula();
                            break;
                        case "3":
                            tela.VerificarAgendas();
                            break;
                        case "4":
                            string opcaoClientes = tela.VerificarClientes();
                            if (int.Parse(opcaoClientes) >= 0 && int.Parse(opcaoClientes) <= 1)
                            {
                                if (opcaoClientes != "0")
                                {
                                    tela.PrepararTela("CADASTRO DE USUARIO");
                                    tela.MontarMoldura(2, 2, 15, usuarioController.usuarios.Count * 2 + 4);
                                    usuarioController.ListarUsuarios();
                                    Console.ReadKey();
                                }
                            }
                            break;
                        case "5":
                            tela.VerificarFuncionarios();
                            break;
                        case "6":
                            tela.VerificarFuncionarios();
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