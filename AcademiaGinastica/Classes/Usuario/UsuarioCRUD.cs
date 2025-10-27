public class UsuarioCRUD
{
    private List<Usuario> usuarios;
    private Usuario usuario;
    private int posicao;
    private List<string> dados = new List<string>();
    private Tela tela;

    public UsuarioCRUD()
    {
        this.usuarios = new List<Usuario>();
        this.usuario = new Usuario();
        this.posicao = -1;
        this.dados.Add("Nome completo   :");
        this.dados.Add("CPF             :");
        this.dados.Add("Email           :");
        this.dados.Add("Telefone        :");
        this.dados.Add("Cargo           :");

    }
}