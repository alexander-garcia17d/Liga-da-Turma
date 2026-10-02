

using System;

public class Menu
{
    private SistemaCampeonato sistema;

    public Menu()
    {
        sistema = new SistemaCampeonato();
    }

    public void Iniciar()
    {
        int opcao = -1;

        while (opcao != 0)
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("         LIGA DA TURMA");
            Console.WriteLine("================================");
            Console.WriteLine("1 - Cadastrar equipe");
            Console.WriteLine("2 - Consultar equipes");
            Console.WriteLine("3 - Registrar partida");
            Console.WriteLine("4 - Consultar histórico");
            Console.WriteLine("5 - Cadastrar festival");
            Console.WriteLine("6 - Gerar convite");
            Console.WriteLine("7 - Gerar cartão de resultado");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("================================");
            Console.Write("Escolha uma opção: ");

            string entrada = Console.ReadLine();

            // Verifica se o usuário apenas apertou ENTER
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
                continue;
            }

            // Tenta transformar a entrada em número
            int numero;

            if (!int.TryParse(entrada, out numero))
            {
                Console.WriteLine();
                Console.WriteLine("Digite apenas números.");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
                continue;
            }

            // Só altera opcao depois que temos certeza
            // de que a entrada é um número
            opcao = numero;

            switch (opcao)
            {
                case 1:
                    sistema.CadastrarEquipe();
                    break;

                case 2:
                    sistema.ConsultarEquipes();
                    break;

                case 3:
                    sistema.RegistrarPartida();
                    break;

                case 4:
                    sistema.ConsultarHistorico();
                    break;

                case 5:
                    sistema.CadastrarFestival();
                    break;

                case 6:
                    sistema.GerarConvite();
                    break;

                case 7:
                    sistema.GerarCartaoResultado();
                    break;

                case 0:
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
