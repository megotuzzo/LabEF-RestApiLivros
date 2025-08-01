using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioRestApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingAutores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Machado', 'de Assis')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Clarice', 'Lispector')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Jorge', 'Amado')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Cecília', 'Meireles')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('José', 'Saramago')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Fernando', 'Pessoa')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Graciliano', 'Ramos')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Rachel', 'de Queiroz')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Érico', 'Veríssimo')");
            mb.Sql("insert into autores(PrimeiroNome, UltimoNome) values ('Carlos Drummond', 'de Andrade')");  
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Autores");
        }
    }
}
