using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoSerie = ObterOpcaoSerie();

			while (opcaoSerie.ToUpper() != "X")
			{
				switch (opcaoSerie)
				{
					case "1":
						ListarSeries();
						break;
                                        case "2":
						InserirSerie(); 
						break;
                                        case "3":
						VisualizarSerie(); 
						break;					
					case "4":
						AtualizarSerie(); 
						break;
					case "5":
						ExcluirSerie(); 
						break;					
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoSerie = ObterOpcaoSerie();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
      
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		} 

        private static void InserirSerie()                                                                                      // Create
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		} 

        private static void VisualizarSerie()                                                                                   // Read
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()                                                                                    // Update
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}  

        private static void ExcluirSerie()                                                                                   // Delete
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}        

        private static string ObterOpcaoSerie()
		{
			Console.WriteLine();
			Console.WriteLine("Séries a seu dispor!!!");
                        Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1 - Listar séries");
                        Console.WriteLine("2 - Inserir nova série");
                        Console.WriteLine("3 - Visualizar série");
			Console.WriteLine("4 - Atualizar série");
			Console.WriteLine("5 - Excluir série");
			Console.WriteLine("C - Limpar a tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string opcaoSerie = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoSerie;
		}
    }
}