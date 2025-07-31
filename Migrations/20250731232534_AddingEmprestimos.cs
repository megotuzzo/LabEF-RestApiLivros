using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaboratorioRestApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingEmprestimos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            // --- Cenário 1: Empréstimos já concluídos (Entregue = true) ---

            // Um empréstimo antigo para Dom Casmurro (LivroId = 1)
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-05-10 14:30:00', '2025-05-24 18:00:00', 1, 1)");

            // Empréstimo para A Hora da Estrela (LivroId = 3)
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-06-01 10:00:00', '2025-06-15 11:20:00', 1, 3)");

            // Empréstimo para Capitães da Areia (LivroId = 5)
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-06-20 16:00:00', '2025-07-04 17:00:00', 1, 5)");


            // --- Cenário 2: Empréstimos ativos, dentro do prazo (Entregue = false) ---

            // Empréstimo recente para Vidas Secas (LivroId = 10), devolução no futuro
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-07-25 09:15:00', '2025-08-08 18:00:00', 0, 10)");

            // Empréstimo para O Tempo e o Vento (LivroId = 12), devolução no futuro
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-07-28 11:00:00', '2025-08-11 18:00:00', 0, 12)");

            // Empréstimo para Ensaio sobre a Cegueira (LivroId = 8)
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-07-30 15:00:00', '2025-08-13 18:00:00', 0, 8)");


            // --- Cenário 3: Empréstimos atrasados (DataDevolucao no passado, mas Entregue = false) ---

            // Empréstimo para Memórias Póstumas de Brás Cubas (LivroId = 2) que deveria ter sido devolvido
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-07-01 12:00:00', '2025-07-15 18:00:00', 0, 2)");

            // Empréstimo para O Quinze (LivroId = 11) também atrasado
            mb.Sql("insert into emprestimos(DataRetirada, DataDevolucao, Entregue, LivroId) values ('2025-07-10 17:45:00', '2025-07-24 18:00:00', 0, 11)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM emprestimos");
        }
    }
}
