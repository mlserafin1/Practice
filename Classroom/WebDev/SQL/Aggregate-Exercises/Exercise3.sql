/*
	Find the gross total of all orders (sum of quantity * unit price) 
	for each customer, order it in descending order by the total.
*/

USE Northwind;
GO

SELECT Sum(od.Quantity * od.UnitPrice) AS Gross, c.CompanyName
FROM Orders o
	INNER JOIN [Order Details] od
		ON o.OrderID = od.OrderID
	INNER JOIN Customers c
		ON o.CustomerID = c.CustomerID
Group By c.CompanyName
Order By Gross
