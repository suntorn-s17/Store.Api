using Microsoft.EntityFrameworkCore;

namespace Store.Api.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categoryElectronicsId = Guid.Parse("a5d24b61-9012-4cfc-a496-bf66d405785f");
            var categorySportsId = Guid.Parse("1c02563b-5678-4321-951f-5063a8241b22");
            var categoryHomeId = Guid.Parse("7d8e9f0a-1122-3344-5566-778899aabbcc");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = categoryElectronicsId,
                    CategoryName = "Electronics & Gadgets"
                },
                new Category
                {
                    Id = categorySportsId,
                    CategoryName = "Sports & Outdoor"
                },
                new Category
                {
                    Id = categoryHomeId,
                    CategoryName = "Home & Living"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("f49341db-a1c2-403d-749c-08deb754c526"),
                    ProductName = "SoundWave Prime-X",
                    ProductDescription = "หูฟังไร้สายครอบหูระบบตัดเสียงรบกวนแบบ Active Noise Cancellation (ANC) มีไดรเวอร์ขนาด 40 มม. ให้เสียงเบสหนักแน่น แบตเตอรี่ใช้งานได้ยาวนานต่อเนื่อง 45 ชั่วโมงต่อการชาร์จหนึ่งครั้ง",
                    ProductPrice = 4990.00m,
                    CategoryId = categoryElectronicsId
                },
                new Product
                {
                    Id = Guid.Parse("8a7b6c5d-4e3f-2a1b-0c9d-8e7f6a5b4c3d"),
                    ProductName = "AuraLink Smart Watch Series 5",
                    ProductDescription = "นาฬิกาอัจฉริยะหน้าจอ AMOLED ขนาด 1.43 นิ้ว รองรับการวัดอัตราการเต้นของหัวใจ ตรวจสอบคุณภาพการนอนหลับ และติดตามโหมดออกกำลังกายกว่า 100 โหมด มี GPS ในตัวและกันน้ำระดับ 5ATM",
                    ProductPrice = 3290.00m,
                    CategoryId = categoryElectronicsId
                },

                new Product
                {
                    Id = Guid.Parse("2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"),
                    ProductName = "ApexRun Pro Carbon",
                    ProductDescription = "รองเท้าวิ่งมาราธอนระดับท็อป เสริมแผ่นคาร์บอนไฟเบอร์เต็มแผ่น ช่วยเพิ่มแรงส่งและรองรับแรงกระแทกได้อย่างยอดเยี่ยม ผ้าหน้าอัปเปอร์ระบายอากาศได้ดี น้ำหนักเบาพิเศษเพียง 185 กรัม",
                    ProductPrice = 6500.00m,
                    CategoryId = categorySportsId
                },
                new Product
                {
                    Id = Guid.Parse("3e4f5a6b-7c8d-9e0f-1a2b-3c4d5e6f7a8b"),
                    ProductName = "HydroPeak Insulated Flask",
                    ProductDescription = "กระบอกน้ำสแตนเลสเก็บอุณหภูมิร้อน-เย็น เกรดพรีเมียม (18/8 Food-Grade) เก็บความเย็นได้นาน 24 ชั่วโมง และเก็บความร้อนได้ 12 ชั่วโมง ฝาปิดกันรั่วซึม 100% ความจุ 32 ออนซ์",
                    ProductPrice = 1250.00m,
                    CategoryId = categorySportsId
                },

                new Product
                {
                    Id = Guid.Parse("4f5a6b7c-8d9e-0f1a-2b3c-4d5e6f7a8b9c"),
                    ProductName = "PureAir Breeze V2",
                    ProductDescription = "เครื่องฟอกอากาศอัจฉริยะสำหรับห้องขนาด 35-50 ตร.ม. มาพร้อมไส้กรอง True HEPA H13 ดักจับฝุ่นละอองขนาดเล็ก PM2.5 และสารก่อภูมิแพ้ได้ถึง 99.97% ทำงานเงียบสนิทเพียง 22 เดซิเบล",
                    ProductPrice = 3990.00m,
                    CategoryId = categoryHomeId
                },
                new Product
                {
                    Id = Guid.Parse("5a6b7c8d-9e0f-1a2b-3c4d-5e6f7a8b9c0d"),
                    ProductName = "ErgoComfort Memory Foam Pillow",
                    ProductDescription = "หมอนเมมโมรี่โฟมเพื่อสุขภาพ ออกแบบตามหลักสรีรศาสตร์ รองรับต้นคอและบ่าได้อย่างพอดี ช่วยลดอาการปวดเมื่อยขณะนอนหลับ ปลอกหมอนผ้าทอจากเส้นใยไม้ไผ่ธรรมชาติ นุ่มสบาย ระบายอากาศได้ดี",
                    ProductPrice = 1590.00m,
                    CategoryId = categoryHomeId
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = Guid.Parse("b11c22d3-44e5-55f6-66a7-77b88c99d0a1"),
                    CustomerName = "สมชาย ใจดี",
                    CustomerAddress = "99/1 มหาวิทยาลัยธรรมศาสตร์ ถ.พหลโยธิน ต.คลองหนึ่ง อ.คลองหลวง จ.ปทุมธานี 12120",
                    CustomerEmail = "sonchat.j@gmail.com",
                    CustomerPhone = "081-234-5678"
                },
                new Customer
                {
                    Id = Guid.Parse("e99d88c7-66b5-55a4-44f3-33e22d11c0b2"),
                    CustomerName = "สมศรี พากเพียร",
                    CustomerAddress = "456 คอนโดศุภาลัย ปาร์ค แขวงจตุจักร เขตจตุจักร กรุงเทพมหานคร 10900",
                    CustomerEmail = "somsri.p@outlook.com",
                    CustomerPhone = "089-876-5432"
                }
            );

            var order1Id = Guid.Parse("11111111-2222-3333-4444-555555555555");
            var order2Id = Guid.Parse("66666666-7777-8888-9999-000000000000");

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = order1Id,
                    CreatedAt = new DateTime(2026, 5, 20, 10, 30, 0),
                    CustomerId = Guid.Parse("b11c22d3-44e5-55f6-66a7-77b88c99d0a1")
                },
                new Order
                {
                    Id = order2Id,
                    CreatedAt = new DateTime(2026, 5, 22, 14, 15, 0),
                    CustomerId = Guid.Parse("e99d88c7-66b5-55a4-44f3-33e22d11c0b2")
                }
            );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = Guid.Parse("a1a1a1a1-b2b2-c3c3-d4d4-e5e5e5e5e5e5"),
                    OrderId = order1Id,
                    ProductId = Guid.Parse("f49341db-a1c2-403d-749c-08deb754c526"),
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = Guid.Parse("b2b2b2b2-c3c3-d4d4-e5e5-f6f6f6f6f6f6"),
                    OrderId = order1Id,
                    ProductId = Guid.Parse("8a7b6c5d-4e3f-2a1b-0c9d-8e7f6a5b4c3d"),
                    Quantity = 2
                },

                new OrderDetail
                {
                    Id = Guid.Parse("c3c3c3c3-d4d4-e5e5-f6f6-a7a7a7a7a7a7"),
                    OrderId = order2Id,
                    ProductId = Guid.Parse("2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"),
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = Guid.Parse("d4d4d4d4-e5e5-f6f6-a7a7-b8b8b8b8b8b8"),
                    OrderId = order2Id,
                    ProductId = Guid.Parse("3e4f5a6b-7c8d-9e0f-1a2b-3c4d5e6f7a8b"),
                    Quantity = 3
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("d2b6fb1a-4c28-4b71-a02d-ff14b986e3a1"),
                    Username = "admin001",
                    Password = BCrypt.Net.BCrypt.HashPassword("P@ssword1234"),
                    Role = "admin"
                },
                new User
                {
                    Id = Guid.Parse("e8fa47c3-3b1a-4f92-96d5-cc2140a7b532"),
                    Username = "operation001",
                    Password = BCrypt.Net.BCrypt.HashPassword("op@12345"),
                    Role = "operation"
                }
                );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}