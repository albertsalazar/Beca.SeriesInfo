using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beca.SeriesInfo.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Descripcion", "Titulo" },
                values: new object[] { 1, "Descripcion", "Breaking Bad" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Descripcion", "Titulo" },
                values: new object[] { 2, "Descripcion", "The Bear" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Descripcion", "Titulo" },
                values: new object[] { 3, "Descripcion", "Bojack Horseman" });

            migrationBuilder.InsertData(
                table: "Capitulos",
                columns: new[] { "Id", "Descripcion", "SerieId", "Titulo" },
                values: new object[] { 1, "Descripcion", 1, "Cap 1" });

            migrationBuilder.InsertData(
                table: "Capitulos",
                columns: new[] { "Id", "Descripcion", "SerieId", "Titulo" },
                values: new object[] { 2, "Descripcion2", 1, "Cap 2" });

            migrationBuilder.InsertData(
                table: "Capitulos",
                columns: new[] { "Id", "Descripcion", "SerieId", "Titulo" },
                values: new object[] { 3, "Descripcion3", 2, "Cap 1" });

            migrationBuilder.InsertData(
                table: "Capitulos",
                columns: new[] { "Id", "Descripcion", "SerieId", "Titulo" },
                values: new object[] { 4, "Descripcion4", 2, "Cap 2" });

            migrationBuilder.InsertData(
                table: "Capitulos",
                columns: new[] { "Id", "Descripcion", "SerieId", "Titulo" },
                values: new object[] { 5, "Descripcion5", 3, "Cap 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Capitulos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Capitulos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Capitulos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Capitulos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Capitulos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
