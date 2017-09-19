/*
	Find the gross total (sum of quantity * unit price) for 
	all orders placed by B's Beverages and Chop-suey Chinese.
*/

USE Northwind;
GO

SELECT SUM(od.Quantity*od.UnitPrice) AS [Gross Total], c.CompanyName
FROM Customers c
	INNER JOIN Orders o
		ON c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od
		ON o.OrderID = od.OrderID
WHERE c.CompanyName LIKE 'B''s Bev%'
	OR c.CompanyName LIKE 'Chop-Suey%'
GROUP BY c.CompanyName;

