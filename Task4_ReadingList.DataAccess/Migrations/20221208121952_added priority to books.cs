using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4ReadingList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedprioritytobooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Books");
        }
    }
}
