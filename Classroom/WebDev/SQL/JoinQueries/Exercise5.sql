/*
	Find a list of all the Employees who have never found a Grant
*/

USE SWCCorp;
GO

SELECT e.FirstName, e.LastName
FROM Employee e
	LEFT JOIN [Grant] g
		ON e.EmpID = g.EmpID
	WHERE g.EmpID IS NULL