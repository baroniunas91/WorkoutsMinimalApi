using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutsMinimalApi.Migrations
{
    /// <inheritdoc />
    public partial class exercisedurationtoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "duration",
                table: "exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "duration",
                table: "exercises",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
