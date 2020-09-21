using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS_API.Migrations
{
    public partial class inin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LMS_Ding",
                columns: table => new
                {
                    DId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNo = table.Column<string>(nullable: true),
                    DName = table.Column<int>(nullable: false),
                    DSzt = table.Column<int>(nullable: false),
                    DMoney = table.Column<int>(nullable: false),
                    DCount = table.Column<int>(nullable: false),
                    DTu = table.Column<string>(nullable: true),
                    DHuan = table.Column<string>(nullable: true),
                    DDan = table.Column<string>(nullable: true),
                    DJia = table.Column<string>(nullable: true),
                    SDTime = table.Column<DateTime>(nullable: false),
                    DFTime = table.Column<DateTime>(nullable: false),
                    DJing = table.Column<string>(nullable: true),
                    DFu = table.Column<string>(nullable: true),
                    DFMoney = table.Column<string>(nullable: true),
                    DLi = table.Column<int>(nullable: false),
                    DFei = table.Column<int>(nullable: false),
                    DYi = table.Column<string>(nullable: true),
                    DJy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_Ding", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "LMS_Nation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_Nation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LMS_Ding");

            migrationBuilder.DropTable(
                name: "LMS_Nation");
        }
    }
}
