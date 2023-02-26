using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBE.Migrations
{
    public partial class updatemodelproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFreeship",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PercentPrice",
                table: "Products",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFreeship",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PercentPrice",
                table: "Products");
        }
    }
}
