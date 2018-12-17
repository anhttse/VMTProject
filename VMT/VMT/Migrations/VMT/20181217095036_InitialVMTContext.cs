using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMT.Migrations.VMT
{
    public partial class InitialVMTContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(maxLength: 100, nullable: true),
                    Ten = table.Column<string>(maxLength: 250, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    GhiChu = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Xe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(maxLength: 100, nullable: true),
                    BienSoXe = table.Column<string>(maxLength: 10, nullable: false),
                    HangXe = table.Column<string>(maxLength: 250, nullable: true),
                    TheTich = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    TheTichThuc = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    GhiChu = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VanChuyen",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(maxLength: 100, nullable: true),
                    HangHoaId = table.Column<int>(nullable: true),
                    HangHoaRef = table.Column<string>(maxLength: 100, nullable: true),
                    XeId = table.Column<int>(nullable: true),
                    XeRef = table.Column<string>(maxLength: 100, nullable: true),
                    BienSoXe = table.Column<string>(maxLength: 10, nullable: false),
                    SoChuyen = table.Column<int>(nullable: false),
                    NgayVanChuyen = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    GhiChu = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanChuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK__VanChuyen__HangHoa",
                        column: x => x.HangHoaId,
                        principalTable: "HangHoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__VanChuyen__Xe",
                        column: x => x.XeId,
                        principalTable: "Xe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VanChuyen_HangHoaId",
                table: "VanChuyen",
                column: "HangHoaId");

            migrationBuilder.CreateIndex(
                name: "IX_VanChuyen_XeId",
                table: "VanChuyen",
                column: "XeId");

            migrationBuilder.CreateIndex(
                name: "UQ__Xe__A78059921A4D5864",
                table: "Xe",
                column: "BienSoXe",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VanChuyen");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "Xe");
        }
    }
}
