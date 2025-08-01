public class AutorDTO
{
    public int Id { get; set; }
    public String PrimeiroNome { get; set; }
    public String UltimoNome { get; set; }

    public virtual List<string> LivrosNomes { get; set; } = new List<string>();
}