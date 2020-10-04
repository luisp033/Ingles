using Microsoft.EntityFrameworkCore.Migrations;

namespace InglesAPI.Migrations
{
    public partial class Remove_Teoria_Req : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CapituloTeoria",
                table: "Capitulos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CapituloTeoria",
                table: "Capitulos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
