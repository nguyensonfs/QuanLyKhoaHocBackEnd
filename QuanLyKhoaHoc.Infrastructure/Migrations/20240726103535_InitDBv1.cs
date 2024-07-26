using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoaHoc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDBv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    HocVienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoDienThoai = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    TinhThanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuanHuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhuongXa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoNha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.HocVienID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiBaiViets",
                columns: table => new
                {
                    LoaiBaiVietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBaiViets", x => x.LoaiBaiVietID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhoaHocs",
                columns: table => new
                {
                    LoaiKhoaHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKhoaHocs", x => x.LoaiKhoaHocID);
                });

            migrationBuilder.CreateTable(
                name: "QuyenHans",
                columns: table => new
                {
                    QuyenHanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHans", x => x.QuyenHanID);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangHocs",
                columns: table => new
                {
                    TinhTrangHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangHocs", x => x.TinhTrangHocID);
                });

            migrationBuilder.CreateTable(
                name: "ChuDes",
                columns: table => new
                {
                    ChuDeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiBaiVietID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDes", x => x.ChuDeID);
                    table.ForeignKey(
                        name: "FK_ChuDes_LoaiBaiViets_LoaiBaiVietID",
                        column: x => x.LoaiBaiVietID,
                        principalTable: "LoaiBaiViets",
                        principalColumn: "LoaiBaiVietID");
                });

            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    KhoaHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThoiGianHoc = table.Column<int>(type: "int", nullable: true),
                    GioiThieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HocPhi = table.Column<double>(type: "float", nullable: true),
                    SoHocVien = table.Column<int>(type: "int", nullable: true),
                    SoLuongMon = table.Column<int>(type: "int", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiKhoaHocID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.KhoaHocID);
                    table.ForeignKey(
                        name: "FK_KhoaHocs_LoaiKhoaHocs_LoaiKhoaHocID",
                        column: x => x.LoaiKhoaHocID,
                        principalTable: "LoaiKhoaHocs",
                        principalColumn: "LoaiKhoaHocID");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TenDangNhap = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    QuyenHanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.TaiKhoanID);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_QuyenHans_QuyenHanID",
                        column: x => x.QuyenHanID,
                        principalTable: "QuyenHans",
                        principalColumn: "QuyenHanID");
                });

            migrationBuilder.CreateTable(
                name: "BaiViets",
                columns: table => new
                {
                    BaiVietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiViet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenTacGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungNgan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuDeID = table.Column<int>(type: "int", nullable: true),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViets", x => x.BaiVietID);
                    table.ForeignKey(
                        name: "FK_BaiViets_ChuDes_ChuDeID",
                        column: x => x.ChuDeID,
                        principalTable: "ChuDes",
                        principalColumn: "ChuDeID");
                    table.ForeignKey(
                        name: "FK_BaiViets_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanID");
                });

            migrationBuilder.CreateTable(
                name: "DangKyHocs",
                columns: table => new
                {
                    DangKyHocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHocID = table.Column<int>(type: "int", nullable: true),
                    HocVienID = table.Column<int>(type: "int", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrangHocID = table.Column<int>(type: "int", nullable: true),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyHocs", x => x.DangKyHocID);
                    table.ForeignKey(
                        name: "FK_DangKyHocs_HocViens_HocVienID",
                        column: x => x.HocVienID,
                        principalTable: "HocViens",
                        principalColumn: "HocVienID");
                    table.ForeignKey(
                        name: "FK_DangKyHocs_KhoaHocs_KhoaHocID",
                        column: x => x.KhoaHocID,
                        principalTable: "KhoaHocs",
                        principalColumn: "KhoaHocID");
                    table.ForeignKey(
                        name: "FK_DangKyHocs_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanID");
                    table.ForeignKey(
                        name: "FK_DangKyHocs_TinhTrangHocs_TinhTrangHocID",
                        column: x => x.TinhTrangHocID,
                        principalTable: "TinhTrangHocs",
                        principalColumn: "TinhTrangHocID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViets_ChuDeID",
                table: "BaiViets",
                column: "ChuDeID");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViets_TaiKhoanID",
                table: "BaiViets",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_ChuDes_LoaiBaiVietID",
                table: "ChuDes",
                column: "LoaiBaiVietID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHocs_HocVienID",
                table: "DangKyHocs",
                column: "HocVienID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHocs_KhoaHocID",
                table: "DangKyHocs",
                column: "KhoaHocID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHocs_TaiKhoanID",
                table: "DangKyHocs",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHocs_TinhTrangHocID",
                table: "DangKyHocs",
                column: "TinhTrangHocID");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHocs_LoaiKhoaHocID",
                table: "KhoaHocs",
                column: "LoaiKhoaHocID");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_QuyenHanID",
                table: "TaiKhoans",
                column: "QuyenHanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViets");

            migrationBuilder.DropTable(
                name: "DangKyHocs");

            migrationBuilder.DropTable(
                name: "ChuDes");

            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "KhoaHocs");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "TinhTrangHocs");

            migrationBuilder.DropTable(
                name: "LoaiBaiViets");

            migrationBuilder.DropTable(
                name: "LoaiKhoaHocs");

            migrationBuilder.DropTable(
                name: "QuyenHans");
        }
    }
}
