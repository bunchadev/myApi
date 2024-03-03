using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myApi.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberStudents = table.Column<int>(type: "int", nullable: true),
                    Evaluate = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evaluate = table.Column<double>(type: "float", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonContents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    TitleVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeVideo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionVideos_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CreatedAt", "Description", "Evaluate", "FileName", "NameTitle", "NumberStudents", "Price", "ProductName", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("05aaf209-4aaf-45b4-8eec-6bc818df6b8e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Go  .", 4.0, "go.jpg", null, 51211, 127000, "Go Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0681c054-9a2e-4b53-885e-02b0d2e12c80"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản C# .", 4.0, "csharp.jpg", null, 11511, 232000, "C# Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0771e90b-ab56-4b5d-8b53-6a57ad2ab03a"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản NOSQL .", 4.5, "nosql.png", null, 51512, 300000, "NOSQL Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("077cdd6a-efc8-420a-8d94-97d68a6b285f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tập trung vào Khách hàng .", 3.0, "kh.png", null, 3112, 222000, "Chiến lược Tập trung vào Khách hàng .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("18cd27a7-1572-46bb-8fc4-07c924d3781b"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Emotions .", 3.5, "th.jpg", null, 5121, 178000, "Kỹ năng Quản lý Emotions .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19e2f438-5dd2-460d-a241-b4f971785d46"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Rust .", 3.0, "rust.jpg", null, 14141, 231000, "Rust Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "xiao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ Api với Asp.net core từ zero to here", 5.0, "aspnetcore.png", "Asp.net core api", 696969, 249000, "Full sờ tách with Asp.net core Api", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1faa370c-32b8-4fb6-accc-bc694177a841"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Shell Scripting  .", 4.5, "shell.jpg", null, 61211, 277000, "Shell Scripting  Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("252a632a-85b7-4a17-b808-731319881581"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Ruby .", 4.5, "ruby.png", null, 15121, 222000, "Ruby Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("268188ab-48e6-4ab0-af1e-660d4c5d591f"), "xiao Chun zz00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Php từ Zero to hero", 4.0, "php.jpg", null, 81278, 394000, "Php ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26c539e6-053c-438c-8cdc-31b31370f260"), "xiao Chun zzzzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Python từ Zero to hero", 4.5, "py.jpg", null, 31567, 390000, "Python ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31410821-8e87-49e5-a4bc-388704651a57"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Javascript từ Zero to hero", 3.5, "jss.jpg", null, 81278, 394000, "Javascript ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("377fba46-5264-4161-867b-5ff39d57a623"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán nhà từ Zero to hero", 3.5, "nha.webp", null, 46723, 198000, "Chiến lược bán nhà", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("380ddf8e-5f09-476f-b94a-91db5b842871"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản PHP .", 4.0, "php.jpg", null, 63352, 213000, "PHP Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3bf7e9a9-f564-40ec-adda-5b833997e451"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tìm hiểu Về Sức Khỏe .", 4.0, "suckhoe.jpg", null, 5121, 300000, "Kỹ năng Tìm hiểu Về Sức Khỏe .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e577a40-b9c3-404f-9b85-7d44c4200d20"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Dầu ăn .", 4.5, "dauan.jpg", null, 5161, 137000, "Kỹ năng Quản lý Mức độ Dầu ăn .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("408d3e90-f17c-49bc-a929-a9739cc397c1"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thời gian .", 4.0, "thoigian.jpg", null, 1416, 279000, "Kỹ năng Quản lý Thời gian .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4136cf59-fea2-4df5-9c5e-2b13fe692c46"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thức ăn Nhanh .", 4.5, "annhanh.jpg", null, 6111, 200000, "Kỹ năng Quản lý Thức ăn Nhanh .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41daee72-fd5b-4af0-b744-44a174c68b45"), "xiao Chun zzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Ruby từ Zero to hero", 4.5, "ruby.png", null, 99999, 389000, "Ruby ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42dc5878-eb83-4502-814f-ff23cbf58dbf"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Caffeine .", 4.5, "cafe.jpg", null, 8141, 179000, "Kỹ năng Quản lý Mức độ Caffeine .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("461bc7a5-026c-4f17-ab1a-bf91672c8bd5"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Stress .", 4.0, "stress.webp", null, 6161, 129000, "Kỹ năng Quản lý Stress .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("46768801-833d-4c61-a73d-0310d86fda13"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Objective .", 4.0, "obC.png", null, 61212, 123000, "Objective-C Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4be971f5-ff27-4adb-b876-e95863d8126a"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tình thần và Tâm lý .", 3.0, "tamly.jpeg", null, 1421, 231000, "Kỹ năng Tình thần và Tâm lý .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d9ca3a0-95f3-49ff-81b6-67b7a85b78b3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Đa dạng hóa .", 3.0, "dadang.jpg", null, 4311, 145000, "Chiến lược Đa dạng hóa .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4db26548-9d38-4e1a-9d1f-51eaee3d1e92"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Javascript trong 3 tháng", 3.5, "jsss.png", null, 31231, 145000, "Javascript Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57898d59-274e-41d2-b862-370cb7c84395"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Áp lực Công việc .", 4.5, "apluc.jpg", null, 5122, 221000, "Kỹ năng Quản lý Áp lực Công việc .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("610a8165-a1b1-4844-8d82-267ff1903fe3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mối quan hệ Xã hội .", 3.0, "quanhe.png", null, 6141, 146000, "Kỹ năng Quản lý Mối quan hệ Xã hội .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61bff8d9-3811-4127-9e02-299ae1cc6742"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán thịt lợn từ Zero to hero", 4.0, "thitlon.jpg", null, 1723, 199000, "Chiến lược bán thịt lợn", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("693bfb4f-8abf-47f0-8f85-21670282cc46"), "xiao Chun zzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn C# từ Zero to hero", 4.0, "csharp.jpg", null, 99999, 389000, "C# ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c9caf41-38eb-481a-be9e-18e45a79978b"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản NextJS .", 3.0, "nextjs.jpg", null, 14144, 233000, "NextJS Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f5355e5-01fd-46c5-929c-3690e9fec424"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Đau .", 3.0, "dau.jpg", null, 6231, 199000, "Kỹ năng Quản lý Đau .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("745b26fc-3956-40ef-89e6-f307323f25fb"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tập Luyện .", 4.5, "tapluyen.jpg", null, 5151, 222000, "Kỹ năng Tập Luyện .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("745fd0b5-7b61-445f-b2a0-0a287360c682"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản JQUERY .", 4.0, "jquery.webp", null, 61611, 145000, "JQUERY Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74b35a08-bf25-495a-9513-102a6e41eabc"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bàn hàng từ Zero to hero", 3.5, "Chien-luoc-ban-hang.png", null, 37853, 727000, "Chiến lược bán hàng", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75b84ea2-0218-4f4e-bf20-3d4659a3937d"), "xiao Chun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn NextJs từ Zero to hero", 4.5, "nextjs.jpg", null, 77777, 304000, "NextJs Pro Max !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "xiao Chun zz69", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Builds a web api application using Golang and Gin/Gorm", 5.0, "golangweb.jpg", "Golang gin&gorm", 670011, 199000, "Golang web api Pro Max !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bf227c8-0055-44d0-9416-bf781492b6eb"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Ngủ đủ giấc .", 4.5, "ngu.webp", null, 1511, 256000, "Kỹ năng Ngủ đủ giấc .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7fe967cf-92ef-485f-bb6e-ad80bda808a0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Dẫn đầu về Chi phí .", 3.5, "toan-cau.jpg", null, 4567, 213000, "Chiến lược Dẫn đầu về Chi phí .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("835fbab3-c491-4981-89ab-e0df0164bbeb"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thói quen Uống Nước .", 4.0, "uongnuoc.webp", null, 3412, 155000, "Kỹ năng Quản lý Thói quen Uống Nước .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("858c7553-c2af-4eaa-962d-83b9125b9b6f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Đường huyết .", 3.5, "huyet.jpg", null, 8214, 256000, "Kỹ năng Quản lý Mức độ Đường huyết .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a63bfc1-3aa1-418b-810d-0a257b8f8145"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Trọng lượng .", 3.0, "trong.png", null, 7373, 156000, "Kỹ năng Quản lý Trọng lượng .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8e5e54dc-5b43-49c7-ac5c-e411bd3fa88d"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm giàu 100%  từ Zero to hero", 4.0, "giau.jpg", null, 23723, 399000, "Nhà làm giàu tài ba", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9211e6f4-f390-4fd7-998e-ec2ed863b65f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Tiêu hóa .", 4.5, "tieuhoa.jpg", null, 6111, 266000, "Kỹ năng Quản lý Tiêu hóa .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("992ab9f3-bbc5-46ac-b0a4-ab2ccc55d0d0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Firebase .", 3.5, "firebase.png", null, 51211, 255000, "Firebase Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "xiao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ ReactJs siêu cấp vip pro", 5.0, "reactjs.png", "ReacJs Typescripts", 777777, 200000, "Làm chủ ReacJs", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a69368fe-e107-47d4-82df-3efbefb0c838"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn đầu tư từ Zero to hero", 4.0, "dautu.png", null, 42647, 847000, "Chiến lược đầu tư", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8c52cbf-eef6-4aa4-a60b-103ffc965ec4"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản React .", 4.5, "reactjs.png", null, 51412, 111000, "React Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0554849-8c3a-4c23-8e54-7e8b5ed05c1d"), "xiao Chun zz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn C++ từ Zero to hero", 4.5, "c++.png", null, 88888, 279000, "C++ ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1080006-6fb5-46ce-b3ab-ac6159f39ad6"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Đổi mới .", 3.0, "doimoi.jpg", null, 3111, 256000, "Chiến lược Đổi mới.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1e322b8-a14f-4eb6-9ada-3029b5c9f7db"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán rau từ Zero to hero", 3.5, "rau.jpg", null, 33723, 162000, "Chiến lược bán rau", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b21f8a41-e24e-412e-b413-1e647cc955b4"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn chứng khoán từ Zero to hero", 4.0, "ck.jpg", null, 278527, 277000, "Chiến lược chứng khoán", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6d3581e-f301-4660-af2c-b1612a811ed7"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Rủi ro .", 4.5, "rr.jpg", null, 6153, 298000, "Chiến lược Quản lý Rủi ro . ", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b875f669-8a6c-442b-a6ad-468d897186a1"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Hợp nhất Ngược dọc .", 4.5, "chi.jpg", null, 7161, 189000, "Chiến lược Hợp nhất Ngược dọc.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b90a8cb9-d786-4cf3-a046-d073d2bc2be0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản MongoDB .", 4.0, "mongodb.png", null, 85431, 100000, "MongoDB Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bae270f0-016c-48a1-bf0f-43816c4739fd"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Hợp nhất Ngang hàng.", 3.5, "chi.jpg", null, 1515, 123000, "Chiến lược Hợp nhất Ngang hàng.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70d57ed-3dae-4c50-851d-a56833fe873f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Toàn cầu hóa .", 4.5, "toan-cau.jpg", null, 4155, 238000, "Chiến lược Toàn cầu hóa.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c912b2d1-1953-4ccc-b3aa-5743f5318b9f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quyết định Lựa chọn Thức Ăn", 4.5, "thucan.jpg", null, 1516, 123000, "Kỹ năng Quyết định Lựa chọn Thức Ăn", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd2b92b4-8506-4097-a14a-a21ba371b2e0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn kinh doanh từ Zero to hero", 3.5, "chien.jpg", null, 53455, 327000, "Chiến lược kinh doanh", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cdd19e28-3926-49d2-ab08-fd0985554844"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Dotnet .", 3.5, "dotnet.jpg", null, 24146, 212000, "Dotnet Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce6c8831-4352-4b92-b030-2d87df4dc397"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tư duy Tích cực .", 4.5, "tuduy.png", null, 1451, 100000, "Kỹ năng Tư duy Tích cực .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0095d82-8d22-4aa9-ac30-2ae6d28e0013"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Python trong 5 tháng", 4.0, "py.jpg", null, 51241, 222000, "Python Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d75ec9af-792c-45a9-86a3-a3c16f368540"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn lùa gà từ Zero to hero", 5.0, "luaga.jpg", null, 698444, 249999, "Chiến lược lùa gà", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcc22d51-28bb-44aa-a4bf-404861802354"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản SQL .", 3.5, "sql.webp", null, 51221, 122000, "SQL Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd19336c-d70d-48d2-9771-27f437575bda"), "xiao Chun zzzzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Java từ Zero to hero", 4.5, "java.jpg", null, 31567, 390000, "Java ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e60a6f45-085c-4384-96de-89bb483c341f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản CSS .", 4.0, "css.jpg", null, 41511, 299000, "CSS Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec812e73-95ab-479e-8344-4abb9f9d8fc9"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản C++ .", 4.0, "c++.png", null, 61211, 234000, "C++ Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("efdf151f-cdca-4d65-848c-2442187970aa"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản ASP .", 3.5, "aspnetcore.png", null, 9542, 299000, "ASP Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f4b0b8c0-6387-48ee-a195-d14cc59e901e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Phát triển Sản phẩm .", 4.5, "sp.jpg", null, 1516, 167000, "Chiến lược Phát triển Sản phẩm .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa010360-8ef0-4653-bf38-081a3d3787e2"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Năng lượng .", 4.0, "Can bang.png", null, 6726, 261000, "Kỹ năng Quản lý Năng lượng .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb02adfd-cd8f-481e-98ab-9fa55e5d7edd"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Phát triển Thị trường .", 4.0, "thitruong.jpg", null, 5432, 231000, "Chiến lược Phát triển Thị trường .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fd9592fe-b4eb-479c-b935-107d92127fa2"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn tài xỉu từ Zero to hero", 5.0, "taixiu.png", null, 534634, 102000, "Chiến lược chơi tài xỉu", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Money", "Password", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("823af859-77b2-4604-9811-48871b73cc86"), "tn01@gmail.com", 10000000, "1232003", "123", "Admin", "XiaoChun" },
                    { new Guid("ad5ddeed-0ed5-4ea1-9a41-ca17321824eb"), "tn02@gmail.com", 10000000, "1232003", "321", "User", "XiaoCchun" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Title", "UpdatedAt", "UserName", "evaluate" },
                values: new object[,]
                {
                    { new Guid("0858976a-24d1-415d-b59c-e34466ca87c3"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(924), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Cần bổ xung thêm nhiều kiến thức hơn", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(924), "XiaoChun", 4.5 },
                    { new Guid("1e623900-b20f-4d2f-8285-0a8e887d1f23"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(917), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Qúa là tuyệt vời", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(917), "ThuongNguyen", 3.5 },
                    { new Guid("1edb48ad-5bf4-4c98-87a4-83494cebef60"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(910), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Quá là hay luôn", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(911), "TrungNguyen", 4.5 },
                    { new Guid("222c83ed-8cad-43c2-8989-e3a411559823"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(902), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Tôi đã ra khi học khóa này!", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(903), "CamTu", 4.0 },
                    { new Guid("321e76de-5c8e-4413-8eb5-a61771413e99"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(921), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Hay tôi đã học được nhiều thứ từ khóa học này", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(921), "HoangGiang", 4.0 },
                    { new Guid("35950927-c332-45d8-aa64-72fdccbb2443"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(927), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Hay vl!!!", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(928), "XiaoChun", 4.0 },
                    { new Guid("4db2131e-dabd-4373-8704-23d59c2c9ec0"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(930), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Qúa tệ!!!", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(930), "XiaoChun", 2.5 },
                    { new Guid("711d1288-4bab-459e-a4db-0b768aafd612"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(933), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Bla bla bla!!!", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(933), "XiaoChun", 4.0 },
                    { new Guid("89681459-1f2d-4450-a768-e4cb8f0583b6"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(908), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Khóa học không phù hợp với tôi", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(908), "TraMy", 3.0 },
                    { new Guid("897851d6-17cf-4565-9238-39df42069fd1"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(887), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Qúa hay và bổ ích", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(899), "XiaoChun", 4.5 },
                    { new Guid("9a1d4100-b3a7-4e43-8cdc-a94cc3e8d829"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(914), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Như cc!!!", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(914), "TrungNguyen", 2.5 },
                    { new Guid("ad4057c9-4e12-4f99-b40e-691b049a8d76"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(938), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Ưng quá chừng!", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(939), "XiaoChun", 4.5 },
                    { new Guid("ea082598-b200-45dd-ac8f-acc41a572fc6"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(935), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Amazing good chop!!!", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(936), "XiaoChun", 3.5 },
                    { new Guid("f576533c-2916-4413-b07a-d801c326c912"), new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(905), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Cần cập nhật thêm 1 số kiến thức", new DateTime(2024, 3, 3, 2, 48, 19, 716, DateTimeKind.Local).AddTicks(905), "LienNguyen", 3.5 }
                });

            migrationBuilder.InsertData(
                table: "LessonContents",
                columns: new[] { "Id", "ProductId", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Xây Dựng và Triển Khai API RESTful với ASP.NET Core" },
                    { 2, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Kết Nối và Làm Việc với Cơ Sở Dữ Liệu SQL Server" },
                    { 3, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Quản Lý Tài Nguyên và Xác Thực" },
                    { 4, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Tối Ưu Hóa Hiệu Suất và Xử Lý Lỗi" },
                    { 5, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Sử Dụng Middleware và Dependency Injection" },
                    { 6, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Thực Hiện Quan Hệ Đa Nhiều và Lazy Loading" },
                    { 7, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Xây Dựng và Triển Khai API RESTful với Golang & gorm gin" },
                    { 8, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Kết Nối và Làm Việc với Cơ Sở Dữ Liệu mySql" },
                    { 9, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Quản Lý Tài Nguyên và Xác Thực" },
                    { 10, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Tối Ưu Hóa Hiệu Suất và Xử Lý Lỗi" },
                    { 11, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Sử Dụng Middleware và Dependency Injection" },
                    { 12, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Thực Hiện Quan Hệ Đa Nhiều và Lazy Loading" },
                    { 13, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Tạo project với reactJs" },
                    { 14, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Kết Nối và Làm Việc backned NestJs" },
                    { 15, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Tạo component với reactJs" },
                    { 16, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Master css với reactJs" },
                    { 17, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Sử dụng typescript với reactJs" },
                    { 18, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Thực hành 1 project đầu tiên với reactJs và Typescript" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "ProductId", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Mở Đầu và Chuẩn Bị Môi Trường Code" },
                    { 2, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "ASP.NET Core là gì có tác dụng gì?" },
                    { 3, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Restfull api with API with ASP.NET Core" },
                    { 4, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Authorization with ASP.NET CORE API" },
                    { 5, new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Deploy ASP.NET CORE with Azure" },
                    { 6, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Hướng dẫn cài đặt Docker và run MySQL Container" },
                    { 7, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Tạo table mysql với TablePlus" },
                    { 8, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Insert data MySQL với TablePlus" },
                    { 9, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Primary Key và Index trên nhiều cột" },
                    { 10, new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "RestFul api với golang!!!" },
                    { 11, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Tại Sao Sử Dụng Hook Thay Vì Class Component" },
                    { 12, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Cài Đặt Môi Trường Dự Án React.JS với Hook" },
                    { 13, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Viết Hello World Với React Hook" },
                    { 14, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "3.1 Hạ Version React 18 Xuống 17" },
                    { 15, new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Components & Templates với React Hook" }
                });

            migrationBuilder.InsertData(
                table: "DescriptionVideos",
                columns: new[] { "Id", "TimeVideo", "TitleVideo", "VideoId" },
                values: new object[,]
                {
                    { 1, "03:25", "Cài Đặt Visual Studio Code hoặc Visual Studio", 1 },
                    { 2, "08:10", "Tạo Dự Án ASP.NET Core API", 1 },
                    { 3, "12:45", "Cấu Hình Cơ Sở Dữ Liệu", 1 },
                    { 4, "15:30", "Tạo Model và Migrate Database", 1 },
                    { 5, "20:15", "Chuẩn Bị Môi Trường Code", 1 },
                    { 6, "23:50", "Kết nối cơ sở dữ liệu Sql Server", 1 },
                    { 7, "03:25", "Giới Thiệu về ASP.NET Core", 2 },
                    { 8, "04:45", "Đa Nền Tảng và Mã Mở", 2 },
                    { 9, "02:21", "Hiệu Suất Cao và Tối Ưu Hóa", 2 },
                    { 10, "07:56", "Mô Hình Middleware và Dependency Injection", 2 },
                    { 11, "04:21", "Created User with ASP.NET Core", 3 },
                    { 12, "02:47", "Get User with ASP.NET Core", 3 },
                    { 13, "03:22", "Update User with ASP.NET Core", 3 },
                    { 14, "01:56", "Delete User with ASP.NET Core", 3 },
                    { 15, "07:32", "Get All Users with pagination with ASP.NET Core", 3 },
                    { 16, "08:21", "What JWT token ?", 4 },
                    { 17, "11:47", "Set up JWT token", 4 },
                    { 18, "06:22", "Create JWT token", 4 },
                    { 19, "18:56", "bla bla bla bla", 4 },
                    { 20, "09:32", "Refresh Token with ASP.NET CORE", 4 },
                    { 21, "03:21", "Create account Azure", 5 },
                    { 22, "12:47", "Set up account Azure", 5 },
                    { 23, "07:22", "Set Database connection to Azure", 5 },
                    { 24, "14:56", "bla bla bla bla", 5 },
                    { 25, "10:32", "Một số câu hỏi thêm", 5 },
                    { 26, "03:00", "Cài đặt Docker", 6 },
                    { 27, "01:54", "Confirm Docker & Start Docker", 6 },
                    { 28, "02:53", "MySQL Container", 6 },
                    { 29, "08:24", "TablePlus", 6 },
                    { 30, "00:15", "Tạo table bằng câu lệnh SQL", 7 },
                    { 31, "00:31", "Tạo table mới bằng TablePlus", 7 },
                    { 32, "00:44", "Đặt tên cho table", 7 },
                    { 33, "01:25", "Cột ID", 7 },
                    { 34, "04:15", "Ôn lại câu lệnh insert data", 8 },
                    { 35, "03:32", "Thử insert data", 8 },
                    { 36, "05:44", "Thử insert nhiều data", 8 },
                    { 37, "07:25", "Insert nhiều data vào cột dữ liệu", 8 },
                    { 38, "02:15", "Tạo khóa chính của bảng", 9 },
                    { 39, "01:31", "Tạo khóa phụ của bảng", 9 },
                    { 40, "07:44", "Kết nối khóa chính với khóa phụ", 9 },
                    { 41, "08:35", "Ôn lại một số kiến thức cơ bản về golang", 9 },
                    { 42, "09:15", "Tạo project khởi đầu", 10 },
                    { 43, "05:21", "Kết nối với cơ sở dữ liệu mySql", 10 },
                    { 44, "06:43", "Tạo api với golang & gin gorm", 10 },
                    { 45, "07:33", "Authecication với golang!!!", 10 },
                    { 46, "00:00", "Giới thiệu", 11 },
                    { 47, "00:15", "React Hook", 11 },
                    { 48, "05:30", "Hook có gì hay", 11 },
                    { 49, "09:05", "Class hay là Hook", 11 },
                    { 50, "00:00", "Giới thiệu", 12 },
                    { 51, "01:15", "Visual Studio Code", 12 },
                    { 52, "04:35", "Môi trường Node.js", 12 },
                    { 53, "07:42", "Git", 12 },
                    { 54, "00:00", "Giới thiệu", 13 },
                    { 55, "01:05", "Tìm tài liệu", 13 },
                    { 56, "07:13", "Sử dụng Create react app", 13 },
                    { 57, "13:30", "Run project", 13 },
                    { 58, "17:35", "Chạy project từ Github", 13 },
                    { 59, "17:35", "Hạ version xuống của reactJs", 14 },
                    { 60, "00:00", "Giới thiệu", 15 },
                    { 61, "00:55", "Components là gì", 15 },
                    { 62, "02:40", "Template HTML", 15 },
                    { 63, "09:05", "Giải thích Component", 15 },
                    { 64, "13:30", "Luồng hoạt động React", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionVideos_VideoId",
                table: "DescriptionVideos",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonContents_ProductId",
                table: "LessonContents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_userCarts_ProductId",
                table: "userCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ProductId",
                table: "Videos",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DescriptionVideos");

            migrationBuilder.DropTable(
                name: "LessonContents");

            migrationBuilder.DropTable(
                name: "userCarts");

            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
