create database Messenger_Data
use Messenger_Data
create table Account
(
	Id int primary key identity(1,1),
	Login varchar(max) not null,
	Password nvarchar(max) not null,
	Name nvarchar(max) not null,
	Email varchar(max) not null,
	Image image not null 
)
select * from Account
create table Message
(
	Id int primary key identity(1,1),
	DeliverId int foreign key references Account(Id),
	Content nvarchar(max) not null,
	Data datetime not null
)

create table Contacts
(
	Id int primary key identity(1,1),
	OwnerId int foreign key references Account(Id),
	ContactId int foreign key references Account(Id)
)

create table Chat
(
	Id int primary key identity(1,1),
	Participants nvarchar(max),
	MessageId int foreign key references Message(Id),
)