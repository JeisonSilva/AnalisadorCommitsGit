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
                var diffcommit = repo.Diff.Compare<TreeChanges>(commit.Parents.FirstOrDefault()?.Tree, commit.Tree);
                
                var cm =new Commit(commit.Sha, commit.Message, commit.Author.Name, commit.Author.Email);
                cm.AddArquivos(diffcommit.Select(x=> new Arquivo(x.Path.Split(char.Parse("/")).Last())));
                yield return cm;
            }
        }
    }
}