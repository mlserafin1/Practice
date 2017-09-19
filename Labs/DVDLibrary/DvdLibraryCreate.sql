SET NOCOUNT ON
GO

USE master
GO

if exists (select * from sysdatabases where name='DvdLibrary')
		drop database DvdLibrary

GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE DvdLibrary
  ON PRIMARY (NAME = N''DvdLibrary'', FILENAME = N''' + @device_directory + N'dvdlibra.mdf'')
  LOG ON (NAME = N''DvdLibrary_log'',  FILENAME = N''' + @device_directory + N'dvdlibra.ldf'')')
GO

--exec sp_dboption 'DvdLibrary','trunc. log on chkpt.','true'
--exec sp_dboption 'DvdLibrary','select into/bulkcopy','true'
GO


/* Set DATEFORMAT so that the date strings are interpreted correctly regardless of
   the default DATEFORMAT on the server.
*/
SET DATEFORMAT mdy
GO

USE DvdLibrary
GO

CREATE TABLE Ratings(
	RatingID INT PRIMARY KEY IDENTITY(1,1),
	RatingType VARCHAR(10) NOT NULL
)
GO

CREATE TABLE Dvds(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(50) NOT NULL,
	ReleaseYear VARCHAR(50) NULL,
	DirectorName VARCHAR(50) NULL,
	RatingID INT NOT NULL FOREIGN KEY REFERENCES Ratings(RatingID),
	RatingType VARCHAR(20) NULL,
	Notes VARCHAR(MAX) NULL
)
GO