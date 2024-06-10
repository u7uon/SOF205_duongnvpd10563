create database QuanLyBanHang
go
use QuanLyBanHangg

go 
create table NhanVien
(
	ID			int  identity(1,1)		not null ,
	maNV		varchar(20) primary key not null , 
	email		varchar(50)				not null , 
	tenNV		nvarchar(50)			not null , 
	DiaChi		nvarchar(100)			not null , 
	VaiTro		tinyint					not null , 
	TinhTrang	tinyint					not null , 
	MatKhau		nvarchar(50)			not null 
)
create table SanPham (
	maSP	int primary key identity(1,1) not null ,
	TenSP	nvarchar(50)				  not Null,
	SoLuong int							  not null,
	GiaBan	float						  not null ,
	GiaNhap float						 not null,
	HinhAnh varchar(400)                  not null,
	ghiChu nvarchar(50)					not null,
	maNV varchar(20) foreign key references NhanVien(maNV) not null
)
create table KhachHang (
	DienThoai varchar(15) primary key  not null ,
	TenKH	  nvarchar(50)             not null ,
	DiaChi    nvarchar(50)				not null,
	GioiTinh  nvarchar(5)               not null,
	maNV      varchar(20)              not null,
	foreign key (maNV) references NhanVien(maNV) 
)
