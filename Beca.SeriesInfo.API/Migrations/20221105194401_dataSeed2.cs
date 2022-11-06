using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.SeriesInfo.API.Migrations
{
    public partial class dataSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Descripcion", "Titulo" },
                values: new object[] { 4, "Descripcion", "Dark" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
