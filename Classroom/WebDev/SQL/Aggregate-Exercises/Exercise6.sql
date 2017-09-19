/*
	Get the count of how many unique countries
	are represented by our suppliers.
*/

USE Northwind;
GO

SELECT Count(Distinct s.Country) AS Country
FROM Suppliers s

