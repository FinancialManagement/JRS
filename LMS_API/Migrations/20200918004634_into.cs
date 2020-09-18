using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS_API.Migrations
{
    public partial class into : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorityJurisdiction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C = table.Column<int>(nullable: false),
                    R = table.Column<int>(nullable: false),
                    U = table.Column<int>(nullable: false),
                    D = table.Column<int>(nullable: false),
                    A = table.Column<int>(nullable: false),
                    B = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorityJurisdiction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Record = table.Column<string>(nullable: true),
                    RecordTime = table.Column<DateTime>(nullable: false),
                    Collector = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LMS_Apply",
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
                    table.PrimaryKey("PK_LMS_Apply", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "LMS_Client",
                columns: table => new
                {
                    SId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SName = table.Column<string>(nullable: true),
                    SPhone = table.Column<string>(nullable: true),
                    SCard = table.Column<string>(nullable: true),
                    SNation = table.Column<int>(nullable: false),
                    SXueli = table.Column<int>(nullable: false),
                    SSfrom = table.Column<string>(nullable: true),
                    SXFrom = table.Column<string>(nullable: true),
                    SImg1 = table.Column<string>(nullable: true),
                    SImg2 = table.Column<string>(nullable: true),
                    SWorks = table.Column<string>(nullable: true),
                    SMonthly = table.Column<int>(nullable: false),
                    SQFrom = table.Column<string>(nullable: true),
                    SQPhone = table.Column<string>(nullable: true),
                    SJian = table.Column<string>(nullable: true),
                    SBei = table.Column<string>(nullable: true),
                    SYin = table.Column<string>(nullable: true),
                    SMm = table.Column<string>(nullable: true),
                    SKuan = table.Column<int>(nullable: false),
                    SHei = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_Client", x => x.SId);
                });

            migrationBuilder.CreateTable(
                name: "LMS_DState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_DState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lms_Education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lms_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LMS_ShouJi",
                columns: table => new
                {
                    JId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SJId = table.Column<int>(nullable: false),
                    JName = table.Column<int>(nullable: false),
                    JNei = table.Column<int>(nullable: false),
                    JTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_ShouJi", x => x.JId);
                });

            migrationBuilder.CreateTable(
                name: "LMS_State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LMS_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperateUser = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    RequestMethod = table.Column<string>(nullable: true),
                    ExecutionDura = table.Column<int>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true),
                    ExecutionResult = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuJurisdiction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MName = table.Column<string>(nullable: true),
                    PId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuJurisdiction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RId = table.Column<int>(nullable: false),
                    MId = table.Column<int>(nullable: false),
                    AId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    RecordTime = table.Column<DateTime>(nullable: false),
                    Operator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periods = table.Column<int>(nullable: false),
                    BullDate = table.Column<DateTime>(nullable: false),
                    Capital = table.Column<string>(maxLength: 50, nullable: true),
                    Interest = table.Column<string>(maxLength: 50, nullable: true),
                    DefaultInterest = table.Column<string>(maxLength: 50, nullable: true),
                    AmountMonry = table.Column<string>(maxLength: 50, nullable: true),
                    RepaymentMoney = table.Column<int>(nullable: false),
                    RepaymentDate = table.Column<DateTime>(nullable: false),
                    DingWai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true),
                    States = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdateRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UpdateContext = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UId = table.Column<int>(nullable: false),
                    RId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserPwd = table.Column<string>(nullable: true),
                    PId = table.Column<int>(nullable: false),
                    States = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorityJurisdiction");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "LMS_Apply");

            migrationBuilder.DropTable(
                name: "LMS_Client");

            migrationBuilder.DropTable(
                name: "LMS_DState");

            migrationBuilder.DropTable(
                name: "Lms_Education");

            migrationBuilder.DropTable(
                name: "LMS_ShouJi");

            migrationBuilder.DropTable(
                name: "LMS_State");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "MenuJurisdiction");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "RaInfo");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "RepaymentSchedule");

            migrationBuilder.DropTable(
                name: "RoleInfo");

            migrationBuilder.DropTable(
                name: "UpdateRecord");

            migrationBuilder.DropTable(
                name: "UrInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
