using Microsoft.EntityFrameworkCore;
using myApi.Models.Domain;

namespace myApi.Data
{
    public class DevDbContext : DbContext
    {
        public DevDbContext(DbContextOptions<DevDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<LessonContent> LessonContents { get; set; }
        public DbSet<DescriptionVideo> DescriptionVideos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserCart> userCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var users = new List<User>()
            {
                new User ()
                {
                   Id = Guid.NewGuid(),
                   Email = "tn01@gmail.com",
                   Password = "1232003",
                   PhoneNumber = "123",
                   Money = 10000000,
                   Role = "Admin",
                   UserName = "XiaoChun"
                },
                new User ()
                {
                   Id = Guid.NewGuid(),
                   Email = "tn02@gmail.com",
                   Password = "1232003",
                   PhoneNumber = "321",
                   Money = 10000000,
                   Role = "User",
                   UserName = "XiaoCchun"
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            var products = new List<Product>()
            {
                 new Product ()
                {
                    Id = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    ProductName = "Full sờ tách with Asp.net core Api",
                    Description = "Làm chủ Api với Asp.net core từ zero to here",
                    NameTitle = "Asp.net core api",
                    Author = "xiao",
                    NumberStudents = 696969,
                    Evaluate = 5,
                    Price = 249000,
                    Type = "IT",
                    FileName = "aspnetcore.png",
                },
                 new Product ()
                {
                    Id = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    ProductName = "Golang web api Pro Max !!!",
                    Description = "Builds a web api application using Golang and Gin/Gorm",
                    NameTitle = "Golang gin&gorm",
                    Author = "xiao Chun zz69",
                    NumberStudents = 670011,
                    Evaluate = 5,
                    Price = 199000,
                    Type = "IT",
                    FileName = "golangweb.jpg",
                },
                 new Product ()
                {
                    Id = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    ProductName = "Làm chủ ReacJs",
                    Description = "Làm chủ ReactJs siêu cấp vip pro",
                    NameTitle = "ReacJs Typescripts",
                    Author = "xiao",
                    NumberStudents = 777777,
                    Evaluate = 5,
                    Price = 200000,
                    Type = "IT",
                    FileName = "reactjs.png",
                },
                 new Product ()
                {
                    Id = Guid.Parse("ec16787e-f650-4a7e-839e-f034b52f9273"),
                    ProductName = "NextJs Pro Max !!!",
                    Description = "Làm chủ hoàn toàn NextJs từ Zero to hero",
                    NameTitle = "NextJs",
                    Author = "xiao Chun",
                    NumberStudents = 77777,
                    Evaluate = 4.5,
                    Price = 304000,
                    Type = "IT",
                    FileName = "nextjs.jpg",
                },
                 new Product ()
                {
                    Id = Guid.Parse("b8b19bdc-d9e6-4d1a-a25d-7c528f47db69"),
                    ProductName = "C++ ProMax !!!",
                    Description = "Làm chủ hoàn toàn C++ từ Zero to hero",
                    NameTitle = "C++",
                    Author = "xiao Chun zz",
                    NumberStudents = 88888,
                    Evaluate = 4.5,
                    Price = 279000,
                    Type = "IT",
                    FileName = "c++.png",
                },
                 new Product ()
                {
                    Id = Guid.Parse("a742f0bd-6f85-4e50-9bc3-8b77b3061c77"),
                    ProductName = "Ruby ProMax !!!",
                    Description = "Làm chủ hoàn toàn Ruby từ Zero to hero",
                    NameTitle = "Ruby on rails",
                    Author = "xiao Chun zzz",
                    NumberStudents = 99999,
                    Evaluate = 4.5,
                    Price = 389000,
                    Type = "IT",
                    FileName = "ruby.png",
                },
                 new Product ()
                {
                    Id = Guid.Parse("e917a7f8-8a12-4df7-bd32-904b2e53b6fa"),
                    ProductName = "C# ProMax !!!",
                    Description = "Làm chủ hoàn toàn C# từ Zero to hero",
                    NameTitle = "C#",
                    Author = "xiao Chun zzz",
                    NumberStudents = 99999,
                    Evaluate = 4,
                    Price = 389000,
                    Type = "IT",
                    FileName = "csharp.jpg",
                },
                 new Product ()
                {
                    Id = Guid.Parse("3d6cb16e-88a2-4b31-bb5e-9af611155a19"),
                    ProductName = "Java ProMax !!!",
                    Description = "Làm chủ hoàn toàn Java từ Zero to hero",
                    NameTitle = "Java with SpringBoot",
                    Author = "xiao Chun zzzzz",
                    NumberStudents = 31567,
                    Evaluate = 4.5,
                    Price = 390000,
                    Type = "IT",
                    FileName = "java.jpg",
                },
                 new Product ()
                {
                    Id = Guid.Parse("f518b97c-ec7d-4d75-bc25-6cb0fd3be1ad"),
                    ProductName = "Python ProMax !!!",
                    Description = "Làm chủ hoàn toàn Python từ Zero to hero",
                    NameTitle = "Python",
                    Author = "xiao Chun zzzzz",
                    NumberStudents = 31567,
                    Evaluate = 4.5,
                    Price = 390000,
                    Type = "IT",
                    FileName = "py.jpg",
                },
                 new Product ()
                {
                    Id =Guid.Parse("8d37624a-5c52-4824-a946-8a09d1e2be87"),
                    ProductName = "Php ProMax !!!",
                    Description = "Làm chủ hoàn toàn Php từ Zero to hero",
                    NameTitle = "Php",
                    Author = "xiao Chun zz00",
                    NumberStudents = 81278,
                    Evaluate = 4,
                    Price = 394000,
                    Type = "IT",
                    FileName = "php.jpg",
                },
                 new Product ()
                {
                    Id = Guid.Parse("0e3347d1-8655-4b59-aa65-f80e4f7b2f81"),
                    ProductName = "Javascript ProMax !!!",
                    Description = "Làm chủ hoàn toàn Javascript từ Zero to hero",
                    NameTitle = "Javascript",
                    Author = "xiao Chun zz11",
                    NumberStudents = 81278,
                    Evaluate = 3.5,
                    Price = 394000,
                    Type = "IT",
                    FileName = "jss.jpg",
                },
                 new Product ()
                {
                    Id =Guid.Parse("cf3e3462-4c7c-4ef5-b88a-7d8d464ac8f5"),
                    ProductName = "Chiến lược kinh doanh",
                    Description = "Làm chủ hoàn toàn kinh doanh từ Zero to hero",
                    NameTitle = "Kinh doanh",
                    Author = "xiao Chun zz11",
                    NumberStudents = 53455,
                    Evaluate = 3.5,
                    Price = 327000,
                    Type = "KT",
                    FileName = "chien.jpg",
                },
                 new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Chiến lược bán hàng",
                    Description = "Làm chủ hoàn toàn bàn hàng từ Zero to hero",
                    NameTitle = "Bán hàng",
                    Author = "xiao Chun zz11",
                    NumberStudents = 37853,
                    Evaluate = 3.5,
                    Price = 727000,
                    Type = "KT",
                    FileName = "Chien-luoc-ban-hang.png",
                },
                 new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Chiến lược bán rau",
                    Description = "Làm chủ hoàn toàn bán rau từ Zero to hero",
                    NameTitle = "Bán rau",
                    Author = "xiao Chun zz11",
                    NumberStudents = 33723,
                    Evaluate = 3.5,
                    Price = 162000,
                    Type = "KT",
                    FileName = "rau.jpg",
                },
                 new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Chiến lược bán nhà",
                    Description = "Làm chủ hoàn toàn bán nhà từ Zero to hero",
                    NameTitle = "Bán nhà",
                    Author = "xiao Chun zz11",
                    NumberStudents = 46723,
                    Evaluate = 3.5,
                    Price = 198000,
                    Type = "KT",
                    FileName = "nha.webp",
                },
                 new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Chiến lược đầu tư",
                    Description = "Làm chủ hoàn toàn đầu tư từ Zero to hero",
                    NameTitle = "Đầu tư",
                    Author = "xiao Chun zz11",
                    NumberStudents = 42647,
                    Evaluate = 4,
                    Price = 847000,
                    Type = "KT",
                    FileName = "dautu.png",
                },
                 new Product ()
                {
                    Id =Guid.NewGuid(),
                    ProductName = "Chiến lược chơi tài xỉu",
                    Description = "Làm chủ hoàn toàn tài xỉu từ Zero to hero",
                    NameTitle = "Tài xỉu",
                    Author = "xiao Chun zz11",
                    NumberStudents = 534634,
                    Evaluate = 5,
                    Price = 102000,
                    Type = "KT",
                    FileName = "taixiu.png",
                },
                 new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Chiến lược lùa gà",
                    Description = "Làm chủ hoàn toàn lùa gà từ Zero to hero",
                    NameTitle = "Lùa gà",
                    Author = "xiao Chun zz11",
                    NumberStudents = 698444,
                    Evaluate = 5,
                    Price = 249999,
                    Type = "KT",
                    FileName = "luaga.jpg",
                },
                 new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Chiến lược bán thịt lợn",
                    Description = "Làm chủ hoàn toàn bán thịt lợn từ Zero to hero",
                    NameTitle = "Bán thịt lợn",
                    Author = "xiao Chun zz11",
                    NumberStudents = 1723,
                    Evaluate = 4,
                    Price = 199000,
                    Type = "KT",
                    FileName = "thitlon.jpg",
                },
                new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Chiến lược chứng khoán",
                    Description = "Làm chủ hoàn toàn chứng khoán từ Zero to hero",
                    NameTitle = "Chứng khoán",
                    Author = "xiao Chun zz11",
                    NumberStudents = 278527,
                    Evaluate = 4,
                    Price = 277000,
                    Type = "KT",
                    FileName = "ck.jpg",
                },
                new Product ()
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Nhà làm giàu tài ba",
                    Description = "Làm giàu 100%  từ Zero to hero",
                    NameTitle = "Làm giàu",
                    Author = "xiao Chun zz11",
                    NumberStudents = 23723,
                    Evaluate = 4,
                    Price = 399000,
                    Type = "KT",
                    FileName = "giau.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("7bf8e48c-ec53-4d21-8321-0577f424d1d8"),
                    ProductName = "Javascript Basic !!!",
                    Description = "Cơ bản Javascript trong 3 tháng",
                    NameTitle = "Javascript",
                    Author = "xiao Chun zz11",
                    NumberStudents = 31231,
                    Evaluate = 3.5,
                    Price = 145000,
                    Type = "IT",
                    FileName = "jsss.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("8fb76189-6c0c-4b89-8ad0-26dca4c1aa2c"),
                    ProductName = "Python Basic !!!",
                    Description = "Cơ bản Python trong 5 tháng",
                    NameTitle = "Pyhton",
                    Author = "xiao Chun zz11",
                    NumberStudents = 51241,
                    Evaluate = 4,
                    Price = 222000,
                    Type = "IT",
                    FileName = "py.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("6e2a3b0e-6467-4ef0-a07c-914f3c0e6c1d"),
                    ProductName = "PHP Basic !!!",
                    Description = "Cơ bản PHP .",
                    NameTitle = "Php",
                    Author = "xiao Chun zz11",
                    NumberStudents = 63352,
                    Evaluate = 4,
                    Price = 213000,
                    Type = "IT",
                    FileName = "php.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("a1c7d314-6627-4a09-a8c3-3e16c44509ae"),
                    ProductName = "React Basic !!!",
                    Description = "Cơ bản React .",
                    NameTitle = "ReactJs",
                    Author = "xiao Chun zz11",
                    NumberStudents = 51412,
                    Evaluate = 4.5,
                    Price = 111000,
                    Type = "IT",
                    FileName = "reactjs.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("b23d5b9f-8ef9-4e7d-8590-2d6079c52a1b"),
                    ProductName = "NextJS Basic !!!",
                    Description = "Cơ bản NextJS .",
                    NameTitle = "NextJs",
                    Author = "xiao Chun zz11",
                    NumberStudents = 14144,
                    Evaluate = 3,
                    Price = 233000,
                    Type = "IT",
                    FileName = "nextjs.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("ec4f7d5b-6312-4693-a146-f3bc58a4d126"),
                    ProductName = "Dotnet Basic !!!",
                    Description = "Cơ bản Dotnet .",
                    NameTitle = "Dotnet",
                    Author = "xiao Chun zz11",
                    NumberStudents = 24146,
                    Evaluate = 3.5,
                    Price = 212000,
                    Type = "IT",
                    FileName = "dotnet.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("d63e51b8-1c7f-44e5-9a9d-0e54f9d9e7a5"),
                    ProductName = "C# Basic !!!",
                    Description = "Cơ bản C# .",
                    NameTitle = "C#",
                    Author = "xiao Chun zz11",
                    NumberStudents = 11511,
                    Evaluate = 4,
                    Price = 232000,
                    Type = "IT",
                    FileName = "csharp.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("f3c86f7b-d631-47b8-b3b2-02a4b4e165c4"),
                    ProductName = "Ruby Basic !!!",
                    Description = "Cơ bản Ruby .",
                    NameTitle = "Ruby on rails",
                    Author = "xiao Chun zz11",
                    NumberStudents = 15121,
                    Evaluate = 4.5,
                    Price = 222000,
                    Type = "IT",
                    FileName = "ruby.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("dcf4a40a-95a4-4e71-b899-92c3b3e5f632"),
                    ProductName = "CSS Basic !!!",
                    Description = "Cơ bản CSS .",
                    NameTitle = "CSS",
                    Author = "xiao Chun zz11",
                    NumberStudents = 41511,
                    Evaluate = 4,
                    Price = 299000,
                    Type = "IT",
                    FileName = "css.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("4b5b6e7f-825c-4375-a79d-0d17d7f4a811"),
                    ProductName = "JQUERY Basic !!!",
                    Description = "Cơ bản JQUERY .",
                    NameTitle = "JQUERY",
                    Author = "xiao Chun zz11",
                    NumberStudents = 61611,
                    Evaluate = 4,
                    Price = 145000,
                    Type = "IT",
                    FileName = "jquery.webp",
                },
                new Product ()
                {
                    Id = Guid.Parse("8e59e0c4-ea7a-490e-a084-289dc3b03e0d"),
                    ProductName = "NOSQL Basic !!!",
                    Description = "Cơ bản NOSQL .",
                    NameTitle = "NOSQL",
                    Author = "xiao Chun zz11",
                    NumberStudents = 51512,
                    Evaluate = 4.5,
                    Price = 300000,
                    Type = "IT",
                    FileName = "nosql.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("b7891cb2-d35d-4790-8e54-f6fc90db20d6"),
                    ProductName = "SQL Basic !!!",
                    Description = "Cơ bản SQL .",
                    NameTitle = "SQL",
                    Author = "xiao Chun zz11",
                    NumberStudents = 51221,
                    Evaluate = 3.5,
                    Price = 122000,
                    Type = "IT",
                    FileName = "sql.webp",
                },
                new Product ()
                {
                    Id = Guid.Parse("6f63b32a-4b7d-48ee-841b-0e1f826d82fb"),
                    ProductName = "Firebase Basic !!!",
                    Description = "Cơ bản Firebase .",
                    NameTitle = "FIREBASE",
                    Author = "xiao Chun zz11",
                    NumberStudents = 51211,
                    Evaluate = 3.5,
                    Price = 255000,
                    Type = "IT",
                    FileName = "firebase.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("ad59e2d4-f0e1-4dd6-aa9c-257fa0c25c35"),
                    ProductName = "MongoDB Basic !!!",
                    Description = "Cơ bản MongoDB .",
                    NameTitle = "MONGODB",
                    Author = "xiao Chun zz11",
                    NumberStudents = 85431,
                    Evaluate = 4,
                    Price = 100000,
                    Type = "IT",
                    FileName = "mongodb.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("c356b040-0bf0-4b02-b882-4f40b3052f09"),
                    ProductName = "ASP Basic !!!",
                    Description = "Cơ bản ASP .",
                    NameTitle = "ASP",
                    Author = "xiao Chun zz11",
                    NumberStudents = 9542,
                    Evaluate = 3.5,
                    Price = 299000,
                    Type = "IT",
                    FileName = "aspnetcore.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("ba8d07d2-2055-46d7-9d63-c13a208e76db"),
                    ProductName = "C++ Basic !!!",
                    Description = "Cơ bản C++ .",
                    NameTitle = "C++",
                    Author = "xiao Chun zz11",
                    NumberStudents = 61211,
                    Evaluate = 4,
                    Price = 234000,
                    Type = "IT",
                    FileName = "c++.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("f1bfc3d8-c3cf-4024-9edc-61d8003e520f"),
                    ProductName = "Objective-C Basic !!!",
                    Description = "Cơ bản Objective .",
                    NameTitle = "OBJECTIVE-C",
                    Author = "xiao Chun zz11",
                    NumberStudents = 61212,
                    Evaluate = 4,
                    Price = 123000,
                    Type = "IT",
                    FileName = "obC.png",
                },
                new Product ()
                {
                    Id = Guid.Parse("9f26d522-805b-4a5f-aa02-8b3ab9d53e9e"),
                    ProductName = "Shell Scripting  Basic !!!",
                    Description = "Cơ bản Shell Scripting  .",
                    NameTitle = "SHELL SCRIPTING",
                    Author = "xiao Chun zz11",
                    NumberStudents = 61211,
                    Evaluate = 4.5,
                    Price = 277000,
                    Type = "IT",
                    FileName = "shell.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("e7b2681a-8d71-458d-aa08-05c1c833f872"),
                    ProductName = "Rust Basic !!!",
                    Description = "Cơ bản Rust .",
                    NameTitle = "RUST",
                    Author = "xiao Chun zz11",
                    NumberStudents = 14141,
                    Evaluate = 3,
                    Price = 231000,
                    Type = "IT",
                    FileName = "rust.jpg",
                },
                new Product ()
                {
                    Id = Guid.Parse("5d138df3-f732-4d9e-8f90-674c070f6ed3"),
                    ProductName = "Go Basic !!!",
                    Description = "Cơ bản Go  .",
                    NameTitle = "GO",
                    Author = "xiao Chun zz11",
                    NumberStudents = 51211,
                    Evaluate = 4,
                    Price = 127000,
                    Type = "IT",
                    FileName = "go.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Đa dạng hóa .",
                        Description = "Làm chủ hoàn toàn Đa dạng hóa .",
                        NameTitle = "Đa dạng",
                        Author = "xiao Chun zz11",
                        NumberStudents = 4311,
                        Evaluate = 3,
                        Price = 145000,
                        Type = "KT",
                        FileName = "dadang.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Đổi mới.",
                        Description = "Làm chủ hoàn toàn Đổi mới .",
                        NameTitle = "Đổi mới",
                        Author = "xiao Chun zz11",
                        NumberStudents = 3111,
                        Evaluate = 3,
                        Price = 256000,
                        Type = "KT",
                        FileName = "doimoi.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Toàn cầu hóa.",
                        Description = "Làm chủ hoàn toàn Toàn cầu hóa .",
                        NameTitle = "Toàn cầu",
                        Author = "xiao Chun zz11",
                        NumberStudents = 4155,
                        Evaluate = 4.5,
                        Price = 238000,
                        Type = "KT",
                        FileName = "toan-cau.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Dẫn đầu về Chi phí .",
                        Description = "Làm chủ hoàn toàn Dẫn đầu về Chi phí .",
                        NameTitle = "Dẫn đầu",
                        Author = "xiao Chun zz11",
                        NumberStudents = 4567,
                        Evaluate = 3.5,
                        Price = 213000,
                        Type = "KT",
                        FileName = "toan-cau.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Tập trung vào Khách hàng .",
                        Description = "Làm chủ hoàn toàn Tập trung vào Khách hàng .",
                        NameTitle = "Khách hàng",
                        Author = "xiao Chun zz11",
                        NumberStudents = 3112,
                        Evaluate = 3,
                        Price = 222000,
                        Type = "KT",
                        FileName = "kh.png",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Phát triển Thị trường .",
                        Description = "Làm chủ hoàn toàn Phát triển Thị trường .",
                        NameTitle = "Thị trường",
                        Author = "xiao Chun zz11",
                        NumberStudents = 5432,
                        Evaluate = 4,
                        Price = 231000,
                        Type = "KT",
                        FileName = "thitruong.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Hợp nhất Ngang hàng.",
                        Description = "Làm chủ hoàn toàn Hợp nhất Ngang hàng.",
                        NameTitle = "Hợp nhất",
                        Author = "xiao Chun zz11",
                        NumberStudents = 1515,
                        Evaluate = 3.5,
                        Price = 123000,
                        Type = "KT",
                        FileName = "chi.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Hợp nhất Ngược dọc.",
                        Description = "Làm chủ hoàn toàn Hợp nhất Ngược dọc .",
                        NameTitle = "Hợp nhất",
                        Author = "xiao Chun zz11",
                        NumberStudents = 7161,
                        Evaluate = 4.5,
                        Price = 189000,
                        Type = "KT",
                        FileName = "chi.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Phát triển Sản phẩm .",
                        Description = "Làm chủ hoàn toàn Phát triển Sản phẩm .",
                        NameTitle = "PT Sản phẩm",
                        Author = "xiao Chun zz11",
                        NumberStudents = 1516,
                        Evaluate = 4.5,
                        Price = 167000,
                        Type = "KT",
                        FileName = "sp.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Chiến lược Quản lý Rủi ro . ",
                        Description = "Làm chủ hoàn toàn Quản lý Rủi ro .",
                        NameTitle = "Rủi ro",
                        Author = "xiao Chun zz11",
                        NumberStudents = 6153,
                        Evaluate = 4.5,
                        Price = 298000,
                        Type = "KT",
                        FileName = "rr.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quyết định Lựa chọn Thức Ăn",
                        Description = "Làm chủ hoàn toàn Quyết định Lựa chọn Thức Ăn",
                        NameTitle = "Thức ăn",
                        Author = "xiao Chun zz11",
                        NumberStudents = 1516,
                        Evaluate = 4.5,
                        Price = 123000,
                        Type = "SK",
                        FileName = "thucan.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Tập Luyện .",
                        Description = "Làm chủ hoàn toàn Tập Luyện .",
                        NameTitle = "Tập luyện",
                        Author = "xiao Chun zz11",
                        NumberStudents = 5151,
                        Evaluate = 4.5,
                        Price = 222000,
                        Type = "SK",
                        FileName = "tapluyen.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Stress .",
                        Description = "Làm chủ hoàn toàn Quản lý Stress .",
                        NameTitle = "Stress",
                        Author = "xiao Chun zz11",
                        NumberStudents = 6161,
                        Evaluate = 4,
                        Price = 129000,
                        Type = "SK",
                        FileName = "stress.webp",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Ngủ đủ giấc .",
                        Description = "Làm chủ hoàn toàn Ngủ đủ giấc .",
                        NameTitle = "Ngủ đủ giấc",
                        Author = "xiao Chun zz11",
                        NumberStudents = 1511,
                        Evaluate = 4.5,
                        Price = 256000,
                        Type = "SK",
                        FileName = "ngu.webp",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Trọng lượng .",
                        Description = "Làm chủ hoàn toàn Quản lý Trọng lượng .",
                        NameTitle = "Trọng lượng",
                        Author = "xiao Chun zz11",
                        NumberStudents = 7373,
                        Evaluate = 3,
                        Price = 156000,
                        Type = "SK",
                        FileName = "trong.png",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Thời gian .",
                        Description = "Làm chủ hoàn toàn Quản lý Thời gian .",
                        NameTitle = "Quản lý thời gian",
                        Author = "xiao Chun zz11",
                        NumberStudents = 1416,
                        Evaluate = 4,
                        Price = 279000,
                        Type = "SK",
                        FileName = "thoigian.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Emotions .",
                        Description = "Làm chủ hoàn toàn Quản lý Emotions .",
                        NameTitle = "Quản lý Emotions",
                        Author = "xiao Chun zz11",
                        NumberStudents = 5121,
                        Evaluate = 3.5,
                        Price = 178000,
                        Type = "SK",
                        FileName = "th.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Tình thần và Tâm lý .",
                        Description = "Làm chủ hoàn toàn Tinh thần và Tâm lý .",
                        NameTitle = "Tinh thần & Tâm lý",
                        Author = "xiao Chun zz11",
                        NumberStudents = 1421,
                        Evaluate = 3,
                        Price = 231000,
                        Type = "SK",
                        FileName = "tamly.jpeg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Năng lượng .",
                        Description = "Làm chủ hoàn toàn Quản lý Năng lượng .",
                        NameTitle = "Năng lượng",
                        Author = "xiao Chun zz11",
                        NumberStudents = 6726,
                        Evaluate = 4,
                        Price = 261000,
                        Type = "SK",
                        FileName = "Can bang.png",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Đau .",
                        Description = "Làm chủ hoàn toàn Quản lý Đau .",
                        NameTitle = "Quản lý Đau",
                        Author = "xiao Chun zz11",
                        NumberStudents = 6231,
                        Evaluate = 3,
                        Price = 199000,
                        Type = "SK",
                        FileName = "dau.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Áp lực Công việc .",
                        Description = "Làm chủ hoàn toàn Quản lý Áp lực Công việc .",
                        NameTitle = "Áp lực công việc",
                        Author = "xiao Chun zz11",
                        NumberStudents = 5122,
                        Evaluate = 4.5,
                        Price = 221000,
                        Type = "SK",
                        FileName = "apluc.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Tiêu hóa .",
                        Description = "Làm chủ hoàn toàn Quản lý Tiêu hóa .",
                        NameTitle = "Tiêu hóa",
                        Author = "xiao Chun zz11",
                        NumberStudents = 6111,
                        Evaluate = 4.5,
                        Price = 266000,
                        Type = "SK",
                        FileName = "tieuhoa.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Thói quen Uống Nước .",
                        Description = "Làm chủ hoàn toàn Quản lý Thói quen Uống Nước .",
                        NameTitle = "Uống nước",
                        Author = "xiao Chun zz11",
                        NumberStudents = 3412,
                        Evaluate = 4,
                        Price = 155000,
                        Type = "SK",
                        FileName = "uongnuoc.webp",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Mức độ Caffeine .",
                        Description = "Làm chủ hoàn toàn Quản lý Mức độ Caffeine .",
                        NameTitle = "Caffeine",
                        Author = "xiao Chun zz11",
                        NumberStudents = 8141,
                        Evaluate = 4.5,
                        Price = 179000,
                        Type = "SK",
                        FileName = "cafe.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Mức độ Đường huyết .",
                        Description = "Làm chủ hoàn toàn Quản lý Mức độ Đường huyết .",
                        NameTitle = "Đường huyết",
                        Author = "xiao Chun zz11",
                        NumberStudents = 8214,
                        Evaluate = 3.5,
                        Price = 256000,
                        Type = "SK",
                        FileName = "huyet.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Thức ăn Nhanh .",
                        Description = "Làm chủ hoàn toàn Quản lý Thức ăn Nhanh .",
                        NameTitle = "Thức ăn nhanh",
                        Author = "xiao Chun zz11",
                        NumberStudents = 6111,
                        Evaluate = 4.5,
                        Price = 200000,
                        Type = "SK",
                        FileName = "annhanh.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Tư duy Tích cực .",
                        Description = "Làm chủ hoàn toàn Tư duy Tích cực .",
                        NameTitle = "Tích cực",
                        Author = "xiao Chun zz11",
                        NumberStudents = 1451,
                        Evaluate = 4.5,
                        Price = 100000,
                        Type = "SK",
                        FileName = "tuduy.png",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Tìm hiểu Về Sức Khỏe .",
                        Description = "Làm chủ hoàn toàn Tìm hiểu Về Sức Khỏe .",
                        NameTitle = "Sức khỏe",
                        Author = "xiao Chun zz11",
                        NumberStudents = 5121,
                        Evaluate = 4,
                        Price = 300000,
                        Type = "SK",
                        FileName = "suckhoe.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Mức độ Dầu ăn .",
                        Description = "Làm chủ hoàn toàn Quản lý Mức độ Dầu ăn .",
                        NameTitle = "Dầu ăn",
                        Author = "xiao Chun zz11",
                        NumberStudents = 5161,
                        Evaluate = 4.5,
                        Price = 137000,
                        Type = "SK",
                        FileName = "dauan.jpg",
                },
                new Product ()
                {
                        Id = Guid.NewGuid(),
                        ProductName = "Kỹ năng Quản lý Mối quan hệ Xã hội .",
                        Description = "Làm chủ hoàn toàn Quản lý Mối quan hệ Xã hội .",
                        NameTitle = "Xã hội",
                        Author = "xiao Chun zz11",
                        NumberStudents = 6141,
                        Evaluate = 3,
                        Price = 146000,
                        Type = "SK",
                        FileName = "quanhe.png",
                },
            };
            modelBuilder.Entity<Product>().HasData(products);
            var videos = new List<Video>
            {
                   new Video ()
                 {
                    Id = 1,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title = "Mở Đầu và Chuẩn Bị Môi Trường Code",
                 },
                   new Video ()
                 {
                    Id = 2,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title = "ASP.NET Core là gì có tác dụng gì?",

                 }
                 ,
                   new Video ()
                 {
                    Id = 3,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title = "Restfull api with API with ASP.NET Core",
                 }
                  ,
                   new Video ()
                 {
                    Id = 4,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title = "Authorization with ASP.NET CORE API",
                 },
                   new Video ()
                 {
                    Id = 5,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title = "Deploy ASP.NET CORE with Azure",
                 },
                   new Video ()
                   {
                    Id = 6,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title = "Hướng dẫn cài đặt Docker và run MySQL Container",
                   },
                new Video{
                    Id = 7,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title = "Tạo table mysql với TablePlus",
                },
                new Video{
                    Id = 8,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title = "Insert data MySQL với TablePlus",
                },
                new Video{
                    Id = 9,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title = "Primary Key và Index trên nhiều cột",
                },
                new Video{
                    Id = 10,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title = "RestFul api với golang!!!",
                },
                new Video ()
                {
                Id = 11,
                ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                Title = "Tại Sao Sử Dụng Hook Thay Vì Class Component",
                },
                new Video ()
                {
                Id = 12,
                ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                Title = "Cài Đặt Môi Trường Dự Án React.JS với Hook",
                },

                new Video ()
                {
                Id = 13,
                ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                Title = "Viết Hello World Với React Hook",
                },

                new Video ()
                {
                Id = 14,
                ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                Title = "3.1 Hạ Version React 18 Xuống 17",
                },

                new Video ()
                {
                Id = 15,
                ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                Title = "Components & Templates với React Hook",
                },
            };
            modelBuilder.Entity<Video>().HasData(videos);
            var LessonContents = new List<LessonContent>()
            {
                 new LessonContent
                {
                    Id = 1,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title =  "Xây Dựng và Triển Khai API RESTful với ASP.NET Core",
                },
                 new LessonContent
                {
                    Id = 2,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title =  "Kết Nối và Làm Việc với Cơ Sở Dữ Liệu SQL Server",
                },
                 new LessonContent
                {
                    Id = 3,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title = "Quản Lý Tài Nguyên và Xác Thực",
                },
                 new LessonContent
                {
                    Id = 4,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title = "Tối Ưu Hóa Hiệu Suất và Xử Lý Lỗi",
                },
                 new LessonContent
                {
                    Id = 5,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title =  "Sử Dụng Middleware và Dependency Injection",
                },
                 new LessonContent
                {
                    Id = 6,
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    Title =  "Thực Hiện Quan Hệ Đa Nhiều và Lazy Loading",
                },
                 new LessonContent
                {
                    Id = 7,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title =  "Xây Dựng và Triển Khai API RESTful với Golang & gorm gin",
                },
                 new LessonContent
                {
                    Id = 8,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title =  "Kết Nối và Làm Việc với Cơ Sở Dữ Liệu mySql",
                },
                 new LessonContent
                {
                    Id = 9,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title = "Quản Lý Tài Nguyên và Xác Thực",
                },
                 new LessonContent
                {
                    Id = 10,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title = "Tối Ưu Hóa Hiệu Suất và Xử Lý Lỗi",
                },
                 new LessonContent
                {
                    Id = 11,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title =  "Sử Dụng Middleware và Dependency Injection",
                },
                 new LessonContent
                {
                    Id = 12,
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    Title =  "Thực Hiện Quan Hệ Đa Nhiều và Lazy Loading",
                },
                 new LessonContent
                {
                    Id = 13,
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Title =  "Tạo project với reactJs",
                },
                 new LessonContent
                {
                    Id = 14,
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Title =  "Kết Nối và Làm Việc backned NestJs",
                },
                 new LessonContent
                {
                    Id = 15,
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Title = "Tạo component với reactJs",
                },
                 new LessonContent
                {
                    Id = 16,
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Title = "Master css với reactJs",
                },
                 new LessonContent
                {
                    Id = 17,
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Title =  "Sử dụng typescript với reactJs",
                },
                 new LessonContent
                {
                    Id = 18,
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    Title =  "Thực hành 1 project đầu tiên với reactJs và Typescript",
                }
            };
            modelBuilder.Entity<LessonContent>().HasData(LessonContents);
            var DescriptionVideos = new List<DescriptionVideo>
            {
                new DescriptionVideo
                {
                    Id = 1,
                    VideoId = 1,
                    TitleVideo = "Cài Đặt Visual Studio Code hoặc Visual Studio",
                    TimeVideo = "03:25"
                },
                new DescriptionVideo
                {
                    Id = 2,
                    VideoId = 1,
                    TitleVideo =  "Tạo Dự Án ASP.NET Core API",
                    TimeVideo = "08:10"
                },
                new DescriptionVideo
                {
                    Id = 3,
                    VideoId = 1,
                    TitleVideo = "Cấu Hình Cơ Sở Dữ Liệu",
                    TimeVideo =  "12:45"
                },
                new DescriptionVideo
                {
                    Id = 4,
                    VideoId = 1,
                    TitleVideo = "Tạo Model và Migrate Database",
                    TimeVideo =  "15:30"
                },
                new DescriptionVideo
                {
                    Id = 5,
                    VideoId = 1,
                    TitleVideo =  "Chuẩn Bị Môi Trường Code",
                    TimeVideo =  "20:15"
                },
                new DescriptionVideo
                {
                    Id = 6,
                    VideoId = 1,
                    TitleVideo = "Kết nối cơ sở dữ liệu Sql Server",
                    TimeVideo =  "23:50"
                },
                new DescriptionVideo
                {
                    Id = 7,
                    VideoId = 2,
                    TitleVideo = "Giới Thiệu về ASP.NET Core",
                    TimeVideo =  "03:25"
                },
                new DescriptionVideo
                {
                    Id = 8,
                    VideoId = 2,
                    TitleVideo = "Đa Nền Tảng và Mã Mở",
                    TimeVideo =   "04:45"
                },
                new DescriptionVideo
                {
                    Id = 9,
                    VideoId = 2,
                    TitleVideo = "Hiệu Suất Cao và Tối Ưu Hóa",
                    TimeVideo =  "02:21"
                },
                new DescriptionVideo
                {
                    Id = 10,
                    VideoId = 2,
                    TitleVideo = "Mô Hình Middleware và Dependency Injection",
                    TimeVideo =  "07:56"
                },
                new DescriptionVideo
                {
                    Id = 11,
                    VideoId = 3,
                    TitleVideo =  "Created User with ASP.NET Core",
                    TimeVideo =  "04:21"
                },
                new DescriptionVideo
                {
                    Id = 12,
                    VideoId = 3,
                    TitleVideo = "Get User with ASP.NET Core",
                    TimeVideo =   "02:47"
                },
                new DescriptionVideo
                {
                    Id = 13,
                    VideoId = 3,
                    TitleVideo = "Update User with ASP.NET Core",
                    TimeVideo =  "03:22"
                },
                new DescriptionVideo
                {
                    Id = 14,
                    VideoId = 3,
                    TitleVideo =  "Delete User with ASP.NET Core",
                    TimeVideo =  "01:56"
                },
                new DescriptionVideo
                {
                    Id = 15,
                    VideoId = 3,
                    TitleVideo =  "Get All Users with pagination with ASP.NET Core",
                    TimeVideo =   "07:32"
                },
                new DescriptionVideo
                {
                    Id = 16,
                    VideoId = 4,
                    TitleVideo =   "What JWT token ?",
                    TimeVideo =    "08:21"
                },
                new DescriptionVideo
                {
                    Id = 17,
                    VideoId = 4,
                    TitleVideo =   "Set up JWT token",
                    TimeVideo =    "11:47"
                },
                new DescriptionVideo
                {
                    Id = 18,
                    VideoId = 4,
                    TitleVideo =   "Create JWT token",
                    TimeVideo =    "06:22"
                },
                new DescriptionVideo
                {
                    Id = 19,
                    VideoId = 4,
                    TitleVideo =    "bla bla bla bla",
                    TimeVideo =   "18:56"
                },
                new DescriptionVideo
                {
                    Id = 20,
                    VideoId = 4,
                    TitleVideo =   "Refresh Token with ASP.NET CORE",
                    TimeVideo =   "09:32"
                },
                new DescriptionVideo
                {
                    Id = 21,
                    VideoId = 5,
                    TitleVideo =   "Create account Azure",
                    TimeVideo =   "03:21"
                },
                new DescriptionVideo
                {
                    Id = 22,
                    VideoId = 5,
                    TitleVideo =   "Set up account Azure",
                    TimeVideo =    "12:47",
                },
                new DescriptionVideo
                {
                    Id = 23,
                    VideoId = 5,
                    TitleVideo =    "Set Database connection to Azure",
                    TimeVideo =    "07:22"
                },
                new DescriptionVideo
                {
                    Id = 24,
                    VideoId = 5,
                    TitleVideo =    "bla bla bla bla",
                    TimeVideo =   "14:56"
                },
                new DescriptionVideo
                {
                    Id = 25,
                    VideoId = 5,
                    TitleVideo =   "Một số câu hỏi thêm",
                    TimeVideo = "10:32"
                },
                new DescriptionVideo
                {
                    Id = 26,
                    VideoId = 6,
                    TitleVideo = "Cài đặt Docker",
                    TimeVideo = "03:00"
                },
                new DescriptionVideo
                {
                    Id = 27,
                    VideoId = 6,
                    TitleVideo = "Confirm Docker & Start Docker",
                    TimeVideo = "01:54"
                },
                new DescriptionVideo
                {
                    Id = 28,
                    VideoId = 6,
                    TitleVideo = "MySQL Container",
                    TimeVideo = "02:53"
                },
                new DescriptionVideo
                {
                    Id = 29,
                    VideoId = 6,
                    TitleVideo = "TablePlus",
                    TimeVideo = "08:24"
                },
                new DescriptionVideo
                {
                    Id = 30,
                    VideoId = 7,
                    TitleVideo = "Tạo table bằng câu lệnh SQL",
                    TimeVideo = "00:15"
                },
                new DescriptionVideo
                {
                    Id = 31,
                    VideoId = 7,
                    TitleVideo = "Tạo table mới bằng TablePlus",
                    TimeVideo = "00:31"
                },
                new DescriptionVideo
                {
                    Id = 32,
                    VideoId = 7,
                    TitleVideo = "Đặt tên cho table",
                    TimeVideo = "00:44"
                },
                new DescriptionVideo
                {
                    Id = 33,
                    VideoId = 7,
                    TitleVideo = "Cột ID",
                    TimeVideo = "01:25"
                },
                new DescriptionVideo
                {
                    Id = 34,
                    VideoId = 8,
                    TitleVideo = "Ôn lại câu lệnh insert data",
                    TimeVideo = "04:15"
                },
                new DescriptionVideo
                {
                    Id = 35,
                    VideoId = 8,
                    TitleVideo = "Thử insert data",
                    TimeVideo = "03:32"
                },
                new DescriptionVideo
                {
                    Id = 36,
                    VideoId = 8,
                    TitleVideo = "Thử insert nhiều data",
                    TimeVideo = "05:44"
                },
                new DescriptionVideo
                {
                    Id = 37,
                    VideoId = 8,
                    TitleVideo = "Insert nhiều data vào cột dữ liệu",
                    TimeVideo = "07:25"
                },
                new DescriptionVideo
                {
                    Id = 38,
                    VideoId = 9,
                    TitleVideo = "Tạo khóa chính của bảng",
                    TimeVideo = "02:15"
                },
                new DescriptionVideo
                {
                    Id = 39,
                    VideoId = 9,
                    TitleVideo = "Tạo khóa phụ của bảng",
                    TimeVideo = "01:31"
                },
                new DescriptionVideo
                {
                    Id = 40,
                    VideoId = 9,
                    TitleVideo = "Kết nối khóa chính với khóa phụ",
                    TimeVideo = "07:44"
                },
                new DescriptionVideo
                {
                    Id = 41,
                    VideoId = 9,
                    TitleVideo = "Ôn lại một số kiến thức cơ bản về golang",
                    TimeVideo = "08:35"
                },
                new DescriptionVideo
                {
                    Id = 42,
                    VideoId = 10,
                    TitleVideo = "Tạo project khởi đầu",
                    TimeVideo = "09:15"
                },
                new DescriptionVideo
                {
                    Id = 43,
                    VideoId = 10,
                    TitleVideo = "Kết nối với cơ sở dữ liệu mySql",
                    TimeVideo = "05:21"
                },
                new DescriptionVideo
                {
                    Id = 44,
                    VideoId = 10,
                    TitleVideo = "Tạo api với golang & gin gorm",
                    TimeVideo = "06:43"
                },
                new DescriptionVideo
                {
                    Id = 45,
                    VideoId = 10,
                    TitleVideo = "Authecication với golang!!!",
                    TimeVideo = "07:33"
                },
                new DescriptionVideo
                {
                    Id = 46,
                    VideoId = 11,
                    TitleVideo = "Giới thiệu",
                    TimeVideo = "00:00"
                },
                new DescriptionVideo
                {
                    Id = 47,
                    VideoId = 11,
                    TitleVideo = "React Hook",
                    TimeVideo = "00:15"
                },
                new DescriptionVideo
                {
                    Id = 48,
                    VideoId = 11,
                    TitleVideo = "Hook có gì hay",
                    TimeVideo = "05:30"
                },
                new DescriptionVideo
                {
                    Id = 49,
                    VideoId = 11,
                    TitleVideo = "Class hay là Hook",
                    TimeVideo = "09:05"
                },
                new DescriptionVideo
                {
                    Id = 50,
                    VideoId = 12,
                    TitleVideo = "Giới thiệu",
                    TimeVideo = "00:00"
                },
                new DescriptionVideo
                {
                    Id = 51,
                    VideoId = 12,
                    TitleVideo = "Visual Studio Code",
                    TimeVideo = "01:15"
                },
                new DescriptionVideo
                {
                    Id = 52,
                    VideoId = 12,
                    TitleVideo = "Môi trường Node.js",
                    TimeVideo = "04:35"
                },
                new DescriptionVideo
                {
                    Id = 53,
                    VideoId = 12,
                    TitleVideo = "Git",
                    TimeVideo = "07:42"
                },
                new DescriptionVideo
                {
                    Id = 54,
                    VideoId = 13,
                    TitleVideo = "Giới thiệu",
                    TimeVideo = "00:00"
                },
                new DescriptionVideo
                {
                    Id = 55,
                    VideoId = 13,
                    TitleVideo = "Tìm tài liệu",
                    TimeVideo = "01:05"
                },
                new DescriptionVideo
                {
                    Id = 56,
                    VideoId = 13,
                    TitleVideo = "Sử dụng Create react app",
                    TimeVideo = "07:13"
                },
                new DescriptionVideo
                {
                    Id = 57,
                    VideoId = 13,
                    TitleVideo = "Run project",
                    TimeVideo = "13:30"
                },
                new DescriptionVideo
                {
                    Id = 58,
                    VideoId = 13,
                    TitleVideo = "Chạy project từ Github",
                    TimeVideo = "17:35"
                },
                new DescriptionVideo
                {
                    Id = 59,
                    VideoId = 14,
                    TitleVideo = "Hạ version xuống của reactJs",
                    TimeVideo = "17:35"
                },
                new DescriptionVideo
                {
                    Id = 60,
                    VideoId = 15,
                    TitleVideo = "Giới thiệu",
                    TimeVideo = "00:00"
                },
                new DescriptionVideo
                {
                    Id = 61,
                    VideoId = 15,
                    TitleVideo = "Components là gì",
                    TimeVideo = "00:55"
                },
                new DescriptionVideo
                {
                    Id = 62,
                    VideoId = 15,
                    TitleVideo = "Template HTML",
                    TimeVideo = "02:40"
                },
                new DescriptionVideo
                {
                    Id = 63,
                    VideoId = 15,
                    TitleVideo = "Giải thích Component",
                    TimeVideo = "09:05"
                },
                new DescriptionVideo
                {
                    Id = 64,
                    VideoId = 15,
                    TitleVideo = "Luồng hoạt động React",
                    TimeVideo = "13:30"
                },
            };
            modelBuilder.Entity<DescriptionVideo>().HasData(DescriptionVideos);
            var Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    evaluate = 4.5,
                    Title = "Qúa hay và bổ ích",
                    UserName = "XiaoChun",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    evaluate = 4,
                    Title = "Tôi đã ra khi học khóa này!",
                    UserName = "CamTu",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    evaluate = 3.5,
                    Title = "Cần cập nhật thêm 1 số kiến thức",
                    UserName = "LienNguyen",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    evaluate = 3,
                    Title = "Khóa học không phù hợp với tôi",
                    UserName = "TraMy",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    evaluate = 4.5,
                    Title = "Quá là hay luôn",
                    UserName = "TrungNguyen",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("1f1ee017-6d3a-46f8-839a-3b41330fbf17"),
                    evaluate = 2.5,
                    Title = "Như cc!!!",
                    UserName = "TrungNguyen",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    evaluate = 3.5,
                    Title = "Qúa là tuyệt vời",
                    UserName = "ThuongNguyen",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                  new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    evaluate = 4,
                    Title = "Hay tôi đã học được nhiều thứ từ khóa học này",
                    UserName = "HoangGiang",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                  new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    evaluate = 4.5,
                    Title = "Cần bổ xung thêm nhiều kiến thức hơn",
                    UserName = "XiaoChun",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                  new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("7a2f9e3b-8a15-4c0b-b784-693c0e20d8a9"),
                    evaluate = 4,
                    Title = "Hay vl!!!",
                    UserName = "XiaoChun",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    evaluate = 2.5,
                    Title = "Qúa tệ!!!",
                    UserName = "XiaoChun",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    evaluate = 4,
                    Title = "Bla bla bla!!!",
                    UserName = "XiaoChun",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    evaluate = 3.5,
                    Title = "Amazing good chop!!!",
                    UserName = "XiaoChun",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Comment
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("a572cd2d-72e4-4e1a-b3cc-84121a9f7a4e"),
                    evaluate = 4.5,
                    Title = "Ưng quá chừng!",
                    UserName = "XiaoChun",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
            modelBuilder.Entity<Comment>().HasData(Comments);
        }
    }
}
