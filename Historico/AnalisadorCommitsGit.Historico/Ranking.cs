namespace AnalisadorCommitsGit.Historico;

public struct Ranking
{
    public Ranking(string nome, int quantidade)
    {
        Nome = nome;
        Quantidade = quantidade;
    }

    public int Quantidade { get;}
    public string Nome { get;}

    public static implicit operator string(Ranking ranking)
        => ranking.Nome;
}