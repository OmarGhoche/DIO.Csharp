using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
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

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.getExcluido();
                Console.WriteLine($"#ID {serie.getId()} - {serie.getTitulo()} {(excluido ? "*EXCLUÍDO*" : "")}");
            }
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int inputGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string inputTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int inputAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string inputDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.NextId(),
                                        genero: (Genero) inputGenero,
                                        titulo: inputTitulo,
                                        ano: inputAno,
                                        descricao: inputDescricao);

            repositorio.Insert(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int inputGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string inputTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int inputAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string inputDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: idSerie,
                                            genero: (Genero) inputGenero,
                                            titulo: inputTitulo,
                                            ano: inputAno,
                                            descricao: inputDescricao);

            repositorio.Update(idSerie, atualizaSerie);
            
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Remove(idSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.getById(idSerie);

            // overrides ToString()
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine(
                Environment.NewLine +
                "DIO Séries a seu dispor!!!" + Environment.NewLine +
                "Informe a opção desejada:" + Environment.NewLine +
                "1 - Listar séries" + Environment.NewLine +
                "2 - Inserir nova série" + Environment.NewLine +
                "3 - Atualizar série" + Environment.NewLine +
                "4 - Excluir série" + Environment.NewLine +
                "5 - Visualizar série" + Environment.NewLine +
                "C - Limpar Tela" + Environment.NewLine +
                "X - Sair"
            );

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
