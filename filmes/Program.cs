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
        opcaoUsuario = ObterOpcaoUsuario();
      }
    }
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Consulte um filme no repositório.");
      Console.WriteLine("Escolha uma opção: ");

      Console.WriteLine("1- Listar filmes");
      Console.WriteLine("2- Inserir filme");
      Console.WriteLine("3- Atualizar filme");
      Console.WriteLine("4- Excluir filme");
      Console.WriteLine("5- Visualizar filme");
      Console.WriteLine("C- Limpar tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();
      Console.Write("Digite a Opção: ");

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
        return;
      }

      Console.WriteLine("Id\tTítulo\t\t\tDisponibilidade");
      foreach (var filme in lista)
      {
        var excluido = filme.retornaExcluido();
        Console.WriteLine("{0}\t{1}\t\t\t{2}", filme.retornaId(), filme.retornaTitulo(), excluido ? "N" : "S");
      }
    }

    private static void InserirFilme()
    {
      Console.WriteLine("-Insira um filme novo-");
      Console.WriteLine();

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("Digite {0} para escolher {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine();

      Console.Write("Opcao escolhida: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine();

      Console.Write("Digite o título: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o ano de lançamento: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Escreva uma sinopse: ");
      string entradaSinopse = Console.ReadLine();

      Filme novoFilme = new Filme(id: repositorio.UltimoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    sinopse: entradaSinopse);
      repositorio.Insere(novoFilme);
    }

    private static void AtualizarFilme()
    {

      Console.WriteLine("-Atualizando um filme-");
      Console.WriteLine();

      Console.Write("Digite o Id do filme: ");
      int entradaId = int.Parse(Console.ReadLine());

      Console.WriteLine("Cadastrando o novo filme");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("Digite {0} para escolher {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine();

      Console.Write("Digite a opção escolhida: ");
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
      repositorio.Atualiza(entradaId, filme);
    }
    private static void ExcluirFilme()
    {
      Console.WriteLine("-Excluindo um filme-");
      Console.WriteLine();

      Console.Write("Digite o id do filme: ");
      int entradaId = int.Parse(Console.ReadLine());

      repositorio.Exclui(entradaId);
    }
    private static void VisualizarFilme()
    {
      Console.WriteLine("-Visualizando um filme-");
      Console.WriteLine();

      Console.Write("Digite o id do filme: ");
      int entradaId = int.Parse(Console.ReadLine());

      var filme = repositorio.retornaPorId(entradaId);

      Console.WriteLine(filme);


    }
  }
}
