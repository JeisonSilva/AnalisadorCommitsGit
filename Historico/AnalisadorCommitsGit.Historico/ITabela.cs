namespace AnalisadorCommitsGit.Historico;

public interface ITabela: IDisposable
{
    ITabela AddColumn(string descricao);
    ITabela AddDados(string texto);
    void Criar();
}