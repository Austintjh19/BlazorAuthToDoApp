using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCascadingAuth.Migrations
{
    /// <inheritdoc />
    public partial class Nationality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "ToDos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NationalityName = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalityId",
                table: "Users",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Nationalities_NationalityId",
                table: "Users",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Nationalities_NationalityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropIndex(
                name: "IX_Users_NationalityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "ToDos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
