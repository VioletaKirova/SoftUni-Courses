USE SoftUni

--Task 1--
SELECT TOP (5)
	e.EmployeeID, 
	e.JobTitle, 
	a.AddressID, 
	a.AddressText 
FROM 
	Employees AS e 
JOIN 
	Addresses AS a ON e.AddressID = a.AddressID
ORDER BY
	AddressID

--Task 2--
SELECT TOP (50) 
	e.FirstName, 
	e.LastName, 
	t.[Name] AS Town, 
	a.AddressText
FROM 
	Employees AS e 
JOIN 
	Addresses AS a ON e.AddressID = a.AddressID
JOIN 
	Towns AS t ON a.TownID = t.TownID
ORDER BY
	e.FirstName, 
	e.LastName

--Task 3--
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS DepartmentName
FROM 
	Employees AS e 
JOIN 
	Departments AS d ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY
	EmployeeID

--Task 4--
SELECT TOP (5)
	e.EmployeeID, 
	e.FirstName, 
	e.Salary, 
	d.[Name] As DepartmentName 
FROM 
	Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
AND 
	e.Salary > 15000
ORDER BY
	e.DepartmentID 

--Task 5--
--First solution:
SELECT TOP (3)
	e.EmployeeID, 
	e.FirstName
FROM 
	Employees AS e 
WHERE 
	e.EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)
ORDER BY
	e.EmployeeID

--Second solution:
SELECT TOP (3)
	e.EmployeeID, 
	e.FirstName
FROM 
	Employees AS e 
LEFT JOIN
	EmployeesProjects AS p ON e.EmployeeID = p.EmployeeID 
WHERE 
	p.EmployeeID IS NULL
ORDER BY
	e.EmployeeID

--Task 6--
SELECT 
	e.FirstName, 
	e.LastName, 
	e.HireDate, 
	d.[Name] AS DeptName
FROM 
	Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
AND 
	e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY
	e.HireDate

--Task 7--
SELECT TOP (5)
	e.EmployeeID, 
	e.FirstName, 
	p.[Name] AS ProjectName
FROM 
	Employees AS e JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN 
	Projects AS p ON ep.ProjectID = p.ProjectID
WHERE 
	p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY 
	e.EmployeeID

--Task 8--
SELECT 
	e.EmployeeID, 
	e.FirstName,
	CASE
		WHEN p.StartDate > '2005-01-01' THEN NULL
		ELSE p.[Name]
	END AS ProjectName
FROM 
	Employees AS e 
JOIN 
	EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID AND e.EmployeeID = 24
JOIN 
	Projects AS p ON ep.ProjectID = p.ProjectID

--Task 9--
SELECT 
	e.EmployeeID, 
	e.FirstName, 
	e.ManagerID, 
	m.FirstName AS ManagerName 
FROM 
	Employees AS e JOIN Employees AS m ON e.ManagerID = m.EmployeeID
AND 
	e.ManagerID IN (3, 7)
ORDER BY
	e.EmployeeID

--Task 10--
SELECT TOP (50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
FROM 
	Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
LEFT JOIN 
	Employees AS m ON e.ManagerID = m.EmployeeID
ORDER BY
	e.EmployeeID

--Task 11--
SELECT 
	MIN(s.AvgSalary) AS MinAverageSalary
FROM 
	(SELECT 
		AVG(Salary) AS AvgSalary 
	 FROM 
		Employees 
	 GROUP BY 
		DepartmentID) AS s

USE Geography

--Task 12--
SELECT 
	c.CountryCode, 
	m.MountainRange, 
	p.PeakName, 
	p.Elevation 
FROM 
	Countries AS c 
JOIN 
	MountainsCountries AS mc ON c.CountryCode = mc.CountryCode AND c.CountryCode = 'BG'
JOIN 
	Mountains AS m ON mc.MountainId = m.Id
JOIN 
	Peaks AS p ON m.Id = p.MountainId AND p.Elevation > 2835
ORDER BY
	p.Elevation DESC

--Task 13--
SELECT 
	c.CountryCode, 
	COUNT(mc.CountryCode) AS MountainRanges
FROM 
	Countries AS c 
JOIN 
	MountainsCountries AS mc ON c.CountryCode = mc.CountryCode AND c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY
	c.CountryCode

--Task 14--
SELECT TOP (5)
	c.CountryName,
	r.RiverName
FROM 
	Countries AS c 
LEFT JOIN
	CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN 
	Rivers AS r ON cr.RiverId = r.Id
WHERE
	c.ContinentCode = 'AF'
ORDER BY
	c.CountryName 

--Task 15--
SELECT s.ContinentCode, s.CurrencyCode, s.CurrencyUsage FROM
	(SELECT 
		ContinentCode, 
		CurrencyCode, 
		COUNT(CurrencyCode) AS CurrencyUsage, 
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS CurrencyRank
	FROM 
		Countries
	GROUP BY 
		ContinentCode, 
		CurrencyCode
	HAVING 
		COUNT(CurrencyCode) > 1) AS s
WHERE 
	s.CurrencyRank = 1
ORDER BY 
	s.ContinentCode

--Task 16--
SELECT 
	COUNT(c.CountryCode) AS CountryCode
FROM 
	Countries AS c 
LEFT JOIN 
	MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE 
	mc.CountryCode IS NULL

--Task 17--
SELECT TOP (5)
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
FROM 
	Countries AS c 
LEFT JOIN  
	CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN 
	Rivers AS r ON cr.RiverId = r.Id 
LEFT JOIN 
	MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN 
	Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN
	Peaks AS p ON m.Id = p.MountainId
GROUP BY 
	c.CountryName
ORDER BY 
	HighestPeakElevation DESC, 
	LongestRiverLength DESC, 
	c.CountryName

--Task 18--
SELECT TOP (5) 
	s.CountryName, 
	ISNULL(s.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(s.Elevation, 0) AS [Highest Peak Elevation],
	ISNULL(s.MountainRange, '(no mountain)') AS Mountain
FROM
	(SELECT 
		c.CountryName, 
		p.PeakName, 
		p.Elevation, 
		m.MountainRange, 
		DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
	FROM 
		Countries AS c 
	LEFT JOIN 
		MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN 
		Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN 
		Peaks AS p ON mc.MountainId = p.MountainId) AS s
WHERE 
	s.PeakRank = 1
ORDER BY
	s.CountryName,
	s.PeakName

