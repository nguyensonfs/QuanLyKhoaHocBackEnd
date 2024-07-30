using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaHoc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViets_ChuDes_ChuDeID",
                table: "BaiViets");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViets_TaiKhoans_TaiKhoanID",
                table: "BaiViets");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuDes_LoaiBaiViets_LoaiBaiVietID",
                table: "ChuDes");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_HocViens_HocVienID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_KhoaHocs_KhoaHocID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_TaiKhoans_TaiKhoanID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_TinhTrangHocs_TinhTrangHocID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHocs_LoaiKhoaHocs_LoaiKhoaHocID",
                table: "KhoaHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoans_QuyenHans_QuyenHanID",
                table: "TaiKhoans");

            migrationBuilder.AlterColumn<int>(
                name: "QuyenHanID",
                table: "TaiKhoans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianHoc",
                table: "KhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongMon",
                table: "KhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoHocVien",
                table: "KhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiKhoaHocID",
                table: "KhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HocPhi",
                table: "KhoaHocs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "HocViens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocID",
                table: "DangKyHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanID",
                table: "DangKyHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "DangKyHocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "DangKyHocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhoaHocID",
                table: "DangKyHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HocVienID",
                table: "DangKyHocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiBaiVietID",
                table: "ChuDes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianTao",
                table: "BaiViets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanID",
                table: "BaiViets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChuDeID",
                table: "BaiViets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_TaiKhoans_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_TaiKhoanId",
                table: "RefreshTokens",
                column: "TaiKhoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViets_ChuDes_ChuDeID",
                table: "BaiViets",
                column: "ChuDeID",
                principalTable: "ChuDes",
                principalColumn: "ChuDeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViets_TaiKhoans_TaiKhoanID",
                table: "BaiViets",
                column: "TaiKhoanID",
                principalTable: "TaiKhoans",
                principalColumn: "TaiKhoanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChuDes_LoaiBaiViets_LoaiBaiVietID",
                table: "ChuDes",
                column: "LoaiBaiVietID",
                principalTable: "LoaiBaiViets",
                principalColumn: "LoaiBaiVietID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_HocViens_HocVienID",
                table: "DangKyHocs",
                column: "HocVienID",
                principalTable: "HocViens",
                principalColumn: "HocVienID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_KhoaHocs_KhoaHocID",
                table: "DangKyHocs",
                column: "KhoaHocID",
                principalTable: "KhoaHocs",
                principalColumn: "KhoaHocID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_TaiKhoans_TaiKhoanID",
                table: "DangKyHocs",
                column: "TaiKhoanID",
                principalTable: "TaiKhoans",
                principalColumn: "TaiKhoanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_TinhTrangHocs_TinhTrangHocID",
                table: "DangKyHocs",
                column: "TinhTrangHocID",
                principalTable: "TinhTrangHocs",
                principalColumn: "TinhTrangHocID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHocs_LoaiKhoaHocs_LoaiKhoaHocID",
                table: "KhoaHocs",
                column: "LoaiKhoaHocID",
                principalTable: "LoaiKhoaHocs",
                principalColumn: "LoaiKhoaHocID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoans_QuyenHans_QuyenHanID",
                table: "TaiKhoans",
                column: "QuyenHanID",
                principalTable: "QuyenHans",
                principalColumn: "QuyenHanID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViets_ChuDes_ChuDeID",
                table: "BaiViets");

            migrationBuilder.DropForeignKey(
                name: "FK_BaiViets_TaiKhoans_TaiKhoanID",
                table: "BaiViets");

            migrationBuilder.DropForeignKey(
                name: "FK_ChuDes_LoaiBaiViets_LoaiBaiVietID",
                table: "ChuDes");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_HocViens_HocVienID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_KhoaHocs_KhoaHocID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_TaiKhoans_TaiKhoanID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyHocs_TinhTrangHocs_TinhTrangHocID",
                table: "DangKyHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_KhoaHocs_LoaiKhoaHocs_LoaiKhoaHocID",
                table: "KhoaHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoans_QuyenHans_QuyenHanID",
                table: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.AlterColumn<int>(
                name: "QuyenHanID",
                table: "TaiKhoans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianHoc",
                table: "KhoaHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongMon",
                table: "KhoaHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SoHocVien",
                table: "KhoaHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiKhoaHocID",
                table: "KhoaHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "HocPhi",
                table: "KhoaHocs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgaySinh",
                table: "HocViens",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrangHocID",
                table: "DangKyHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanID",
                table: "DangKyHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayKetThuc",
                table: "DangKyHocs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayDangKy",
                table: "DangKyHocs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayBatDau",
                table: "DangKyHocs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "KhoaHocID",
                table: "DangKyHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HocVienID",
                table: "DangKyHocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiBaiVietID",
                table: "ChuDes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianTao",
                table: "BaiViets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "TaiKhoanID",
                table: "BaiViets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChuDeID",
                table: "BaiViets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViets_ChuDes_ChuDeID",
                table: "BaiViets",
                column: "ChuDeID",
                principalTable: "ChuDes",
                principalColumn: "ChuDeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViets_TaiKhoans_TaiKhoanID",
                table: "BaiViets",
                column: "TaiKhoanID",
                principalTable: "TaiKhoans",
                principalColumn: "TaiKhoanID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChuDes_LoaiBaiViets_LoaiBaiVietID",
                table: "ChuDes",
                column: "LoaiBaiVietID",
                principalTable: "LoaiBaiViets",
                principalColumn: "LoaiBaiVietID");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_HocViens_HocVienID",
                table: "DangKyHocs",
                column: "HocVienID",
                principalTable: "HocViens",
                principalColumn: "HocVienID");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_KhoaHocs_KhoaHocID",
                table: "DangKyHocs",
                column: "KhoaHocID",
                principalTable: "KhoaHocs",
                principalColumn: "KhoaHocID");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_TaiKhoans_TaiKhoanID",
                table: "DangKyHocs",
                column: "TaiKhoanID",
                principalTable: "TaiKhoans",
                principalColumn: "TaiKhoanID");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyHocs_TinhTrangHocs_TinhTrangHocID",
                table: "DangKyHocs",
                column: "TinhTrangHocID",
                principalTable: "TinhTrangHocs",
                principalColumn: "TinhTrangHocID");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoaHocs_LoaiKhoaHocs_LoaiKhoaHocID",
                table: "KhoaHocs",
                column: "LoaiKhoaHocID",
                principalTable: "LoaiKhoaHocs",
                principalColumn: "LoaiKhoaHocID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoans_QuyenHans_QuyenHanID",
                table: "TaiKhoans",
                column: "QuyenHanID",
                principalTable: "QuyenHans",
                principalColumn: "QuyenHanID");
        }
    }
}
