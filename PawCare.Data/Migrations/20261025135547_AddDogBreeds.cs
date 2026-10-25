using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawCare.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDogBreeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efae5c16-afc1-4d16-a5ec-ce71cc687735", "AQAAAAIAAYagAAAAENvmBTcSMiIZEZh/o60WsmxG0En4Ne2wMHgy7x6qW+JLke7uiVh7Q8clNL8iffuC4Q==", "0ab63e08-c330-46ad-b14c-08a26b71ed40" });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Name", "SpeciesId" },
                values: new object[,]
                {
                    { 16, "Miniature Pinscher", 1 },
                    { 17, "Cavalier King Charles Spaniel", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3e6b69f-2ae6-4582-9897-c60ef6ee988a", "AQAAAAIAAYagAAAAEKhDkTzvJz3qG3+BVO3GFgEzqh3dfIii7isI3QhEP8efICKu3hG9NM/3QRlmn14URQ==", "8e774dec-aee7-4c6f-a295-c3e23f2e3746" });
        }
    }
}
