using System.Runtime.InteropServices;

public class ModalidadeController
{
    public List<Modalidade> modalidades;
    Modalidade modalidade;

    public ModalidadeController()
    {
        this.modalidades = new List<Modalidade>();
    }

    public void CadastrarModalidade(int coluna, int li)
    {
        string nome = Tela.Perguntar(coluna, li, "Nome da Modalidade: ");
        string descricao = Tela.Perguntar(coluna, li + 2, "Descricao : ");

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
        if (id >= 0 && this.modalidades.Count >= id)
        {

            if (id == 0)
            {
                for (int i = 0; i < this.modalidades.Count; i++)
                {
                    Tela.MostrarMensagem(col, lin, $"{i + 1} Nome : {this.modalidades[i].nome}");
                    Tela.MostrarMensagem(col, lin + 1, $"Descricao : {this.modalidades[i].descricao}");
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
}