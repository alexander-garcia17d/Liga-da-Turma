public abstract class Partida : IResultado
{
    private static int proximoId = 1;

    public int Id { get; private set; }
    public Equipe Equipe1 { get; private set; }
    public Equipe Equipe2 { get; private set; }

    public Partida(Equipe equipe1, Equipe equipe2)
    {
        Id = proximoId++;
        Equipe1 = equipe1;
        Equipe2 = equipe2;
    }

    public abstract string ObterModalidade();

    public abstract string ObterPlacar();

    public abstract string ObterResultado();

    public override string ToString()
    {
        return "Partida " + Id +
               " | " + ObterModalidade() +
               " | " + Equipe1.Nome +
               " x " + Equipe2.Nome +
               " | " + ObterPlacar() +
               " | " + ObterResultado();
    }
}