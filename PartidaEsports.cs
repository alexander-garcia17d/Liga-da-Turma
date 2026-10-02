public class PartidaEsports : Partida
{
    public int Vitorias1 { get; private set; }
    public int Vitorias2 { get; private set; }

    public PartidaEsports(
        Equipe equipe1,
        Equipe equipe2,
        int vitorias1,
        int vitorias2) : base(equipe1, equipe2)
    {
        Vitorias1 = vitorias1;
        Vitorias2 = vitorias2;
    }

    public override string ObterModalidade()
    {
        return "eSports";
    }

    public override string ObterPlacar()
    {
        return Vitorias1 + " x " + Vitorias2;
    }

    public override string ObterResultado()
    {
        if (Vitorias1 > Vitorias2)
        {
            return "Vitória de " + Equipe1.Nome;
        }

        if (Vitorias2 > Vitorias1)
        {
            return "Vitória de " + Equipe2.Nome;
        }

        return "Empate";
    }
}