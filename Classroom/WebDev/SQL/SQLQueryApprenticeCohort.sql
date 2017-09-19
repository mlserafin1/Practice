USE master;
GO

CREATE DATABASE SGRoster;
GO

USE SGRoster;
GO

CREATE TABLE Cohorts(
CohortID INT IDENTITY(1,1) PRIMARY KEY,
StartDate DATE NOT NULL,
[Subject] varchar(30) NOT NULL,
[Location] varchar(30) NOT NULL,
IsActive BIT NOT NULL DEFAULT(1)
)
GO

CREATE TABLE Apprentices(
ApprenticeID INT IDENTITY(1,1) PRIMARY KEY,
FirstName varchar(30) NOT NULL,
LastName varchar(30) NOT NULL,
CohortID INT FOREIGN KEY REFERENCES Cohorts(CohortID) NOT NULL
)
GO