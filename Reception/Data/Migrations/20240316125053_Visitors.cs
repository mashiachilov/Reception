using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceptionApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Visitors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceptId",
                table: "Visitors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ReceptId",
                table: "Visitors",
                column: "ReceptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Receptions_ReceptId",
                table: "Visitors",
                column: "ReceptId",
                principalTable: "Receptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Receptions_ReceptId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_ReceptId",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "ReceptId",
                table: "Visitors");
        }
    }
}
