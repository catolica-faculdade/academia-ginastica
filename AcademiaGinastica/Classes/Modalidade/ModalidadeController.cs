using System.ComponentModel.DataAnnotations;
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
        string nome = "";
        string descricao = "";
        bool nomeValido = false;
        while (!nomeValido)
        {
            tela.ApagarArea(coluna + "Nome da Modalidade : ".Length, li, coluna + "Nome da Modalidade : ".Length + nome.Length, li);
            nome = Tela.Perguntar(coluna, li, "Nome da Modalidade : ");
            if (string.Equals(nome.ToLower(), "sair")) return;
            if (nome == "" || nome.Length <= 3)
            {
                Tela.MostrarMensagem(coluna, li + 6, "[NOME INVÁLIDO, DIGITE NOVAMENTE]");
            }
            else
            {
                nomeValido = true;
            }
        }

        bool descricaoValida = false;
        while (!descricaoValida)
        {
            tela.ApagarArea(coluna + "Descricao : ".Length, li + 2, coluna + "Descricao : ".Length + descricao.Length, li + 2);
            descricao = Tela.Perguntar(coluna, li + 2, "Descricao : ");
            if (string.Equals(descricao.ToLower(), "sair")) return;
            if (descricao == "" || descricao.Length <= 3)
            {
                Tela.MostrarMensagem(coluna, li + 6, "[DESC. INVÁLIDO, DIGITE NOVAMENTE]");
            }
            else
            {
                descricaoValida = true;
            }
        }

        Modalidade novaModalidade = new Modalidade(
            nome,
            descricao
        );

        this.modalidades.Add(novaModalidade);
    }

    public void AlterarModalidade(int col, int lin, int id)
    {
        bool nomeValido = false;
        this.modalidade = this.modalidades[id - 1];

        Tela.MostrarMensagem(col, lin+1, $"Nome: {this.modalidade.nome}");
        Tela.MostrarMensagem(col, lin+3, $"Descrição: {this.modalidade.descricao}");

        Tela.MostrarMensagem(col, lin + 10, "[APERTE QUALQUER TECLA PARA COMEÇAR A ALTERAR]");
        Console.ReadKey();


        while (!nomeValido)
        {
            tela.ApagarArea(col + "Nome: ".Length, lin+1, col + "Nome: ".Length + this.modalidade.nome.Length, lin+1);
            this.modalidade.nome = Tela.Perguntar(col, lin+1, "Novo nome : ");
            if (string.Equals(this.modalidade.nome.ToLower(), "sair")) return;
            if (this.modalidade.nome == "" || this.modalidade.nome.Length <= 3)
            {
                Tela.MostrarMensagem(col, lin + 6, "NOME INVÁLIDO, DIGITE NOVAMENTE");
            }
            else
            {
                nomeValido = true;
            }
        }

        bool descricaoValida = false;
        while (!descricaoValida)
        {
            tela.ApagarArea(col + "Descrição: ".Length, lin + 3, col + "Descrição: ".Length + this.modalidade.descricao.Length, lin + 3);
            this.modalidade.descricao = Tela.Perguntar(col, lin + 3, "Nova descricao : ");
            if (string.Equals(this.modalidade.descricao.ToLower(), "sair")) return;
            if (this.modalidade.descricao == "" || this.modalidade.descricao.Length <= 3)
            {
                Tela.MostrarMensagem(col, lin + 6, "DESCRIÇÃO INVÁLIDO, DIGITE NOVAMENTE");
            }
            else
            {
                descricaoValida = true;
            }
        }

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
        tela.MontarMoldura(col - 1, lin - 1, col + 40, lin + (qtdModalidades + 2) * 2);
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