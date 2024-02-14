using System.Diagnostics;

namespace AnalisadorCommitsGit.Historico;

public struct Commit
{
    private readonly string _sha;
    private readonly string _mensagem;
    private readonly string _nomeAutor;
    private readonly string _emailAutor;
    
    public IEnumerable<Arquivo> Arquivos { get; private set; }

    public Commit(string sha, string mensagem, string nomeAutor, string emailAutor)
    {
        _sha = sha;
        _mensagem = mensagem;
        _nomeAutor = nomeAutor;
        _emailAutor = emailAutor;
    }

    public void AddArquivos(IEnumerable<Arquivo> arquivos)
        => Arquivos = arquivos;
}