namespace AnalisadorCommitsGit.Historico;

public class AnalisadorCommits
{
    private readonly ITabela _tabela;
    private readonly IGitCommit _gitCommit;
    private IEnumerable<Commit> _commits;

    public AnalisadorCommits(ITabela tabela, IGitCommit gitCommit)
    {
        _tabela = tabela;
        _gitCommit = gitCommit;
    }
    
    public void ListarArquivosMaisAlterados()
    {
        _tabela
            .AddColumn(descricao: "Nome do Arquivo")
            .AddDados("arquivo.txt")
            .Criar();

    }

    public void ExtrairDados()
    {
        _commits = _gitCommit.ListarCommits().ToList();
    }
}