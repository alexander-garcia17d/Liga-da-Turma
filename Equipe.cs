public class Equipe
{
    public string Nome { get; private set; }

    public Equipe(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return Nome;
    }
}