using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiGames.Infra.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Brothers_BrotherDomainId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Brothers",
                keyColumn: "Id",
                keyValue: new Guid("16e4c410-547b-4c58-b29f-669795d801e0"));

            migrationBuilder.DeleteData(
                table: "Brothers",
                keyColumn: "Id",
                keyValue: new Guid("1e1e0439-cb8b-41ca-88f2-649d6ad76065"));

            migrationBuilder.DeleteData(
                table: "Brothers",
                keyColumn: "Id",
                keyValue: new Guid("5b09be78-3f35-4406-87bb-7b91b87607fc"));

            migrationBuilder.DeleteData(
                table: "Brothers",
                keyColumn: "Id",
                keyValue: new Guid("b144f25f-0cbc-4ffb-a66a-630c7115a119"));

            migrationBuilder.DeleteData(
                table: "Brothers",
                keyColumn: "Id",
                keyValue: new Guid("e0ee2bbb-254c-48f1-b8b4-165a8da2a0ff"));

            migrationBuilder.DeleteData(
                table: "Brothers",
                keyColumn: "Id",
                keyValue: new Guid("f85d2b70-bfc3-4af8-a741-7903fb444f54"));

            migrationBuilder.RenameColumn(
                name: "BrotherDomainId",
                table: "Games",
                newName: "BrotherId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_BrotherDomainId",
                table: "Games",
                newName: "IX_Games_BrotherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Brothers_BrotherId",
                table: "Games",
                column: "BrotherId",
                principalTable: "Brothers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Brothers_BrotherId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "BrotherId",
                table: "Games",
                newName: "BrotherDomainId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_BrotherId",
                table: "Games",
                newName: "IX_Games_BrotherDomainId");

            migrationBuilder.InsertData(
                table: "Brothers",
                columns: new[] { "Id", "AddressId", "Cpf", "DateCriate", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("16e4c410-547b-4c58-b29f-669795d801e0"), null, "555.555.555-05", new DateTimeOffset(new DateTime(2023, 8, 23, 15, 44, 22, 787, DateTimeKind.Unspecified).AddTicks(8107), new TimeSpan(0, 0, 0, 0, 0)), "teste05@teste.com", "Teste5" },
                    { new Guid("1e1e0439-cb8b-41ca-88f2-649d6ad76065"), null, "333.333.333-03", new DateTimeOffset(new DateTime(2023, 8, 23, 15, 44, 22, 787, DateTimeKind.Unspecified).AddTicks(7394), new TimeSpan(0, 0, 0, 0, 0)), "teste03@teste.com", "Teste3" },
                    { new Guid("5b09be78-3f35-4406-87bb-7b91b87607fc"), null, "444.444.444-04", new DateTimeOffset(new DateTime(2023, 8, 23, 15, 44, 22, 787, DateTimeKind.Unspecified).AddTicks(7747), new TimeSpan(0, 0, 0, 0, 0)), "teste04@teste.com", "Teste4" },
                    { new Guid("b144f25f-0cbc-4ffb-a66a-630c7115a119"), null, "222.222.222-02", new DateTimeOffset(new DateTime(2023, 8, 23, 15, 44, 22, 787, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, 0, 0, 0, 0)), "teste02@teste.com", "Teste2" },
                    { new Guid("e0ee2bbb-254c-48f1-b8b4-165a8da2a0ff"), null, "111.111.111-01", new DateTimeOffset(new DateTime(2023, 8, 23, 15, 44, 22, 787, DateTimeKind.Unspecified).AddTicks(6442), new TimeSpan(0, 0, 0, 0, 0)), "teste01@teste.com", "Teste1" },
                    { new Guid("f85d2b70-bfc3-4af8-a741-7903fb444f54"), null, "666.666.666-06", new DateTimeOffset(new DateTime(2023, 8, 23, 15, 44, 22, 787, DateTimeKind.Unspecified).AddTicks(8436), new TimeSpan(0, 0, 0, 0, 0)), "teste06@teste.com", "Teste6" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Brothers_BrotherDomainId",
                table: "Games",
                column: "BrotherDomainId",
                principalTable: "Brothers",
                principalColumn: "Id");
        }
    }
}
