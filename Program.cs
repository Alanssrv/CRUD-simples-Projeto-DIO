using System;

namespace CRUDBirds
{
    internal class Program
    {
        static BirdRepository repository = new BirdRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						GetAll();
						break;
					case "2":
						Insert();
						break;
					case "3":
						Update();
						break;
					case "4":
						Delete();
						break;
					case "5":
						GetById();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						Console.WriteLine("Informe uma opção válida");
						break;
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Delete()
		{
			Console.Write("Informe o id: ");
			int index = int.Parse(Console.ReadLine());

			try
			{
				repository.Remove(index);
			}
			catch (System.Exception)
			{
				System.Console.WriteLine("Não existe um registro com esse id");
			}
		}

        private static void GetById()
		{
			Console.Write("Informe o id: ");
			int index = int.Parse(Console.ReadLine());
			Bird bird;
			try
			{
				bird = repository.ReturnById(index);
				Console.WriteLine(bird);
			}
			catch (System.Exception)
			{
				System.Console.WriteLine("Não existe um registro com esse id");
			}
		}

        private static void Update()
		{
			Console.Write("Informe o id: ");
			int index = int.Parse(Console.ReadLine());
			try
			{
				repository.ReturnById(index);

				foreach (int i in Enum.GetValues(typeof(Conservation)))
				{
					Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Conservation), i));
				}
				Console.Write("Digite o status de conservação: ");
				
				int conservationValue = 0;
				do
				{
					conservationValue = int.Parse(Console.ReadLine());
				} while (conservationValue < 0 || conservationValue > 6);
				
				Conservation conservation = (Conservation) conservationValue;

				Console.Write("Digite o nome popular: ");
				string popularName = Console.ReadLine();

				Console.Write("Digite o nome cientifico: ");
				string scientificName = Console.ReadLine();

				Console.Write("Informe a url da foto: ");
				string photo = Console.ReadLine();

				Bird updateBird = new Bird(id: index,
											popularName,
											scientificName,
											conservation,
											photo
										);

				repository.Update(index, updateBird);
			}
			catch (System.Exception)
			{
				System.Console.WriteLine("Não existe um registro com esse id");
			}
		}
        private static void GetAll()
		{
			Console.WriteLine("Listar");

			var lista = repository.Items();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum item cadastrado.");
				return;
			}

			foreach (var bird in lista)
			{
                var isDeleted = bird.isDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", bird.returnId(), bird.returnName(), (isDeleted ? "*Excluído*" : ""));
			}
		}

        private static void Insert()
		{
			Console.WriteLine("Inserir");

			foreach (int i in Enum.GetValues(typeof(Conservation)))
			{
				Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Conservation), i));
			}
			Console.Write("Digite o status de conservação: ");

			int conservationValue = 0;
			conservationValue = int.Parse(Console.ReadLine());
			while (conservationValue < 0 || conservationValue > 6) {
				Console.WriteLine("Informe um status válido: ");
				conservationValue = int.Parse(Console.ReadLine());
			}
			
			Conservation conservation = (Conservation) conservationValue;

			Console.Write("Digite o nome popular: ");
			string popularName = Console.ReadLine();

			Console.Write("Digite o nome cientifico: ");
			string scientificName = Console.ReadLine();

			Console.Write("Informe a url da foto: ");
			string photo = Console.ReadLine();

			Bird newBird = new Bird(id: repository.NextId(),
									    popularName,
										scientificName,
										conservation,
										photo
									);

			repository.Add(newBird);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar");
			Console.WriteLine("2- Inserir");
			Console.WriteLine("3- Atualizar");
			Console.WriteLine("4- Excluir");
			Console.WriteLine("5- Visualizar");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

    }
}