using AnalisadorCommitsGit.Historico;
using ConsoleTables;

namespace AnalisadorCommitsGit;

public class Tabela: ITabela
{
    private readonly List<string> _colunas;
    private readonly List<Ranking> _linhas;

    public Tabela()
    {
        _colunas = new List<string>();
        _linhas = new List<Ranking>();
    }
    public ITabela AddColumn(string descricao)
    {
        _colunas.Add(descricao);
        return this;
    }

    public ITabela AddRow(Ranking dados)
    {
        _linhas.Add(dados);
        return this;
    }



    public void Criar()
    {
        var tabela = new ConsoleTable(_colunas.ToArray());
        
        foreach (var linha in _linhas.Take(10))
            tabela.AddRow(linha.Nome, linha.Quantidade);
        
        tabela.Write();
        
        this.Dispose();
    }

    public void Dispose()
    {
        _colunas.Clear();
        _linhas.Clear();
    }
}