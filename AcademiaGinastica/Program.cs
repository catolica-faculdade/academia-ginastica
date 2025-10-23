Tela tela = new Tela(80,25);
Usuario usuario = new Usuario();

string opcao;
List<string> opcoes = new List<string>();
opcoes.Add("1 - Entrar      ");
opcoes.Add("2 - Cadastrar-se");
opcoes.Add("0 - Sair        ");

while (true)
{
    tela.PrepararTela("Academia de Ginástica");
    opcao = tela.MostrarMenu(opcoes, 2, 2);
    Console.ReadKey();

    switch (opcao)
    {
        case "1":
            usuario.Login();
            break;
        case "2":
            usuario.Cadastrar();
            break;
        case "0":
            break;
        default:
            tela.MostrarMensagem(10, 10, "Escolha inválida, digite 1 (Entrar) ou 2 (Cadastrar-se)");
            break;
    }
    if (opcao == "0")
    {
        Console.Clear();
        return;
    }
}