using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdentityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identity_id",
                table: "people",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_people_identity_id",
                table: "people",
                column: "identity_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_people_identity_id",
                table: "people");

            migrationBuilder.DropColumn(
                name: "identity_id",
                table: "people");
        }
    }
}
