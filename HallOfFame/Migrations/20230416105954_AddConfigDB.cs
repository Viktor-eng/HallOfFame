using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallOfFame.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Persons_PersonId",
                table: "Skill");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Persons_PersonId",
                table: "Skill",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Persons_PersonId",
                table: "Skill");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Persons_PersonId",
                table: "Skill",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
