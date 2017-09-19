/*
	Get the Company Name, Order Date, and each order detail’s 
	Product name for USA customers only.
*/

USE Northwind;
GO

SELECT c.CompanyName, o.OrderDate,p.ProductName
FROM Customers c
	INNER JOIN Orders o
		ON c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od
		ON o.OrderID = od.OrderID
	INNER JOIN Products p
		ON od.ProductID = p.ProductID
	WHERE c.Country = 'USA';