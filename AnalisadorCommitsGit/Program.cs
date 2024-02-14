// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations.Schema;
using AnalisadorCommitsGit;
using AnalisadorCommitsGit.Historico;
using AnalisadorCommitsGit.Historico.Git;
using ConsoleTools;

var tabela = new Tabela();
var gitCommits = new GitCommits(@"/home/jeison/RiderProjects/AnalisadorCommitsGit");
var analisadorCommits = new AnalisadorCommits(tabela, gitCommits);
analisadorCommits.AddEstrategia(new ArquivosMaisAlteradosStrategy());
analisadorCommits.ExtrairDados();

var menu = new ConsoleMenu(args, level:0)
    .Add("Arquivos mais alterados",()=>
    {
        analisadorCommits.ListarArquivosMaisAlterados();
        Console.ReadKey();
    })
    .Add("Usuários que mais alteraram arquivos", () =>
    {
        UsuariosQueMaisAlteracamArquivos();

        static void UsuariosQueMaisAlteracamArquivos()
        {
            throw new NotImplementedException();
        }
    })
    .Configure(config =>
    {
        config.Selector = "*";
        config.Title = "Análise de Repositório";
    })
    .Add("Fechar", () => Environment.Exit(0));
    
    
menu.Show();