using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.DataBaseContext.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisonId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Divisons_DivisonId",
                        column: x => x.DivisonId,
                        principalTable: "Divisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upazilas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazilas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upazilas_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UpazilaId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Upazilas_UpazilaId",
                        column: x => x.UpazilaId,
                        principalTable: "Upazilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Divisons",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "IsDeleted", "Name" },
                values: new object[] { 1L, "001D", null, null, false, "Dhaka" });

            migrationBuilder.InsertData(
                table: "Divisons",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "IsDeleted", "Name" },
                values: new object[] { 2L, "002D", null, null, false, "Khulna" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DivisonId", "IsDeleted", "Name" },
                values: new object[] { 1L, "001Di", null, null, 1L, false, "Kishoreganj" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DivisonId", "IsDeleted", "Name" },
                values: new object[] { 2L, "002Di", null, null, 1L, false, "Gazipur" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DivisonId", "IsDeleted", "Name" },
                values: new object[] { 3L, "003Di", null, null, 1L, false, "Manikganj" });

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DistrictId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1L, "001U", null, null, 1L, false, "Kishoreganj Sadar" },
                    { 2L, "002U", null, null, 1L, false, "Bhairab" },
                    { 3L, "003U", null, null, 1L, false, "Bajitpur" },
                    { 4L, "004U", null, null, 1L, false, "Kuliarchar" },
                    { 5L, "005U", null, null, 1L, false, "Pakundia" },
                    { 6L, "006U", null, null, 1L, false, "Itna" },
                    { 7L, "007U", null, null, 1L, false, "Karimganj" },
                    { 8L, "008U", null, null, 1L, false, "Katiadi" },
                    { 9L, "009U", null, null, 1L, false, "Ashtagram" },
                    { 10L, "0010U", null, null, 1L, false, "Mithamin" },
                    { 11L, "0011U", null, null, 1L, false, "Tarail" },
                    { 12L, "0012U", null, null, 1L, false, "Hossainpur" },
                    { 13L, "0013U", null, null, 1L, false, "Nikli" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_DivisonId",
                table: "Districts",
                column: "DivisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UpazilaId",
                table: "Stock",
                column: "UpazilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Upazilas_DistrictId",
                table: "Upazilas",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Upazilas");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Divisons");
        }
    }
}
