create table Members(id int identity(1,1),
					Name varchar(20),
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
					
insert into Members values('tanaka',21,123,'admin','pass');
insert into items values(N'‚É‚­',300,'meet.png',1);
drop table items
