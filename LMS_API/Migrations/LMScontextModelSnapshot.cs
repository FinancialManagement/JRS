﻿// <auto-generated />
using System;
using AD_LMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LMS_API.Migrations
{
    [DbContext(typeof(LMScontext))]
    partial class LMScontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AD_LMS.Models.Cxy.AuthorityJurisdiction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("A")
                        .HasColumnType("int");

                    b.Property<int>("B")
                        .HasColumnType("int");

                    b.Property<int>("C")
                        .HasColumnType("int");

                    b.Property<int>("D")
                        .HasColumnType("int");

                    b.Property<int>("R")
                        .HasColumnType("int");

                    b.Property<int>("U")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuthorityJurisdiction");
                });

            modelBuilder.Entity("AD_LMS.Models.Cxy.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExecutionDura")
                        .HasColumnType("int");

                    b.Property<int>("ExecutionResult")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("AD_LMS.Models.Cxy.MenuJurisdiction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MenuJurisdiction");
                });

            modelBuilder.Entity("AD_LMS.Models.Cxy.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("AD_LMS.Models.Cxy.RaInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AId")
                        .HasColumnType("int");

                    b.Property<int>("MId")
                        .HasColumnType("int");

                    b.Property<int>("RId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RaInfo");
                });

            modelBuilder.Entity("AD_LMS.Models.Cxy.RoleInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("States")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoleInfo");
                });

            modelBuilder.Entity("AD_LMS.Models.Cxy.UrInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RId")
                        .HasColumnType("int");

                    b.Property<int>("UId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UrInfo");
                });

            modelBuilder.Entity("AD_LMS.Models.Cxy.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("States")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPwd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("AD_LMS.Models.RepaymentSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmountMonry")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("BullDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Capital")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DefaultInterest")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("DingWai")
                        .HasColumnType("int");

                    b.Property<string>("Interest")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Periods")
                        .HasColumnType("int");

                    b.Property<DateTime>("RepaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RepaymentMoney")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RepaymentSchedule");
                });

            modelBuilder.Entity("AD_LMS.Models.UpdateRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateContext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdateDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UpdateRecord");
                });

            modelBuilder.Entity("AD_LMS.Models.WzbModels.LMS_Apply", b =>
                {
                    b.Property<int>("DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DCount")
                        .HasColumnType("int");

                    b.Property<string>("DDan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DFMoney")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DFTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DFei")
                        .HasColumnType("int");

                    b.Property<string>("DFu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DHuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DJia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DJing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DJy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DLi")
                        .HasColumnType("int");

                    b.Property<int>("DMoney")
                        .HasColumnType("int");

                    b.Property<int>("DName")
                        .HasColumnType("int");

                    b.Property<string>("DNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DSzt")
                        .HasColumnType("int");

                    b.Property<string>("DTu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DYi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SDTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DId");

                    b.ToTable("LMS_Apply");
                });

            modelBuilder.Entity("AD_LMS.Models.WzbModels.LMS_Client", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SBei")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SHei")
                        .HasColumnType("int");

                    b.Property<string>("SImg1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SImg2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SJian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SKuan")
                        .HasColumnType("int");

                    b.Property<string>("SMm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SMonthly")
                        .HasColumnType("int");

                    b.Property<string>("SName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SNation")
                        .HasColumnType("int");

                    b.Property<string>("SPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SQFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SQPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSfrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SWorks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SXFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SXueli")
                        .HasColumnType("int");

                    b.Property<string>("SYin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SId");

                    b.ToTable("LMS_Client");
                });

            modelBuilder.Entity("AD_LMS.Models.WzbModels.LMS_DState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LMS_DState");
                });

            modelBuilder.Entity("AD_LMS.Models.WzbModels.LMS_Nation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LMS_Nation");
                });

            modelBuilder.Entity("AD_LMS.Models.WzbModels.LMS_ShouJi", b =>
                {
                    b.Property<int>("JId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JName")
                        .HasColumnType("int");

                    b.Property<int>("JNei")
                        .HasColumnType("int");

                    b.Property<int>("JTime")
                        .HasColumnType("int");

                    b.Property<int>("SJId")
                        .HasColumnType("int");

                    b.HasKey("JId");

                    b.ToTable("LMS_ShouJi");
                });

            modelBuilder.Entity("AD_LMS.Models.WzbModels.LMS_State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LMS_State");
                });

            modelBuilder.Entity("AD_LMS.Models.WzbModels.Lms_Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lms_Education");
                });

            modelBuilder.Entity("AD_LMS.Models.zmm.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Collector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Record")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("AD_LMS.Models.zmm.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("LMS_API.Models.WzbModels.LMS_Ding", b =>
                {
                    b.Property<int>("DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DCount")
                        .HasColumnType("int");

                    b.Property<string>("DDan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DFMoney")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DFTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DFei")
                        .HasColumnType("int");

                    b.Property<string>("DFu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DHuan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DJia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DJing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DJy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DLi")
                        .HasColumnType("int");

                    b.Property<int>("DMoney")
                        .HasColumnType("int");

                    b.Property<int>("DName")
                        .HasColumnType("int");

                    b.Property<string>("DNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DSzt")
                        .HasColumnType("int");

                    b.Property<string>("DTu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DYi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SDTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DId");

                    b.ToTable("LMS_Ding");
                });
#pragma warning restore 612, 618
        }
    }
}
