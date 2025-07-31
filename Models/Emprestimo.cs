public class Emprestimo
{
    public int Id { get; set; }
    public DateTime DataRetirada { get; set; }
    public DateTime DataDevolucao { get; set; }
    public bool Entregue { get; set; }

    public int LivroId { get; set; }
}