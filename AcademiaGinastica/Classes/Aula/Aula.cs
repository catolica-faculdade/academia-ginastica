public class Aula
{
    private int id;
    private string nome;
    private Modalidade modalidade;
    private Funcionario instrutor;
    public DateTime horarioInicio;
    public DateTime horarioFim;
    public List<Cliente> clientes;
    private int lotacao;

    public Aula(string modalidade, DateTime horario, List<Cliente> clientes, int lotacao)
    {
        Console.WriteLine("teste Aula");
    }
}