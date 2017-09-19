/*
   Select the Suppliers whose contact has a title that starts with the word 
   Sales
*/

USE Northwind;
GO

SELECT *
FROM Suppliers
WHERE ContactTitle LIKE 'Sales%';