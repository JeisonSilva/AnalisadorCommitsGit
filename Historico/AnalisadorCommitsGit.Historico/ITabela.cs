namespace AnalisadorCommitsGit.Historico;

public interface ITabela: IDisposable
{
    ITabela AddColumn(string descricao);
    ITabela AddRow(Ranking dados);
    void Criar();
}