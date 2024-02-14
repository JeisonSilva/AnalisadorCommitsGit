namespace AnalisadorCommitsGit.Historico;

public class AnalisadorCommits
{
    private readonly ITabela _tabela;
    private readonly IGitCommit _gitCommit;
    private IEnumerable<Commit> _commits;
    private ArquivosMaisAlteradosStrategy _strategy;

    public AnalisadorCommits(ITabela tabela, IGitCommit gitCommit)
    {
        _tabela = tabela;
        _gitCommit = gitCommit;
    }
    
    public void ListarArquivosMaisAlterados()
        => _strategy.Run();

    public void ExtrairDados()
        => _commits = _gitCommit.ListarCommits();

    public void AddEstrategia(ArquivosMaisAlteradosStrategy strategy)
    {
        _strategy = strategy;
        _strategy
            .AddTabela(_tabela)
            .AddGitCommit(_gitCommit);
    }
}