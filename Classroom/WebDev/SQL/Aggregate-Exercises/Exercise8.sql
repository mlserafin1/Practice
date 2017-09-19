/*
	Show the number of orders placed by customers 
	from fewest to most provided the customer has 
	a minimum of 4 orders.
*/

USE Northwind;
GO

SELECT Count(o.CustomerID) AS [# of Customer Orders], o.CustomerID
FROM Orders o

Group By o.CustomerID
HAVING Count(o.CustomerID) > 4
Order By [# of Customer Orders]