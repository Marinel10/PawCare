using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawCare.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 0, "e3e6b69f-2ae6-4582-9897-c60ef6ee988a", "admin@pawcare.com", true, false, null, "ADMIN@PAWCARE.COM", "ADMIN@PAWCARE.COM", "AQAAAAIAAYagAAAAEKhDkTzvJz3qG3+BVO3GFgEzqh3dfIii7isI3QhEP8efICKu3hG9NM/3QRlmn14URQ==", null, false, "8e774dec-aee7-4c6f-a295-c3e23f2e3746", false, "admin@pawcare.com" });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Routine veterinary examination", "General Examination", 30.00m },
                    { 2, "Standard pet vaccination", "Vaccination", 45.00m },
                    { 3, "Laboratory blood examination", "Blood Test", 60.00m },
                    { 4, "Pet identification microchip", "Microchipping", 40.00m },
                    { 5, "Internal parasite treatment", "Deworming", 25.00m },
                    { 6, "Diagnostic ultrasound examination", "Ultrasound", 75.00m },
                    { 7, "Diagnostic radiography", "X-ray", 80.00m },
                    { 8, "Professional dental cleaning", "Dental Cleaning", 120.00m }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Rabbit" },
                    { 4, "Bird" },
                    { 5, "Hamster" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Name", "SpeciesId" },
                values: new object[,]
                {
                    { 1, "Labrador Retriever", 1 },
                    { 2, "German Shepherd", 1 },
                    { 3, "Golden Retriever", 1 },
                    { 4, "Bulldog", 1 },
                    { 5, "Beagle", 1 },
                    { 6, "British Shorthair", 2 },
                    { 7, "Persian", 2 },
                    { 8, "Maine Coon", 2 },
                    { 9, "Siamese", 2 },
                    { 10, "Holland Lop", 3 },
                    { 11, "Netherland Dwarf", 3 },
                    { 12, "Budgerigar", 4 },
                    { 13, "Cockatiel", 4 },
                    { 14, "Syrian Hamster", 5 },
                    { 15, "Dwarf Hamster", 5 }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDate", "BreedId", "Gender", "IsDeleted", "Name", "OwnerId", "PetImageUrl", "SpeciesId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, "Max", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", null, 1 },
                    { 2, new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, false, "Bella", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", null, 1 },
                    { 3, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, false, "Milo", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", null, 2 },
                    { 4, new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2, false, "Luna", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", null, 2 },
                    { 5, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, false, "Coco", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", null, 3 },
                    { 6, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 2, false, "Kiwi", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", null, 4 },
                    { 7, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 1, false, "Nibbles", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", null, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
