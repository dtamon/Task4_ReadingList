using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4ReadingList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addIsReadfieldtoBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Books");
        }
    }
}
