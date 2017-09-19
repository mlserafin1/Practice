/*
	Write a query to show every combination of employee and location.
*/

USE SWCCorp;
GO

SELECT e.FirstName, e.LastName, l.city
FROM Employee e
	CROSS JOIN [Location] l