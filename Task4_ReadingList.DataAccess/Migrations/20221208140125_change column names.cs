using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4ReadingList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changecolumnnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Books",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Books",
                newName: "Priority");
        }
    }
}
