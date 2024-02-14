namespace AnalisadorCommitsGit.Historico;

public interface IStrategyRun
{
    void Run();
    IStrategyRun AddTabela(ITabela tabela);
    IStrategyRun AddGitCommit(IGitCommit gitCommit);
}