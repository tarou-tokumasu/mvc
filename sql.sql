create table Members(id int identity(1,1),
					loginid varchar(20) unique,
					rnd varchar(8),
					password varchar(64) not null
					);
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
insert into Members values(N'“c’†',21,123,'admin','pass');
insert into items values(N'‚É‚­',300,'meet.png',1);
insert into cates values(N'H•i');
insert into cates values(N'ˆù—¿');
drop table members;
drop table  __MigrationHistory ;
