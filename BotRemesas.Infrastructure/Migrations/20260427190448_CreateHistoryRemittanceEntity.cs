using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotRemesas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateHistoryRemittanceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PerCent",
                table: "Users",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "HistoryRemittances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AmountPay = table.Column<double>(type: "double precision", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Customer = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryRemittances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryRemittances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryRemittances_UserId",
                table: "HistoryRemittances",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryRemittances");

            migrationBuilder.DropColumn(
                name: "PerCent",
                table: "Users");
        }
    }
}
