/*
	Find the average freight paid for orders 
	placed by companies in the USA
*/

USE Northwind;
GO

SELECT AVG(o.Freight) AS [Freight Average]
FROM Customers c
	INNER JOIN Orders o
		ON c.CustomerID = o.CustomerID
WHERE c.Country = 'USA'
