Use GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO
-------------------------------------------
CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM ContactInquiries
	DELETE FROM Vehicles
	DELETE FROM Purchases
	DELETE FROM Models
	DELETE FROM Makes
	DELETE FROM CustomerInfo
	DELETE FROM PurchaseTypes
	DELETE FROM AspNetUsers WHERE id IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111');
	DBCC CHECKIDENT ('PurchaseTypes',RESEED,0)
	DBCC CHECKIDENT ('CustomerInfo',RESEED,0)
	DBCC CHECKIDENT ('Makes',RESEED,0)
	DBCC CHECKIDENT ('Models',RESEED,0)
	DBCC CHECKIDENT ('Purchases',RESEED,0)
	DBCC CHECKIDENT ('Vehicles',RESEED,0)
	DBCC CHECKIDENT ('ContactInquiries',RESEED,0)
-------------------------------------------
	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test');

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com',  0, 0, 0, 'test2');
-------------------------------------------
SET IDENTITY_INSERT PurchaseTypes ON;

	INSERT INTO PurchaseTypes(PurchaseTypeId,PurchaseType)
	VALUES (1,'Bank Finance'),
	(2,'Cash'),
	(3,'Dealer Finance')

SET IDENTITY_INSERT PurchaseTypes OFF;
-------------------------------------------
SET IDENTITY_INSERT CustomerInfo ON;

	INSERT INTO CustomerInfo(CustomerInfoId,[Name],Address1,City,[State],Zip,Phone,Email)
	VALUES (1, 'Allison McKinney','123 Guild St.','Akron','Ohio','44444','333-333-3333','allison@guild.net'),
	(2, 'Chris ThreeAlarmTaggart','345 Anywhere Lane','Strongsville','Ohio','44114','777-777-7777','chris3@guild.net'),
	(3, 'James McManus','476 Cedar Rd.','Parkersburg','West Virginia','46478','555-555-5555','jame@guild.net')
	

SET IDENTITY_INSERT CustomerInfo OFF;
-------------------------------------------
SET IDENTITY_INSERT Makes ON;

	INSERT INTO Makes(MakeId,MakeName,DateAdded,UserId)
	VALUES (1, 'Ford',GetDate(),'admin@admin.com'),
	(2, 'Subaru',GetDate(),'admin@admin.com'),
	(3, 'Hyundai',GetDate(),'admin@admin.com')

SET IDENTITY_INSERT Makes OFF;
-------------------------------------------
SET IDENTITY_INSERT Models ON;

	INSERT INTO Models(ModelId,MakeId,ModelName,DateAdded,UserId)
	VALUES (1, 1, 'F-150',GetDate(),'admin@admin.com'),
	(2, 1, 'Focus',GetDate(),'admin@admin.com'),
	(3, 2, 'Forester',GetDate(),'admin@admin.com'),
	(4, 2, 'Outback',GetDate(),'admin@admin.com'),
	(5, 3, 'Tucson',GetDate(),'admin@admin.com'),
	(6, 3, 'Santa Fe',GetDate(),'admin@admin.com')

SET IDENTITY_INSERT Models OFF;
-------------------------------------------
SET IDENTITY_INSERT Purchases ON;

	INSERT INTO Purchases(PurchaseId,PurchaseTypeId,PurchaseDate,UserId,[Message],CustomerInfoId,Price)
	VALUES (1,2,GetDate(),'ac3ece39-adf7-4823-bfc3-3ce5a42e8d0b','VIN Test',1,15000.00),
	(2,2,GetDate(),'ac3ece39-adf7-4823-bfc3-3ce5a42e8d0b','VIN Test2',1,45000.00),
	(3,2,GetDate(),'da38ae12-2d66-4948-bcac-e3c4fa54a4bc','VIN Test3',2,45000.00)

SET IDENTITY_INSERT Purchases OFF;
-------------------------------------------
SET IDENTITY_INSERT Vehicles ON;

	INSERT INTO Vehicles(VehicleId,Price,Vin,ModelId,[Year],IsNew,PurchaseId,Msrp,Color,Interior,Transmission,Mileage,[Description],BodyStyle,PictureFileName,IsFeatured)
	VALUES (1,45000.00,'5NPEB4AC1DH576656',4,'2012',0,1,50000.00,'Blue','Black','Automatic','150,345','Great condition!','SUV','placeholder.png',0),
	(2,55000.00,'2G1WD57C491198247',2,'2017',1,null,60000.00,'Silver','Gray','Automatic','0','Brand spanking new!','Car','placeholder.png',1),
	(3,30000.00,'JH4DB1570LS800098',5,'2016',0,null,35000.00,'Black','Black','Automatic','5,345','ALMOST new!','SUV','placeholder.png',1),
	(4,18000.00,'JTDBT123710161315',6,'2007',0,null,20000.00,'Gray','Gray','Automatic','80,234','Drives well, not a ton of miles!','SUV','placeholder.png',1),
	(5,33000.00,'1NXBR12E31Z463785',3,'2008',0,null,35000.00,'Silver','Black','Automatic','121,235','Pretty good for an older vehicle!','SUV','placeholder.png',1),
	(6,24000.00,'1C4RJFAG8DC537142',2,'2017',1,null,28000.00,'Blue','Gray','Manual','0','New rally car!','Car','placeholder.png',1),
	(7,21000.00,'JH4KA8252NC002110',1,'2017',1,null,25000.00,'Red','Black','Manual','0','New truck!','Truck','placeholder.png',1)

SET IDENTITY_INSERT Vehicles OFF;
-------------------------------------------
SET IDENTITY_INSERT ContactInquiries ON;

	INSERT INTO ContactInquiries(ContactInfoId,[Name],Phone,Email,[Message])
	VALUES (1,'John McEnroe','456-1237890','angrytennis@aol.com','Please call me about the 2012 Outback')

SET IDENTITY_INSERT ContactInquiries OFF;
-------------------------------------------
END