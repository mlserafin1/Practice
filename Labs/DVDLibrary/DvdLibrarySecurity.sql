USE master
GO
 
CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DvdLibrary
GO
 
CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON CreateDvd TO DvdLibraryApp
GRANT EXECUTE ON DeleteDvd TO DvdLibraryApp
GRANT EXECUTE ON GetDvdById TO DvdLibraryApp
GRANT EXECUTE ON SearchForDirector TO DvdLibraryApp
GRANT EXECUTE ON SearchForRating TO DvdLibraryApp
GRANT EXECUTE ON SearchForTitle TO DvdLibraryApp
GRANT EXECUTE ON SearchForYear TO DvdLibraryApp
GRANT EXECUTE ON SelectAllDvds TO DvdLibraryApp
GRANT EXECUTE ON UpdateDvd TO DvdLibraryApp
GO

GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GO

GRANT SELECT ON Ratings TO DvdLibraryApp
GRANT INSERT ON Ratings TO DvdLibraryApp
GRANT UPDATE ON Ratings TO DvdLibraryApp
GRANT DELETE ON Ratings TO DvdLibraryApp
GO