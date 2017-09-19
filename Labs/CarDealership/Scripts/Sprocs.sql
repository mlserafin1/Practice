Use GuildCars
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakesSelectAll')
		DROP PROCEDURE MakesSelectAll
GO

CREATE PROCEDURE MakesSelectAll AS
BEGIN
	SELECT MakeId, MakeName, DateAdded, UserId
	FROM Makes
	ORDER BY MakeName;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsSelectAll')
		DROP PROCEDURE ModelsSelectAll
GO

CREATE PROCEDURE ModelsSelectAll AS
BEGIN
	SELECT ModelId, MakeId, ModelName, DateAdded, UserId
	FROM Models;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CustomersSelectAll')
		DROP PROCEDURE CustomersSelectAll
GO

CREATE PROCEDURE CustomersSelectAll AS
BEGIN
	SELECT CustomerInfoId, [Name], Address1, Address2, City, [State], Zip, Phone, Email 
	FROM CustomerInfo;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAllAvailable')
		DROP PROCEDURE VehiclesSelectAllAvailable
GO

CREATE PROCEDURE VehiclesSelectAllAvailable AS
BEGIN
	SELECT v.VehicleId, v.Price, v.Vin, a.MakeName, m.ModelName, v.[Year], v.IsNew, v.PurchaseId, v.Msrp, v.Color, v.Interior, v.Transmission, v.Mileage, v.[Description], v.BodyStyle, v.PictureFileName, v.IsFeatured
	FROM Vehicles v
	INNER JOIN Models m ON v.ModelId = m.ModelId
	INNER JOIN Makes a on m.MakeId = a.MakeId
	WHERE v.PurchaseId IS NULL;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactInquiriesSelectAll')
		DROP PROCEDURE ContactInquiriesSelectAll
GO

CREATE PROCEDURE ContactInquiriesSelectAll AS
BEGIN
	SELECT ContactInfoId, [Name], Phone, Email, [Message]
	FROM ContactInquiries;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AddContactInquiry')
		DROP PROCEDURE AddContactInquiry
GO

CREATE PROCEDURE AddContactInquiry(@Name varchar(60),@Phone varchar(18),@Email varchar(40),@Message varchar(156)) AS
BEGIN
	INSERT INTO ContactInquiries([Name],Phone,Email,[Message])
	VALUES(@Name,@Phone,@Email,@Message)
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchasesSelectAll')
		DROP PROCEDURE PurchasesSelectAll
GO

CREATE PROCEDURE PurchasesSelectAll AS
BEGIN
	SELECT PurchaseId, PurchaseTypeId, PurchaseDate, UserId, [Message], CustomerInfoId, Price
	FROM Purchases;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypesSelectAll')
		DROP PROCEDURE PurchaseTypesSelectAll
GO

CREATE PROCEDURE PurchaseTypesSelectAll AS
BEGIN
	SELECT PurchaseTypeId, PurchaseType
	FROM PurchaseTypes;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetVehicleById')
		DROP PROCEDURE GetVehicleById
GO

CREATE PROCEDURE GetVehicleById(@VehicleId int) AS
BEGIN
	SELECT v.VehicleId, v.Price, v.Vin, a.MakeName, m.ModelName, v.[Year], v.IsNew, v.PurchaseId, v.Msrp, v.Color, v.Interior, v.Transmission, v.Mileage, v.[Description], v.BodyStyle, v.PictureFileName, v.IsFeatured
	FROM Vehicles v
	INNER JOIN Models m ON v.ModelId = m.ModelId
	INNER JOIN Makes a on m.MakeId = a.MakeId
	WHERE v.VehicleId = @VehicleId;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateVehicle')
      DROP PROCEDURE CreateVehicle
GO

CREATE PROCEDURE CreateVehicle (
	@VehicleId int output,
	@Price decimal(8,2),
	@Vin varchar(30),
	@ModelId int,
	@Year varchar(4),
	@IsNew bit,
	@PurchaseId int,
	@Msrp decimal(8,2),
	@Color varchar(20),
	@Interior varchar(20),
	@Transmission varchar(20),
	@Mileage varchar(10),
	@Description varchar(156),
	@BodyStyle varchar(20),
	@PictureFileName varchar(100),
	@IsFeatured bit
) AS
BEGIN
	INSERT INTO Vehicles(Price, Vin, ModelId, [Year], Isnew, PurchaseId, Msrp, Color, Interior, Transmission, Mileage, [Description], BodyStyle, PictureFileName, IsFeatured)
	VALUES (@Price,@Vin,@ModelId,@Year,@IsNew,@PurchaseId,@Msrp,@Color,@Interior,@Transmission,@Mileage,@Description,@BodyStyle,@PictureFileName,@IsFeatured);

	SET @VehicleId = SCOPE_IDENTITY();
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateVehicle')
      DROP PROCEDURE UpdateVehicle
GO

CREATE PROCEDURE UpdateVehicle (
	@VehicleId int,
	@Price decimal(8,2),
	@Vin varchar(30),
	@ModelId int,
	@Year varchar(4),
	@IsNew bit,
	@PurchaseId int,
	@Msrp decimal(8,2),
	@Color varchar(20),
	@Interior varchar(20),
	@Transmission varchar(20),
	@Mileage varchar(10),
	@Description varchar(156),
	@BodyStyle varchar(20),
	@PictureFileName varchar(100),
	@IsFeatured bit
) AS
BEGIN
	UPDATE Vehicles SET 
		Price = @Price,
		Vin = @Vin,
		ModelId = @ModelId,
		[Year] = @Year,
		IsNew = @IsNew,
		PurchaseId = @PurchaseId,
		Msrp = @Msrp,
		Color = @Color,
		Interior = @Interior,
		Transmission = @Transmission,
		Mileage = @Mileage,
		[Description] = @Description,
		BodyStyle = @BodyStyle,
		PictureFileName = @PictureFileName,
		IsFeatured = @IsFeatured
	WHERE VehicleId = @VehicleId
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteVehicle')
      DROP PROCEDURE DeleteVehicle
GO

CREATE PROCEDURE DeleteVehicle (
	@VehicleId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Vehicles WHERE VehicleId = @VehicleId;

	COMMIT TRANSACTION
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateMake')
      DROP PROCEDURE CreateMake
GO

CREATE PROCEDURE CreateMake (
	@MakeName varchar(30),
	@UserId nvarchar(128)
) AS
BEGIN
	INSERT INTO Makes(MakeName,UserId)
	VALUES (@MakeName,@UserId);
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateModel')
      DROP PROCEDURE CreateModel
GO

CREATE PROCEDURE CreateModel (
	@MakeId int,
	@ModelName varchar(30),
	@UserId nvarchar(128)
) AS
BEGIN
	INSERT INTO Models(MakeId,ModelName,UserId)
	VALUES (@MakeId,@ModelName,@UserId);
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'FeaturedVehiclesSelectAll')
		DROP PROCEDURE FeaturedVehiclesSelectAll
GO

CREATE PROCEDURE FeaturedVehiclesSelectAll AS
BEGIN
	SELECT v.VehicleId, v.Price, v.Vin, a.MakeName, m.ModelName, v.[Year], v.IsNew, v.PurchaseId, v.Msrp, v.Color, v.Interior, v.Transmission, v.Mileage, v.[Description], v.BodyStyle, v.PictureFileName, v.IsFeatured
	FROM Vehicles v
	INNER JOIN Models m ON v.ModelId = m.ModelId
	INNER JOIN Makes a on m.MakeId = a.MakeId
	WHERE v.IsFeatured = 1
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAll')
		DROP PROCEDURE VehiclesSelectAll
GO

CREATE PROCEDURE VehiclesSelectAll AS
BEGIN
	SELECT v.VehicleId, v.Price, v.Vin, a.MakeName, m.ModelName, v.[Year], v.IsNew, v.PurchaseId, v.Msrp, v.Color, v.Interior, v.Transmission, v.Mileage, v.[Description], v.BodyStyle, v.PictureFileName, v.IsFeatured
	FROM Vehicles v
	INNER JOIN Models m ON v.ModelId = m.ModelId
	INNER JOIN Makes a on m.MakeId = a.MakeId;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddPurchase')
      DROP PROCEDURE AddPurchase
GO

CREATE PROCEDURE AddPurchase (
	@PurchaseId int output,
	@PurchaseTypeId int,
	@UserId nvarchar(128),
	@Message varchar(156),
	@CustomerInfoId int,
	@Price decimal (8,2)
) AS
BEGIN
	INSERT INTO Purchases(PurchaseTypeId,UserId,[Message],CustomerInfoId,Price)
	VALUES (@PurchaseTypeId,@UserId,@Message,@CustomerInfoId,@Price);

	SET @PurchaseId = SCOPE_IDENTITY();
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddCustomerInfo')
      DROP PROCEDURE AddCustomerInfo
GO

CREATE PROCEDURE AddCustomerInfo (
	@CustomerInfoId int output,
	@Name varchar(60),
	@Address1 varchar(50),
	@Address2 varchar(50),
	@City varchar(50),
	@State varchar(20),
	@Zip varchar(10),
	@Phone varchar(18),
	@Email varchar(40)
) AS
BEGIN
	INSERT INTO CustomerInfo([Name],Address1,Address2,City,[State],Zip,Phone,Email)
	VALUES (@Name,@Address1,@Address2,@City,@State,@Zip,@Phone,@Email);

	SET @CustomerInfoId = SCOPE_IDENTITY();
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetRawVehicleById')
		DROP PROCEDURE GetRawVehicleById
GO

CREATE PROCEDURE GetRawVehicleById(@VehicleId int) AS
BEGIN
	SELECT *
	FROM Vehicles 
	WHERE VehicleId = @VehicleId;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetModelByMakeId')
		DROP PROCEDURE GetModelByMakeId
GO

CREATE PROCEDURE GetModelByMakeId(@MakeId int) AS
BEGIN
	SELECT *
	FROM Models
	WHERE MakeId = @MakeId;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetModelsAndMakes')
		DROP PROCEDURE GetModelsAndMakes
GO

CREATE PROCEDURE GetModelsAndMakes AS
BEGIN
	SELECT ma.MakeName, mo.ModelName, mo.DateAdded, mo.UserId
	FROM Models mo
	INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
	ORDER BY ma.MakeName;
END
GO
-------------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetMakeIdByModelId')
		DROP PROCEDURE GetMakeIdByModelId
GO

CREATE PROCEDURE GetMakeIdByModelId(@ModelId int) AS
BEGIN
	SELECT m.MakeId
	FROM Models m
	WHERE m.ModelId = @ModelId;
END
GO
-------------------------------------------