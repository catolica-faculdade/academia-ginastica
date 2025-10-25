Tela tela = new Tela(90,25);

string opcao;
List<string> opcoes = new List<string>();
opcoes.Add("1 - Entrar      ");
opcoes.Add("0 - Sair        ");

while (true)
{
    tela.PrepararTela("Academia de Ginástica");
    opcao = tela.MostrarMenu(opcoes, 2, 2);

    switch (opcao)
    {
        case "1":
            tela.Login();
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