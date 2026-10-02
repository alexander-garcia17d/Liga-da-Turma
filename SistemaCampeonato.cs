using System;
using System.Collections.Generic;

public class SistemaCampeonato
{
    private List<Equipe> equipes;
    private List<Partida> partidas;
    private Festival festival;

    public SistemaCampeonato()
    {
        equipes = new List<Equipe>();
        partidas = new List<Partida>();
        festival = null;
    }

    public void CadastrarEquipe()
    {
        Console.Clear();

        Console.WriteLine("========== CADASTRAR EQUIPE ==========");
        Console.Write("Nome da equipe: ");

        string nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido.");
            Console.ReadKey();
            return;
        }

        foreach (Equipe equipe in equipes)
        {
            if (equipe.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Essa equipe já está cadastrada.");
                Console.ReadKey();
                return;
            }
        }

        equipes.Add(new Equipe(nome));

        Console.WriteLine("Equipe cadastrada com sucesso!");
        Console.ReadKey();
    }

    public void ConsultarEquipes()
    {
        Console.Clear();

        Console.WriteLine("========== EQUIPES ==========");

        if (equipes.Count == 0)
        {
            Console.WriteLine("Nenhuma equipe cadastrada.");
        }
        else
        {
            for (int i = 0; i < equipes.Count; i++)
            {
                Console.WriteLine((i + 1) + " - " + equipes[i].Nome);
            }
        }

        Console.ReadKey();
    }

    public void RegistrarPartida()
    {
        Console.Clear();

        Console.WriteLine("========== REGISTRAR PARTIDA ==========");

        if (equipes.Count < 2)
        {
            Console.WriteLine("É necessário cadastrar pelo menos duas equipes.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Equipes disponíveis:");

        for (int i = 0; i < equipes.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " + equipes[i].Nome);
        }

        Console.Write("Escolha a primeira equipe: ");

        int equipe1;

        if (!int.TryParse(Console.ReadLine(), out equipe1) ||
            equipe1 < 1 ||
            equipe1 > equipes.Count)
        {
            Console.WriteLine("Equipe inválida.");
            Console.ReadKey();
            return;
        }

        Console.Write("Escolha a segunda equipe: ");

        int equipe2;

        if (!int.TryParse(Console.ReadLine(), out equipe2) ||
            equipe2 < 1 ||
            equipe2 > equipes.Count)
        {
            Console.WriteLine("Equipe inválida.");
            Console.ReadKey();
            return;
        }

        if (equipe1 == equipe2)
        {
            Console.WriteLine("Uma equipe não pode jogar contra ela mesma.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("1 - Futsal");
        Console.WriteLine("2 - eSports");
        Console.Write("Escolha a modalidade: ");

        int modalidade;

        if (!int.TryParse(Console.ReadLine(), out modalidade) ||
            (modalidade != 1 && modalidade != 2))
        {
            Console.WriteLine("Modalidade inválida.");
            Console.ReadKey();
            return;
        }

        if (modalidade == 1)
        {
            RegistrarFutsal(
                equipes[equipe1 - 1],
                equipes[equipe2 - 1]);
        }
        else
        {
            RegistrarEsports(
                equipes[equipe1 - 1],
                equipes[equipe2 - 1]);
        }
    }

    private void RegistrarFutsal(
        Equipe equipe1,
        Equipe equipe2)
    {
        Console.Write("Gols de " + equipe1.Nome + ": ");

        int gols1;

        if (!int.TryParse(Console.ReadLine(), out gols1) || gols1 < 0)
        {
            Console.WriteLine("Quantidade de gols inválida.");
            Console.ReadKey();
            return;
        }

        Console.Write("Gols de " + equipe2.Nome + ": ");

        int gols2;

        if (!int.TryParse(Console.ReadLine(), out gols2) || gols2 < 0)
        {
            Console.WriteLine("Quantidade de gols inválida.");
            Console.ReadKey();
            return;
        }

        PartidaFutsal partida =
            new PartidaFutsal(equipe1, equipe2, gols1, gols2);

        partidas.Add(partida);

        Console.WriteLine();
        Console.WriteLine("Partida registrada com sucesso!");
        Console.WriteLine(partida.ObterResultado());

        Console.ReadKey();
    }

    private void RegistrarEsports(
        Equipe equipe1,
        Equipe equipe2)
    {
        Console.WriteLine();
        Console.WriteLine("Melhor de três mapas.");
        Console.WriteLine("O placar deve ser 2 x 0 ou 2 x 1.");

        Console.Write("Vitórias de " + equipe1.Nome + ": ");

        int vitorias1;

        if (!int.TryParse(Console.ReadLine(), out vitorias1))
        {
            Console.WriteLine("Valor inválido.");
            Console.ReadKey();
            return;
        }

        Console.Write("Vitórias de " + equipe2.Nome + ": ");

        int vitorias2;

        if (!int.TryParse(Console.ReadLine(), out vitorias2))
        {
            Console.WriteLine("Valor inválido.");
            Console.ReadKey();
            return;
        }

        bool placarValido =
            (vitorias1 == 2 && (vitorias2 == 0 || vitorias2 == 1)) ||
            (vitorias2 == 2 && (vitorias1 == 0 || vitorias1 == 1));

        if (!placarValido)
        {
            Console.WriteLine("Placar inválido para uma série melhor de três.");
            Console.ReadKey();
            return;
        }

        PartidaEsports partida =
            new PartidaEsports(
                equipe1,
                equipe2,
                vitorias1,
                vitorias2);

        partidas.Add(partida);

        Console.WriteLine();
        Console.WriteLine("Partida registrada com sucesso!");
        Console.WriteLine(partida.ObterResultado());

        Console.ReadKey();
    }

    public void ConsultarHistorico()
    {
        Console.Clear();

        Console.WriteLine("========== HISTÓRICO ==========");

        if (partidas.Count == 0)
        {
            Console.WriteLine("Nenhuma partida registrada.");
        }
        else
        {
            foreach (Partida partida in partidas)
            {
                Console.WriteLine(partida);
            }
        }

        Console.ReadKey();
    }

    public void CadastrarFestival()
    {
        Console.Clear();

        Console.WriteLine("========== CADASTRAR FESTIVAL ==========");

        Console.Write("Nome do festival: ");
        string nome = Console.ReadLine();

        Console.Write("Local: ");
        string local = Console.ReadLine();

        Console.Write("Data: ");
        string data = Console.ReadLine();

        Console.Write("Horário: ");
        string horario = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome) ||
            string.IsNullOrWhiteSpace(local) ||
            string.IsNullOrWhiteSpace(data) ||
            string.IsNullOrWhiteSpace(horario))
        {
            Console.WriteLine("Todos os campos devem ser preenchidos.");
            Console.ReadKey();
            return;
        }

        festival = new Festival(
            nome,
            local,
            data,
            horario);

        Console.WriteLine("Festival cadastrado com sucesso!");

        Console.ReadKey();
    }

    public void GerarConvite()
    {
        Console.Clear();

        Console.WriteLine("========== CONVITE ==========");

        if (festival == null)
        {
            Console.WriteLine("Nenhum festival cadastrado.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("           " + festival.Nome);
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("Local: " + festival.Local);
        Console.WriteLine("Data: " + festival.Data);
        Console.WriteLine("Horário: " + festival.Horario);
        Console.WriteLine();
        Console.WriteLine("Venha participar do festival!");
        Console.WriteLine("========================================");

        Console.ReadKey();
    }

    public void GerarCartaoResultado()
    {
        Console.Clear();

        Console.WriteLine("========== CARTÃO DE RESULTADO ==========");

        if (partidas.Count == 0)
        {
            Console.WriteLine("Nenhuma partida registrada.");
            Console.ReadKey();
            return;
        }

        foreach (Partida partida in partidas)
        {
            Console.WriteLine(
                "Partida " + partida.Id +
                " - " +
                partida.Equipe1.Nome +
                " x " +
                partida.Equipe2.Nome);
        }

        Console.Write("Escolha o número da partida: ");

        int id;

        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Número inválido.");
            Console.ReadKey();
            return;
        }

        Partida partidaEscolhida = null;

        foreach (Partida partida in partidas)
        {
            if (partida.Id == id)
            {
                partidaEscolhida = partida;
                break;
            }
        }

        if (partidaEscolhida == null)
        {
            Console.WriteLine("Partida não encontrada.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("        RESULTADO DA PARTIDA");
        Console.WriteLine("========================================");
        Console.WriteLine("Modalidade: " +
                          partidaEscolhida.ObterModalidade());
        Console.WriteLine();
        Console.WriteLine(
            partidaEscolhida.Equipe1.Nome +
            " " +
            partidaEscolhida.ObterPlacar() +
            " " +
            partidaEscolhida.Equipe2.Nome);
        Console.WriteLine();
        Console.WriteLine(
            "Resultado: " +
            partidaEscolhida.ObterResultado());
        Console.WriteLine("========================================");

        Console.ReadKey();
    }
}