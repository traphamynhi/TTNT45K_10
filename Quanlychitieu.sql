create database Quanlychitieu
use Quanlychitieu


create table KhoanChi
(MaKC int not null primary key,
TenKC nvarchar (50) not null,
MoTa nvarchar (50) not null)
create table CTKhoanChi
(MaCTKC int not null primary key,
MaKC int  not null,
MaND char(5) not null,
NgayChi datetime not null,
SoTien float  not null,
MoTa nvarchar (50) not null,
constraint fk_KhoanChi foreign key (MaKC) references KhoanChi(MaKC))


create table KhoanThu
(MaKT int not null primary key, 
TenKT nvarchar (50) not null,
MoTa nvarchar (50) not null)

create table CTKhoanThu
(MaCTKT int not null primary key,
MaKT int not null,
MaND char(5) not null,
NgayChi datetime not null,
SoTien float  not null,
MoTa nvarchar (50) not null,
constraint fk_KhoanThu foreign key (MaKT) references KhoanThu(MaKT)
)

create table NGUOIDUNG
(MaND char(5) not null primary key,
MaCTKT int not null,
MaCTKC int not null,
tenND nvarchar(30) not null,
constraint fk_CTKhoanThu foreign key (MaCTKT) references CTKhoanThu(MaCTKT),
constraint fk_CTKhoanChi foreign key (MaCTKC) references CTKhoanChi(MaCTKC))

insert into KhoanChi
values
(1402,'Di Chuyen','di tu truong ve nha'),
(1403,'Tien Tro','tra cho thang 3'),
(1404,'Tien Nuoc','tra cho thang 4'),
(1405,'An Uong','tien an uong trong ngay le 30/5')
insert into CTKhoanChi
values
(901,1402,'unn','2021-05-21',70,'di tu truong ve nha'),
(902,1403,'un','2021-05-15',2500,'tra cho thang 3'),
(903,1404,'um','2021-05-15',1500,'tra cho thang 4'),
(904,1405,'unm','2021-05-30',900,'tien an uong trong ngay le 30/5')
insert into KhoanThu
values
(123,'tien luong','tien luong thang 1'),
(124,'nha gui len','tien nha gui len thang 1'),
(125,'tien luong','tien luong thang 2'),
(126,'nha gui len','tien nha gui len thang 2')
insert into CTKhoanThu
values
(601,123,'unn','2021-01-01',3000,'tien luong thang 1'),
(602,124,'unn','2021-01-05',3000,'tien nha gui len thang 1'),
(603,125,'unm','2021-02-03',2000,'tien luong thang 2'),
(604,126,'unm','2021-02-01',5000,'tien nha gui len thang 2')
insert into NGUOIDUNG
values
('unn',601,901,'Tra Pham Y Nhi'),
('un',602,902,'Tra Pham Y Nhi'),
('unm',603,903,'Vo Thi Thu Thuy'),
('um',604,904,'Vo Thi Thu Thuy')