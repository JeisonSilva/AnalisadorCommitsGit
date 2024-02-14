using LibGit2Sharp;

namespace AnalisadorCommitsGit.Historico.Git;

public class GitCommits: IGitCommit
{
    private readonly string _caminhoRepo;

    public GitCommits(string caminhoRepo)
    {
        _caminhoRepo = caminhoRepo;
    }
    
    public IEnumerable<Commit> ListarCommits()
    {
        // Período de tempo desejado
        DateTimeOffset dataInicio = DateTimeOffset.Now.Date.AddDays(-30);
        DateTimeOffset dataFim = DateTimeOffset.Now.Date.AddDays(1).AddMinutes(-1);

        // Abre o repositório Git
        using (var repo = new Repository(_caminhoRepo))
        {
            // Filtra os commits pelo período de tempo
            var commits = repo.Commits.Where(c => c.Author.When >= dataInicio && c.Author.When <= dataFim);
            // Itera sobre os commits filtrados
            foreach (var commit in commits)
            {
                var cm =new Commit(commit.Sha, commit.Message, commit.Author.Name, commit.Author.Email);
                cm.AddArquivos(commit.Tree.Where(x=>x.TargetType == TreeEntryTargetType.Blob).Select(x=>new Arquivo(x.Name)));
                yield return cm;
            }
        }
    }
}