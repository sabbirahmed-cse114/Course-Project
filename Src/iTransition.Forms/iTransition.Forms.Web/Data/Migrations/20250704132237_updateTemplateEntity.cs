using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTransition.Forms.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTemplateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Tags_TagId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_TagId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Templates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Templates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TagId",
                table: "Templates",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Tags_TagId",
                table: "Templates",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
