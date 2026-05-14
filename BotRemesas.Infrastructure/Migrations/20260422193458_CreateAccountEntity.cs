using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotRemesas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAccountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Remittances",
                newName: "AccountId");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    AdminId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remittances_AccountId",
                table: "Remittances",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AdminId",
                table: "Accounts",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remittances_Accounts_AccountId",
                table: "Remittances",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remittances_Accounts_AccountId",
                table: "Remittances");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Remittances_AccountId",
                table: "Remittances");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Remittances",
                newName: "Address");
        }
    }
}
