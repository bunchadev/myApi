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
                    { new Guid("093b192c-192b-44cc-b0d1-3538410c4db3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản CSS .", 4.0, "css.jpg", null, 41511, 299000, "CSS Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f23df72-47d2-4bca-a6c2-6be6d1e3b386"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tư duy Tích cực .", 4.5, "tuduy.png", null, 1451, 100000, "Kỹ năng Tư duy Tích cực .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("150864a4-1f11-46cd-bde2-6afeb586b7a0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tìm hiểu Về Sức Khỏe .", 4.0, "suckhoe.jpg", null, 5121, 300000, "Kỹ năng Tìm hiểu Về Sức Khỏe .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("170b893c-c67e-4421-9d4c-907207b00e37"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản ASP .", 3.5, "aspnetcore.png", null, 9542, 299000, "ASP Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("18516b17-729a-4397-855a-fdf2af7ca838"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mối quan hệ Xã hội .", 3.0, "quanhe.png", null, 6141, 146000, "Kỹ năng Quản lý Mối quan hệ Xã hội .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("190d9719-ff4d-4a63-8129-07d05097a151"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thức ăn Nhanh .", 4.5, "annhanh.jpg", null, 6111, 200000, "Kỹ năng Quản lý Thức ăn Nhanh .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1af22b8b-b400-437f-b810-bfeb4a4e14fb"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Trọng lượng .", 3.0, "trong.png", null, 7373, 156000, "Kỹ năng Quản lý Trọng lượng .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1cd9b3c1-f0b1-4041-83f5-2a9f4bf4a3e1"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn lùa gà từ Zero to hero", 5.0, "luaga.jpg", null, 698444, 249999, "Chiến lược lùa gà", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1de81735-0200-4e6d-8960-5801f56d767a"), "xiao Chun zz00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Php từ Zero to hero", 4.0, "php.jpg", null, 81278, 394000, "Php ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "xiao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ Api với Asp.net core từ zero to here", 5.0, "aspnetcore.png", "Asp.net core api", 696969, 249000, "Full sờ tách with Asp.net core Api", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f5241da-9d76-4ccf-a0d5-17f472fde70b"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Hợp nhất Ngược dọc .", 4.5, "chi.jpg", null, 7161, 189000, "Chiến lược Hợp nhất Ngược dọc.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26eccb51-85c5-4cc9-a05e-88a9cf9b3dcb"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn tài xỉu từ Zero to hero", 5.0, "taixiu.png", null, 534634, 102000, "Chiến lược chơi tài xỉu", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("279278a0-2691-484c-9e86-3453580e8cb3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Năng lượng .", 4.0, "Can bang.png", null, 6726, 261000, "Kỹ năng Quản lý Năng lượng .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2910fad5-cdb6-419a-bd35-d0e16c9e6d05"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản React .", 4.5, "reactjs.png", null, 51412, 111000, "React Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b9fbb2f-8ace-4a12-b48f-d24965300def"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Ngủ đủ giấc .", 4.5, "ngu.webp", null, 1511, 256000, "Kỹ năng Ngủ đủ giấc .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("320c19ce-fe1e-48b4-9719-d851281f8e94"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Áp lực Công việc .", 4.5, "apluc.jpg", null, 5122, 221000, "Kỹ năng Quản lý Áp lực Công việc .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43f03212-1f52-434d-96da-e482ce58a7c4"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản MongoDB .", 4.0, "mongodb.png", null, 85431, 100000, "MongoDB Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4871b584-d2eb-4785-aa02-a16cc14310d4"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Javascript từ Zero to hero", 3.5, "jss.jpg", null, 81278, 394000, "Javascript ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4933cbee-4c27-4998-a894-66c4d1e84200"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Tiêu hóa .", 4.5, "tieuhoa.jpg", null, 6111, 266000, "Kỹ năng Quản lý Tiêu hóa .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c8a11d7-20f6-4d6b-8c65-6fa605922b01"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản PHP .", 4.0, "php.jpg", null, 63352, 213000, "PHP Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d5e118c-d959-4c5b-97b7-8a6344cac178"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn kinh doanh từ Zero to hero", 3.5, "chien.jpg", null, 53455, 327000, "Chiến lược kinh doanh", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e55e99c-8cf6-4858-8ac6-fdd66023dd8c"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán rau từ Zero to hero", 3.5, "rau.jpg", null, 33723, 162000, "Chiến lược bán rau", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("596f62b8-4d77-4157-8032-250681cd4210"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Firebase .", 3.5, "firebase.png", null, 51211, 255000, "Firebase Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c3b1587-003b-41fa-90b9-184899217ee2"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Đa dạng hóa .", 3.0, "dadang.jpg", null, 4311, 145000, "Chiến lược Đa dạng hóa .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c484825-28ec-4e37-8f1a-e86900858e63"), "xiao Chun zzzzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Python từ Zero to hero", 4.5, "py.jpg", null, 31567, 390000, "Python ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ae0ae8b-bf8c-47cf-ac79-f1db668ad4d6"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản NOSQL .", 4.5, "nosql.png", null, 51512, 300000, "NOSQL Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c198a29-3d02-4465-b50c-3e94167c2791"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Toàn cầu hóa .", 4.5, "toan-cau.jpg", null, 4155, 238000, "Chiến lược Toàn cầu hóa.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("738fcf60-567a-4163-a498-cc686732db43"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Dẫn đầu về Chi phí .", 3.5, "toan-cau.jpg", null, 4567, 213000, "Chiến lược Dẫn đầu về Chi phí .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79d78e2d-bda5-4e52-a2d1-ece210dde14d"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bàn hàng từ Zero to hero", 3.5, "Chien-luoc-ban-hang.png", null, 37853, 727000, "Chiến lược bán hàng", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "xiao Chun zz69", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Builds a web api application using Golang and Gin/Gorm", 5.0, "golangweb.jpg", "Golang gin&gorm", 670011, 199000, "Golang web api Pro Max !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7de0f70d-78bc-47c2-8a53-5110ad851ab7"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản JQUERY .", 4.0, "jquery.webp", null, 61611, 145000, "JQUERY Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("808da0e7-17f2-408d-a70f-d2be20b07792"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Phát triển Thị trường .", 4.0, "thitruong.jpg", null, 5432, 231000, "Chiến lược Phát triển Thị trường .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8343004f-d65d-453a-8e71-e1ea8eb4cce8"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Go  .", 4.0, "go.jpg", null, 51211, 127000, "Go Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83fa8fa1-e1ca-493d-8862-bd15271b4323"), "xiao Chun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn NextJs từ Zero to hero", 4.5, "nextjs.jpg", null, 77777, 304000, "NextJs Pro Max !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("870c0511-7e14-4474-b4f9-853d775e75d9"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Javascript trong 3 tháng", 3.5, "jsss.png", null, 31231, 145000, "Javascript Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("88aec0a6-df28-4550-bce7-091263ef3ad3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tình thần và Tâm lý .", 3.0, "tamly.jpeg", null, 1421, 231000, "Kỹ năng Tình thần và Tâm lý .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a99a8d4-6f1a-425b-9451-e3942b3f2f7e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản NextJS .", 3.0, "nextjs.jpg", null, 14144, 233000, "NextJS Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c272086-e2f4-42b3-8733-d24664735863"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán nhà từ Zero to hero", 3.5, "nha.webp", null, 46723, 198000, "Chiến lược bán nhà", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91f65392-1d40-4b26-9faf-351a7c0f74d0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Rust .", 3.0, "rust.jpg", null, 14141, 231000, "Rust Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9acd061b-b29e-4e2a-a213-028aa24d1746"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Emotions .", 3.5, "th.jpg", null, 5121, 178000, "Kỹ năng Quản lý Emotions .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f98fdc7-8ba3-4c36-b400-58983234cf12"), "xiao Chun zzzzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Java từ Zero to hero", 4.5, "java.jpg", null, 31567, 390000, "Java ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a0321d7a-71f5-48f9-8a24-e8be66a95315"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Stress .", 4.0, "stress.webp", null, 6161, 129000, "Kỹ năng Quản lý Stress .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4dd353b-9a4a-41de-9c9d-0d77dff1d9f9"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán thịt lợn từ Zero to hero", 4.0, "thitlon.jpg", null, 1723, 199000, "Chiến lược bán thịt lợn", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "xiao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ ReactJs siêu cấp vip pro", 5.0, "reactjs.png", "ReacJs Typescripts", 777777, 200000, "Làm chủ ReacJs", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a82985c0-f589-48cb-80cf-148a1448bc36"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm giàu 100%  từ Zero to hero", 4.0, "giau.jpg", null, 23723, 399000, "Nhà làm giàu tài ba", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8f846de-4d0e-45f8-aed1-8c8dd1ec39c3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Đau .", 3.0, "dau.jpg", null, 6231, 199000, "Kỹ năng Quản lý Đau .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("aa9c4e40-e075-4645-8e6a-19fd4cf03402"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản C# .", 4.0, "csharp.jpg", null, 11511, 232000, "C# Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af2b8931-0a3e-49bb-9dcc-7dcd1f7726b0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Phát triển Sản phẩm .", 4.5, "sp.jpg", null, 1516, 167000, "Chiến lược Phát triển Sản phẩm .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("afac7655-ea24-46a6-8c2e-f19c6e1453d6"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn đầu tư từ Zero to hero", 4.0, "dautu.png", null, 42647, 847000, "Chiến lược đầu tư", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b18d9e96-b54f-409c-af2a-bcb80e4e9220"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quyết định Lựa chọn Thức Ăn", 4.5, "thucan.jpg", null, 1516, 123000, "Kỹ năng Quyết định Lựa chọn Thức Ăn", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9fd1e27-7077-4730-b67b-6bc2bd247159"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Hợp nhất Ngang hàng.", 3.5, "chi.jpg", null, 1515, 123000, "Chiến lược Hợp nhất Ngang hàng.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bd1ee76b-1a21-4582-861e-06603c1efd3d"), "xiao Chun zz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn C++ từ Zero to hero", 4.5, "c++.png", null, 88888, 279000, "C++ ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bfc09598-618c-474d-a8e4-d14192e01341"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Caffeine .", 4.5, "cafe.jpg", null, 8141, 179000, "Kỹ năng Quản lý Mức độ Caffeine .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca0e1f9a-7d36-428c-a663-738bd916103b"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thời gian .", 4.0, "thoigian.jpg", null, 1416, 279000, "Kỹ năng Quản lý Thời gian .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cfa8351b-4f3a-4226-bf57-79ef31bec6af"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Đường huyết .", 3.5, "huyet.jpg", null, 8214, 256000, "Kỹ năng Quản lý Mức độ Đường huyết .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8307b15-80b8-4e74-b442-2c34323e87f6"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn chứng khoán từ Zero to hero", 4.0, "ck.jpg", null, 278527, 277000, "Chiến lược chứng khoán", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8895771-d215-4e4d-8a50-f81cf4785595"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản C++ .", 4.0, "c++.png", null, 61211, 234000, "C++ Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da47bf62-3093-4390-b48a-49a41b34dec9"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản SQL .", 3.5, "sql.webp", null, 51221, 122000, "SQL Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dba7dc7c-5511-4262-9edc-2615ea509951"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Objective .", 4.0, "obC.png", null, 61212, 123000, "Objective-C Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd7e5ad4-1de8-4c22-858a-79aefadf1921"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Ruby .", 4.5, "ruby.png", null, 15121, 222000, "Ruby Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dfc2f685-bf87-4846-95d2-5f70f0682c52"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tập trung vào Khách hàng .", 3.0, "kh.png", null, 3112, 222000, "Chiến lược Tập trung vào Khách hàng .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e18f80a6-f943-469c-8c90-ed81d1ae518a"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Rủi ro .", 4.5, "rr.jpg", null, 6153, 298000, "Chiến lược Quản lý Rủi ro . ", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e53672b7-564c-40a7-ba3f-50f9222be0bc"), "xiao Chun zzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn C# từ Zero to hero", 4.0, "csharp.jpg", null, 99999, 389000, "C# ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8cd75fe-bcf4-405f-bb6d-08a027924864"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Dotnet .", 3.5, "dotnet.jpg", null, 24146, 212000, "Dotnet Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("edba1aff-f813-4106-a018-74d53bdff984"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Shell Scripting  .", 4.5, "shell.jpg", null, 61211, 277000, "Shell Scripting  Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f05044bc-df25-4f8b-9ded-ff4da69119f0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Python trong 5 tháng", 4.0, "py.jpg", null, 51241, 222000, "Python Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2b20cdc-37a8-4888-ad5b-f7339ac6dc3f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Dầu ăn .", 4.5, "dauan.jpg", null, 5161, 137000, "Kỹ năng Quản lý Mức độ Dầu ăn .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f4c1d72e-0d71-4dab-9939-ccc3ffcca3d6"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Đổi mới .", 3.0, "doimoi.jpg", null, 3111, 256000, "Chiến lược Đổi mới.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9a0157b-eea1-4177-a573-3e4cb786dc9c"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thói quen Uống Nước .", 4.0, "uongnuoc.webp", null, 3412, 155000, "Kỹ năng Quản lý Thói quen Uống Nước .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9b04ff0-e616-4973-beef-39a40363be00"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tập Luyện .", 4.5, "tapluyen.jpg", null, 5151, 222000, "Kỹ năng Tập Luyện .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb6ce49d-a434-46af-a468-f333d6003657"), "xiao Chun zzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Ruby từ Zero to hero", 4.5, "ruby.png", null, 99999, 389000, "Ruby ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Money", "Password", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("045a826d-c46f-48fa-8e98-c98dc14c5020"), "tn02@gmail.com", 10000000, "1232003", "321", "User", "XiaoCchun" },
                    { new Guid("d3ef390e-bb4a-45dc-b58b-73bee1283c96"), "tn01@gmail.com", 10000000, "1232003", "123", "Admin", "XiaoChun" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Title", "UpdatedAt", "UserName", "evaluate" },
                values: new object[,]
                {
                    { new Guid("03e8a086-7335-4133-b50a-a17fd782ecb8"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5153), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Hay tôi đã học được nhiều thứ từ khóa học này", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5153), "HoangGiang", 4.0 },
                    { new Guid("2071600a-4027-41ba-9b3e-aa4a462ddc92"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5141), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Khóa học không phù hợp với tôi", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5141), "TraMy", 3.0 },
                    { new Guid("2c938b4e-a9b3-455a-95b8-57686afb0796"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5161), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Hay vl!!!", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5161), "XiaoChun", 4.0 },
                    { new Guid("4a5c4260-a85a-42d8-822e-a620d35a9a27"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5147), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Như cc!!!", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5148), "TrungNguyen", 2.5 },
                    { new Guid("55b9aa86-18bc-4d83-99bc-bb4539f886e6"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5143), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Quá là hay luôn", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5144), "TrungNguyen", 4.5 },
                    { new Guid("7ecb894b-9102-496c-9dce-fc1354e76c70"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5172), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Ưng quá chừng!", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5172), "XiaoChun", 4.5 },
                    { new Guid("b7a170d7-f08f-415e-b39f-546aa4e0b0da"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5164), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Qúa tệ!!!", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5164), "XiaoChun", 2.5 },
                    { new Guid("cb1ca027-9430-44a9-92bc-db22425f1ac6"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5169), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Amazing good chop!!!", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5170), "XiaoChun", 3.5 },
                    { new Guid("cdd5bb46-e89d-48d0-b6a0-4889a8d759f9"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5138), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Cần cập nhật thêm 1 số kiến thức", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5138), "LienNguyen", 3.5 },
                    { new Guid("d49b5e7d-45cd-4a47-8217-f34e7cfbe9d5"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5157), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Cần bổ xung thêm nhiều kiến thức hơn", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5158), "XiaoChun", 4.5 },
                    { new Guid("d78e3be5-4850-4c62-8872-892b67638867"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5120), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Qúa hay và bổ ích", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5132), "XiaoChun", 4.5 },
                    { new Guid("e940c70a-79ce-4460-9ee4-8239b7b6d24b"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5150), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Qúa là tuyệt vời", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5150), "ThuongNguyen", 3.5 },
                    { new Guid("f29ec837-61b6-401e-8554-7c9421759f87"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5135), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Tôi đã ra khi học khóa này!", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5135), "CamTu", 4.0 },
                    { new Guid("fc4765a6-46b8-4e64-a3f9-cb7cbb5feeef"), new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5166), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Bla bla bla!!!", new DateTime(2024, 2, 23, 8, 33, 1, 102, DateTimeKind.Local).AddTicks(5167), "XiaoChun", 4.0 }
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
