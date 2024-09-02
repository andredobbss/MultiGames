using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiGames.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TelPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CelPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DateCriate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brothers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCriate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brothers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brothers_Adresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VersionEdition = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DateOut = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BrotherDomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCriate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Brothers_BrotherDomainId",
                        column: x => x.BrotherDomainId,
                        principalTable: "Brothers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Brothers_AddressId",
                table: "Brothers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_BrotherDomainId",
                table: "Games",
                column: "BrotherDomainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Brothers");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
