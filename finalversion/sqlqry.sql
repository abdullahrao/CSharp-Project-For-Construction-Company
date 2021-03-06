create database constructionCompany

go

use constructionCompany

 

go

create table users(
users_id bigint primary key identity(1,1),
Users_name nvarchar(300) not null,
Users_pass nvarchar(300) not null,
Field2 nvarchar(300) not null,
users_contactNO nvarchar(300),
users_address nvarchar(300),
users_status nvarchar(300),
users_cnic nvarchar(300),
FirstLogin bit,
InvalidAttamp int,
IvalidCount int,
IsStatus varchar(5),
check(users_status in ('P','A')),
users_right nvarchar(300),
check(users_right in('Admin','User','Block'))
)
insert into users values('admin','202cb962ac59075b964b07152d234b70','b59ca92ab517193a2b3c9d7aac65d853',03337062481,'Mailr City Karachi','P',4237925711497,1,3,0,'A','Admin')
select * from users

--update users set FirstLogin=1, IsStatus='A' where users_id =3
--update users set IvalidCount = IvalidCount+1 where IsStatus ='A' and Users_name
--update users set IvalidCount=0 where users_id =1  

go



create table login_Time(
login_Time_id bigint primary key identity(1,1),
login_Time_user_name nvarchar(300),
login_time datetime,
Logout_time datetime
)
select * from login_Time


go


--create table teacher(
--teacherID bigint primary key identity(1,1),
--tea_Name nvarchar(300),
--tea_fatherName nvarchar(300),
--tea_Gender nvarchar(300),
--tea_contactNo bigint,
--tea_address nvarchar(300),
--tea_cnic bigint,
--[Date] nvarchar(300)
--user_idno bigint foreign key references users(users_id)
--)
--select * from teacher
--select max(teacherID)+1 from teacher
--select null(max(teacherID,1)+1 from teacher)
--select NULL(max(teacherID,1)+1 from teacher)
--drop table teacher
--select ISNull (max(teacherID),0)+1 from teacher


go

create table tbl_customer(
cust_ID bigint primary key identity(1,1),
cust_Name nvarchar(300),
cust_email nvarchar(300),
cust_contactno bigint,
cust_address nvarchar(300),
cust_cnic bigint,
cust_gender nvarchar(300),
[Date] nvarchar(300)
)


select * from tbl_customer

go

create table tbl_villa(
villa_ID bigint primary key identity(1,1),
villa_Name nvarchar(300),
villa_address nvarchar(300),
villa_code nvarchar(300),
villa_desc nvarchar(300),
cust_name nvarchar(300),
)
ALTER TABLE tbl_villa
ALTER COLUMN vill_bud bigint;



select * from tbl_villa

--insert into tbl_villa values('B','malir','2341','mkc','bc',2300)
--insert into tbl_villa values('BC','malir','2341','mkc','bc',2500)
--select * from tbl_villa

--delete from tbl_villa where villa_ID='1'

go

create table tbl_staff(
staff_ID bigint primary key identity(1,1),
staff_Name nvarchar(300),
staff_address nvarchar(300),
staff_cnic bigint,
staff_contactno bigint,
staff_position nvarchar(300),
)
--insert into tbl_staff values('abcs','malir',644,65466,'msdnj')
--select * from tbl_staff

go

create table tbl_contractor(
con_ID bigint primary key identity(1,1),
con_Name nvarchar(300),
con_email nvarchar(300),
con_address nvarchar(300),
con_postalcode bigint,
con_cnic bigint,
con_contactno bigint,
con_base_fair int,
)

--select * from tbl_contractor


create table tbl_store(
store_ID bigint primary key identity(1,1),
item_Name nvarchar(300),
item_unit nvarchar(300),
item_quantity decimal,
item_rate decimal,
item_grossamount bigint,
item_discount decimal,
item_tax decimal,
item_totalamount bigint,
item_deb_cred nvarchar(300),
item_credit nvarchar(300),
item_debit nvarchar(300),
item_remarks nvarchar(300),
item_con_ret nvarchar(300),
item_company_name nvarchar(300),
)
--use constructionCompany

--select * from tbl_store

create table tbl_contract(
contrac_ID bigint primary key identity(1,1),
contrac_Name nvarchar(300),
contrac_quantity decimal,
contrac_unit nvarchar(300),
contrac_unit_quantity decimal,
contrac_amount decimal,
contrac_remarks nvarchar(300)
)
--insert into tbl_contract values('abc',87,'87',89,900,'fffff')
/*select * from tbl_contract

SELECT SUM(contrac_amount) AS TotalAmount FROM tbl_contract
              
use constructionCompany
*/

create table tbl_genexpense(
gen_ID bigint primary key identity(1,1),
gen_Name nvarchar(300),
gen_quantity decimal,
gen_unit nvarchar(300),
gen_unit_quantity decimal,
gen_amount decimal,
gen_remarks nvarchar(300)
)

--select * from tbl_genexpense

--use constructionCompany

create table tbl_miscexpense(
misc_ID bigint primary key identity(1,1),
misc_Name nvarchar(300),
misc_quantity decimal,
misc_unit nvarchar(300),
misc_unit_quantity decimal,
misc_amount decimal,
misc_remarks nvarchar(300)
)

--use Constructioncompany

create table tbl_villaMat(
vmat_ID bigint primary key identity(1,1),
vil_id bigint FOREIGN KEY REFERENCES tbl_villa(villa_ID),
item_id bigint FOREIGN KEY REFERENCES tbl_store(store_ID),
vmat_quantity decimal,
vmat_rate decimal,
vmat_amount decimal
)

/*select * from tbl_villaMat

SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,vmat_quantity,vmat_rate,vmat_amount
FROM tbl_villaMat 
INNER JOIN tbl_villa 
ON tbl_villaMat.vil_id =tbl_villa.villa_ID 
INNER JOIN tbl_store ON tbl_villaMat.item_id =tbl_store.store_ID ;

select * from tbl_villaMat

select * from tbl_villa

select * from tbl_store



--i am using this query to ensure that desired quantity available or not
Select 
sum(item_quantity) as TotalQuantityInHand
From tbl_store
Where store_ID = 3
and item_quantity >= 5
group by store_ID;

SELECT tbl_store.item_quantity as InventoryQuantity
FROM tbl_villaMat 
INNER JOIN tbl_store ON tbl_villaMat.item_id =tbl_store.store_ID 


update tbl_store set item_quantity=3 where store_ID = (select tbl_villaMat.item_id from tbl_villaMat INNER JOIN tbl_store ON tbl_villaMat.item_id =tbl_store.store_ID)

select * from tbl_store

SELECT tbl_store.item_totalamount as ItemAmount
FROM tbl_villaMat 
INNER JOIN tbl_store ON tbl_villaMat.item_id =tbl_store.store_ID 


SELECT tbl_store.item_rate as ItemRate
FROM tbl_villaMat 
INNER JOIN tbl_store ON tbl_villaMat.item_id =tbl_store.store_ID 


select * from tbl_villaMat
*/
create table tbl_bound(
bound_ID bigint primary key identity(1,1),
vil_id bigint FOREIGN KEY REFERENCES tbl_villa(villa_ID),
item_id bigint FOREIGN KEY REFERENCES tbl_store(store_ID),
bound_quantity decimal,
bound_rate decimal,
bound_amount decimal
)

/*use constructionCompany

SELECT SUM(misc_amount) AS TotalAmount FROM tbl_miscexpense


SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,bound_quantity,bound_rate,bound_amount FROM tbl_bound INNER JOIN tbl_villa ON tbl_bound.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_bound.item_id = tbl_store.store_ID;

SELECT tbl_villa.villa_Name,tbl_store.item_Name,tbl_store.item_quantity as InventoryQuantity,vmat_quantity,vmat_rate,vmat_amount FROM tbl_villaMat INNER JOIN tbl_villa ON tbl_villaMat.vil_id = tbl_villa.villa_ID INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID

SELECT tbl_store.item_totalamount as ItemAmount FROM tbl_villaMat INNER JOIN tbl_store ON tbl_villaMat.item_id = tbl_store.store_ID

select * from tbl_villaMat

select * from tbl_store

select * from tbl_villa

select * from tbl_genexpense*/

select * from tbl_contract

create table tbl_bill(
bill_ID bigint primary key identity(1,1),
cont_Name nvarchar(300),
cont_quantity decimal,
cont_unit nvarchar(300),
cont_unit_quantity decimal,
cont_amount decimal,
cont_remarks nvarchar(300)
)
