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
        int lf = li + (this.aulas.Count * (alturaPorAgenda + espacamento)); 

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
            Tela.MostrarMensagem(ci + 2, linhaAtual + 1, $"Modalidade: {a.modalidade.descricao.ToString()}");
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
            Tela.MostrarMensagem(62, 5+c, $"Clientes: {a.clientes[c].nomeCompleto}");
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
        if (id <= 0 || id > aulas.Count)
        {
            Tela.MostrarMensagem(4, 4, "Aula inválida!");
            Console.ReadKey();
            return;
        }

        Aula aula = this.aulas[id - 1];
        tela.MontarMoldura(3, 3, 70, 20);

        Tela.MostrarMensagem(col, lin - 2, "[DIGITE 0 PARA MANTER O DADO]");
        Tela.MostrarMensagem(col, lin, $"Nome              : {aula.nome}");
        Tela.MostrarMensagem(col, lin + 2, $"ID da Modalidade  : {aula.modalidade.nome}");
        Tela.MostrarMensagem(col, lin + 4, $"ID do Instrutor   : {aula.instrutor.nomeCompleto}");
        Tela.MostrarMensagem(col, lin + 6, $"Data (DD/MM/AAAA) : {aula.horarioInicio:dd/MM/yyyy}");
        Tela.MostrarMensagem(col, lin + 8, $"Horário de Início (HH:MM): {aula.horarioInicio:HH:mm}");
        Tela.MostrarMensagem(col, lin + 10, $"Horário de Término (HH:MM): {aula.horarioFim:HH:mm}");
        Tela.MostrarMensagem(col, lin + 12, $"Lotação           : {aula.lotacao}");

        Console.SetCursorPosition(col + "Nome              : ".Length, lin);
        string novoNome = Console.ReadLine();
        if (!string.IsNullOrEmpty(novoNome) && novoNome != "0")
            aula.nome = novoNome;

        Console.SetCursorPosition(col + "ID da Modalidade  : ".Length, lin + 2);
        if (int.TryParse(Console.ReadLine(), out int novaModalidade) && novaModalidade > 0)
            aula.modalidade = modalidadeController.modalidades[novaModalidade - 1];

        Console.SetCursorPosition(col + "ID do Instrutor   : ".Length, lin + 4);
        if (int.TryParse(Console.ReadLine(), out int novoInstrutor) && novoInstrutor > 0)
            aula.instrutor = funcionarioController.funcionarios[novoInstrutor - 1];

        string data = Tela.Perguntar(col, lin + 6, "Data (DD/MM/AAAA) : ");
        string horaInicio = Tela.Perguntar(col, lin + 8, "Horário de Início (HH:MM): ");
        string horaFim = Tela.Perguntar(col, lin + 10, "Horário de Término (HH:MM): ");

        if (data != "0" && horaInicio != "0")
            aula.horarioInicio = DateTime.Parse($"{data} {horaInicio}");
        if (data != "0" && horaFim != "0")
            aula.horarioFim = DateTime.Parse($"{data} {horaFim}");

        Console.SetCursorPosition(col + "Lotação           : ".Length, lin + 12);
        if (int.TryParse(Console.ReadLine(), out int novaLotacao) && novaLotacao > 0)
            aula.lotacao = novaLotacao;

        tela.MontarMoldura(62, 3, 110, 5 + aula.lotacao);
        Tela.MostrarMensagem(63, 3, "[CLIENTES]");
        Tela.MostrarMensagem(62, 2, "[Digite 0 para manter o cliente]");

        List<Cliente> novosClientes = new List<Cliente>();
        for (int c = 0; c < aula.clientes.Count; c++)
        {
            Tela.MostrarMensagem(63, 5 + c, $"Cliente {c + 1}: {aula.clientes[c].nomeCompleto}");
            string novoCliente = Tela.Perguntar(63 + $"Cliente {c + 1}: {aula.clientes[c].nomeCompleto}".Length, 5 + c, "| Novo ID: ");
            if (novoCliente != "0" && int.TryParse(novoCliente, out int idCliente))
            {
                if (idCliente > 0 && idCliente <= clienteController.clientes.Count)
                    novosClientes.Add(clienteController.clientes[idCliente - 1]);
            }
        }

        if (novosClientes.Count > 0)
            aula.clientes = novosClientes;

        aulas[id - 1] = aula;
    }
}