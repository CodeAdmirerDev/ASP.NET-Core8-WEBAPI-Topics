using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoServerAppForHMAC.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ClientSecretKey = table.Column<byte[]>(type: "varbinary(1000)", maxLength: 1000, nullable: false),
                    ClientSecretSalt = table.Column<byte[]>(type: "varbinary(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ClientInfos",
                columns: new[] { "Id", "ClientId", "ClientName", "ClientSecretKey", "ClientSecretSalt" },
                values: new object[,]
                {
                    { 1, "WebApp", "XYZ Company", new byte[] { 172, 14, 128, 238, 100, 112, 148, 156, 162, 187, 195, 29, 210, 200, 230, 249, 203, 85, 94, 128, 92, 70, 121, 220, 3, 104, 68, 131, 72, 226, 215, 99, 41, 253, 145, 58, 37, 188, 64, 78, 236, 79, 17, 55, 118, 62, 75, 115, 158, 71, 38, 196, 137, 224, 77, 177, 159, 58, 119, 60, 220, 227, 209, 185 }, new byte[] { 230, 252, 216, 125, 153, 2, 136, 65, 37, 165, 104, 53, 126, 84, 19, 13, 104, 183, 203, 106, 149, 9, 152, 192, 147, 211, 41, 205, 185, 7, 225, 145, 252, 1, 37, 63, 213, 132, 213, 87, 134, 223, 217, 115, 249, 104, 220, 24, 50, 250, 113, 65, 201, 207, 85, 231, 11, 144, 162, 227, 95, 98, 125, 82, 129, 45, 200, 89, 170, 153, 202, 129, 44, 26, 106, 17, 127, 59, 114, 43, 235, 59, 1, 126, 211, 103, 52, 43, 223, 6, 238, 205, 79, 123, 184, 101, 31, 184, 229, 139, 125, 195, 248, 169, 164, 237, 182, 71, 132, 89, 130, 194, 198, 81, 234, 80, 69, 226, 115, 59, 211, 254, 234, 101, 139, 52, 89, 76 } },
                    { 2, "MobileApp", "ABC Company", new byte[] { 119, 95, 42, 116, 108, 145, 170, 25, 221, 47, 62, 210, 222, 143, 168, 104, 56, 64, 235, 220, 62, 184, 205, 110, 149, 224, 203, 58, 217, 45, 181, 201, 188, 30, 87, 187, 204, 248, 165, 209, 149, 229, 156, 130, 116, 30, 187, 205, 22, 195, 232, 33, 46, 136, 16, 31, 254, 159, 27, 79, 175, 197, 17, 127 }, new byte[] { 90, 63, 146, 154, 184, 94, 255, 173, 106, 55, 140, 118, 178, 33, 56, 244, 2, 180, 179, 101, 59, 145, 90, 44, 27, 234, 168, 119, 21, 139, 188, 148, 175, 242, 223, 124, 190, 129, 211, 67, 245, 24, 72, 134, 249, 65, 57, 127, 185, 171, 129, 124, 31, 192, 161, 192, 113, 157, 115, 3, 127, 131, 40, 166, 229, 124, 130, 235, 231, 6, 33, 218, 56, 204, 224, 171, 174, 58, 71, 224, 68, 163, 235, 239, 178, 18, 69, 168, 132, 136, 180, 92, 156, 232, 248, 21, 172, 115, 115, 13, 169, 192, 155, 46, 64, 134, 108, 8, 189, 59, 73, 76, 251, 17, 22, 165, 168, 235, 155, 158, 159, 144, 112, 206, 138, 49, 242, 150 } },
                    { 3, "DeskTop", "123 Company", new byte[] { 229, 92, 33, 129, 34, 148, 4, 243, 93, 44, 44, 21, 196, 37, 221, 106, 101, 109, 204, 204, 211, 64, 210, 22, 168, 239, 0, 170, 108, 222, 79, 68, 120, 127, 178, 221, 241, 117, 41, 236, 232, 205, 164, 229, 128, 59, 3, 15, 19, 247, 232, 64, 216, 71, 132, 242, 130, 65, 159, 254, 202, 72, 239, 158 }, new byte[] { 54, 162, 54, 155, 3, 173, 8, 91, 215, 156, 166, 43, 211, 193, 141, 142, 246, 117, 1, 139, 225, 18, 51, 74, 205, 130, 186, 82, 131, 162, 126, 44, 184, 44, 170, 246, 6, 118, 74, 180, 207, 33, 207, 184, 19, 70, 2, 237, 52, 231, 81, 193, 77, 7, 209, 55, 22, 30, 18, 245, 63, 57, 95, 22, 88, 60, 252, 35, 244, 146, 11, 168, 247, 194, 193, 94, 231, 18, 98, 170, 86, 28, 6, 115, 19, 230, 102, 154, 77, 64, 44, 126, 142, 217, 57, 19, 188, 18, 206, 21, 12, 202, 193, 126, 71, 244, 4, 99, 252, 55, 179, 133, 124, 59, 37, 65, 113, 222, 5, 238, 201, 192, 57, 246, 50, 8, 6, 32 } }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Salary", "UserRole", "Username" },
                values: new object[,]
                {
                    { 1, 10000m, "Software Engineer", "Rama" },
                    { 2, 500000m, "Manager", "Krishna" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientInfos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
