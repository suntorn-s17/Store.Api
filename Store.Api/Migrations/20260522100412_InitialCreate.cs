using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("1c02563b-5678-4321-951f-5063a8241b22"), "Sports & Outdoor" },
                    { new Guid("7d8e9f0a-1122-3344-5566-778899aabbcc"), "Home & Living" },
                    { new Guid("a5d24b61-9012-4cfc-a496-bf66d405785f"), "Electronics & Gadgets" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerAddress", "CustomerEmail", "CustomerName", "CustomerPhone" },
                values: new object[,]
                {
                    { new Guid("b11c22d3-44e5-55f6-66a7-77b88c99d0a1"), "99/1 มหาวิทยาลัยธรรมศาสตร์ ถ.พหลโยธิน ต.คลองหนึ่ง อ.คลองหลวง จ.ปทุมธานี 12120", "nattapong.k@gmail.com", "ณัฐพงษ์ แก้วมณี", "081-234-5678" },
                    { new Guid("e99d88c7-66b5-55a4-44f3-33e22d11c0b2"), "456 คอนโดศุภาลัย ปาร์ค แขวงจตุจักร เขตจตุจักร กรุงเทพมหานคร 10900", "pimonpat.s@outlook.com", "พิมลภัส ศรีสุข", "089-876-5432" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("d2b6fb1a-4c28-4b71-a02d-ff14b986e3a1"), "$2a$11$8l5uer78GXrq6Hl6Py8v.e3qOisnxDbVOZW/prHQombzmJmvrw6Du", "admin", "admin001" },
                    { new Guid("e8fa47c3-3b1a-4f92-96d5-cc2140a7b532"), "$2a$11$fW2zVTrDAiOLpOe2xsoB1uhHjJDonKyRAgeiQM6c7FJC25T1fvxHm", "operation", "operation001" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-3333-4444-555555555555"), new DateTime(2026, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), new Guid("b11c22d3-44e5-55f6-66a7-77b88c99d0a1") },
                    { new Guid("66666666-7777-8888-9999-000000000000"), new DateTime(2026, 5, 22, 14, 15, 0, 0, DateTimeKind.Unspecified), new Guid("e99d88c7-66b5-55a4-44f3-33e22d11c0b2") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { new Guid("2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"), new Guid("1c02563b-5678-4321-951f-5063a8241b22"), "รองเท้าวิ่งมาราธอนระดับท็อป เสริมแผ่นคาร์บอนไฟเบอร์เต็มแผ่น ช่วยเพิ่มแรงส่งและรองรับแรงกระแทกได้อย่างยอดเยี่ยม ผ้าหน้าอัปเปอร์ระบายอากาศได้ดี น้ำหนักเบาพิเศษเพียง 185 กรัม", "ApexRun Pro Carbon", 6500.00m },
                    { new Guid("3e4f5a6b-7c8d-9e0f-1a2b-3c4d5e6f7a8b"), new Guid("1c02563b-5678-4321-951f-5063a8241b22"), "กระบอกน้ำสแตนเลสเก็บอุณหภูมิร้อน-เย็น เกรดพรีเมียม (18/8 Food-Grade) เก็บความเย็นได้นาน 24 ชั่วโมง และเก็บความร้อนได้ 12 ชั่วโมง ฝาปิดกันรั่วซึม 100% ความจุ 32 ออนซ์", "HydroPeak Insulated Flask", 1250.00m },
                    { new Guid("4f5a6b7c-8d9e-0f1a-2b3c-4d5e6f7a8b9c"), new Guid("7d8e9f0a-1122-3344-5566-778899aabbcc"), "เครื่องฟอกอากาศอัจฉริยะสำหรับห้องขนาด 35-50 ตร.ม. มาพร้อมไส้กรอง True HEPA H13 ดักจับฝุ่นละอองขนาดเล็ก PM2.5 และสารก่อภูมิแพ้ได้ถึง 99.97% ทำงานเงียบสนิทเพียง 22 เดซิเบล", "PureAir Breeze V2", 3990.00m },
                    { new Guid("5a6b7c8d-9e0f-1a2b-3c4d-5e6f7a8b9c0d"), new Guid("7d8e9f0a-1122-3344-5566-778899aabbcc"), "หมอนเมมโมรี่โฟมเพื่อสุขภาพ ออกแบบตามหลักสรีรศาสตร์ รองรับต้นคอและบ่าได้อย่างพอดี ช่วยลดอาการปวดเมื่อยขณะนอนหลับ ปลอกหมอนผ้าทอจากเส้นใยไม้ไผ่ธรรมชาติ นุ่มสบาย ระบายอากาศได้ดี", "ErgoComfort Memory Foam Pillow", 1590.00m },
                    { new Guid("8a7b6c5d-4e3f-2a1b-0c9d-8e7f6a5b4c3d"), new Guid("a5d24b61-9012-4cfc-a496-bf66d405785f"), "นาฬิกาอัจฉริยะหน้าจอ AMOLED ขนาด 1.43 นิ้ว รองรับการวัดอัตราการเต้นของหัวใจ ตรวจสอบคุณภาพการนอนหลับ และติดตามโหมดออกกำลังกายกว่า 100 โหมด มี GPS ในตัวและกันน้ำระดับ 5ATM", "AuraLink Smart Watch Series 5", 3290.00m },
                    { new Guid("f49341db-a1c2-403d-749c-08deb754c526"), new Guid("a5d24b61-9012-4cfc-a496-bf66d405785f"), "หูฟังไร้สายครอบหูระบบตัดเสียงรบกวนแบบ Active Noise Cancellation (ANC) มีไดรเวอร์ขนาด 40 มม. ให้เสียงเบสหนักแน่น แบตเตอรี่ใช้งานได้ยาวนานต่อเนื่อง 45 ชั่วโมงต่อการชาร์จหนึ่งครั้ง", "SoundWave Prime-X", 4990.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-b2b2-c3c3-d4d4-e5e5e5e5e5e5"), new Guid("11111111-2222-3333-4444-555555555555"), new Guid("f49341db-a1c2-403d-749c-08deb754c526"), 1 },
                    { new Guid("b2b2b2b2-c3c3-d4d4-e5e5-f6f6f6f6f6f6"), new Guid("11111111-2222-3333-4444-555555555555"), new Guid("8a7b6c5d-4e3f-2a1b-0c9d-8e7f6a5b4c3d"), 2 },
                    { new Guid("c3c3c3c3-d4d4-e5e5-f6f6-a7a7a7a7a7a7"), new Guid("66666666-7777-8888-9999-000000000000"), new Guid("2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"), 1 },
                    { new Guid("d4d4d4d4-e5e5-f6f6-a7a7-b8b8b8b8b8b8"), new Guid("66666666-7777-8888-9999-000000000000"), new Guid("3e4f5a6b-7c8d-9e0f-1a2b-3c4d5e6f7a8b"), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}