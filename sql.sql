create table Members(id int identity(1,1),
					Name nvarchar(20),
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
					
create table Articles (id int identity(1,1),
						url nvarchar(100),
						title nvarchar(100),
						description nvarchar(200),
						viewcount int,
						published datetime,
						released bit,
						comments int  );
insert into Members values(N'田中',21,123,'admin','pass');
insert into items values(N'にく',300,'meet.png',1);
insert into cates values(N'食品');
insert into cates values(N'飲料');
insert into Articles()
insert into Comments (name,body,updated,Article_id)values('taro','test',2019/04/04,1);
drop table items
