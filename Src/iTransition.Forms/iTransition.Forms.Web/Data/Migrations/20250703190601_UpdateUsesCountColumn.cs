using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTransition.Forms.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsesCountColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UsageCount",
                table: "Templates",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UsageCount",
                table: "Templates",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
