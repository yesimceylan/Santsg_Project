using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace santsg.project.Migrations
{
    /// <inheritdoc />
    public partial class rezmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rezName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rezPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rezEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rezPerson = table.Column<int>(type: "int", nullable: false),
                    rezDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rezDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rezEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rezCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
