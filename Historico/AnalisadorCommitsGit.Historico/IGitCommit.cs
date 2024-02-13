namespace AnalisadorCommitsGit.Historico;

public interface IGitCommit
{
    IEnumerable<Commit> ListarCommits();
}