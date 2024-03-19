using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Added_CvsDoc_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    docTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    docCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    docType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    docPublish = table.Column<DateTime>(type: "datetime2", nullable: true),
                    docValid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    docExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    docPlace = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DocStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    docSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDocs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewDocs");
        }
    }
}
