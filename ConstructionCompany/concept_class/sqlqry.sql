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


create table teacher(
teacherID bigint primary key identity(1,1),
tea_Name nvarchar(300),
tea_fatherName nvarchar(300),
tea_Gender nvarchar(300),
tea_contactNo bigint,
tea_address nvarchar(300),
tea_cnic bigint,
[Date] nvarchar(300)
--user_idno bigint foreign key references users(users_id)
)
select * from teacher
select max(teacherID)+1 from teacher
--select null(max(teacherID,1)+1 from teacher)
--select NULL(max(teacherID,1)+1 from teacher)
--drop table teacher
--select ISNull (max(teacherID),0)+1 from teacher
