use QuanLyBanHangg 
go 

--đăng nhập
create proc DangNhap
@email varchar(50) , @MatKhau varchar(50) 
as 
begin 
declare @check int
	if exists (select * from NhanVien where email = @email and MatKhau = @MatKhau)
		set @check = 1
	else
		set @check = 0
	select @check
end

---KHôi phục quên mật khẩu 
create proc setNewpass 
@email varchar(50) ,
@pass varchar(50) 
as 
begin 
	update NhanVien set MatKhau =@pass where email = @email
end

create proc LayVaiTro 
	@Email varchar(50) 
as
begin
	Select Vaitro from NhanVien where email = @Email
end


--Kiểm tra email có tồn tại không 
create proc checkEmail 
@email varchar(50) 
as begin
	declare @check int 
	if exists (select MaNV from NhanVien where email =@email ) 
		set @check = 1 
	 else 
		set @check =0 
 select @check 
end

-- Đổi mật khẩu
create proc DoiMatKhau 
	@email varchar(50),
	@MatKhauCu varchar(50) ,
	@MatKhauMoi varchar(50) 
as 
begin 
	declare @matKhau  varchar(50) 
	select @matKhau = MatKhau from NhanVien where email = @email
	if ( @matKhau = @MatKhauCu ) 
		begin 
			update NhanVien set MatKhau = @MatKhauMoi where email = @email
			return 1
		end
	else 
		return 0 
end

-- Tải data sản phẩm lên
alter proc LoadSanPham 
as
begin 
	select maSP , TenSP , SoLuong ,
	GiaBan ,GiaNhap , ghiChu , maNV  from SanPham
end 


---Xóa một sản phẩm
create proc delete_SP
@maSP int 
as
begin 
declare @check int 
	if exists( select * from SanPham where maSP = @maSP ) 
	 begin 
		delete from SanPham where maSP = @maSP
		set @check = 1
	 end
	 else 
	  set @check =0
select @check
end

---Thêm Sản phẩm 
create proc insert_SP 
@TenHang nvarchar(50) , @SoLuong int , @Giaban float  ,@GiaNhap float , @HinhAnh varchar(400) ,@GhiChu nvarchar(50) ,@email varchar(50) 
as
begin 
	declare @maNV varchar(20) 
	select @maNV  = MaNV from NhanVien where email= @email
	insert into SanPham values (@TenHang,@SoLuong,@Giaban ,@GiaNhap,@HinhAnh ,@GhiChu ,@maNV)
end 

--Cập nhật sản phẩm 
create proc update_SP 
 @maSP int , @tenSp nvarchar(50) , @soLuong int  , @giaBan float , @giaNhap float ,@hinhAnh varchar(400) ,@ghiChu nvarchar(50) 
as
begin
	update SanPham   set TenSP =@tenSp ,SoLuong = @soLuong , GiaBan = @giaBan ,GiaNhap =@giaNhap , HinhAnh = @hinhAnh , ghiChu =@ghiChu 
	where maSP = @maSP 
end 

--tìm kiếm  sản phẩm 
create proc search_SP 
@tenSP nvarchar(50) 
as
begin 
select * from SanPham where TenSP like '%' + @tenSp + '%'
end 

create proc getImg 
@maSp int 
as
begin 
	declare @imgAdress varchar(400) 
	select @imgAdress = Hinhanh from SanPham where maSP = @maSp
select @imgAdress
end 


--Thêm Nhân viên 
alter proc insert_NV 
	@email varchar(50) ,
	@ten nvarchar(50) ,
	@diaChi nvarchar(400) ,
	@vaiTro tinyint ,
	@Tinhtrang tinyint ,
	@MatKhau varchar(50) 
as 
begin
	Declare @Manv varchar(20) 
	declare @Id int 
	select @Id = ISNULL(Max(Id),1000) +1 from NhanVien
	select @Manv = 'NV' + convert(varchar(20) , @Id ) 

	insert into NhanVien values ( @Manv , @email , @ten , @diaChi , @vaiTro , @Tinhtrang , @MatKhau  )
end

create proc delete_NV 
	@email varchar(50) 
as
begin
	declare @status int =1 ; 
	if exists(select * from NhanVien where email= @email ) 
	delete NhanVien where Email = @email
	else
	set @status = 0 
select @status
end

create proc update_NV 
	@email varchar(50) ,
	@tennv nvarchar(50) ,
	@diaChi nvarchar(50) ,
	@vaiTro tinyint ,
	@tinhTrang tinyint 
as
begin
	update NhanVien set TenNV = @tennv , DiaChi = @diaChi , VaiTro = @vaiTro ,TinhTrang =@tinhTrang 
	where email = @email
end

create proc Load_NV 
as
begin 
	select  email ,tenNV , DiaChi , VaiTro ,TinhTrang  from  NhanVien
end 


create proc search_NV 
	@tenNV nvarchar(50) 
as
begin
	select email , Tennv , Diachi , vaitro , tinhtrang from NhanVien where tenNV like '%' + @tenNV  + '%'
end



create proc insert_KH 
	@Dienthoai varchar(15) ,
	@Ten nvarchar(50) ,
	@DiaChi nvarchar(50) ,
	@GioiTinh nvarchar(5),
	@email varchar(50) 
as
begin 
	declare @MaNV varchar(20) 
	select @MaNV = manv from NhanVien where Email = @email
	Insert into  KhachHang values (@Dienthoai , @Ten , @DiaChi,@GioiTinh,@MaNV) 
end



create proc update_KH
	@Dienthoai varchar(15) ,
	@Ten nvarchar(50) ,
	@DiaChi nvarchar(50) ,
	@GioiTinh nvarchar(5)
as
begin
	Update KhachHang set TenKH = @Ten , DiaChi = @DiaChi , GioiTinh =@GioiTinh
	where DienThoai = @Dienthoai 

end 

create proc delete_KH @DienThoai varchar(15) 
as 
begin	
	declare @result int =1 ;
	if exists (select * from KhachHang where DienThoai = @DienThoai)
		Delete KhachHang where DienThoai = @DienThoai
		else 
		 set @result = 0
select @result
end

create proc search @ten nvarchar(50) 
as
begin 
	select * from KhachHang where TenKH like '%' + @ten + '%'
end


create proc Load_KH 
as 
begin
	select * from KhachHang
end