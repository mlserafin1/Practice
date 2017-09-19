USE DvdLibrary
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllDvds')
BEGIN
   DROP PROCEDURE SelectAllDvds
END
GO

CREATE PROCEDURE SelectAllDvds
AS
 
SELECT d.Id, d.Title, d.ReleaseYear, d.DirectorName, r.RatingType, d.Notes 
FROM Dvds d
	LEFT JOIN Ratings r ON d.RatingID = r.RatingID
ORDER BY d.Id
 
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetDvdById')
BEGIN
   DROP PROCEDURE GetDvdById
END
GO
 
CREATE PROCEDURE GetDvdById (
    @Id int
)
AS
    SELECT d.ID, d.Title, d.ReleaseYear, d.DirectorName, r.RatingType, d.Notes 
	FROM Dvds d
	LEFT JOIN Ratings r ON d.RatingID = r.RatingID
    WHERE d.ID = @Id
	ORDER BY ID
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateDvd')
BEGIN
   DROP PROCEDURE UpdateDvd
END
GO
 
CREATE PROCEDURE UpdateDvd (
    @Id int, @Title varchar(50), @ReleaseYear varchar(50), @DirectorName varchar(50), @RatingID int, @Notes varchar(max)
)
AS
    Update Dvds
	 Set Title = @Title,ReleaseYear = @ReleaseYear,DirectorName = @DirectorName,RatingID = @RatingID,Notes = @Notes 
	 WHERE ID = @Id
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteDvd')
BEGIN
   DROP PROCEDURE DeleteDvd
END
GO

CREATE PROCEDURE DeleteDvd (
	@Id int
)
AS
 
DELETE FROM Dvds WHERE ID = @Id
 
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateDvd')
BEGIN
   DROP PROCEDURE CreateDvd
END
GO

CREATE PROCEDURE CreateDvd (
	@Title varchar(50), @ReleaseYear varchar(50), @DirectorName varchar(50), @RatingID int, @Notes varchar(max)
)
AS
 
INSERT INTO Dvds (Title, ReleaseYear, DirectorName, RatingID, Notes) 
Values(@Title,@ReleaseYear,@DirectorName,@RatingId,@Notes)
 
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchForDirector')
BEGIN
   DROP PROCEDURE SearchForDirector
END
GO

CREATE PROCEDURE SearchForDirector (
	@DirectorName nvarchar(max)
)
AS
 
SELECT d.ID, d.Title, d.ReleaseYear, d.DirectorName, r.RatingType, d.Notes 
	FROM Dvds d
	LEFT JOIN Ratings r ON d.RatingID = r.RatingID
    Where d.DirectorName like '%'+@DirectorName+'%'
	ORDER BY ID
 
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchForRating')
BEGIN
   DROP PROCEDURE SearchForRating
END
GO

CREATE PROCEDURE SearchForRating (
	@RatingType nvarchar(max)
)
AS
 
SELECT d.ID, d.Title, d.ReleaseYear, d.DirectorName, r.RatingType, d.Notes 
	FROM Dvds d
	LEFT JOIN Ratings r ON d.RatingID = r.RatingID
    Where r.RatingType like @RatingType
	ORDER BY ID
 
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchForYear')
BEGIN
   DROP PROCEDURE SearchForYear
END
GO

CREATE PROCEDURE SearchForYear (
	@ReleaseYear nvarchar(max)
)
AS
 
SELECT d.ID, d.Title, d.ReleaseYear, d.DirectorName, r.RatingType, d.Notes 
	FROM Dvds d
	LEFT JOIN Ratings r ON d.RatingID = r.RatingID
    Where d.ReleaseYear like '%'+@ReleaseYear+'%'
	ORDER BY ID
 
GO

