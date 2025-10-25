public class Aula
{
    private int id;
    private string modalidade;
    public DateTime horario;
    public List<Cliente> clientes;
    private int lotacao;

    public Aula(string modalidade, DateTime horario, List<Cliente> clientes, int lotacao)
    {
        Console.WriteLine("teste Aula");
    }
}