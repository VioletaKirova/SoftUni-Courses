USE SoftUni
GO

--Task 1--
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary > 35000
GO

--Test
EXECUTE dbo.usp_GetEmployeesSalaryAbove35000
GO

--Task 2--
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary >= @Number
GO

--Test
EXECUTE dbo.usp_GetEmployeesSalaryAboveNumber 48100
GO

--Task 3--
CREATE PROCEDURE usp_GetTownsStartingWith (@StartingString VARCHAR(20))
AS
	SELECT [Name] FROM Towns
	WHERE LEFT([Name], LEN(@StartingString)) = @StartingString
GO

--Test
EXECUTE dbo.usp_GetTownsStartingWith 'b'
GO

--Task 4--
CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName VARCHAR(50))
AS
	SELECT 
		e.FirstName,
		e.LastName 
	FROM Employees AS e 
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @TownName
GO

--Test
EXECUTE dbo.usp_GetEmployeesFromTown 'Sofia'
GO

--Task 5--
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(20)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(20)

	IF @Salary < 30000
		SET @salaryLevel = 'Low'
	ELSE IF @Salary >= 30000 AND @Salary <= 50000
		SET @salaryLevel = 'Average'
	ELSE
		SET @salaryLevel = 'High'

	RETURN @salaryLevel
END
GO

--Test
SELECT 
	FirstName, 
	LastName, 
	dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees 
GO

--Task 6--
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(20))
AS
	SELECT 
		FirstName, 
		LastName 
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
GO

--Test
EXECUTE dbo.usp_EmployeesBySalaryLevel 'High'
GO

--Task 7--
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(MAX), @Word NVARCHAR(MAX))
RETURNS BIT
AS
	BEGIN
		DECLARE @result BIT = 1
		DECLARE @index INT = 1

		WHILE(@index <= LEN(@Word))
		BEGIN
			DECLARE @currentLetter NVARCHAR(1)= SUBSTRING(@Word, @index, 1)

			IF(CHARINDEX(@currentLetter, @SetOfLetters) = 0)
			BEGIN
				SET @result = 0
				BREAK
			END
			ELSE
				SET @index += 1
		END
		RETURN @result
	END
GO

--Task 8--
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@DepartmentId INT) 
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @DepartmentId

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @DepartmentId)

DELETE FROM Employees
WHERE DepartmentID = @DepartmentId

DELETE FROM Departments
WHERE DepartmentID = @DepartmentId

SELECT COUNT(*)
FROM Employees
WHERE DepartmentID = @DepartmentId
GO

--Test
EXECUTE dbo.usp_DeleteEmployeesFromDepartment 1
GO

USE Bank
GO

--Task 9--
CREATE PROCEDURE usp_GetHoldersFullName 
AS
	SELECT 
		CONCAT(FirstName, ' ', LastName) AS [Full Name] 
	FROM AccountHolders
GO

--Test
EXECUTE dbo.usp_GetHoldersFullName
GO

--Task 10--
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@Amount MONEY)
AS
	SELECT 
		ah.FirstName, 
		ah.LastName 
	FROM AccountHolders AS ah 
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY 
		a.AccountHolderId,
		ah.FirstName, 
		ah.LastName 
	HAVING SUM(a.Balance) > @Amount
	ORDER BY
		ah.FirstName,
		ah.LastName
GO

--Test
EXECUTE dbo.usp_GetHoldersWithBalanceHigherThan 10000
GO

--Task 11--
CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(16,4), @Rate FLOAT, @Years INT)
RETURNS DECIMAL(16,4)
BEGIN
	DECLARE @result DECIMAL(16,4)
	SET @result = @Sum * POWER((1 + @Rate), @Years)
	RETURN @result
END
GO

--Task 12--
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@AccountId INT, @Rate FLOAT)
AS
	SELECT 
		a.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @Rate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah 
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @AccountId 
GO

--Test
EXECUTE usp_CalculateFutureValueForAccount 1, 0.1
GO

USE Diablo
GO

--Task 13--
CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(MAX))
RETURNS TABLE
RETURN(
SELECT SUM(s.Cash) AS SumCash
FROM(
	SELECT 
		g.[Name], 
		ug.Cash, 
		ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
	FROM Games AS g 
	JOIN UsersGames AS ug ON g.Id = ug.GameId
	WHERE g.[Name] = @GameName) AS s
WHERE s.RowNumber % 2 = 1)
GO

--Task 14--
USE Bank

CREATE TABLE Logs
(	
	LogId INT PRIMARY KEY IDENTITY, 
	AccountID INT NOT NULL, 
	OldSum DECIMAL(16,2) NOT NULL, 
	NewSum DECIMAL(16,2) NOT NULL, 
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountID) REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_AddLog ON Accounts AFTER UPDATE
AS
BEGIN
	INSERT INTO Logs
	SELECT 
		i.Id, 
		d.Balance, 
		i.Balance 
	FROM inserted AS i JOIN deleted AS d ON i.Id = d.Id
END
GO

--Test
UPDATE Accounts 
SET Balance += 500
WHERE Id = 1
GO

--Task 15--
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL, 
	[Subject] NVARCHAR(MAX) NOT NULL, 
	Body NVARCHAR(MAX) NOT NULL
)
GO

CREATE TRIGGER tr_SendEmail ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails
	SELECT 
		i.AccountID,
		CONCAT('Balance change for account: ', i.AccountID),
		CONCAT('On ', CONVERT(NVARCHAR(50), GETDATE(), 109) ,' your balance was changed from ', i.OldSum, ' to ', i.NewSum, '.')
	FROM inserted AS i
END

--Test
UPDATE Accounts 
SET Balance += 200
WHERE Id = 1
GO

--Task 16--
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(16,4))
AS
BEGIN
	BEGIN TRANSACTION

		IF(@MoneyAmount < 0)
		BEGIN
			ROLLBACK
			RETURN
		END

		UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId

	COMMIT
END
GO

--Test
EXEC dbo.usp_DepositMoney 1, 1000
GO

--Task 17--
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(16,4))
AS
BEGIN
	BEGIN TRANSACTION

		IF(@MoneyAmount < 0)
		BEGIN
			ROLLBACK
			RETURN
		END

		UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId

	COMMIT
END

--Test
EXEC dbo.usp_WithdrawMoney 1, 1000
GO

--Task 18--
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(16,4))
AS
BEGIN
	BEGIN TRANSACTION
		
		IF(@Amount < 0)
		BEGIN
			ROLLBACK
			RETURN
		END

		EXEC dbo.usp_WithdrawMoney @SenderId, @Amount
		EXEC dbo.usp_DepositMoney @ReceiverId, @Amount

	COMMIT
END

--Test 
EXEC dbo.usp_TransferMoney 2, 1, 1000
GO

USE Diablo
GO

--Task 19--
--First Part
CREATE TRIGGER tr_BuyItem ON UserGameItems INSTEAD OF INSERT
AS
BEGIN
	DECLARE @itemId INT = (SELECT ItemId FROM inserted)
	DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

	DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
	DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

	IF(@userGameLevel > @itemLevel)
	BEGIN 
		INSERT INTO UserGameItems (ItemId, UserGameId)
		VALUES (@itemId, @userGameId)
	END
END 
GO

--Test
INSERT INTO UserGameItems
VALUES 
(14, 38)
GO

--Second Part
--First Solution
UPDATE UsersGames
SET Cash += 50000
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
WHERE g.[Name] = 'Bali' 
AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
GO

--Second Solution
UPDATE UsersGames
SET Cash += 50000
WHERE 
	GameId = (SELECT Id FROM Games WHERE [Name] = 'Bali') AND
	UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')) 
GO

--Test
SELECT * 
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
WHERE g.[Name] = 'Bali' 
AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
GO

--Third Part
CREATE PROCEDURE usp_BuyItem (@UserId INT, @ItemId INT, @GameId INT)
AS 
BEGIN TRANSACTION
	DECLARE @user INT = (SELECT Id FROM Users WHERE Id = @UserId)
	DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @ItemId)

	IF (@user IS NULL OR @item IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid user or item.', 16, 1)
		RETURN
	END

	DECLARE @userCash DECIMAL(15,2) = 
		(SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
	DECLARE @itemPrice DECIMAL(15,2) = 
		(SELECT Price FROM Items WHERE Id = @ItemId)

	IF (@userCash < @itemPrice)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient amount of money.', 16, 2)
		RETURN
	END

	UPDATE UsersGames
	SET Cash -= @itemPrice
	WHERE UserId = @UserId AND GameId = @GameId

	DECLARE @userGameId INT = 
		(SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)

	INSERT INTO UserGameItems (ItemId, UserGameId)
	VALUES (@ItemId, @userGameId)
COMMIT
GO

DECLARE @itemId INT = 255

WHILE @itemId <= 291
BEGIN
	EXEC usp_BuyItem 12, @itemId, 212
	EXEC usp_BuyItem 22, @itemId, 212
	EXEC usp_BuyItem 37, @itemId, 212
	EXEC usp_BuyItem 52, @itemId, 212
	EXEC usp_BuyItem 61, @itemId, 212

	SET @itemId += 1
END

SET @itemId = 501

WHILE @itemId <= 539
BEGIN
	EXEC usp_BuyItem 12, @itemId, 212
	EXEC usp_BuyItem 22, @itemId, 212
	EXEC usp_BuyItem 37, @itemId, 212
	EXEC usp_BuyItem 52, @itemId, 212
	EXEC usp_BuyItem 61, @itemId, 212

	SET @itemId += 1
END

--Test
SELECT * 
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
WHERE g.[Name] = 'Bali' 
AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

--Forth Part
SELECT u.Username, g.[Name], ug.Cash, i.[Name] AS [Item Name]
FROM Users AS u 
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Games AS g ON ug.GameId = g.Id
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Items AS i ON ugi.ItemId = i.Id
WHERE g.[Name] = 'Bali'

--Task 20--
DECLARE @gameId INT = (SELECT Id FROM Games AS g WHERE g.[Name] = 'Safflower'); 
DECLARE @userId INT = (SELECT u.Id FROM Users AS u WHERE u.Username = 'Stamat');	
DECLARE @userGameId INT = (SELECT ug.Id FROM UsersGames AS ug WHERE ug.GameId = @gameId AND ug.UserId = @userId);
DECLARE @userCash DECIMAL(15, 2) = (SELECT ug.Cash FROM UsersGames AS ug WHERE ug.Id = @userGameId);  
DECLARE @itemsTotalPrice DECIMAL(15, 2) = (SELECT SUM(i.Price) FROM Items AS i WHERE i.MinLevel BETWEEN 11 AND 12); 

IF(@userCash >= @itemsTotalPrice)
BEGIN
	BEGIN TRANSACTION

		INSERT UserGameItems
		SELECT i.Id, @UserGameId
		FROM Items AS i
		WHERE i.MinLevel BETWEEN 11 AND 12

		UPDATE UsersGames 
		SET Cash -= @itemsTotalPrice
		WHERE Id = @userGameId 

	COMMIT
END

SET @itemsTotalPrice = (SELECT SUM(i.Price) FROM Items AS i WHERE i.MinLevel BETWEEN 19 AND 21); 
SET @userCash = (SELECT ug.Cash FROM UsersGames AS ug WHERE ug.Id = @UserGameId);  

IF(@userCash >= @itemsTotalPrice)
BEGIN 	
	BEGIN TRANSACTION

		INSERT UserGameItems
		SELECT i.Id, @UserGameId
		FROM Items AS i
		WHERE i.MinLevel BETWEEN 19 AND 21

		UPDATE UsersGames 
		SET Cash -= @itemsTotalPrice
		WHERE Id = @UserGameId 

	COMMIT
END

SELECT i.[Name] 
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE (u.Username = 'Stamat' AND g.[Name] = 'Safflower')
ORDER BY i.[Name]
GO

USE SoftUni
GO

--Task 21--
CREATE PROC usp_AssignProject(@EmloyeeId INT, @ProjectID INT)
AS
BEGIN
	BEGIN TRANSACTION
	
		DECLARE @allowedNumerOfProjects INT = 3
		DECLARE @numberOfProjects INT = (
			SELECT COUNT(*) 
			FROM EmployeesProjects
			WHERE EmployeeID = @EmloyeeId)

			IF (@numberOfProjects >= @allowedNumerOfProjects)
			BEGIN
				RAISERROR('The employee has too many projects!', 16, 1)
				ROLLBACK
				RETURN
			END

		INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
		VALUES (@EmloyeeId, @ProjectID)

	COMMIT
END

--Task 22--
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentId),
	Salary MONEY NOT NULL
)
GO

CREATE TRIGGER tr_DeleteEmployees ON Employees AFTER DELETE 
AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT 
		d.FirstName,
		d.LastName,
		d.MiddleName,
		d.JobTitle,
		d.DepartmentID,
		d.Salary
	FROM deleted AS d
END