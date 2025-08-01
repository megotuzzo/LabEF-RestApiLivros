public class Livro
{
    public int Id { get; set; }
    public String Titulo { get; set; }

    public int AutorId { get; set; }

    public virtual Autor Autor { get; set; }
}


