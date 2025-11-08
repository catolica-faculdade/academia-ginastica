public class Aula
{
    public string nome;
    public Modalidade modalidade;
    public Funcionario instrutor;
    public DateTime horarioInicio;
    public DateTime horarioFim;
    public List<Cliente> clientes;
    public int lotacao;

    public Aula(string nome, Modalidade modalidade, Funcionario instrutor, DateTime horarioInicio, DateTime horarioFim, List<Cliente> clientes, int lotacao)
    {
        this.nome = nome;
        this.modalidade = modalidade;
        this.instrutor = instrutor;
        this.horarioInicio = horarioInicio;
        this.horarioFim = horarioFim;
        this.clientes = clientes ?? new List<Cliente>();
        this.lotacao = lotacao;

    }
    public Aula()
    { 
    modalidade = new Modalidade();
    instrutor = new Funcionario();
    clientes = new List<Cliente>();

        
    }
}