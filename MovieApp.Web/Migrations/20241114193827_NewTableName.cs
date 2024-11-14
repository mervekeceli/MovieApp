using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Web.Migrations
{
    public partial class NewTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crewers_Movies_MovieId",
                table: "Crewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Crewers_People_PersonId",
                table: "Crewers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crewers",
                table: "Crewers");

            migrationBuilder.RenameTable(
                name: "Crewers",
                newName: "Crews");

            migrationBuilder.RenameIndex(
                name: "IX_Crewers_PersonId",
                table: "Crews",
                newName: "IX_Crews_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Crewers_MovieId",
                table: "Crews",
                newName: "IX_Crews_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crews",
                table: "Crews",
                column: "CrewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Movies_MovieId",
                table: "Crews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_People_PersonId",
                table: "Crews",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Movies_MovieId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Crews_People_PersonId",
                table: "Crews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crews",
                table: "Crews");

            migrationBuilder.RenameTable(
                name: "Crews",
                newName: "Crewers");

            migrationBuilder.RenameIndex(
                name: "IX_Crews_PersonId",
                table: "Crewers",
                newName: "IX_Crewers_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Crews_MovieId",
                table: "Crewers",
                newName: "IX_Crewers_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crewers",
                table: "Crewers",
                column: "CrewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crewers_Movies_MovieId",
                table: "Crewers",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crewers_People_PersonId",
                table: "Crewers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
