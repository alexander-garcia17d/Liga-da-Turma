public class Festival
{
    public string Nome { get; private set; }
    public string Local { get; private set; }
    public string Data { get; private set; }
    public string Horario { get; private set; }

    public Festival(
        string nome,
        string local,
        string data,
        string horario)
    {
        Nome = nome;
        Local = local;
        Data = data;
        Horario = horario;
    }
}