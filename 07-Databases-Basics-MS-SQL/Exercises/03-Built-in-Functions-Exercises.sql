USE SoftUni

SELECT FirstName, LastName 
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

SELECT FirstName, LastName 
  FROM Employees
 WHERE LastName LIKE '%ei%'

SELECT FirstName 
  FROM Employees
 WHERE (DepartmentID = 3 OR DepartmentID = 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName 
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name] 
  FROM Towns
 WHERE LEN([Name]) IN (5,6)
 ORDER BY [Name]

SELECT TownID, [Name] 
  FROM Towns
 WHERE 
	[Name] LIKE 'M%' OR
	[Name] LIKE 'K%' OR
	[Name] LIKE 'B%' OR
	[Name] LIKE 'E%'
 ORDER BY [Name]

SELECT TownID, [Name] 
  FROM Towns
 WHERE 
	[Name] NOT LIKE 'R%' AND
	[Name] NOT LIKE 'B%' AND
	[Name] NOT LIKE 'D%' 
 ORDER BY [Name]

GO

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName 
  FROM Employees
 WHERE YEAR(HireDate) > 2000

 GO

 SELECT FirstName, LastName 
  FROM Employees
 WHERE LEN(LastName) = 5

 SELECT EmployeeID, FirstName, LastName,Salary, 
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
   FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000
 ORDER BY Salary DESC

SELECT * 
FROM (
SELECT EmployeeID, 
	   FirstName, 
	   LastName,
	   Salary, 
	   DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
  FROM Employees
  WHERE Salary BETWEEN 10000 AND 50000) AS R
 WHERE [Rank] = 2
 ORDER BY Salary DESC

USE Geography

SELECT CountryName, IsoCode 
  FROM Countries
 WHERE CountryName LIKE '%a%a%a%'
 ORDER BY IsoCode

SELECT PeakName, 
       RiverName, 
       LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName) - 1)) AS [Mix]
FROM Peaks JOIN Rivers ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

SELECT PeakName, 
	   RiverName,
	   LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName) - 1))  AS Mix
  FROM Peaks, Rivers
 WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
 ORDER BY Mix

USE Diablo

SELECT TOP (50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
  FROM Games
 WHERE YEAR([Start]) = 2011 OR YEAR([Start]) = 2012
 ORDER BY [Start], [Name]

SELECT Username, 
	   SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
  FROM Users
 ORDER BY [Email Provider], Username

SELECT Username, IpAddress AS [IP Address] 
  FROM Users
 WHERE IpAddress LIKE '___.1_%._%.___'
 ORDER BY Username

SELECT [Name] AS [Game],
  CASE 
	WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
  END
  AS [Part of the Day],
  CASE 
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration > 3 AND Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
  END
  AS [Duration]
  FROM Games
 ORDER BY [Name], Duration

USE Orders

SELECT ProductName, 
	   OrderDate,
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
  FROM Orders

CREATE TABLE People(
	   Id INT PRIMARY KEY IDENTITY,
	   [Name] NVARCHAR(20) NOT NULL,
	   Birthdate DATETIME NOT NULL)

TRUNCATE TABLE People

INSERT INTO People ([Name], Birthdate)
VALUES ('Pesho', '1995-05-03'),
('Mimi', '1998-09-21'),
('Kiro', '2001-12-01')

SELECT [Name],
	   DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years],
	   DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months],
	   DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days],
	   DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
  FROM People
