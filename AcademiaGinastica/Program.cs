Tela tela = new Tela(90,25);

string opcao;
List<string> opcoes = new List<string>();
opcoes.Add("1 - Entrar      ");
opcoes.Add("0 - Sair        ");

while (true)
{
    tela.PrepararTela("Academia de Ginástica");
    opcao = tela.MostrarMenu(opcoes, 35, 12);

    switch (opcao)
    {
        case "0":
            break;
        case "1":
            tela.Login();
            break;
        default:
            tela.MostrarMensagem(15, 20, "Escolha inválida, pressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
            break;
    }
    if (opcao == "0")
    {
        Console.Clear();
        return;
    }
}