using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTransition.Forms.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsesCountColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UsageCount",
                table: "Templates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsageCount",
                table: "Templates");
        }
    }
}
