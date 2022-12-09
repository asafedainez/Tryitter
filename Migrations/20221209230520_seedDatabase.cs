using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into dbo.Users " +
                "(Name, Email, [Module], [Password], [Status], CreatedDate) " +
                "VALUES " +
                "('User Test1', 'usertest1@email.com', 0, '123456', 'Eu me sinto um test', GETDATE());");
            migrationBuilder.Sql("insert into dbo.Users " +
                "(Name, Email, [Module], [Password], [Status], CreatedDate) " +
                "VALUES " +
                "('User Test2', 'usertest2@email.com', 1, '123456', 'Eu me sinto um test2', GETDATE());");

            migrationBuilder.Sql("insert into dbo.Posts " +
                "(Content, ImageUrl, UserId, CreatedDate, UpdatedDate) " +
                "VALUES " +
                "('Eu sou um post do User Test1', 'imagem.png', 1, GETDATE(), GETDATE());");
            migrationBuilder.Sql("insert into dbo.Posts " +
                "(Content, ImageUrl, UserId, CreatedDate, UpdatedDate) " +
                "VALUES " +
                "('Eu sou um post do User Test2', 'imagem.png', 2, GETDATE(), GETDATE());");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE from dbo.Posts;");
            migrationBuilder.Sql("DELETE from dbo.Users;");
        }
    }
}
