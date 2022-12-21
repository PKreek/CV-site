using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CV_Site_MVC.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cVs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utbildning = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cVs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentTo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SentFrom = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SentFrom",
                        column: x => x.SentFrom,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SentTo",
                        column: x => x.SentTo,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project_User",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjektID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_User", x => new { x.UserID, x.ProjektID });
                    table.ForeignKey(
                        name: "FK_Project_User_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_User_Projects_ProjektID",
                        column: x => x.ProjektID,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Work_CV",
                columns: table => new
                {
                    WorkID = table.Column<int>(type: "int", nullable: false),
                    CVID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_CV", x => new { x.WorkID, x.CVID });
                    table.ForeignKey(
                        name: "FK_Work_CV_cVs_CVID",
                        column: x => x.CVID,
                        principalTable: "cVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_CV_Works_WorkID",
                        column: x => x.WorkID,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1e938ecc-ac36-445f-8390-4164e1b10b18", "fc408dfb-e699-430c-9272-d2693bdd85a6" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SentFrom",
                table: "Messages",
                column: "SentFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SentTo",
                table: "Messages",
                column: "SentTo");

            migrationBuilder.CreateIndex(
                name: "IX_Project_User_ProjektID",
                table: "Project_User",
                column: "ProjektID");

            migrationBuilder.CreateIndex(
                name: "IX_Work_CV_CVID",
                table: "Work_CV",
                column: "CVID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Project_User");

            migrationBuilder.DropTable(
                name: "Work_CV");

            migrationBuilder.DropTable(
                name: "cVs");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "019669df-cb16-41ac-b86c-325ccf47247b", "81b67786-9afa-463c-b466-dd9bef25662e" });
        }
    }
}
