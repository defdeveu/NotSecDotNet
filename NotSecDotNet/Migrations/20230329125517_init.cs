using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotSecDotNet.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "MovieObjects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MovieObjects",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A beautiful, handpainted lively model of the young Lea.", "Princess Lea figure", 3500 },
                    { 2, "A beautiful, handpainted exclusvely-green model of Yoda.", "Yoda figure", 3600 },
                    { 3, "A full-sized authentic costume of Darth-veder with boots, trousers, robe, mask and a beutifully cracted light-sword", "Full Darth Veder Armor", 214750 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", "sci-fi", "Star Wars - A new hope" },
                    { 2, "After the Rebels are overpowered by the Empire, Luke Skywalker begins Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.", "sci-fi", "Star Wars - The Empire Strikes Back" },
                    { 3, "After rescuing Han Solo from Jabba the Hutt, the Rebels attempt to destroy the second Death Star, while Luke struggles to help Darth Vader back from the dark side.", "sci-fi", "Star Wars - The Return of the Jedi" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Motto", "Name", "Password", "Sex", "WebPageUrl" },
                values: new object[,]
                {
                    { 1, "youda@jeditemple.org", "I don't know how old I am", "Yoda", "NoSecretsATrueJediHas", "m", "http://www.starwars.com/databank/yoda" },
                    { 2, "vader@jeditemple.org", "I see a red door and I want it paint it back", "Darth Vader", "IamYourFather", "m", "http://www.starwars.com/databank/vader" },
                    { 3, "leia@jeditemple.org", "I wish I have choosen the Wookie instead", "Princess Leia", "Hansword123", "f", "http://www.starwars.com/databank/leia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieObjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieObjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieObjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "MovieObjects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
