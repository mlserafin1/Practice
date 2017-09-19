/*
	Get the count of how many employees work for the 
	company
*/

USE Northwind;
GO

SELECT Count(e.EmployeeID) AS [Employee Count]
FROM Employees e