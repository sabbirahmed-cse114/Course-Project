using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iTransition.Forms.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TagTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ef5e8c0-ea9e-458d-b82f-9bd361f6eae5"), "Other" },
                    { new Guid("0fadbf4c-f8cf-4937-86a2-0ca33feb33f9"), "Survey" },
                    { new Guid("24a44820-cff8-4509-aa16-a1f4c5bb0bd5"), "Quiz" },
                    { new Guid("4db86802-9aea-4e7e-801a-b05a2463be39"), "Developer" },
                    { new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), "General" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
