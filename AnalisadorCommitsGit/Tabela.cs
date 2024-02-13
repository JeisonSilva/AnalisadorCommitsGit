using AnalisadorCommitsGit.Historico;
using ConsoleTables;

namespace AnalisadorCommitsGit;

public class Tabela: ITabela
{
    private readonly List<string> _colunas;
    private readonly List<string> _linhas;

    public Tabela()
    {
        _colunas = new List<string>();
        _linhas = new List<string>();
    }
    public ITabela AddColumn(string descricao)
    {
        _colunas.Add(descricao);
        return this;
    }

    public ITabela AddDados(string texto)
    {
        _linhas.Add(texto);
        return this;
    }

    public void Criar()
    {
        var table = new ConsoleTable(_colunas.ToArray());
        table.AddRow(_linhas.ToArray());
        
        table.Write();
        
        this.Dispose();
    }

    public void Dispose()
    {
        _colunas.Clear();
        _linhas.Clear();
    }
}