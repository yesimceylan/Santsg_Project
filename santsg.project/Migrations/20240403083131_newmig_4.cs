using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace santsg.project.Migrations
{
    /// <inheritdoc />
    public partial class newmig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bathrooms",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bedrooms",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HotelImage4",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeopleCount",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Bedrooms",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelImage4",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PeopleCount",
                table: "Hotels");
        }
    }
}
