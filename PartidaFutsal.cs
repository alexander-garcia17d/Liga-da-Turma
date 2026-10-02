public class PartidaFutsal : Partida
{
    public int Gols1 { get; private set; }
    public int Gols2 { get; private set; }

    public PartidaFutsal(
        Equipe equipe1,
        Equipe equipe2,
        int gols1,
        int gols2) : base(equipe1, equipe2)
    {
        Gols1 = gols1;
        Gols2 = gols2;
    }

    public override string ObterModalidade()
    {
        return "Futsal";
    }

    public override string ObterPlacar()
    {
        return Gols1 + " x " + Gols2;
    }

    public override string ObterResultado()
    {
        if (Gols1 > Gols2)
        {
            return "Vitória de " + Equipe1.Nome;
        }

        if (Gols2 > Gols1)
        {
            return "Vitória de " + Equipe2.Nome;
        }

        return "Empate";
    }
}