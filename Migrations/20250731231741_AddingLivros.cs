using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioRestApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            // --- Machado de Assis (AutorId = 1) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('Dom Casmurro', 1)");
            mb.Sql("insert into livros(Titulo, AutorId) values ('Memórias Póstumas de Brás Cubas', 1)");

            // --- Clarice Lispector (AutorId = 2) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('A Hora da Estrela', 2)");
            mb.Sql("insert into livros(Titulo, AutorId) values ('Perto do Coração Selvagem', 2)");

            // --- Jorge Amado (AutorId = 3) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('Capitães da Areia', 3)");
            mb.Sql("insert into livros(Titulo, AutorId) values ('Gabriela, Cravo e Canela', 3)");

            // --- Cecília Meireles (AutorId = 4) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('Romanceiro da Inconfidência', 4)");

            // --- José Saramago (AutorId = 5) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('Ensaio sobre a Cegueira', 5)");

            // --- Fernando Pessoa (AutorId = 6) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('Livro do Desassossego', 6)");

            // --- Graciliano Ramos (AutorId = 7) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('Vidas Secas', 7)");

            // --- Rachel de Queiroz (AutorId = 8) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('O Quinze', 8)");

            // --- Érico Veríssimo (AutorId = 9) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('O Tempo e o Vento', 9)");
            mb.Sql("insert into livros(Titulo, AutorId) values ('Clarissa', 9)");

            // --- Carlos Drummond de Andrade (AutorId = 10) ---
            mb.Sql("insert into livros(Titulo, AutorId) values ('A Rosa do Povo', 10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Livros");
        }
    }
}
