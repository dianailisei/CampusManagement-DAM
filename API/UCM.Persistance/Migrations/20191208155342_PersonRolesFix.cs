using Microsoft.EntityFrameworkCore.Migrations;

namespace UCM.Persistance.Migrations
{
    public partial class PersonRolesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonRole_Persons_PersonId",
                table: "PersonRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRole_Roles_RoleId",
                table: "PersonRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonRole",
                table: "PersonRole");

            migrationBuilder.RenameTable(
                name: "PersonRole",
                newName: "PersonRoles");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRole_RoleId",
                table: "PersonRoles",
                newName: "IX_PersonRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonRoles",
                table: "PersonRoles",
                columns: new[] { "PersonId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Persons_PersonId",
                table: "PersonRoles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Roles_RoleId",
                table: "PersonRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Persons_PersonId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Roles_RoleId",
                table: "PersonRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonRoles",
                table: "PersonRoles");

            migrationBuilder.RenameTable(
                name: "PersonRoles",
                newName: "PersonRole");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRoles_RoleId",
                table: "PersonRole",
                newName: "IX_PersonRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonRole",
                table: "PersonRole",
                columns: new[] { "PersonId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRole_Persons_PersonId",
                table: "PersonRole",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRole_Roles_RoleId",
                table: "PersonRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
