using System.Reflection.Metadata;
using System.Runtime.InteropServices;

public class Agenda
{
    public List<Aula> aulas;
    public ClienteController clienteController;
    public FuncionarioController funcionarioController;
    public ModalidadeController modalidadeController;

    public Agenda(List<Aula> aulas, ClienteController clienteController, FuncionarioController funcionarioController, ModalidadeController modalidadeController)
    {
        this.aulas = aulas ?? new List<Aula>();
        this.clienteController = clienteController;
        this.funcionarioController = funcionarioController;
        this.modalidadeController = modalidadeController;
    }
    
    public void CadastrarAula(Aula novaAula)
    {
        this.aulas.Add(novaAula);
    }

    public void VerAgenda(DateTime dataLimite, bool mostrarClientes)
    {
        for (int i = 1; i < this.aulas.Count; i++)
        {
            if (dataLimite <= this.aulas[i].horarioInicio)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("HORARIO  : " + this.aulas[i].horarioInicio);
                Console.WriteLine("AULA     : " + aulas[i]);
                if (mostrarClientes)
                {
                    Console.WriteLine("CLIENTES : ");
                    for (int j = 1; j <= this.aulas[i].clientes.Count; j++)
                    {
                        Console.WriteLine(j + " - " + aulas[i].clientes[j]);
                    }
                }
                Console.WriteLine("------------------------");
            }
        }
        Console.ReadKey();
    }

    public void VerAgendaComFiltro(DateTime dataLimite, bool mostrarClientes)
    {
        for (int i = 1; i <= this.aulas.Count; i++)
        {
            if (dataLimite <= this.aulas[i].horarioInicio)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("HORARIO  : " + this.aulas[i].horarioInicio);
                Console.WriteLine("AULA     : " + aulas[i]);
                if (mostrarClientes)
                {
                    Console.WriteLine("CLIENTES : ");
                    for (int j = 1; j <= this.aulas[i].clientes.Count; j++)
                    {
                        Console.WriteLine(j + " - " + aulas[i].clientes[j]);
                    }
                }
                Console.WriteLine("------------------------");
            }
        }
        Console.ReadKey();
    }

    public List<string> AcontecendoAgora()
    {
        DateTime agora = DateTime.Now;
        List<string> retorno = new List<string>();
        List<Aula> aulasAtuais = aulas
            .Where(x => x.horarioInicio <= agora && x.horarioFim >= agora)
            .ToList();

        if (aulasAtuais.Count == 0)
            return new List<string>();
        for(int i = 0; i < aulasAtuais.Count; i++)
        {
            var momentoI = aulasAtuais[i].horarioInicio;
            var momentoF = aulasAtuais[i].horarioFim;
            retorno.Add($"Aula : {aulasAtuais[i].nome}");
            retorno.Add($"[ {momentoI.Hour}:{momentoI.Minute} | {momentoF.Hour}:{momentoF.Minute} ]");
        }
        
        return retorno;
    }

    public List<string> Agendamentos(int qtd)
    {
        DateTime agora = DateTime.Now;
        List<string> retorno = new List<string>();

        List<Aula> aulasAtuais = this.aulas
            .Where(x => x.horarioInicio.Hour >= agora.Hour)
            .Take(qtd)
            .ToList();

        if (aulasAtuais.Count == 0)
            return new List<string>();
        for (int i = 0; i < aulasAtuais.Count; i++)
        {
            var momentoI = aulasAtuais[i].horarioInicio;
            var momentoF = aulasAtuais[i].horarioFim;
            retorno.Add($"Aula : {aulasAtuais[i].nome}");
            retorno.Add($"[ {momentoI.Hour}:{momentoI.Minute} | {momentoF.Hour}:{momentoF.Minute} ]");
        }

        return retorno;

    }
    
    public void ListarAgenda(int ci, int li, Tela tela)
    {
        if (this.aulas.Count == 0)
        {
            tela.PrepararTela("LISTA DE AULAS");
            tela.MontarMoldura(2, 2, 80, 10);
            Tela.MostrarMensagem(5, 5, "Não há aulas cadastrados.");
            Console.ReadKey();
            return;
        }

        int larguraMoldura = 90;
        
        int cf = ci + larguraMoldura; 
        int alturaPorAgenda = 10;
        int espacamento = 1;    
        int margemRodape = 4;     
        int lf = li + (this.aulas.Count * (alturaPorAgenda + espacamento)) + margemRodape; 

        Console.Clear();


        tela.MontarMoldura(ci, li, cf, lf);

        string titulo = "LISTA DE AULAS";
        int colTitulo = ci + 1 + (larguraMoldura - titulo.Length) / 2;
        Tela.MostrarMensagem(colTitulo, li + 1, titulo);

        int linhaAtual = li + 3;
        for (int i = 0; i < this.aulas.Count; i++)
        {
            var a = this.aulas[i];

            Tela.MostrarMensagem(ci + 2, linhaAtual, $"{i + 1}. {a.nome}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 1, $"CPF: {a.modalidade.descricao.ToString()}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 2, $"Instrutor: {a.instrutor.nomeCompleto}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 3, $"Horario de Inicio: {a.horarioInicio}");
            Tela.MostrarMensagem(ci + 2, linhaAtual + 4, $"Horario de Termino: {a.horarioFim}");

            for(int c = 0; c < a.clientes.Count; c++)
            {
                Tela.MostrarMensagem(ci + 2, linhaAtual + 4, $"Clientes: {a.clientes[c].nomeCompleto}");
            }

            Tela.MostrarMensagem(ci + 2, linhaAtual + 5, $"Lotacao: {a.lotacao}");

            linhaAtual += alturaPorAgenda + espacamento;
        }

        Tela.MostrarMensagem(ci + 2, lf, "[Pressione qualquer tecla para voltar]");
        Console.ReadKey();
        Console.Clear();
    }

    public void VerAula(int col, int lin, int indice, Tela tela)
    {
       if (indice < 0 || indice > aulas.Count)
        {
            Tela.MostrarMensagem(4, 4, "Aula invalido!");
            Console.ReadKey();
            return;
        }

        Aula a = aulas[indice-1];

        tela.PrepararTela("DETALHES DA AULA");
        tela.MontarMoldura(3, 3, 70, 20);


        Tela.MostrarMensagem(col, lin,     $"Nome: {a.nome}");
        Tela.MostrarMensagem(col, lin + 1, $"CPF: {a.modalidade.descricao.ToString()}");
        Tela.MostrarMensagem(col, lin + 2, $"Instrutor: {a.instrutor.nomeCompleto}");
        Tela.MostrarMensagem(col, lin + 3, $"Horario de Inicio: {a.horarioInicio}");
        Tela.MostrarMensagem(col, lin + 4, $"Horario de Termino: {a.horarioFim}");
        for (int c = 0; c < a.clientes.Count; c++)
        {
            Tela.MostrarMensagem(62, 6+c, $"Clientes: {a.clientes[c].nomeCompleto}");
        }
        Tela.MostrarMensagem(col, lin + 4, $"Lotacao: {a.lotacao}");




        Tela.MostrarMensagem(col, lin + 12, "[Pressione qualquer tecla para voltar]");
        Console.ReadKey();
        Console.Clear();
    }
    public void ApagarAula(int id)
    {
        this.aulas.RemoveAt(id - 1);
    }
    public void AlterarAgenda(int col, int lin, int id, Tela tela)
    {
        Console.Clear();
        if (id < 0 || id > aulas.Count)
        {
            Tela.MostrarMensagem(4, 4, "Cliente invalido!");
            Console.ReadKey();
            return;
        }

        Aula aula = this.aulas[id - 1];

        tela.MontarMoldura(3, 3, 70, 20);

        Tela.MostrarMensagem(col, lin,      $"Nome              : {aula.nome}");
        Tela.MostrarMensagem(col, lin + 2,  $"Modalidade        : {aula.modalidade}");
        Tela.MostrarMensagem(col, lin + 4,  $"ID do Instrutor   : {aula.instrutor}");
        Tela.MostrarMensagem(col, lin + 6,  $"Horario de Inicio : {aula.horarioInicio}");
        Tela.MostrarMensagem(col, lin + 8,  $"Horario de Termino: {aula.horarioFim}");
        Tela.MostrarMensagem(col, lin + 10,  $"lotacao           : {aula.lotacao}");

        

        Console.SetCursorPosition(col + "Nome              : ".Length, lin);
        aula.nome = Console.ReadLine();
        
        Console.SetCursorPosition(col + "Modalidade        : ".Length, lin + 2);
        int novaModalidade = int.Parse(Console.ReadLine());
        aula.modalidade = modalidadeController.modalidades[novaModalidade-1];

        Console.SetCursorPosition(col + "ID do Instrutor   : ".Length, lin + 4);
        int novoInstrutor = int.Parse(Console.ReadLine());
        aula.instrutor = this.funcionarioController.funcionarios[novoInstrutor-1];

        Console.SetCursorPosition(col + "Horario de Inicio : ".Length, lin+6);
        aula.horarioInicio = DateTime.Parse(Console.ReadLine());

        Console.SetCursorPosition(col + "Horario de Termino: ".Length, lin+8);
        aula.horarioFim = DateTime.Parse(Console.ReadLine());

        Console.SetCursorPosition(col + "Lotacao           : ".Length, lin+10);
        aula.lotacao = int.Parse(Console.ReadLine());


        tela.MontarMoldura(61, 3, 105, 5 + aula.lotacao);
        Tela.MostrarMensagem(62, 3, "[CLIENTES]");
        List<Cliente> novosClientes = new List<Cliente>();
        
        Tela.MostrarMensagem(61, 2, "[Digite 0 para manter o cliente]");
        for (int c = 0; c < aula.clientes.Count; c++)
        {
            Tela.MostrarMensagem(62, 6+c, $"Clientes: {aula.clientes[c].nomeCompleto} | {c + 1}");
            var novoCliente = Tela.Perguntar(62 + $"Clientes: {aula.clientes[c].nomeCompleto} | {c + 1}".Length, 6 + c, " -> Novo ID: ");
            if(novoCliente != "0")
            {
                novosClientes.Add(clienteController.clientes[int.Parse(novoCliente)-1]);
            }
        }

        aulas[id - 1] = aula;
    }



}