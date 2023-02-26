﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnBE.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCateID",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCategoryCateID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCateID",
                table: "Products",
                column: "ProductCategoryCateID",
                principalTable: "ProductCategories",
                principalColumn: "CateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCateID",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductCategoryCateID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCateID",
                table: "Products",
                column: "ProductCategoryCateID",
                principalTable: "ProductCategories",
                principalColumn: "CateID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
