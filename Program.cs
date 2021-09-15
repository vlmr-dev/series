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
						// Create: InserirSerie 
						break;
                                        case "3":
						// Read: VisualizarSerie 
						break;					
					case "4":
						// Update: AtualizarSerie 
						break;
					case "5":
						// Delete: ExcluirSerie 
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