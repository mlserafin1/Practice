/*
   Select the orders shipping to the USA whose freight is 
   between $10 and $20
*/

USE Northwind;
GO

SELECT *
FROM Orders
WHERE Freight BETWEEN 10 AND 20
AND ShipCountry = 'USA';