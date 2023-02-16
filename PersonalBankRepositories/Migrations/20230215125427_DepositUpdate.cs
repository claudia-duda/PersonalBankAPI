using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBankRepositories.Migrations
{
    public partial class DepositUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Deposits",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTransaction",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTransaction",
                table: "Deposits");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Deposits",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
