using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutsMinimalApi.Migrations
{
    /// <inheritdoc />
    public partial class workoutdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "workouts",
                type: "timestamp",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "workouts");
        }
    }
}
