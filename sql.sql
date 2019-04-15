create table Members(id int identity(1,1),
					loginid varchar(20) unique,
					rnd varchar(8),
					password varchar(64) not null
					);
create table Products(id int identity(1,1),
					name nvarchar(50) unique not null, 
					price decimal not null,
					pic varchar(20)not null unique,
					Categoly_Id int
					);
					
create table Categories(id int identity(1,1),
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
						
create table Buys(id int identity(1,1),
					UserID int,
					BuyDate DateTime
					);
create table BuyDetails(id int identity(1,1),
						BuyID int,
						ProductID int,
						Price decimal,
						Number int	
					);
insert into Members values(N'“c’†',21,123,'admin','pass');
insert into Products values(N'“÷',300,'meet.png',1);
insert into Categories values(N'ˆù—¿');
drop table categolies;
drop table  __MigrationHistory ;
alter table BuyDetails alter column Number tinyint;
