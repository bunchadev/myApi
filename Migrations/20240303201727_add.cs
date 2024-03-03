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
                    { new Guid("056ceb2e-23af-43f8-b074-ce22842c96c3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tư duy Tích cực .", 4.5, "tuduy.png", "Tích cực", 1451, 100000, "Kỹ năng Tư duy Tích cực .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("078e27fe-c909-475a-9f57-952bf6b563a0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Ngủ đủ giấc .", 4.5, "ngu.webp", "Ngủ đủ giấc", 1511, 256000, "Kỹ năng Ngủ đủ giấc .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("08516fd4-4c50-4c28-b1a8-ec6b043fd53e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Dẫn đầu về Chi phí .", 3.5, "toan-cau.jpg", "Dẫn đầu", 4567, 213000, "Chiến lược Dẫn đầu về Chi phí .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("09267b98-d53a-419b-b748-569d88ffdba3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán nhà từ Zero to hero", 3.5, "nha.webp", "Bán nhà", 46723, 198000, "Chiến lược bán nhà", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("09f5f0b4-e3c7-43d6-a292-842d182f95a0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn đầu tư từ Zero to hero", 4.0, "dautu.png", "Đầu tư", 42647, 847000, "Chiến lược đầu tư", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e3347d1-8655-4b59-aa65-f80e4f7b2f81"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Javascript từ Zero to hero", 3.5, "jss.jpg", "Javascript", 81278, 394000, "Javascript ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("105caa62-0c1c-41af-b57a-531b94c251d5"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tìm hiểu Về Sức Khỏe .", 4.0, "suckhoe.jpg", "Sức khỏe", 5121, 300000, "Kỹ năng Tìm hiểu Về Sức Khỏe .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1390ae16-70cd-4299-a7f9-243f362085db"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Đa dạng hóa .", 3.0, "dadang.jpg", "Đa dạng", 4311, 145000, "Chiến lược Đa dạng hóa .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("144e10e0-2d65-40c0-ad52-b7500c21dc84"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Hợp nhất Ngang hàng.", 3.5, "chi.jpg", "Hợp nhất", 1515, 123000, "Chiến lược Hợp nhất Ngang hàng.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1740d805-a0f0-464e-9d7f-e03464203482"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Caffeine .", 4.5, "cafe.jpg", "Caffeine", 8141, 179000, "Kỹ năng Quản lý Mức độ Caffeine .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e0d75d8-2d39-478b-8e87-2ad6bbc8cc4e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mối quan hệ Xã hội .", 3.0, "quanhe.png", "Xã hội", 6141, 146000, "Kỹ năng Quản lý Mối quan hệ Xã hội .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "xiao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ Api với Asp.net core từ zero to here", 5.0, "aspnetcore.png", "Asp.net core api", 696969, 249000, "Full sờ tách with Asp.net core Api", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21aff7e9-3475-4ed6-aa51-a5ad0ee7de32"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thời gian .", 4.0, "thoigian.jpg", "Quản lý thời gian", 1416, 279000, "Kỹ năng Quản lý Thời gian .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ec03d34-725b-412d-af4f-c1d17dac4ce7"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Rủi ro .", 4.5, "rr.jpg", "Rủi ro", 6153, 298000, "Chiến lược Quản lý Rủi ro . ", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2eddc1c0-4d45-4546-8297-02f8a11e0737"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm giàu 100%  từ Zero to hero", 4.0, "giau.jpg", "Làm giàu", 23723, 399000, "Nhà làm giàu tài ba", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3476a058-e48b-4d4c-86f9-8af2b26c588a"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tập Luyện .", 4.5, "tapluyen.jpg", "Tập luyện", 5151, 222000, "Kỹ năng Tập Luyện .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36171157-56ca-400a-9057-a911280e1099"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Stress .", 4.0, "stress.webp", "Stress", 6161, 129000, "Kỹ năng Quản lý Stress .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d6cb16e-88a2-4b31-bb5e-9af611155a19"), "xiao Chun zzzzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Java từ Zero to hero", 4.5, "java.jpg", "Java with SpringBoot", 31567, 390000, "Java ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43596d0c-c581-43ed-92f5-4b9dde91ce30"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tinh thần và Tâm lý .", 3.0, "tamly.jpeg", "Tinh thần & Tâm lý", 1421, 231000, "Kỹ năng Tình thần và Tâm lý .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b5b6e7f-825c-4375-a79d-0d17d7f4a811"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản JQUERY .", 4.0, "jquery.webp", "JQUERY", 61611, 145000, "JQUERY Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("53545cdd-3ff9-4009-8b3c-d104a11d38b6"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán rau từ Zero to hero", 3.5, "rau.jpg", "Bán rau", 33723, 162000, "Chiến lược bán rau", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5898860e-04ac-4c69-bbc7-8b5571276527"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Phát triển Thị trường .", 4.0, "thitruong.jpg", "Thị trường", 5432, 231000, "Chiến lược Phát triển Thị trường .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d138df3-f732-4d9e-8f90-674c070f6ed3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Go  .", 4.0, "go.jpg", "GO", 51211, 127000, "Go Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67bdeb34-43dd-44d6-a5de-3b74c0ffe175"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thói quen Uống Nước .", 4.0, "uongnuoc.webp", "Uống nước", 3412, 155000, "Kỹ năng Quản lý Thói quen Uống Nước .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6dd2bbc1-6e11-4473-9162-e11e4b1c95f0"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Tập trung vào Khách hàng .", 3.0, "kh.png", "Khách hàng", 3112, 222000, "Chiến lược Tập trung vào Khách hàng .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e2a3b0e-6467-4ef0-a07c-914f3c0e6c1d"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản PHP .", 4.0, "php.jpg", "Php", 63352, 213000, "PHP Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f63b32a-4b7d-48ee-841b-0e1f826d82fb"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Firebase .", 3.5, "firebase.png", "FIREBASE", 51211, 255000, "Firebase Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f84e8c6-c1b9-4c16-884a-b38acfc33b44"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Đổi mới .", 3.0, "doimoi.jpg", "Đổi mới", 3111, 256000, "Chiến lược Đổi mới.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("72b74c94-3880-426c-8dc8-2ea5a921e557"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Thức ăn Nhanh .", 4.5, "annhanh.jpg", "Thức ăn nhanh", 6111, 200000, "Kỹ năng Quản lý Thức ăn Nhanh .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "xiao Chun zz69", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Builds a web api application using Golang and Gin/Gorm", 5.0, "golangweb.jpg", "Golang gin&gorm", 670011, 199000, "Golang web api Pro Max !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bf8e48c-ec53-4d21-8321-0577f424d1d8"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Javascript trong 3 tháng", 3.5, "jsss.png", "Javascript", 31231, 145000, "Javascript Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7cb4660d-1054-468c-8442-ebadb3cae1f8"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn tài xỉu từ Zero to hero", 5.0, "taixiu.png", "Tài xỉu", 534634, 102000, "Chiến lược chơi tài xỉu", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("841473c7-ad98-4cb9-b0c1-745a10b72e1f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Hợp nhất Ngược dọc .", 4.5, "chi.jpg", "Hợp nhất", 7161, 189000, "Chiến lược Hợp nhất Ngược dọc.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d37624a-5c52-4824-a946-8a09d1e2be87"), "xiao Chun zz00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Php từ Zero to hero", 4.0, "php.jpg", "Php", 81278, 394000, "Php ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8e59e0c4-ea7a-490e-a084-289dc3b03e0d"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản NOSQL .", 4.5, "nosql.png", "NOSQL", 51512, 300000, "NOSQL Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8fb76189-6c0c-4b89-8ad0-26dca4c1aa2c"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Python trong 5 tháng", 4.0, "py.jpg", "Pyhton", 51241, 222000, "Python Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91a8f934-a817-4f3c-b790-38b59b537bf8"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Tiêu hóa .", 4.5, "tieuhoa.jpg", "Tiêu hóa", 6111, 266000, "Kỹ năng Quản lý Tiêu hóa .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94deb579-cc56-479c-ba5d-7eb3f45086a3"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bán thịt lợn từ Zero to hero", 4.0, "thitlon.jpg", "Bán thịt lợn", 1723, 199000, "Chiến lược bán thịt lợn", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f26d522-805b-4a5f-aa02-8b3ab9d53e9e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Shell Scripting  .", 4.5, "shell.jpg", "SHELL SCRIPTING", 61211, 277000, "Shell Scripting  Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f431126-1da5-4608-9f8a-7672b99769da"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Dầu ăn .", 4.5, "dauan.jpg", "Dầu ăn", 5161, 137000, "Kỹ năng Quản lý Mức độ Dầu ăn .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1c7d314-6627-4a09-a8c3-3e16c44509ae"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản React .", 4.5, "reactjs.png", "ReactJs", 51412, 111000, "React Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2d5a4a6-22ff-4f9d-ae68-3988fa5b4e0e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn bàn hàng từ Zero to hero", 3.5, "Chien-luoc-ban-hang.png", "Bán hàng", 37853, 727000, "Chiến lược bán hàng", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "xiao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ ReactJs siêu cấp vip pro", 5.0, "reactjs.png", "ReacJs Typescripts", 777777, 200000, "Làm chủ ReacJs", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"), "xiao Chun zzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Ruby từ Zero to hero", 4.5, "ruby.png", "Ruby on rails", 99999, 389000, "Ruby ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a90061ac-46c3-4078-8512-6ab87f818bbe"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Đau .", 3.0, "dau.jpg", "Quản lý Đau", 6231, 199000, "Kỹ năng Quản lý Đau .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad59e2d4-f0e1-4dd6-aa9c-257fa0c25c35"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản MongoDB .", 4.0, "mongodb.png", "MONGODB", 85431, 100000, "MongoDB Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b23d5b9f-8ef9-4e7d-8590-2d6079c52a1b"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản NextJS .", 3.0, "nextjs.jpg", "NextJs", 14144, 233000, "NextJS Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4ab814c-3b5e-4700-8011-2bac446bef10"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Toàn cầu hóa .", 4.5, "toan-cau.jpg", "Toàn cầu", 4155, 238000, "Chiến lược Toàn cầu hóa.", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7891cb2-d35d-4790-8e54-f6fc90db20d6"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản SQL .", 3.5, "sql.webp", "SQL", 51221, 122000, "SQL Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"), "xiao Chun zz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn C++ từ Zero to hero", 4.5, "c++.png", "C++", 88888, 279000, "C++ ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9151fe4-eb19-46b7-ac8c-75d3161d4825"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Phát triển Sản phẩm .", 4.5, "sp.jpg", "PT Sản phẩm", 1516, 167000, "Chiến lược Phát triển Sản phẩm .", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ba8d07d2-2055-46d7-9d63-c13a208e76db"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản C++ .", 4.0, "c++.png", "C++", 61211, 234000, "C++ Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bdb0dc44-2912-4bb3-879c-34845c5d590f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn chứng khoán từ Zero to hero", 4.0, "ck.jpg", "Chứng khoán", 278527, 277000, "Chiến lược chứng khoán", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf72b521-4704-470b-be3d-36c3f60fec81"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Năng lượng .", 4.0, "Can bang.png", "Năng lượng", 6726, 261000, "Kỹ năng Quản lý Năng lượng .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c356b040-0bf0-4b02-b882-4f40b3052f09"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản ASP .", 3.5, "aspnetcore.png", "ASP", 9542, 299000, "ASP Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7a56ddb-e80b-4c92-ab8c-3d2cbc3af236"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Mức độ Đường huyết .", 3.5, "huyet.jpg", "Đường huyết", 8214, 256000, "Kỹ năng Quản lý Mức độ Đường huyết .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cf3e3462-4c7c-4ef5-b88a-7d8d464ac8f5"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn kinh doanh từ Zero to hero", 3.5, "chien.jpg", "Kinh doanh", 53455, 327000, "Chiến lược kinh doanh", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d63e51b8-1c7f-44e5-9a9d-0e54f9d9e7a5"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản C# .", 4.0, "csharp.jpg", "C#", 11511, 232000, "C# Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d8601d22-023a-4828-b55a-6b7bef4e2098"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Emotions .", 3.5, "th.jpg", "Quản lý Emotions", 5121, 178000, "Kỹ năng Quản lý Emotions .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc78cdf0-e23c-4a66-8463-8b697bdf398e"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Áp lực Công việc .", 4.5, "apluc.jpg", "Áp lực công việc", 5122, 221000, "Kỹ năng Quản lý Áp lực Công việc .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcf4a40a-95a4-4e71-b899-92c3b3e5f632"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản CSS .", 4.0, "css.jpg", "CSS", 41511, 299000, "CSS Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd06980f-961d-48c1-855d-632796988972"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quản lý Trọng lượng .", 3.0, "trong.png", "Trọng lượng", 7373, 156000, "Kỹ năng Quản lý Trọng lượng .", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3a09445-d486-4351-95d6-26b39b56fe1d"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Quyết định Lựa chọn Thức Ăn", 4.5, "thucan.jpg", "Thức ăn", 1516, 123000, "Kỹ năng Quyết định Lựa chọn Thức Ăn", "SK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7b2681a-8d71-458d-aa08-05c1c833f872"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Rust .", 3.0, "rust.jpg", "RUST", 14141, 231000, "Rust Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"), "xiao Chun zzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn C# từ Zero to hero", 4.0, "csharp.jpg", "C#", 99999, 389000, "C# ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec16787e-f650-4a7e-839e-f034b52f9273"), "xiao Chun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn NextJs từ Zero to hero", 4.5, "nextjs.jpg", "NextJs", 77777, 304000, "NextJs Pro Max !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec4f7d5b-6312-4693-a146-f3bc58a4d126"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Dotnet .", 3.5, "dotnet.jpg", "Dotnet", 24146, 212000, "Dotnet Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ecc287fd-d405-4e23-bba3-4916ec37e132"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn lùa gà từ Zero to hero", 5.0, "luaga.jpg", "Lùa gà", 698444, 249999, "Chiến lược lùa gà", "KT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1bfc3d8-c3cf-4024-9edc-61d8003e520f"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Objective .", 4.0, "obC.png", "OBJECTIVE-C", 61212, 123000, "Objective-C Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3c86f7b-d631-47b8-b3b2-02a4b4e165c4"), "xiao Chun zz11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ bản Ruby .", 4.5, "ruby.png", "Ruby on rails", 15121, 222000, "Ruby Basic !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f518b97c-ec7d-4d75-bc25-6cb0fd3be1ad"), "xiao Chun zzzzz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm chủ hoàn toàn Python từ Zero to hero", 4.5, "py.jpg", "Python", 31567, 390000, "Python ProMax !!!", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Money", "Password", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("05bb8376-e057-42cc-812d-a9d9d0b63ce6"), "tn02@gmail.com", 10000000, "1232003", "321", "User", "XiaoCchun" },
                    { new Guid("e2c625fb-0179-4464-9197-d96cf92b4ec4"), "tn01@gmail.com", 10000000, "1232003", "123", "Admin", "XiaoChun" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Title", "UpdatedAt", "UserName", "evaluate" },
                values: new object[,]
                {
                    { new Guid("03653cd4-b4b9-40b4-a497-d537f34275a5"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3636), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Qúa hay và bổ ích", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3647), "XiaoChun", 4.5 },
                    { new Guid("094cc70b-af8b-4845-af7d-2c4f298cb66c"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3666), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Qúa là tuyệt vời", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3666), "ThuongNguyen", 3.5 },
                    { new Guid("1993cd0e-a211-4bdd-949a-4b611e6d0a60"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3655), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Khóa học không phù hợp với tôi", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3656), "TraMy", 3.0 },
                    { new Guid("39e8c3b0-5c46-4579-be23-ec15698dab85"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3658), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Quá là hay luôn", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3658), "TrungNguyen", 4.5 },
                    { new Guid("473d14b0-e442-48b6-93e5-aa5707685c59"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3671), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Cần bổ xung thêm nhiều kiến thức hơn", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3672), "XiaoChun", 4.5 },
                    { new Guid("64aeb8f9-94aa-4dae-b506-8152a6ddebdd"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3683), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Amazing good chop!!!", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3683), "XiaoChun", 3.5 },
                    { new Guid("6a319486-ad53-45be-bd20-ac0aaf3ee943"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3669), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Hay tôi đã học được nhiều thứ từ khóa học này", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3669), "HoangGiang", 4.0 },
                    { new Guid("90711a28-4d52-4e0b-9e7a-1f7bbee54df7"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3652), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Cần cập nhật thêm 1 số kiến thức", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3653), "LienNguyen", 3.5 },
                    { new Guid("a77b33f8-8d22-4884-a157-a1776e97265c"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3661), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Như cc!!!", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3662), "TrungNguyen", 2.5 },
                    { new Guid("ab29b537-67d5-4dfd-9de1-025fdb67929a"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3686), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Ưng quá chừng!", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3686), "XiaoChun", 4.5 },
                    { new Guid("b11c8816-9c62-40ee-a6ef-6a2f02aa28d6"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3675), new Guid("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"), "Hay vl!!!", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3675), "XiaoChun", 4.0 },
                    { new Guid("c4449c8f-8499-4712-b0cb-3111887f308b"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3677), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Qúa tệ!!!", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3678), "XiaoChun", 2.5 },
                    { new Guid("f033b808-c4da-44d8-8d9b-defe64bc0b71"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3680), new Guid("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"), "Bla bla bla!!!", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3681), "XiaoChun", 4.0 },
                    { new Guid("f094e69b-55f1-4c0b-a6a1-129047e2412f"), new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3650), new Guid("1f1ee017-6d3a-46f8-839a-3b41330fbf17"), "Tôi đã ra khi học khóa này!", new DateTime(2024, 3, 4, 3, 17, 27, 483, DateTimeKind.Local).AddTicks(3650), "CamTu", 4.0 }
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
