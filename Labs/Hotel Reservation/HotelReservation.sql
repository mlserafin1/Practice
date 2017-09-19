SET NOCOUNT ON
GO

USE master
GO

if exists (select * from sysdatabases where name='HotelReservation')
		drop database HotelReservation

GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE HotelReservation
  ON PRIMARY (NAME = N''HotelReservation'', FILENAME = N''' + @device_directory + N'hotelres.mdf'')
  LOG ON (NAME = N''HotelReservation_log'',  FILENAME = N''' + @device_directory + N'hotelres.ldf'')')
GO

--exec sp_dboption 'HotelReservation','trunc. log on chkpt.','true'
--exec sp_dboption 'HotelReservation','select into/bulkcopy','true'
GO


/* Set DATEFORMAT so that the date strings are interpreted correctly regardless of
   the default DATEFORMAT on the server.
*/
SET DATEFORMAT mdy
GO

USE HotelReservation
GO

CREATE TABLE RoomTypes(
	RoomTypeID INT PRIMARY KEY IDENTITY(1,1),
	TypeName VARCHAR(10) NOT NULL
)
GO

CREATE TABLE Rooms(
	RoomNumberID INT PRIMARY KEY IDENTITY(1,1),
	[Floor] INT NOT NULL,
	OccupancyLimit INT NOT NULL,
	RoomTypeID INT NOT NULL FOREIGN KEY REFERENCES RoomTypes(RoomTypeID)
)
GO

CREATE TABLE Amenities(
	AmenityID INT PRIMARY KEY IDENTITY(1,1),
	AmenityName VARCHAR(30) NOT NULL
)
GO

CREATE TABLE RoomAmenities(

	RoomNumberID INT,
	AmenityID INT,
	
  CONSTRAINT RoomAmenityID PRIMARY KEY (RoomNumberID, AmenityID),
  CONSTRAINT FK_RoomNumberID 
      FOREIGN KEY (RoomNumberID) REFERENCES Rooms (RoomNumberID),
  CONSTRAINT FK_TalentID 
      FOREIGN KEY (AmenityID) REFERENCES Amenities (AmenityID)
)
GO

CREATE TABLE AddOns(
	AddOnId INT PRIMARY KEY IDENTITY(1,1),
	AddOnType VARCHAR(30) NOT NULL,
	AddOnRate VARCHAR(30) NOT NULL
)
GO

CREATE TABLE RoomRates(
	RoomRateId INT PRIMARY KEY IDENTITY(1,1),
	RoomNumberID INT NOT NULL FOREIGN KEY REFERENCES Rooms(RoomNumberID),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	Rate DECIMAL NOT NULL
)
GO

CREATE TABLE RoomRateAddOns(
	
	RoomRateID INT,
	AddOnID INT,

	CONSTRAINT RoomRateAddOnID PRIMARY KEY (RoomRateID, AddOnID),
	CONSTRAINT FK_RoomRateID 
      FOREIGN KEY (RoomRateID) REFERENCES RoomRates (RoomRateID),
	CONSTRAINT FK_AddOnID 
      FOREIGN KEY (AddOnID) REFERENCES AddOns (AddOnID)
)
GO

CREATE TABLE Billing(
	BillingID INT PRIMARY KEY IDENTITY(1,1),
	RoomRateID INT NOT NULL FOREIGN KEY REFERENCES RoomRates(RoomRateID),
	Tax DECIMAL NOT NULL,
	Total DECIMAL NOT NULL
)
GO

CREATE TABLE Promos(
	PromoID INT PRIMARY KEY IDENTITY(1,1),
	PromoRate DECIMAL NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL
)
GO

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(30) NOT NULL,
	Phone VARCHAR(15) NOT NULL,
	Email VARCHAR(30) NOT NULL
)
GO

CREATE TABLE Guests(
	GuestID INT PRIMARY KEY IDENTITY(1,1),
	GuestAge INT NOT NULL,
	GuestName VARCHAR(30) NOT NULL,
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
)
GO

CREATE TABLE Reservations(
	ReservationID INT PRIMARY KEY IDENTITY(1,1),
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
	CheckInDate DATE NOT NULL,
	CheckOutDate DATE NULL,
	BillingID INT NOT NULL FOREIGN KEY REFERENCES Billing(BillingID),
	PromoID INT NOT NULL FOREIGN KEY REFERENCES Promos(PromoID)
)
GO

CREATE TABLE ReservationRoomRate(

	RoomRateID INT,
	ReservationID INT,

	CONSTRAINT ReservationRoomRateID PRIMARY KEY (RoomRateID, ReservationID),
	CONSTRAINT FKRoom_RateID 
      FOREIGN KEY (RoomRateID) REFERENCES RoomRates (RoomRateID),
	CONSTRAINT FK_ReservationID 
      FOREIGN KEY (ReservationID) REFERENCES Reservations (ReservationID)
)
GO