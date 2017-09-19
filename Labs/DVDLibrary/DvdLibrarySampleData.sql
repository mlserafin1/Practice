USE DvdLibrary
GO

--------------------------------------------------------------
SET IDENTITY_INSERT Ratings ON;
GO

INSERT INTO Ratings(RatingID, RatingType)
VALUES (1, 'G'),
	   (2, 'PG'),
	   (3, 'PG-13'),
	   (4, 'R')

SET IDENTITY_INSERT Ratings OFF;
GO
--------------------------------------------------------------
SET IDENTITY_INSERT Dvds ON;
GO
 
INSERT INTO Dvds(ID, Title, ReleaseYear, DirectorName, RatingID, RatyingType, Notes)
VALUES (1, 'First Movie', '2017', 'Mel Brooks', 1, 'G', 'The first movie.'),
	   (2, 'Second Movie', '2016', 'Wes Anderson', 2, 'PG', 'The second movie.'),
	   (3, 'Third Movie', '2015', 'Some Other Guy', 3, 'PG-13', 'The third movie.')
 

SET IDENTITY_INSERT Dvds OFF;
GO