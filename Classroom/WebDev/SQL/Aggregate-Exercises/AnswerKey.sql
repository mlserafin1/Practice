USE Northwind;
GO

-- 1
SELECT AVG(Freight) AS FreightAverage
FROM Orders o	
	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE c.Country = 'USA'

-- 2
SELECT SUM(Quantity * UnitPrice) AS GrossTotal
FROM Orders o	
	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE c.CompanyName IN ('B''s Beverages', 'Chop-suey Chinese')

-- 3
SELECT SUM(Quantity * UnitPrice) AS GrossTotal, CompanyName
FROM Orders o	
	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY CompanyName
ORDER BY GrossTotal DESC

-- 4
SELECT Count(*) as TotalEmployees
FROM Employees

-- 5
SELECT Count(*) as ManagedEmployees
FROM Employees e1 
	INNER JOIN Employees e2 ON e1.EmployeeID = e2.ReportsTo

-- 6
SELECT COUNT(DISTINCT(Country)) as UniqueCountries
FROM Suppliers

-- 7
SELECT SUM(od.Quantity * od.UnitPrice) AS TotalSales, s.CompanyName
FROM Suppliers s
	INNER JOIN Products p ON s.SupplierID = p.ProductID
	INNER JOIN [Order Details] od ON od.ProductID = p.ProductID
GROUP BY CompanyName
ORDER BY TotalSales DESC	

-- 8 
SELECT COUNT(OrderID) as TotalOrders, CompanyName
FROM Orders o 
	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY CompanyName
HAVING COUNT(OrderID) >= 4
ORDER BY TotalOrders

-- 9
SELECT SUM(od.UnitPrice * od.Quantity) as TotalSales, c.Country, 
	DATEPART(yyyy, o.OrderDate) as [Year]
FROM Orders o
	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.Country, DATEPART(yyyy, o.OrderDate)
ORDER BY [Year], TotalSales DESC