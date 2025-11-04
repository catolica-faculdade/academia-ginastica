using System.Runtime.InteropServices;

public class ModalidadeController
{
    public List<Modalidade> modalidades;
    Modalidade modalidade;
    Tela tela;

    public ModalidadeController(List<Modalidade> modalidades)
    {
        this.modalidades = modalidades ?? new List<Modalidade>();
        this.tela = new Tela();
    }

    public void CadastrarModalidade(int coluna, int li)
    {
        string nome = Tela.Perguntar(coluna, li, "Nome da Modalidade: ");
        if (string.Equals(nome.ToLower(), "sair")) return;
        string descricao = Tela.Perguntar(coluna, li + 2, "Descricao : ");
        if (string.Equals(descricao.ToLower(), "sair")) return;

        Modalidade novaModalidade = new Modalidade(
            nome,
            descricao
        );

        this.modalidades.Add(novaModalidade);
    }
    
    public void AlterarModalidade(int col, int lin, int id)
    {
        this.modalidade.nome = Tela.Perguntar(col, lin, "Novo nome: ");
        this.modalidade.descricao = Tela.Perguntar(col, lin, "Nova descricao: ");

        this.modalidades[id - 1] = this.modalidade;
    }

    public void ApagarModalidade(int id)
    {
        this.modalidades.RemoveAt(id - 1);
    }
    public void VerModalidade(int col, int lin, int id)
    {
        if (id >= 0 && this.modalidades.Count > id)
        {
            if (id == 0)
            {
                tela.MontarMoldura(60, 2, 120, 60 + this.modalidades.Count);
                for (int i = 0; i < this.modalidades.Count; i++)
                {
                    Tela.MostrarMensagem(61, 2 + i, $"{i + 1} Nome : {this.modalidades[i].nome}");
                    Tela.MostrarMensagem(61, 2 + 2 + i, $"Descricao : {this.modalidades[i].descricao}");
                }
            }
            else
            {
                Tela.MostrarMensagem(col, lin, $"Nome : {this.modalidades[id - 1].nome}");
                Tela.MostrarMensagem(col, lin + 1, $"Descricao : {this.modalidades[id - 1].descricao}");
            }
        }
        else
        {
            Tela.MostrarMensagem(col, lin + 1, "Id invalido");
        }
        Console.ReadKey();
    }

    public void VerModalidades(int col, int lin)
    {
        int qtdModalidades = this.modalidades.Count;
        int linha = lin;
        tela.MontarMoldura(col - 1, lin - 1, col + 40, lin + ( qtdModalidades + 2)* 2);
        for (int i = 0; i < qtdModalidades; i++)
        {
            Tela.MostrarMensagem(col, linha, $"{i + 1} Nome : {this.modalidades[i].nome}");
            Tela.MostrarMensagem(col, linha + 1, $"Descricao : {this.modalidades[i].descricao}");
            linha += 3;
        }
        Tela.MostrarMensagem(4, linha, "Digite qualquer tecla para sair");
        Console.ReadKey();
    }
}