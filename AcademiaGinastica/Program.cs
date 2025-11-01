﻿GeralController geralController = new GeralController();

ModalidadeController modalidadeController = new ModalidadeController(geralController.modalidades);
FuncionarioController funcionarioController = new FuncionarioController(geralController.funcionarios);
ClienteController clienteController = new ClienteController(geralController.clientes);
Agenda agenda = new Agenda(geralController.aulas, clienteController, funcionarioController, modalidadeController);
Tela tela = new Tela(90, 25, agenda, modalidadeController, funcionarioController, clienteController);

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
                                tela.PrepararTela("CADASTRO DE USUARIO");
                                tela.MontarMoldura(2, 2, 60, 19);
                                Tela.MostrarMensagem(4, 2, "Dados do novo usuario");
                                if (opcaoCadastro == "1") clienteController.Cadastrar(5, 4, opcaoCadastro);
                                else if (opcaoCadastro == "0") break;
                                else funcionarioController.Cadastrar(5, 4, opcaoCadastro);
                            }
                            break;
                        case "2":
                            tela.PrepararTela("CADASTRO DE AULA");
                            tela.MontarMoldura(2, 2, 65, 15);
                            Tela.MostrarMensagem(4, 2, "Dados da nova aula");
                            tela.CadastrarAula(5, 4);
                            break;
                        case "3":
                            string opcaoModalidade = tela.VerificarModalidades();
                            if (int.Parse(opcaoModalidade) >= 0 && int.Parse(opcaoModalidade) <= 4)
                            {
                                if (opcaoModalidade == "1")
                                {
                                    tela.PrepararTela("CRIAR MODALIDADE");
                                    tela.MontarMoldura(2, 2, 15, 10);
                                    modalidadeController.CadastrarModalidade(4,4);
                                }
                                if (opcaoModalidade == "2")
                                {
                                    tela.PrepararTela("APAGAR MODALIDADE");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(3, 3, "Digite o ID da modalidade : ");
                                    modalidadeController.ApagarModalidade(int.Parse(id));
                                }
                                if (opcaoModalidade == "3")
                                {
                                    tela.PrepararTela("VER MODALIDADE");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    Tela.MostrarMensagem(3, 3, "[Digite 0 para listar todas]");
                                    string id = Tela.Perguntar(3, 3, "Digite o ID da modalidade : ");
                                    if(int.Parse(id) == 0)
                                    {
                                        tela.MontarMoldura(2, 2, 35, modalidadeController.modalidades.Count * 2 + 4);
                                    }
                                    modalidadeController.VerModalidade(4, 4, int.Parse(id));
                                }
                                if (opcaoModalidade == "4")
                                {
                                    tela.PrepararTela("Lista de Modalidades");
                                    tela.MontarMoldura(2, 2, 65, 20);

                                    int qtdModalidades = modalidadeController.modalidades.Count;
                                    if (qtdModalidades == 0)
                                    {
                                        string op = Tela.Perguntar(4, 4, "Nenhuma modalidade cadastrada. Deseja cadastrar? (S/N): ");

                                        while (!string.Equals(op, "s") && !string.Equals(op, "n"))
                                        {
                                            if (string.Equals(op.ToLower(), "s"))
                                            {
                                                modalidadeController.CadastrarModalidade(4, 6);
                                            }

                                            if (string.Equals(op.ToLower(), "n")) return;

                                            op = Tela.Perguntar(4, 6, "Opção inválida. Digite novamente (S/N)");
                                        }
                                        modalidadeController.CadastrarModalidade(4, 6);
                                        tela.ApagarArea(4, 6, 64, 19);
                                        modalidadeController.VerModalidades(4, 6);
                                    }
                                    else
                                    {
                                        modalidadeController.VerModalidades(4, 4);
                                    }

                                }
                                if (opcaoModalidade == "5")
                                {
                                    tela.PrepararTela("ALTERAR MODALIDADE");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(3, 3, "Digite o ID da modalidade : ");
                                    modalidadeController.AlterarModalidade(4, 4, int.Parse(id));

                                }
                            }
                            break;
                        case "4":
                            string opcaoAgenda = tela.VerificarAgenda();
                            if (int.Parse(opcaoAgenda) >= 0 && int.Parse(opcaoAgenda) <= 4)
                            {
                                if (opcaoAgenda == "1")
                                {
                                    tela.PrepararTela("LISTAR AGENDA");
                                    tela.MontarMoldura(2, 2, 15, 10);
                                    agenda.ListarAgenda(4,4, tela);
                                }
                                if (opcaoAgenda == "2")
                                {
                                    tela.PrepararTela("APAGAR AGENDA");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(3, 3, "Digite o ID da modalidade : ");
                                    agenda.ApagarAula(int.Parse(id));
                                }
                                if (opcaoAgenda == "3")
                                {
                                    tela.PrepararTela("VER AGENDA");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    Tela.MostrarMensagem(3, 3, "[Digite 0 para listar todas]");
                                    string id = Tela.Perguntar(3, 3, "Digite o ID da modalidade : ");
                                    if(int.Parse(id) == 0)
                                    {
                                        tela.MontarMoldura(2, 2, 35, modalidadeController.modalidades.Count * 2 + 4);
                                    }
                                    agenda.VerAula(4, 4, int.Parse(id), tela);
                                }
                                if (opcaoAgenda == "4")
                                {
                                    tela.PrepararTela("ALTERAR AGENDA");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(3, 3, "Digite o ID da modalidade : ");
                                    agenda.AlterarAgenda(4, 4, int.Parse(id), tela);

                                }
                            }
                            break;
                        case "5":
                            string opcaoClientes = tela.VerificarClientes();
                            if (int.Parse(opcaoClientes) >= 0 && int.Parse(opcaoClientes) <= 4)
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
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(3, 3, "Digite o ID do cliente : ");
                                    clienteController.ApagarCliente(int.Parse(id));
                                }
                                if (opcaoClientes == "3")
                                {
                                    tela.PrepararTela("VER CLIENTE");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(3, 3, "Digite o ID do cliente : ");
                                    clienteController.VerCliente(int.Parse(id));
                                }
                                if (opcaoClientes == "4")
                                {
                                    tela.PrepararTela("ALTERAR CLIENTE");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(3, 3, "Digite o ID do cliente : ");
                                    clienteController.AlterarCliente(int.Parse(id));
                                }
                            }
                            break;
                        case "6":
                            string opcaoFuncionario = tela.VerificarFuncionarios();
                            if (int.Parse(opcaoFuncionario) >= 0 && int.Parse(opcaoFuncionario) <= 4)
                            {
                                if (opcaoFuncionario == "1")
                                {
                                    tela.PrepararTela("LISTAR FUNCIONARIOS");
                                    tela.MontarMoldura(2, 2, 15, funcionarioController.funcionarios.Count * 2 + 4);
                                    funcionarioController.ListarFuncionarios();
                                }
                                if (opcaoFuncionario == "2")
                                {
                                    tela.PrepararTela("APAGAR FUNCIONARIO");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(4, 3, "Digite o ID do funcionario");
                                    funcionarioController.ApagarFuncionario(int.Parse(id));
                                }
                                if (opcaoFuncionario == "3")
                                {
                                    tela.PrepararTela("VER FUNCIONARIO");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(4, 3, "Digite o ID do funcionario: ");
                                    funcionarioController.VerFuncionario(int.Parse(id));
                                }
                                if (opcaoFuncionario == "4")
                                {
                                    tela.PrepararTela("ALTERAR FUNCIONARIO");
                                    tela.MontarMoldura(2, 2, 35, 4);
                                    string id = Tela.Perguntar(4, 3, "Digite o ID do funcionario: ");
                                    funcionarioController.AlterarFuncionario(int.Parse(id));
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
            Tela.MostrarMensagem(15, 25, "[Escolha inválida, pressione qualquer tecla para tentar novamente]");
            Console.ReadKey();
            break;
    }
    if (opcao == "0")
    {
        Console.Clear();
        return;
    }
}