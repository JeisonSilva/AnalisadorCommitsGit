namespace AnalisadorCommitsGit.Historico;

public interface ITabela: IDisposable
{
    ITabela AddColumn(string descricao, IEnumerable<string> dados);
    void Criar();
}