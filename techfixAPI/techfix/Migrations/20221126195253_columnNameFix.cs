using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techfix.Migrations
{
    /// <inheritdoc />
    public partial class columnNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Quote",
                newName: "deviceModel");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscriber",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Quote",
                newName: "deviceModel");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscriber",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
