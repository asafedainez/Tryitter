using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Email", "Module", "Password", "Status", "IsDeleted", "CreatedDate" },
                values: new object[,]
                {
                    {1, "User Test1", "usertest1@email.com", 0, "123456", "Eu me sinto um test1", false, DateTime.Now },
                    {2, "User Test2", "usertest2@email.com", 1, "123456", "Eu me sinto um test2", false, DateTime.Now }
                }
             );

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "ImageUrl", "UserId", "IsDeleted", "CreatedDate" },
                values: new object[,]
                {
                    {1, "Eu sou um post do User Test1", "imagem.png", 1, false, DateTime.Now },
                    {2, "Eu sou um post do User Test2", "imagem.png", 2, false, DateTime.Now },
                }
             );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Posts");
            migrationBuilder.DropTable(name: "Users");
        }
    }
}
