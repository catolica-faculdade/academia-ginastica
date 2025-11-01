public class GeralController
{

    public List<Cliente> clientes;
    public List<Funcionario> funcionarios; 
    public List<Modalidade> modalidades;
    public List<Aula> aulas;
    public GeralController()
    {
        this.clientes = new List<Cliente>();
        this.funcionarios = new List<Funcionario>();
        this.modalidades = new List<Modalidade>();
        this.aulas = new List<Aula>();

        // Clientes
        this.clientes.Add(new Cliente("Gustavo Floriano", "12345678901", "gustavo.floriano@catolicasc.edu.br", "senha123", "47992654789", "R. Visc. de Taunay, 427 - Joinville - SC"));
        this.clientes.Add(new Cliente("Johann Gossen Ruth", "987654321", "johann.ruth@catolicasc.edu.br", "123456", "47978542635", "R. Visc. de Taunay, 427 - Centro, Joinville - SC"));
        this.clientes.Add(new Cliente("João Constantino Caetano", "34567890123", "joao.constantino@catolicasc.edu.br", "senha789", "47999887766", "R. Visc. de Taunay, 427 - Joinville - SC"));

        // Modalidades
        var modMusculacao = new Modalidade("Musculação", "Treino de força e hipertrofia.");
        var modSpinning = new Modalidade("Spinning", "Aula de bicicleta indoor com foco em cardio.");
        var modYoga = new Modalidade("Yoga", "Alongamento, respiração e relaxamento.");
        this.modalidades.Add(modMusculacao);
        this.modalidades.Add(modSpinning);
        this.modalidades.Add(modYoga);

        var func1 = new Funcionario("Carlos Mendes", "45678901234", "carlos.mendes@academia.com", "pass1", "47991110001", "R. A, 123", 3200m, Cargo.instrutor);
        var func2 = new Funcionario("Ana Ferreira", "56789012345", "ana.ferreira@academia.com", "pass2", "47991110002", "Av. B, 456", 3800m, Cargo.instrutor);
        var func3 = new Funcionario("Roberto Lima", "67890123456", "roberto.lima@academia.com", "pass3", "47991110003", "R. C, 789", 4200m, Cargo.admin);
        this.funcionarios.Add(func1);
        this.funcionarios.Add(func2);
        this.funcionarios.Add(func3);

        // Aulas
        this.aulas.Add(new Aula(
            "Musculação - Manhã",
            modMusculacao,
            func1,
            new DateTime(2025, 11, 03, 6, 30, 0),
            new DateTime(2025, 11, 03, 7, 30, 0),
            new List<Cliente> { this.clientes[0], this.clientes[1] },
            20
        ));

        this.aulas.Add(new Aula(
            "Spinning - Tarde",
            modSpinning,
            func2,
            new DateTime(2025, 11, 03, 18, 0, 0),
            new DateTime(2025, 11, 03, 19, 0, 0),
            new List<Cliente> { this.clientes[1], this.clientes[2] },
            15
        ));

        this.aulas.Add(new Aula(
            "Yoga - Noite",
            modYoga,
            func3,
            new DateTime(2025, 11, 03, 20, 0, 0),
            new DateTime(2025, 11, 03, 21, 0, 0),
            new List<Cliente>(),
            25
        ));

        this.aulas.Add(new Aula(
            "Aula em Andamento",
            modSpinning,            
            func2,                  
            DateTime.Now,
            DateTime.Now.AddHours(1),
            new List<Cliente> { this.clientes[0] }, 
            20
        ));
    }
}