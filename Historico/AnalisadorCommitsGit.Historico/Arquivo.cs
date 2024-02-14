namespace AnalisadorCommitsGit.Historico;

public struct Arquivo
{
    private readonly string _nome;

    public Arquivo(string nome)
    {
        _nome = nome;
    }

    public static implicit operator string(Arquivo arquivo)
        => arquivo._nome;
}