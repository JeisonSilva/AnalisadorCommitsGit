using LibGit2Sharp;

namespace AnalisadorCommitsGit.Historico.Git;

public class GitCommits: IGitCommit
{
    private readonly string _caminhoRepo;

    public GitCommits()
    {
        _caminhoRepo = Directory.GetCurrentDirectory();
    }
    
    public IEnumerable<Commit> ListarCommits()
    {
        // Período de tempo desejado
        DateTimeOffset dataInicio = DateTimeOffset.Now;
        DateTimeOffset dataFim = dataInicio.AddDays(-30);

        // Abre o repositório Git
        using (var repo = new Repository(_caminhoRepo))
        {
            // Filtra os commits pelo período de tempo
            var commits = repo.Commits.Where(c => c.Author.When >= dataInicio && c.Author.When <= dataFim);
            // Itera sobre os commits filtrados
            foreach (var commit in commits)
            {
                 yield return new Commit(commit.Sha, commit.Message);
            }
        }
    }
}