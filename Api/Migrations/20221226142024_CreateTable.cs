using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<long>(type: "int8", nullable: true),
                    bar_code = table.Column<string>(type: "varchar", nullable: true),
                    imported_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    url = table.Column<string>(type: "varchar", nullable: true),
                    product_name = table.Column<string>(type: "varchar", nullable: true),
                    quantity = table.Column<string>(type: "varchar", nullable: true),
                    categories = table.Column<string>(type: "varchar", nullable: true),
                    packaging = table.Column<string>(type: "varchar", nullable: true),
                    brands = table.Column<string>(type: "varchar", nullable: true),
                    imageurl = table.Column<string>(name: "image-url", type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
