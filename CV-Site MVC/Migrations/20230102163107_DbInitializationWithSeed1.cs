using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CV_Site_MVC.Migrations
{
    public partial class DbInitializationWithSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_AspNetUsers_UserID",
                table: "Project_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_Projects_ProjektID",
                table: "Project_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_CV_cVs_CVID",
                table: "Work_CV");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_CV_Works_WorkID",
                table: "Work_CV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Work_CV",
                table: "Work_CV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project_User",
                table: "Project_User");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cVs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Work_CV",
                newName: "Work_CVs");

            migrationBuilder.RenameTable(
                name: "Project_User",
                newName: "Project_Users");

            migrationBuilder.RenameIndex(
                name: "IX_Work_CV_CVID",
                table: "Work_CVs",
                newName: "IX_Work_CVs_CVID");

            migrationBuilder.RenameIndex(
                name: "IX_Project_User_ProjektID",
                table: "Project_Users",
                newName: "IX_Project_Users_ProjektID");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Works",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Works",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Works",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "cVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "cVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "cVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "cVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "cVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrivateCV",
                table: "cVs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Work_CVs",
                table: "Work_CVs",
                columns: new[] { "WorkID", "CVID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project_Users",
                table: "Project_Users",
                columns: new[] { "UserID", "ProjektID" });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_cVs_CVId",
                        column: x => x.CVId,
                        principalTable: "cVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_cVs_CVId",
                        column: x => x.CVId,
                        principalTable: "cVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CVId",
                table: "Educations",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CVId",
                table: "Skills",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Users_AspNetUsers_UserID",
                table: "Project_Users",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Users_Projects_ProjektID",
                table: "Project_Users",
                column: "ProjektID",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_CVs_cVs_CVID",
                table: "Work_CVs",
                column: "CVID",
                principalTable: "cVs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_CVs_Works_WorkID",
                table: "Work_CVs",
                column: "WorkID",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Users_AspNetUsers_UserID",
                table: "Project_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Users_Projects_ProjektID",
                table: "Project_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_CVs_cVs_CVID",
                table: "Work_CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_CVs_Works_WorkID",
                table: "Work_CVs");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Work_CVs",
                table: "Work_CVs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project_Users",
                table: "Project_Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "cVs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "cVs");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "cVs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "cVs");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "cVs");

            migrationBuilder.DropColumn(
                name: "PrivateCV",
                table: "cVs");

            migrationBuilder.RenameTable(
                name: "Work_CVs",
                newName: "Work_CV");

            migrationBuilder.RenameTable(
                name: "Project_Users",
                newName: "Project_User");

            migrationBuilder.RenameIndex(
                name: "IX_Work_CVs_CVID",
                table: "Work_CV",
                newName: "IX_Work_CV_CVID");

            migrationBuilder.RenameIndex(
                name: "IX_Project_Users_ProjektID",
                table: "Project_User",
                newName: "IX_Project_User_ProjektID");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Works",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Work_CV",
                table: "Work_CV",
                columns: new[] { "WorkID", "CVID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project_User",
                table: "Project_User",
                columns: new[] { "UserID", "ProjektID" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "fe704781-7da0-4006-ae2a-addc6740c5f4", "IdentityUser", null, false, false, null, null, null, null, null, false, "6b2cd182-6c63-43df-80f3-0363550d4c19", false, "Patte1337" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "EndDate", "ProjectName", "StartDate", "UserId" },
                values: new object[] { 1, "Rymdvarelser och så", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MIB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(10), null });

            migrationBuilder.InsertData(
                table: "cVs",
                columns: new[] { "ID", "UserID", "Utbildning" },
                values: new object[] { 2, null, "Ekonomi" });

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_AspNetUsers_UserID",
                table: "Project_User",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_Projects_ProjektID",
                table: "Project_User",
                column: "ProjektID",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_CV_cVs_CVID",
                table: "Work_CV",
                column: "CVID",
                principalTable: "cVs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_CV_Works_WorkID",
                table: "Work_CV",
                column: "WorkID",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
