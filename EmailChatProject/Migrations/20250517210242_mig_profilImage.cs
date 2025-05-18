using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailChatProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_profilImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageURL",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageURL",
                table: "AspNetUsers");
        }
    }
}
