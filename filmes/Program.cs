using System;
using DIO.filmes.Classes;

namespace DIO.filmes
{
  class Program
  {
    static FilmeRepositorio repositorio = new FilmeRepositorio();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();
      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarFilmes();
            break;
          case "2":
            InserirFilme();
            break;
          case "3":
            AtualizarFilme();
            break;
          case "4":
            ExcluirFilme();
            break;
          case "5":
            VisualizarFilme();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario(false);
      }
    }
    private static string ObterOpcaoUsuario(bool mostrarOpcoes = true)
    {
      if (mostrarOpcoes)
      {
        Console.WriteLine();
        Console.WriteLine("Consulte um filme no repositório.");
        Console.WriteLine();
        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine();

        Console.WriteLine("1- Listar filmes");
        Console.WriteLine("2- Inserir filme");
        Console.WriteLine("3- Atualizar filme");
        Console.WriteLine("4- Excluir filme");
        Console.WriteLine("5- Visualizar filme");
        Console.WriteLine("C- Limpar tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();
      }
      Console.Write("Opção: ");

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
    private static void ListarFilmes()
    {
      Console.WriteLine("-Filmes cadastrados-");
      Console.WriteLine();

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Não há filmes cadastrados.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();
        return;
      }

      Console.WriteLine("Id\tTítulo\t\t\tDisponibilidade");
      foreach (var filme in lista)
      {
        var excluido = filme.retornaExcluido();
        Console.WriteLine("{0}\t{1}\t\t\t{2}", filme.retornaId(), filme.retornaTitulo(), excluido ? "N" : "S");
      }
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("------------------------------");
      Console.WriteLine();
    }

    private static void InserirFilme()
    {
      Console.WriteLine("-Insira um filme novo-");
      Console.WriteLine();

      Filme novoFilme = CadastrarFilme("Inserir");
      repositorio.Insere(novoFilme);
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("--Filme inserido--");
      Console.WriteLine("------------------------------");
      Console.WriteLine();
    }

    private static void AtualizarFilme()
    {

      Console.WriteLine("-Atualizando um filme-");
      Console.WriteLine();

      Filme filme = CadastrarFilme("Atualizar");

      repositorio.Atualiza(filme.retornaId(), filme);
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("--Filme atualizado--");
      Console.WriteLine("------------------------------");
      Console.WriteLine();
    }
    private static void ExcluirFilme()
    {
      Console.WriteLine("-Excluindo um filme-");
      Console.WriteLine();

      Console.Write("Digite o id do filme: ");
      int entradaId = int.Parse(Console.ReadLine());

      repositorio.Exclui(entradaId);

      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("--Filme excluido--");
      Console.WriteLine("------------------------------");
      Console.WriteLine();
    }
    private static void VisualizarFilme()
    {
      Console.WriteLine("-Visualizando um filme-");
      Console.WriteLine();

      Console.Write("Digite o id do filme: ");
      int entradaId = int.Parse(Console.ReadLine());

      var filme = repositorio.retornaPorId(entradaId);

      Console.WriteLine(filme);

      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("------------------------------");
      Console.WriteLine();
    }

    private static Filme CadastrarFilme(string tipo)
    {
      int entradaId = repositorio.UltimoId();
      if (tipo.Equals("Atualizar"))
      {
        Console.Write("Digite o Id do filme: ");
        entradaId = int.Parse(Console.ReadLine());
      }

      Console.WriteLine("Cadastrando o novo filme");
      Console.WriteLine("");
      Console.WriteLine("Escolha um gênero, digite:");
      Console.WriteLine();

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} para {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine();

      Console.Write("Opção de gênero: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine();

      Console.Write("Digite o novo título: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano de lançamento: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Escreva a sinopse: ");
      string entradaSinopse = Console.ReadLine();


      var filme = new Filme(id: entradaId,
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                sinopse: entradaSinopse);

      return filme;

    }
  }
}
