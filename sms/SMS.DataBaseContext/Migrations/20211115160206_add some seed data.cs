using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.DataBaseContext.Migrations
{
    public partial class addsomeseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DivisonId", "IsDeleted", "Name" },
                values: new object[] { 4L, "004Di", null, null, 2L, false, "Jessore" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DivisonId", "IsDeleted", "Name" },
                values: new object[] { 5L, "005Di", null, null, 2L, false, "Narail" });

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DistrictId", "IsDeleted", "Name" },
                values: new object[] { 14L, "0014U", null, null, 4L, false, "Lohagara" });

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DistrictId", "IsDeleted", "Name" },
                values: new object[] { 16L, "0016U", null, null, 4L, false, "Kalia" });

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "Code", "DeletedById", "DeletedOn", "DistrictId", "IsDeleted", "Name" },
                values: new object[] { 15L, "0014U", null, null, 5L, false, "Jigorgacha" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
