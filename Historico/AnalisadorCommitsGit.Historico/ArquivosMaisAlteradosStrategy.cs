namespace AnalisadorCommitsGit.Historico;

public class ArquivosMaisAlteradosStrategy : IStrategyRun
{
    private ITabela _tabela;
    private IGitCommit _gitCommit;

    public void Run()
    {
        var commits = _gitCommit.ListarCommits();
        var arquivosAgrupados = commits.SelectMany(x => x.Arquivos).GroupBy(arquivo => arquivo);
        var quantidadePorArquivos = arquivosAgrupados
            .Select(group => new Ranking(group.Key, group.Count()));
        var ordenadoEmDescrecente = quantidadePorArquivos.OrderByDescending(x => x.Quantidade);
        _tabela
            .AddColumn(descricao: "Nome do Arquivo", ordenadoEmDescrecente.Select(x=>x.Nome))
            .Criar();
    }

    public IStrategyRun AddTabela(ITabela tabela)
    {
        _tabela = tabela;
        return this;
    }

    public IStrategyRun AddGitCommit(IGitCommit gitCommit)
    {
        _gitCommit = gitCommit;
        return this;
    }
}