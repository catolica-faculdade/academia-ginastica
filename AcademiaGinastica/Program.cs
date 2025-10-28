using System.Reflection.Metadata;

Tela tela = new Tela(90,25);

string opcao;
List<string> opcoes = new List<string>();
opcoes.Add("1 - Entrar      ");
opcoes.Add("0 - Sair        ");

#if WINDOWS
        try
        {
            int larguraDesejada = 180;
            int alturaDesejada = 50;

            // Garante que o tamanho pedido não ultrapasse o máximo
            int larguraMax = Console.LargestWindowWidth;
            int alturaMax = Console.LargestWindowHeight;

            int larguraFinal = Math.Min(larguraDesejada, larguraMax);
            int alturaFinal = Math.Min(alturaDesejada, alturaMax);

            Console.SetBufferSize(larguraFinal, alturaFinal);
            Console.SetWindowSize(larguraFinal, alturaFinal);
        }
        catch
        {
            // Ignora se a plataforma não suportar
        }
#endif
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