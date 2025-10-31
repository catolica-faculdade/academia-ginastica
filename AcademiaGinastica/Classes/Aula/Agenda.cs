using System.Reflection.Metadata;
using System.Runtime.InteropServices;

public class Agenda
{
    private Cliente cliente;
    public List<Aula> aulas;

    public Agenda()
    {
        this.aulas = new List<Aula>();
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
}