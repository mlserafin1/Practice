USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ContactInquiries')
	DROP TABLE ContactInquiries
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicles')
	DROP TABLE Vehicles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Purchases')
	DROP TABLE Purchases
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Models')
	DROP TABLE Models
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Makes')
	DROP TABLE Makes
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CustomerInfo')
	DROP TABLE CustomerInfo
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseTypes')
	DROP TABLE PurchaseTypes
GO

CREATE TABLE PurchaseTypes(
	PurchaseTypeId int identity(1,1) not null primary key,
	PurchaseType varchar(30) not null
)

CREATE TABLE CustomerInfo(
	CustomerInfoId int identity(1,1) not null primary key,
	[Name] varchar(60) not null,
	Address1 varchar(50) not null,
	Address2 varchar(50) null,
	City varchar(50) not null,
	[State] varchar(20) not null,
	Zip varchar(10) not null,
	Phone varchar(18) null,
	Email varchar(40) null
)

CREATE TABLE Makes(
	MakeId int identity(1,1) not null primary key,
	MakeName varchar(30) not null,
	DateAdded datetime2 null default(getdate()),
	UserId nvarchar(128) null
)

CREATE TABLE Models(
	ModelId int identity(1,1) not null primary key,
	MakeId int not null foreign key references Makes(MakeId),
	ModelName varchar(30) not null,
	DateAdded datetime2 null default(getdate()),
	UserId nvarchar(128) null
)

CREATE TABLE Purchases(
	PurchaseId int identity(1,1) not null primary key,
	PurchaseTypeId int not null foreign key references PurchaseTypes(PurchaseTypeId),
	PurchaseDate datetime2 not null default(getdate()),
	UserId nvarchar(128) not null foreign key references AspNetUsers(Id),
	[Message] varchar(156) null,
	CustomerInfoId int not null foreign key references CustomerInfo(CustomerInfoId),
	Price decimal(8,2) not null
)

CREATE TABLE Vehicles(
	VehicleId int identity(1,1) not null primary key,
	Price decimal(8,2) not null,
	Vin varchar(30) not null,
	ModelId int not null foreign key references Models(ModelId),
	[Year] varchar(4) not null,
	IsNew bit not null,
	PurchaseId int null foreign key references Purchases(PurchaseId),
	Msrp decimal(8,2) not null,
	Color varchar(20) not null,
	Interior varchar(20) not null,
	Transmission varchar(20) not null,
	Mileage varchar(10) not null,
	[Description] varchar(156) not null,
	BodyStyle varchar(20) not null,
	PictureFileName varchar(max) null,
	IsFeatured bit not null
)

CREATE TABLE ContactInquiries(
	ContactInfoId int identity(1,1) not null primary key,
	[Name] varchar(60) not null,
	Phone varchar(18) null,
	Email varchar(40) null,
	[Message] varchar(156) null
)