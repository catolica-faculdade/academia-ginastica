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
            retorno.Add($"[ {momentoI:HH}:{momentoI:mm} | {momentoF:HH}:{momentoF:mm} ]");
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
            retorno.Add($"[ {momentoI:HH}:{momentoI:mm} | {momentoF:HH}:{momentoF:mm} ]");
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

            Tela.MostrarMensagem(ci+2, linhaAtual + 5, $"Total clientes: {a.clientes.Count}");

            Tela.MostrarMensagem(ci + 2, linhaAtual + 6, $"Lotacao: {a.lotacao}");

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

        tela.MontarMoldura(62, 3, 90, a.clientes.Count+5);
        Tela.MostrarMensagem(63, 3, $"[Total: {a.clientes.Count} | Listagem :]");
        for (int c = 0; c < a.clientes.Count; c++)
        {
            Tela.MostrarMensagem(63, 5 + c, $"{c+1} - {a.clientes[c].nomeCompleto}");
        }
        
        Tela.MostrarMensagem(col, lin + 5, $"Lotacao: {a.lotacao}");




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

        Aula aula = aulas[id - 1];
        tela.MontarMoldura(3, 3, 70, 20);
        Tela.MostrarMensagem(22, 18, "Digite 'Sair' para voltar...");

        Tela.MostrarMensagem(col, lin - 2, "[DIGITE 0 PARA MANTER O DADO] | [Aperte qualquer tecla para começar a trocar os dados]");
        Tela.MostrarMensagem(col, lin, $"Nome              : {aula.nome}");
        Tela.MostrarMensagem(col, lin + 2, $"Modalidade atual  : {aula.modalidade.nome}");
        Tela.MostrarMensagem(col, lin + 4, $"Instrutor atual   : {aula.instrutor.nomeCompleto}");
        Tela.MostrarMensagem(col, lin + 6, $"Data atual        : {aula.horarioInicio:dd/MM/yyyy}");
        Tela.MostrarMensagem(col, lin + 8, $"Horário Início    : {aula.horarioInicio:HH:mm}");
        Tela.MostrarMensagem(col, lin + 10, $"Horário Término   : {aula.horarioFim:HH:mm}");
        Tela.MostrarMensagem(col, lin + 12, $"Lotação atual     : {aula.lotacao}");

        Console.ReadKey();
        tela.ApagarArea(col + "Nome              :".Length, lin, col + $"Nome              : {aula.nome}".Length, lin);
        Console.SetCursorPosition(col + "Nome              : ".Length, lin);
        string novoNome = Console.ReadLine();
        if (string.Equals(novoNome.ToLower(), "sair")) return;
        if (!string.IsNullOrEmpty(novoNome) && novoNome != "0")
            aula.nome = novoNome;
        if(novoNome == "0")
            Tela.MostrarMensagem(col, lin, $"Nome              : {aula.nome}");

        bool modalidadeValida = false;
        while (!modalidadeValida)
        {
            List<string> listaModalidades = new List<string>();
            for (int i = 0; i < modalidadeController.modalidades.Count; i++)
                listaModalidades.Add($"{i + 1} - {modalidadeController.modalidades[i].nome}");

            tela.MostrarSubMenu(60, 2, 100, 4 + listaModalidades.Count, "Modalidades", listaModalidades);
            
            tela.ApagarArea(col + "Modalidade atual  :".Length, lin+2, col + $"Modalidade atual  : {aula.modalidade.nome}".Length, lin+2);
            
            string idModalidade = Tela.Perguntar(col, lin + 2, "Nova modalidade   : ");
            if (string.Equals(idModalidade.ToLower(), "sair")) return;

            if (idModalidade == "0")
            {
                Tela.MostrarMensagem(col, lin + 2, $"Modalidade atual  : {aula.modalidade.nome}");
                modalidadeValida = true;
            }
            else if (int.TryParse(idModalidade, out int idxMod) && idxMod > 0 && idxMod <= modalidadeController.modalidades.Count)
            {
                aula.modalidade = modalidadeController.modalidades[idxMod - 1];
                modalidadeValida = true;
            }
            tela.ApagarArea(60, 2, 100, 4+listaModalidades.Count);
        }

        bool instrutorValido = false;
        while (!instrutorValido)
        {
            List<string> listaInstrutores = new List<string>();
            for (int i = 0; i < funcionarioController.funcionarios.Count; i++)
                listaInstrutores.Add($"{i + 1} - {funcionarioController.funcionarios[i].nomeCompleto}");


            tela.MostrarSubMenu(60, 2, 100, 4 + listaInstrutores.Count, "Instrutores", listaInstrutores);

            tela.ApagarArea(col + "Instrutor atual   :".Length, lin+4, col + $"Instrutor atual   : {aula.instrutor.nomeCompleto}".Length, lin+4);
            
            string idInstrutor = Tela.Perguntar(col, lin + 4, "Novo instrutor    : ");
            if (string.Equals(idInstrutor.ToLower(), "sair")) return;

            if (idInstrutor == "0")
            {
                Tela.MostrarMensagem(col, lin + 4, $"Instrutor atual   : {aula.instrutor.nomeCompleto}");
                instrutorValido = true;
            }
            else if (int.TryParse(idInstrutor, out int idxInst) && idxInst > 0 && idxInst <= funcionarioController.funcionarios.Count)
            {
                aula.instrutor = funcionarioController.funcionarios[idxInst - 1];
                instrutorValido = true;
            }
            tela.ApagarArea(60, 2, 101, 4 + listaInstrutores.Count);
            tela.ReconstruirMoldura(3, 3, 70, 20);
        }

        tela.ApagarArea(col + "Data atual        : ".Length, lin+6, col + $"Data atual        : {aula.horarioInicio:dd/MM/yyyy}".Length, lin+6);
        string data = Tela.Perguntar(col, lin + 6, "Nova Data (DD/MM/AAAA) : ");
        if (string.Equals(data.ToLower(), "sair")) return;

        if (data == "0")
        {
            Tela.MostrarMensagem(col, lin + 6, $"Data atual        : {aula.horarioInicio:dd/MM/yyyy}");
        }
        
        tela.ApagarArea(col + "Horário Início    : ".Length, lin+8, col + $"Horário Início    : {aula.horarioInicio:HH:mm}".Length, lin+8);
        string horaInicio = Tela.Perguntar(col, lin + 8, "Novo Início (HH:MM) : ");
        if (string.Equals(horaInicio.ToLower(), "sair")) return;

        if (data != "0" && horaInicio != "0")
        {
            aula.horarioInicio = DateTime.Parse($"{data} {horaInicio}");
        }
        else
        {
            if (data == "0" && horaInicio != "0")
            {
                aula.horarioInicio = DateTime.Parse($"{aula.horarioInicio.Date:dd/MM/yyyy} {horaInicio}");
            }
            tela.ApagarArea(col + "Horário Início    : ".Length, lin+8, col + $"Horário Início    : {aula.horarioInicio:HH:mm}".Length, lin+8);
            Tela.MostrarMensagem(col, lin + 8, $"Novo Início (HH:MM) : {aula.horarioInicio:HH:mm}");
        }




        tela.ApagarArea(col + "Horário Término   : ".Length, lin+10, col + $"Horário Término   : {aula.horarioInicio:HH:mm}".Length, lin+10);
        string horaFim = Tela.Perguntar(col, lin + 10, "Novo Fim (HH:MM) : ");
        if (string.Equals(horaFim.ToLower(), "sair")) return;

        if (data != "0" && horaFim != "0")
        {
            aula.horarioFim = DateTime.Parse($"{data} {horaFim}");
        }
        else
        {
            if(data == "0" && horaFim != "0")
            {
                aula.horarioFim = DateTime.Parse($"{aula.horarioFim.Date:dd/MM/yyyy} {horaFim}");
            }
            tela.ApagarArea(col + "Horário Término   : ".Length, lin+10, col + $"Horário Término   : {aula.horarioInicio:HH:mm}".Length, lin+10);
            Tela.MostrarMensagem(col, lin + 10, $"Novo Fim (HH:MM) : {aula.horarioFim:HH:mm}");
        }
            

        if (data == "0" && horaInicio == "0" && horaFim == "0")
        {
            Tela.MostrarMensagem(col, lin + 6, $"Data atual        : {aula.horarioInicio:dd/MM/yyyy}");
        }
            
        




        tela.ApagarArea(col + "Lotação atual     :".Length, lin + 12, col + $"Lotação atual     : {aula.lotacao}".Length + 1, lin + 12); //.Length + 1 para caso o usuario digite uma letra
        Console.SetCursorPosition(col + "Lotação atual     : ".Length, lin + 12);
        string novaLotacao = Console.ReadLine();
        if (string.Equals(novaLotacao?.ToLower(), "sair"))
        {
            Console.Clear();
            return;
        }

        if (int.TryParse(novaLotacao, out int lotacao) && lotacao > 0)
            aula.lotacao = lotacao;

        if(novaLotacao == "0")
        {
            Tela.MostrarMensagem(col, lin + 12, $"Lotação atual     : {aula.lotacao}");
        }

        tela.MontarMoldura(60, 2, 110, 5 + aula.lotacao);
        Tela.MostrarMensagem(63, 2, "[CLIENTES]");

        List<Cliente> novosClientes = new List<Cliente>();
        var clienteAtual = 0;

        for (int c = 0; c < aula.lotacao; c++)
        {
            bool clienteValido = false;
            bool clienteVazio = false;

            string nomeCliente = (aula.clientes != null && c < aula.clientes.Count)
                ? aula.clientes[c].nomeCompleto
                : "[VAZIO]";

            while (!clienteValido)
            {
                Tela.MostrarMensagem(63, 4 + c, $"Cliente {c + 1}: {nomeCliente}");
                Tela.MostrarMensagem(col, lin - 2, "[DIGITE 0 PARA MANTER O DADO] | [DIGITE ? PARA LISTAR OS CLIENTES] | [DIGITE @ PARA NÃO CADASTRAR CLIENTE]");
                string novoCliente = Tela.Perguntar(63, 5 + c, "Novo ID: ");
                if (string.Equals(novoCliente.ToLower(), "sair"))
                {
                    Console.Clear(); 
                    return;
                }
                    

                if (novoCliente == "0")
                {
                    if (nomeCliente != "[VAZIO]")
                    {
                        novosClientes.Add(aula.clientes[c]);
                    }
                    clienteValido = true;
                }
                else if (novoCliente == "@")
                {
                    clienteValido = true;
                    clienteVazio = true;
                }
                else if (novoCliente == "?")
                {
                    this.clienteController.ListarClientes();

                    // redesenha a tela
                    tela.MontarMoldura(3, 3, 70, 20);
                    Tela.MostrarMensagem(col, lin - 2, "[DIGITE 0 PARA MANTER O DADO] | [Aperte qualquer tecla para começar a trocar os dados]");
                    Tela.MostrarMensagem(col, lin, $"Nome              : {aula.nome}");
                    Tela.MostrarMensagem(col, lin + 2, $"Modalidade atual  : {aula.modalidade.nome}");
                    Tela.MostrarMensagem(col, lin + 4, $"Instrutor atual   : {aula.instrutor.nomeCompleto}");
                    Tela.MostrarMensagem(col, lin + 6, $"Data atual        : {aula.horarioInicio:dd/MM/yyyy}");
                    Tela.MostrarMensagem(col, lin + 8, $"Horário Início    : {aula.horarioInicio:HH:mm}");
                    Tela.MostrarMensagem(col, lin + 10, $"Horário Término   : {aula.horarioFim:HH:mm}");
                    Tela.MostrarMensagem(col, lin + 12, $"Lotação atual     : {aula.lotacao}");
                    tela.MontarMoldura(60, 2, 110, 5 + aula.lotacao);
                    Tela.MostrarMensagem(63, 2, "[CLIENTES]");

                    // mostra os clientes já confirmados até agora
                    for (int j = 0; j < novosClientes.Count; j++)
                    {
                        Tela.MostrarMensagem(63, 4 + j, $"Cliente {j + 1}: {novosClientes[j].nomeCompleto}");
                    }

                    continue;
                }
                else
                {
                    int idCliente;
                    bool conversaoOk = int.TryParse(novoCliente, out idCliente);

                    if (!clienteVazio)
                    {
                        if (conversaoOk)
                        {
                            if (idCliente > 0 && idCliente <= clienteController.clientes.Count)
                            {
                                Cliente novo = clienteController.clientes[idCliente - 1];
                                novosClientes.Add(novo);
                                clienteValido = true;

                                Tela.MostrarMensagem(63, 4 + c, $"Cliente {c + 1}: {novo.nomeCompleto}     ");
                            }
                            else
                            {
                                Tela.MostrarMensagem(63, 7 + c, "ID inválido! Digite um número válido.");
                            }
                        }
                        else
                        {
                            Tela.MostrarMensagem(63, 7 + c, "Entrada inválida. Digite um número ou ?.");
                        }
                    }
                }
            }
        }


        if (novosClientes.Count > 0)
            aula.clientes = novosClientes;
        aulas[id - 1] = aula;

        Console.Clear();
    }
}