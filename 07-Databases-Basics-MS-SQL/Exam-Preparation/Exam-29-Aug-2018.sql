CREATE DATABASE Supermarket

USE Supermarket

--01. DDL 

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Price DECIMAL(16,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL,
	Salary DECIMAL(16,2) NOT NULL
)

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
	Quantity INT CHECK(Quantity >= 1) NOT NULL

	CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)
)

CREATE TABLE Shifts
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL

	CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId)
)

ALTER TABLE Shifts
ADD CONSTRAINT CHK_CheckDates CHECK(CheckOut > CheckIn)

--02. Insert 

INSERT INTO Employees (FirstName, LastName, Phone, Salary)
VALUES 
	('Stoyan', 'Petrov', '888-785-8573', 500.25),
	('Stamat', 'Nikolov', '789-613-1122', 999995.25),
	('Evgeni', 'Petkov', '645-369-9517', 1234.51),
	('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items ([Name], Price, CategoryId)
VALUES
	('Tesla battery', 154.25, 8),
	('Chess', 30.25, 8),
	('Juice', 5.32, 1),
	('Glasses', 10, 8),
	('Bottle of water', 1, 1)

--03. Update

UPDATE Items
SET Price += Price * 0.27
WHERE CategoryId IN (1, 2, 3)

--04. Delete 

DELETE FROM OrderItems
WHERE OrderId = 48

DELETE FROM Orders
WHERE Id = 48

--05. Richest People 

SELECT 
	Id, 
	FirstName 
FROM Employees
WHERE Salary > 6500
ORDER BY 
	FirstName, 
	Id

--06. Cool Phone Numbers 

SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name], 
	Phone 
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY 
	FirstName, 
	Phone

--07. Employee Statistics 

SELECT 
	FirstName, 
	LastName, 
	COUNT(FirstName) AS [Count] 
FROM Employees AS e 
JOIN Orders AS o ON e.Id = o.EmployeeId
GROUP BY 
	FirstName, 
	LastName
ORDER BY 
	COUNT(FirstName) DESC, 
	FirstName

--08. Hard Workers Club 

SELECT 
	k.FirstName, 
	k.LastName, 
	k.[Work hours]
FROM 
	(SELECT 
		e.Id,
		e.FirstName,
		e.LastName, 
		AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours]
	FROM Employees AS e 
	JOIN Shifts AS s ON e.Id = s.EmployeeId
	GROUP BY 
		e.Id,
		e.FirstName, 
		e.LastName) AS k
WHERE k.[Work hours] > 7
ORDER BY 
	k.[Work hours] DESC,
	k.Id

--09. The Most Expensive Order 

SELECT TOP(1) 
	oi.OrderId, 
	SUM(oi.Quantity * i.Price) AS TotalPrice
FROM Orders AS o 
JOIN OrderItems AS oi ON o.Id = oi.OrderId 
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY oi.OrderId
ORDER BY TotalPrice DESC

--10. Rich Item, Poor Item 

SELECT TOP (10)
	o.Id AS OrderId, 
	MAX(Price) AS ExpensivePrice, 
	MIN(Price) AS CheapPrice
FROM Orders AS o 
JOIN OrderItems AS oi ON o.Id = oi.OrderId 
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY o.Id
ORDER BY 
	MAX(Price) DESC,
	o.Id

--11. Cashiers 

SELECT 
	e.Id, 
	e.FirstName, 
	e.LastName
FROM Employees AS e 
JOIN Orders AS o ON e.Id = o.EmployeeId
GROUP BY 
	e.Id, 
	e.FirstName, 
	e.LastName
ORDER BY e.Id

--12. Lazy Employees

SELECT DISTINCT
	e.Id,
	CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
FROM Employees AS e 
JOIN Shifts AS s ON e.Id = s.EmployeeId
WHERE (DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) < 4
ORDER BY e.Id

--13. Sellers

SELECT TOP(10)
	CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
	SUM(i.Price * oi.Quantity) AS [Total Price], 
	SUM(oi.Quantity) AS [Items] 
FROM Employees AS e 
JOIN Orders AS o ON e.Id = o.EmployeeId
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
WHERE o.[DateTime] < '2018-06-15'
GROUP BY 
	e.FirstName, 
	e.LastName
ORDER BY 
	SUM(i.Price * oi.Quantity) DESC,
	SUM(oi.Quantity) DESC

--14. Tough Days

SELECT 
	CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name], 
	DATENAME(DW, s.CheckIn) AS [Day of week]
FROM Shifts AS s 
JOIN Employees AS e ON s.EmployeeId = e.Id 
LEFT JOIN Orders AS o ON e.Id = o.EmployeeId
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

--15. Top Order per Employee ---> Not correct

--Find all information of the employees who have orders. 
--Select their full name, duration of the work day (in hours) and total price of all sold products. 
--Find only the top orders (top orders with highest total price).
--Sort them by full name (ascending), work hours (descending) and total price (descending)

SELECT k.[Full Name], k.TotalPrice 
FROM
	(SELECT
		CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
		DENSE_RANK() OVER (PARTITION BY e.FirstName ORDER BY oi.Quantity * i.Price DESC) AS [Rank],
		oi.Quantity * i.Price AS [TotalPrice],
		DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS [WorkHours]
	FROM Shifts AS s 
	JOIN Employees AS e ON s.EmployeeId = e.Id 
	JOIN Orders AS o ON e.Id = o.EmployeeId
	JOIN OrderItems AS oi ON o.Id = oi.OrderId
	JOIN Items AS i ON oi.ItemId = i.Id) AS k
WHERE k.[Rank] = 1
GROUP BY k.[Full Name], k.TotalPrice 
ORDER BY k.[Full Name]

--Author solution
SELECT 
	emp.FirstName + ' ' + emp.LastName AS FullName, 
	DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours, 
	e.TotalPrice AS TotalPrice 
FROM 
	(SELECT	
		o.EmployeeId, 
		SUM(oi.Quantity * i.Price) AS TotalPrice, 
		o.DateTime,
		ROW_NUMBER() OVER (PARTITION BY o.EmployeeId ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC ) AS Rank
    FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
	GROUP BY o.EmployeeId, o.Id, o.DateTime) AS e 
JOIN Employees AS emp ON emp.Id = e.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.EmployeeId
WHERE e.Rank = 1 AND e.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY 
	FullName,
	WorkHours DESC, 
	TotalPrice DESC

--16. Average Profit per Day 

SELECT 
	DAY(o.DateTime) AS [Day], 
	CONVERT(DECIMAL(10,2), AVG(i.Price * oi.Quantity)) AS [Total profit]
FROM Items AS i 
JOIN OrderItems AS oi ON i.Id = oi.ItemId
JOIN Orders AS o ON oi.OrderId = o.Id
GROUP BY DAY(o.DateTime)
ORDER BY DAY(o.DateTime)

--17. Top Products

SELECT
	i.[Name] AS Item, 
	c.[Name] AS Category, 
	SUM(oi.Quantity) AS [Count], 
	SUM(i.Price * oi.Quantity) AS TotalPrice
FROM Categories AS c 
JOIN Items AS i ON c.Id = i.CategoryId
LEFT JOIN OrderItems AS oi ON i.Id = oi.ItemId
GROUP BY 
	i.[Name], 
	c.[Name]
ORDER BY 
	TotalPrice DESC, 
	[Count] DESC

--Author solution
SELECT
	i.Name,
	c.Name,
	SUM(oi.Quantity)  As [Count],
	SUM(i.Price * oi.Quantity) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
RIGHT JOIN Items AS i ON i.Id = oi.ItemId
JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY 
	i.Name, 
	c.Name
ORDER BY 
	TotalPrice DESC, 
	[Count] DESC
GO

--18. Promotion Days

CREATE FUNCTION udf_GetPromotedProducts (@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount DECIMAL(16,2), @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @fistId INT = (SELECT Id FROM Items WHERE Id = @FirstItemId)
	DECLARE @secondId INT = (SELECT Id FROM Items WHERE Id = @SecondItemId)
	DECLARE @thirdId INT = (SELECT Id FROM Items WHERE Id = @ThirdItemId)

	DECLARE @result NVARCHAR(MAX)

	IF (@fistId IS NULL OR @secondId IS NULL OR @thirdId IS NULL)
	BEGIN
		SET @result = 'One of the items does not exists!'
		RETURN @result
	END

	IF (@CurrentDate < @StartDate OR @CurrentDate > @EndDate)
	BEGIN
		SET @result = 'The current date is not within the promotion dates!'
		RETURN @result
	END

	DECLARE @fistItemPrice DECIMAL(16,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
	DECLARE @secondItemPrice DECIMAL(16,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
	DECLARE @thirdItemPrice DECIMAL(16,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

	DECLARE @fistItemDiscountedPrice DECIMAL(16,2) = @fistItemPrice - (@fistItemPrice * @Discount/100)
	DECLARE @secondItemDiscountedPrice DECIMAL(16,2) = @secondItemPrice - (@secondItemPrice * @Discount/100)
	DECLARE @thirdItemDiscountedPrice DECIMAL(16,2) = @thirdItemPrice - (@thirdItemPrice * @Discount/100)

	DECLARE @fistItemName NVARCHAR(30) =  (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @secondItemName NVARCHAR(30) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @thirdItemName NVARCHAR(30) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	SET @result = CONCAT(@fistItemName, ' price: ', @fistItemDiscountedPrice, ' <-> ', @secondItemName, ' price: ', @secondItemDiscountedPrice, ' <-> ', @thirdItemName, ' price: ', @thirdItemDiscountedPrice)
	RETURN @result 
END
GO

--19. Cancel Order 

CREATE OR ALTER PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
BEGIN
	BEGIN TRANSACTION
	
		DECLARE @actualOrderId INT = (SELECT Id FROM Orders WHERE Id = @OrderId)

		IF @actualOrderId IS NULL
		BEGIN
			RAISERROR('The order does not exist!', 16, 1)
			ROLLBACK
			RETURN
		END
	
		DECLARE @issueDate DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)
		DECLARE @overdueDate DATETIME = DATEADD(DAY, 3, @issueDate)

		IF @CancelDate > @overdueDate
		BEGIN
			RAISERROR('You cannot cancel the order!', 16, 2)
			ROLLBACK
			RETURN
		END

		DELETE FROM OrderItems
		WHERE OrderId = @OrderId

		DELETE FROM Orders
		WHERE Id = @OrderId

	COMMIT
END

--Test
EXEC usp_CancelOrder 1, '2018-06-02'
SELECT COUNT(*) FROM Orders
SELECT COUNT(*) FROM OrderItems
GO

--20. Deleted Orders

CREATE TABLE DeletedOrders 
(	
	OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
	Quantity INT CHECK(Quantity >= 1) NOT NULL

	CONSTRAINT PK_DeletedOrderItems PRIMARY KEY (OrderId, ItemId)
)
GO

CREATE TRIGGER tr_DeletedOrders ON OrderItems FOR DELETE
AS
BEGIN
	INSERT INTO DeletedOrders
	SELECT 
		OrderId, 
		ItemId, 
		Quantity
	FROM deleted
END

DELETE FROM OrderItems
WHERE OrderId = 5

DELETE FROM Orders
WHERE Id = 5 
