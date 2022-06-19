using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodZone.Data.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Food",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Menu_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "common",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CancelReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalSchema: "common",
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "common",
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDetails",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationDetails_Food_FoodId",
                        column: x => x.FoodId,
                        principalSchema: "common",
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationDetails_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "common",
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5188a7a7-5b1d-4c02-a47e-d032961253f9", "984f8b7c-3ce2-417f-8438-e63ff6d8ec2a", "Owner", "OWNER" },
                    { "6db8e259-cc84-44f0-952a-20daf821a5ac", "0442e20b-c219-43dc-903d-19a104cea932", "Staff", "STAFF" },
                    { "850d4e33-fcb4-417b-b738-67edfb69d5ee", "2b65d4ec-3f43-4d67-8672-38e75eaf40ab", "User", "USER" },
                    { "96b48346-4528-47cb-be00-a3eeecc7b695", "9eb65db5-3e70-4afc-b9b7-442b0c8a6b6b", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fec388f4-32c6-4e2c-bae0-d3c807612c6d", 0, "779265e1-f218-4161-aff7-2e697dd408f0", "owner@foodzone.com", false, "Quang", false, null, null, null, "AQAAAAEAACcQAAAAEEq8MUCPJS/GZLTz5Ngr6npdDecUkOoTTFwDygK5sxU5xu98QxkFpIZQMHoicNWF+Q==", "0985786750", false, "ff966643-b843-44dc-8a4c-985d24e8287f", false, "owner@foodzone.com" });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Menu",
                columns: new[] { "Id", "Description", "InsertedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Mang lại một vị tươi mới", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(413), false, "Đồ Uống", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Mỗi mùa mang đến một vị khác nhau", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(424), false, "Thực Đơn Theo Mùa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Mùa nào cũng có", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(425), false, "Thực Đơn Tối", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Mùa nào cũng có", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(426), false, "Thực Đơn Sáng", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Salaries",
                columns: new[] { "Id", "AccountId", "BasicSalary", "InsertedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, 3000000m, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(846), false, "Nhân viên 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, 4000000m, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(847), false, "Nhân viên 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, 5000000m, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(848), false, "Nhân viên 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, 8000000m, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(849), false, "Quản lý 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, 10000000m, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(850), false, "Quản lý 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Tables",
                columns: new[] { "Id", "Capacity", "InsertedAt", "IsDeleted", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(748), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 10, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(749), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 8, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(750), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 8, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(751), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 6, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(752), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(753), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(754), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2, new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(754), false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5188a7a7-5b1d-4c02-a47e-d032961253f9", "fec388f4-32c6-4e2c-bae0-d3c807612c6d" });

            migrationBuilder.InsertData(
                schema: "common",
                table: "Food",
                columns: new[] { "Id", "Description", "Image", "InsertedAt", "IsDeleted", "MenuId", "Name", "Price", "RateCount", "Status", "TotalRate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Có vị thanh ngọt của đào, vị chua dịu của những tép cam căng mọng, vị chát của trà, cùng hương thơm nồng đặc trưng của sả.", "tradaocamxa.jpg", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(622), false, 1, "Trà Đào Cam Sả", 30000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Vị chua chua hòa quyện với vị ngọt từ hoa quả cùng cảm giác mát lạnh từ món ăn.", "suachuadanhda.jpg", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(624), false, 1, "Sữa Chua Đánh Đá", 30000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Thịt bò được kho vừa mềm mà không bị dai, cà rốt giòn ngọt thấm vị nước sốt cay cay mặn mặn đậm đà, dậy mùi thơm phức từ sả rất hấp dẫn.", "thitbokhocarot.jpg", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(625), false, 2, "Thịt Bò Kho Cà Rốt", 50000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Mùi vị thơm ngon và độ dai giòn của mực hòa với vị ngon của nhân bên trong. ", "mucvientuyethoa.jpg", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(626), false, 2, "Mực Viên Tuyết Hoa", 215000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Ướp với nước sốt đặc biệt làm món ăn ngon ngọt thơm.", "canhganuongraucu.png", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(628), false, 3, "Cánh Gà Nướng Rau Củ", 150000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Vị thơm của dứa thêm vào cho sườn heo một vị chua chua.", "suonheoomdua.png", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(629), false, 3, "Sườn Heo Om Dứa", 170000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Vị thơm của cà thêm vào cho thịt heo vị ngon.", "catimhapthitheo.png", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(630), false, 4, "Cà Tím Hấp Thịt Heo", 130000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Vị thơm của cà thêm vào cho thịt heo vị ngon.", "dauphuomvoitom.png", new DateTime(2022, 6, 19, 0, 25, 50, 624, DateTimeKind.Local).AddTicks(631), false, 4, "Đậu Phụ Om Với Tôm", 120000m, 0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FoodId",
                schema: "common",
                table: "Feedback",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_MenuId",
                schema: "common",
                table: "Food",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountId",
                schema: "common",
                table: "Payment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDetails_FoodId",
                schema: "common",
                table: "ReservationDetails",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDetails_ReservationId",
                schema: "common",
                table: "ReservationDetails",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AccountId",
                schema: "common",
                table: "Reservations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                schema: "common",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_AccountId",
                schema: "common",
                table: "Salaries",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Feedback",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "common");

            migrationBuilder.DropTable(
                name: "ReservationDetails",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Salaries",
                schema: "common");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Food",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "common");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tables",
                schema: "common");
        }
    }
}
