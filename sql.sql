create table Members(id int identity(1,1),
					Name nvarchar(20),
					Age tinyint,
					rnd tinyint,
					loginid varchar(20) unique,
					password varchar(20) not null);
create table Items(id int identity(1,1),
					name nvarchar(50) unique not null, 
					price decimal not null,
					pic varchar(20)not null unique,
					cate tinyint
					);
					
create table Cates(id int identity(1,1),
					name nvarchar(10) unique not null
					);
insert into Members values(N'田中',21,123,'admin','pass');
insert into items values(N'にく',300,'meet.png',1);
insert into cates values(N'食品');
insert into cates values(N'飲料');
drop table Members
