using Microsoft.EntityFrameworkCore.Migrations;

namespace BankTransfers.Data.Migrations
{
    public partial class AlterCommisionMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanTransferTypeId",
                table: "BankCommisions");

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "BankTransferTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "BankTransferTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "BankTransferTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 4,
                column: "BankTransferTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 5,
                column: "BankTransferTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 6,
                column: "BankTransferTypeId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BanTransferTypeId",
                table: "BankCommisions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BanTransferTypeId", "BankTransferTypeId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BanTransferTypeId", "BankTransferTypeId" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BanTransferTypeId", "BankTransferTypeId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BanTransferTypeId", "BankTransferTypeId" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BanTransferTypeId", "BankTransferTypeId" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "BankCommisions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BanTransferTypeId", "BankTransferTypeId" },
                values: new object[] { 2, null });
        }
    }
}
