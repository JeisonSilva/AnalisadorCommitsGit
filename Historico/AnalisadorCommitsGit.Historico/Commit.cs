namespace AnalisadorCommitsGit.Historico;

public struct Commit
{
    private readonly string _sha;
    private readonly string _mensagem;

    public Commit(string sha, string mensagem)
    {
        _sha = sha;
        _mensagem = mensagem;
    }
}