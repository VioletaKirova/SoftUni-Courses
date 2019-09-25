CREATE DATABASE TripService

USE TripService

--01. DDL 

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
) 

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK (Luggage >= 0) NOT NULL

	CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId, TripId)
)

ALTER TABLE Trips
ADD CONSTRAINT CH_BookDate CHECK(BookDate < ArrivalDate)

ALTER TABLE Trips
ADD CONSTRAINT CH_ArrivalDate CHECK(ArrivalDate < ReturnDate)

--02. Insert 

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES 
	('John', 'Smith', 'Smith', 34, '1975-07-21',	'j_smith@gmail.com'),
	('Gosho', NULL,	'Petrov', 11, '1978-05-16',	'g_petrov@gmail.com'),
	('Ivan', 'Petrovich', 'Pavlov', 59,	'1849-09-26', 'i_pavlov@softuni.bg'),
	('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
	(101, '2015-04-12',	'2015-04-14', '2015-04-20',	'2015-02-02'),
	(102, '2015-07-07',	'2015-07-15', '2015-07-22',	'2015-04-29'),
	(103, '2013-07-17',	'2013-07-23', '2013-07-24',	NULL),
	(104, '2012-03-17',	'2012-03-31', '2012-04-01',	'2012-01-10'),
	(109, '2017-08-07',	'2017-08-28', '2017-08-29',	NULL)

--03. Update

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

--04. Delete 

DELETE FROM AccountsTrips
WHERE AccountId = 47

--05. Bulgarian Cities 

SELECT Id, [Name] 
FROM Cities
WHERE CountryCode = 'BG'
ORDER BY [Name]

--06. People Born After 1991 

SELECT 
	CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name],
	DATEPART(YEAR, BirthDate) AS BirthYear
FROM Accounts
WHERE DATEPART(YEAR, BirthDate) > 1991
ORDER BY 
	BirthYear DESC, 
	FirstName

--07. EEE-Mails 

SELECT 
	a.FirstName, 
	a.LastName, 
	FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
	c.[Name] AS Hometown,
	a.Email
FROM Accounts AS a 
JOIN Cities AS c ON c.Id = a.CityId
WHERE a.Email LIKE('e%')
ORDER BY Hometown DESC

--08. City Statistics 

SELECT 
	c.[Name] AS City, 
	COUNT(h.Id) AS Hotels
FROM Cities AS c 
LEFT JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC, City

--09. Expensive First Class Rooms 

SELECT 
	r.Id, 
	r.Price, 
	h.[Name] AS Hotel, 
	c.[Name] AS City
FROM Rooms AS r 
JOIN Hotels AS h ON h.Id = r.HotelId 
JOIN Cities AS c ON c.Id = h.CityId
WHERE r.[Type] = 'First Class'
ORDER BY 
	r.Price DESC, 
	r.Id

--10. Longest and Shortest Trips 

SELECT
	a.Id AS AccountId,
	CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
	MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip, 
	MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a 
JOIN AccountsTrips AS acct ON acct.AccountId = a.Id
JOIN Trips AS t ON t.Id  = acct.TripId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY 
	a.Id, 
	a.FirstName, 
	a.LastName
ORDER BY 
	LongestTrip DESC, 
	a.Id

--11. Metropolis 

SELECT TOP(5)
	c.Id, 
	c.[Name] AS City, 
	c.CountryCode AS Country, 
	COUNT(a.Id) AS Accounts 
FROM Cities AS c 
JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY 
	c.[Name], 
	c.Id, 
	c.CountryCode
ORDER BY Accounts DESC

--12. Romantic Getaways 

SELECT 
	a.Id, 
	a.Email, 
	c.[Name] AS City, 
	COUNT(c.[Name]) AS Trips
FROM Accounts AS a 
JOIN AccountsTrips AS acct ON acct.AccountId = a.Id
JOIN Trips AS t ON t.Id = acct.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY 
	a.Id, 
	a.Email, 
	c.[Name] 
ORDER BY 
	Trips DESC, 
	a.Id

--13. Lucrative Destinations 

SELECT TOP(10)
	c.Id,
	c.[Name],
	SUM(h.BaseRate + r.Price) AS [Total Revenue],
	COUNT(t.Id) AS Trips
FROM Trips AS t
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE DATEPART(YEAR, t.BookDate) = 2016
GROUP BY 
	c.Id, 
	c.[Name]
ORDER BY 
	[Total Revenue] DESC, 
	COUNT(t.Id) DESC

--14. Trip Revenues 

SELECT 
	t.Id, 
	h.[Name] AS HotelName, 
	r.[Type] AS RoomType,
	CASE
		WHEN t.CancelDate IS NOT NULL THEN 0
		ELSE SUM(h.BaseRate + r.Price)
	END AS Revenue
FROM Trips AS t
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN AccountsTrips AS ac ON ac.TripId = t.Id
GROUP BY 
	t.Id, 
	h.[Name], 
	r.[Type],
	t.CancelDate
ORDER BY 
	r.[Type], 
	t.Id

--15. Top Travelers 

--First Solution
SELECT 
	k.AccountId, 
	k.Email, 
	k.CountryCode, 
	k.Trips
FROM
	(SELECT 
		a.Id AS AccountId, 
		a.Email, 
		c.CountryCode, 
		COUNT(*) AS Trips,
		DENSE_RANK() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(*) DESC, a.Id) AS [Rank]
	FROM Accounts a
	JOIN AccountsTrips ac on a.Id = ac.AccountId
	JOIN Trips t on ac.TripId = t.Id
	JOIN Rooms r on T.RoomId = r.Id
	JOIN Hotels h on r.HotelId = h.Id
	JOIN Cities c on h.CityId = c.Id
	GROUP BY 
		c.CountryCode,
		a.Email, 
		a.Id) AS k
WHERE k.[Rank] = 1
ORDER BY 
	Trips DESC,
	AccountId

--Second Solution
SELECT 
	k.AccountId, 
	k.Email, 
	k.CountryCode, 
	k.Trips
FROM
	(SELECT 
		a.Id AS AccountId, 
		a.Email, 
		c.CountryCode, 
		COUNT(*) AS Trips,
		ROW_NUMBER() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(*) DESC) AS [Rank]
	FROM Accounts a
	JOIN AccountsTrips ac on a.Id = ac.AccountId
	JOIN Trips t on ac.TripId = t.Id
	JOIN Rooms r on T.RoomId = r.Id
	JOIN Hotels h on r.HotelId = h.Id
	JOIN Cities c on h.CityId = c.Id
	GROUP BY 
		c.CountryCode,
		a.Email, 
		a.Id) AS k
WHERE k.[Rank] = 1
ORDER BY 
	Trips DESC,
	AccountId

--16. Luggage Fees

SELECT 
	ac.TripId, 
	SUM(ac.Luggage) AS Luggage,
	CASE
		WHEN SUM(ac.Luggage) > 5 THEN CONCAT('$', SUM(ac.Luggage) * 5)
		ELSE CONCAT('$', 0)
	END AS Fee
FROM Accounts AS a 
JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
WHERE ac.Luggage > 0
GROUP BY ac.TripId
ORDER BY SUM(ac.Luggage) DESC

--17. GDPR Violation 

SELECT 
	t.Id,
	CONCAT(FirstName, ' ', ISNULL(MiddleName + ' ', ''), LastName) AS [Full Name],
	ci.[Name] AS [From],
	c.[Name] AS [To],
	CASE
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
	END AS Duration
FROM Accounts AS a 
JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
JOIN Trips AS t ON t.Id = ac.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
JOIN Cities AS ci ON ci.Id = a.CityId
ORDER BY 
	[Full Name],
	t.Id
GO

--18. Available Room -> 5/7

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @result NVARCHAR(MAX)

	DECLARE @roomId INT = (SELECT TOP (1) r.Id
						   FROM Hotels AS h 
						   JOIN Rooms AS r ON r.HotelId = h.Id 
						   JOIN Trips AS t ON t.RoomId = r.Id
						   WHERE
								h.Id = @HotelId 
								AND ((@Date NOT BETWEEN t.ArrivalDate AND T.ReturnDate 
								AND t.CancelDate IS NULL) OR t.CancelDate IS NOT NULL)
								AND r.Beds > @People
						   ORDER BY (h.BaseRate + r.Price) * @People DESC )
	
	IF @roomId IS NULL
	BEGIN
		SET @result = 'No rooms available'
		RETURN @result
	END

	DECLARE @roomType NVARCHAR(20) = (SELECT [Type] FROM Rooms WHERE Id = @roomId)
	DECLARE @roomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @roomId)
	DECLARE @totalPrice DECIMAL(15,2) = (SELECT TOP (1) (h.BaseRate + r.Price) * @People AS TotalRoomPrice
						   FROM Hotels AS h 
						   JOIN Rooms AS r ON r.HotelId = h.Id 
						   WHERE r.Id = @roomId
						   ORDER BY TotalRoomPrice DESC )


	SET @result = CONCAT('Room ',@roomId,': ',@roomType,' (',@roomBeds,' beds) - $',@totalPrice)
	RETURN @result
END
 
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
GO

--19. Switch Room 
CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	BEGIN TRANSACTION
			
		DECLARE @sourceHotelId INT = (SELECT h.Id
									  FROM Hotels h
                                      JOIN Rooms r on h.Id = r.HotelId
                                      JOIN Trips t on r.Id = t.RoomId
                                      WHERE t.Id = @TripId)
		DECLARE @targetHotelId INT = (SELECT h.Id
									  FROM Hotels AS h 
									  JOIN Rooms AS r ON r.HotelId = h.Id 
									  WHERE r.Id = @TargetRoomId)

		IF @sourceHotelId <> @targetHotelId
		BEGIN
			ROLLBACK
			RAISERROR('Target room is in another hotel!', 16, 1)
			RETURN
		END

		DECLARE @targetRoomBeds INT = (SELECT TOP(1) Beds FROM Rooms WHERE Id = @TargetRoomId)
		DECLARE @tripAccounts INT = (SELECT COUNT(*) 
									 FROM Accounts AS a 
									 JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
									 JOIN Trips AS t ON t.Id = ac.TripId
									 WHERE t.Id = @TripId)
		IF @targetRoomBeds < @tripAccounts
		BEGIN
			ROLLBACK
			RAISERROR('Not enough beds in target room!', 16, 2)
			RETURN
		END

		UPDATE Trips
		SET  RoomId = @TargetRoomId
		WHERE Id = @TripId

	COMMIT
END

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
GO

--20. Cancel Trip 

CREATE OR ALTER TRIGGER tr_CancelTrip ON Trips INSTEAD OF DELETE
AS
BEGIN
	UPDATE Trips
	SET CancelDate = GETDATE()
	WHERE Id IN (SELECT Id FROM deleted) AND CancelDate IS NULL
END

DELETE FROM Trips
WHERE Id IN (48, 49, 50)

