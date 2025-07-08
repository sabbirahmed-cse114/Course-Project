using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTransition.Forms.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsesCountColumn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsageCount",
                table: "Templates",
                newName: "UsesCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsesCount",
                table: "Templates",
                newName: "UsageCount");
        }
    }
}
