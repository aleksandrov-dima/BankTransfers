using Microsoft.EntityFrameworkCore.Migrations;

namespace BankTransfers.Data.Migrations
{
    public partial class AddCommisionMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankTransferTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransferTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferCommisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SenderAccountTypeId = table.Column<int>(type: "int", nullable: true),
                    RecipientAccountTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferCommisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferCommisions_AccountTypes_RecipientAccountTypeId",
                        column: x => x.RecipientAccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferCommisions_AccountTypes_SenderAccountTypeId",
                        column: x => x.SenderAccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankCommisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BanTransferTypeId = table.Column<int>(type: "int", nullable: true),
                    BankTransferTypeId = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCommisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCommisions_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankCommisions_BankTransferTypes_BankTransferTypeId",
                        column: x => x.BankTransferTypeId,
                        principalTable: "BankTransferTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BankCommisions",
                columns: new[] { "Id", "BanTransferTypeId", "BankId", "BankTransferTypeId", "Rate" },
                values: new object[,]
                {
                    { 1, 1, 1, null, 0m },
                    { 2, 2, 1, null, 1.0m },
                    { 3, 1, 2, null, 0m },
                    { 4, 2, 2, null, 2.0m },
                    { 5, 1, 3, null, 1.0m },
                    { 6, 2, 3, null, 2.5m }
                });

            migrationBuilder.InsertData(
                table: "BankTransferTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Внутренний перевод" },
                    { 2, "На счет в другом банке" }
                });

            migrationBuilder.InsertData(
                table: "TransferCommisions",
                columns: new[] { "Id", "Rate", "RecipientAccountTypeId", "SenderAccountTypeId" },
                values: new object[,]
                {
                    { 7, 4.0m, 1, 3 },
                    { 6, 4.0m, 3, 2 },
                    { 5, 3.0m, 2, 2 },
                    { 1, 0m, 1, 1 },
                    { 3, 0m, 3, 1 },
                    { 2, 0m, 2, 1 },
                    { 8, 6.0m, 2, 3 },
                    { 4, 2.0m, 1, 2 },
                    { 9, 6.0m, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankCommisions_BankId",
                table: "BankCommisions",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankCommisions_BankTransferTypeId",
                table: "BankCommisions",
                column: "BankTransferTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferCommisions_RecipientAccountTypeId",
                table: "TransferCommisions",
                column: "RecipientAccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferCommisions_SenderAccountTypeId",
                table: "TransferCommisions",
                column: "SenderAccountTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCommisions");

            migrationBuilder.DropTable(
                name: "TransferCommisions");

            migrationBuilder.DropTable(
                name: "BankTransferTypes");
        }
    }
}
