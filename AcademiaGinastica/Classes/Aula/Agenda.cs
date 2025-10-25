public class Agenda
{
    private int id;
    private List<Aula> aulas;

    public Agenda()
    {
        Console.WriteLine("teste agenda");
    }

    public void MostrarAgenda(DateTime dataLimite, bool mostrarClientes)
    {
        for(int i = 1; i <= this.aulas.Count; i++)
        {
            if (dataLimite <= this.aulas[i].horario)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("HORARIO  : " + this.aulas[i].horario);
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
    }
}