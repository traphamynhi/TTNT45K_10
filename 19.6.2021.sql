create database Quanly
use Quanly
----------------------------

create table NguoiDung
(tenND nvarchar(30) not null primary key,
tenDN nvarchar(30) not null,
MatKhau nvarchar(50) not null,
GioiTinh nvarchar (30) not null,
DiaChi nvarchar (30) not null)
-------------------------------------


create table KhoanThu
(MaKT int not null primary key,
TenKT nvarchar (50) not null,
tenND nvarchar(30) not null,
NgayThu datetime not null,
SoTien float  not null,
MoTa nvarchar (50) not null,
constraint fk_NguoiDung foreign key (tenND) references NguoiDung(tenND))

---------------------------------------------------------------------------
create table KhoanChi
(MaKC int not null primary key,
TenKC nvarchar (50) not null,
tenND nvarchar(30) not null,
NgayChi datetime not null,
SoTien float  not null,
MoTa nvarchar (50) not null,
foreign key (tenND) references NGUOIDUNG(tenND))
----------------------------------------------------------------------
insert into NguoiDung
values
('Tra Pham Y Nhi','Nhisss','123','Nu','Da Nang')


insert into KhoanThu
values
(11,'Tien Luong','Tra Pham Y Nhi','2021-02-01',3000,'tien luong thang 2'),
(12,'Tien ba me cho','Tra Pham Y Nhi','2021-01-05',3000,'tien nme cho vao thang 4'),
(13,'Tien lam them','Tra Pham Y Nhi','2021-02-03',2000,'tien lam freelancer 2'),
(14,'Tien ba me cho','Tra Pham Y Nhi','2021-03-01',5000,'tien me chu cap thang 3')


insert into KhoanChi
values
(01,'Tien Sinh Hoat','Tra Pham Y Nhi','2021-05-21',1500,'tien sinh hoat thang 5'),
(02,'Di chuyen','Tra Pham Y Nhi','2021-05-15',1500,'tien di may bay vao SG'),
(03,'Quan ao','Tra Pham Y Nhi','2021-05-15',1500,'tien mua quan ao vao dip Le'),
(04,'Di chuyen','Tra Pham Y Nhi','2021-05-30',900,'tien di choi Vu Tau'),
(05,'Tien Sinh Hoat','Tra Pham Y Nhi','2021-04-26',900,'tien Sinh Nhat ban')
