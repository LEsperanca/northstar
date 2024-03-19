using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NorthStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_people_identity_id",
                table: "people");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "people",
                newName: "person_role");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person_role",
                columns: table => new
                {
                    people_id = table.Column<Guid>(type: "uuid", nullable: false),
                    roles_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_person_role", x => new { x.people_id, x.roles_id });
                    table.ForeignKey(
                        name: "fk_person_role_person_people_id",
                        column: x => x.people_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_person_role_role_roles_id",
                        column: x => x.roles_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Registered" });

            migrationBuilder.CreateIndex(
                name: "ix_person_role_roles_id",
                table: "person_role",
                column: "roles_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person_role");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.RenameColumn(
                name: "person_role",
                table: "people",
                newName: "role");

            migrationBuilder.CreateIndex(
                name: "ix_people_identity_id",
                table: "people",
                column: "identity_id",
                unique: true);
        }
    }
}
