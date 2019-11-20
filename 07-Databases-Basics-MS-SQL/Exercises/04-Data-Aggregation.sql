USE Gringotts

--Task 1--
SELECT 
	COUNT(*) AS [Count]
FROM 
	WizzardDeposits

--Task 2--
SELECT 
	MAX(MagicWandSize) AS LongestMagicWand 
FROM 
	WizzardDeposits

--Task 3--
SELECT 
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
FROM 
	WizzardDeposits
GROUP BY 
	DepositGroup

--Task 4--
SELECT TOP (2) 
	DepositGroup
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup
ORDER BY 
	AVG(MagicWandSize)

--Task 5--
SELECT 
	DepositGroup, 
	SUM(DepositAmount) AS TotalSum 
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup

--Task 6--
SELECT 
	DepositGroup, 
	SUM(DepositAmount) AS TotalSum 
FROM 
	WizzardDeposits
WHERE
	MagicWandCreator = 'Ollivander family'
GROUP BY
	DepositGroup

--Task 7--
SELECT 
	DepositGroup, 
	SUM(DepositAmount) AS TotalSum 
FROM 
	WizzardDeposits
WHERE
	MagicWandCreator = 'Ollivander family'
GROUP BY
	DepositGroup
HAVING
	SUM(DepositAmount) < 150000
ORDER BY
	TotalSum DESC

--Task 8--
SELECT 
	DepositGroup, 
	MagicWandCreator, 
	MIN(DepositCharge) AS MinDepositCharge 
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup,
	MagicWandCreator
ORDER BY
	MagicWandCreator, 
	DepositGroup

--Task 9--
SELECT 
	AgeGroupTable.AgeGroup, 
	COUNT(*) AS WizardCount
FROM 
(SELECT 
	CASE
		WHEN Age BETWEEN  0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN  11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN  21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN  31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN  41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN  51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup
FROM WizzardDeposits) AS AgeGroupTable
GROUP BY
	AgeGroupTable.AgeGroup
	
--Task 10--
SELECT 
	SUBSTRING(FirstName, 1, 1) AS FirstLetter
FROM 
	WizzardDeposits
WHERE 
	DepositGroup = 'Troll Chest'
GROUP BY 
	SUBSTRING(FirstName, 1, 1)

--Task 11--
SELECT 
	DepositGroup, 
	IsDepositExpired, 
	AVG(DepositInterest) AS AverageInterest
FROM 
	WizzardDeposits
WHERE
	DepositStartDate > CAST('01/01/1985' AS DATE)
GROUP BY 
	DepositGroup,
	IsDepositExpired
ORDER BY
	DepositGroup DESC, IsDepositExpired

--Task 12--
	--First solution:
SELECT 
	wd.Id, 
	wd.FirstName AS [Host Wizard], 
	wd.DepositAmount AS [Host Wizard Deposit],
	(SELECT 
		fn.FirstName
	FROM 
		WizzardDeposits AS fn 
	WHERE 
		fn.Id = wd.Id + 1) AS [Guest Wizard],
	(SELECT 
		da.DepositAmount
	FROM 
		WizzardDeposits AS da
	WHERE 
		da.Id = wd.Id + 1) AS [Guest Wizard Deposit]
FROM 
	WizzardDeposits AS wd

SELECT 
	SUM(w.[Difference]) AS [SumDifference]
FROM 
(SELECT 
	wd.DepositAmount -
	(SELECT 
		da.DepositAmount
	FROM 
		WizzardDeposits AS da
	WHERE 
		da.Id = wd.Id + 1) AS [Difference]
FROM 
	WizzardDeposits AS wd) AS w

	--Second solution:
SELECT
	SUM(w.[Difference]) AS SumDifference
FROM
(SELECT 
	DepositAmount - LEAD(DepositAmount,1) OVER (ORDER BY Id) AS [Difference] 
FROM 
	WizzardDeposits) AS w

	--Third solution:
SELECT
	SUM(w.[Difference]) * -1 AS SumDifference
FROM
(SELECT 
	DepositAmount - LAG(DepositAmount,1) OVER (ORDER BY Id) AS [Difference] 
FROM 
	WizzardDeposits) AS w

USE SoftUni

--Task 13--
SELECT 
	DepartmentID, 
	SUM(Salary) AS TotalSalary 
FROM 
	Employees
GROUP BY
	DepartmentID
ORDER BY
	DepartmentID

--Task 14--
SELECT 
	DepartmentID, 
	MIN(Salary) AS TotalSalary 
FROM 
	Employees
WHERE
	DepartmentID IN (2, 5, 7) AND HireDate > CAST('01/01/2000' AS SMALLDATETIME)
GROUP BY
	DepartmentID

--Task 15--
SELECT *
INTO 
	EmployeesWithSalariesOver30000
FROM 
	Employees 
WHERE 
	Salary > 30000

DELETE 
FROM 
	EmployeesWithSalariesOver30000
WHERE 
	ManagerID = 42

UPDATE 
	EmployeesWithSalariesOver30000
SET
	Salary += 5000
WHERE 
	DepartmentID = 1

SELECT 
	DepartmentID, 
	AVG(Salary) AS AverageSalary
FROM 
	EmployeesWithSalariesOver30000
GROUP BY
	DepartmentID

--Task 16--
SELECT 
	DepartmentID, 
	MAX(Salary) AS MaxSalary 
FROM 
	Employees
GROUP BY
	DepartmentID
HAVING
	MAX(Salary) < 30000 OR MAX(Salary) > 70000

--Task 17--
SELECT 
	Count(Salary) AS Count 
FROM 
	Employees
WHERE
	ManagerID IS NULL

--Task 18--
SELECT 
	sr.DepartmentID, 
	sr.Salary
FROM
	(SELECT 
		DepartmentID, 
		Salary, 
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM 
		Employees) AS sr
WHERE
	sr.SalaryRank = 3
GROUP BY 
	sr.DepartmentID, sr.Salary

--Task 19--
SELECT TOP (10)
	e.FirstName, 
	e.LastName, 
	e.DepartmentID
FROM
	Employees AS e
WHERE
	Salary > (SELECT AVG(s.Salary) FROM Employees AS s WHERE e.DepartmentID = s.DepartmentID)
ORDER BY
	e.DepartmentID