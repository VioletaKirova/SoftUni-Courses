CREATE DATABASE ColonialJourney

USE ColonialJourney

--01. DDL

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) NOT NULL CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(10) CHECK(LEN(CardNumber) = 10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8) NOT NULL CHECK(JobDuringJourney IN('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

--02. Insert 

INSERT INTO Planets([Name])
VALUES 
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO Spaceships ([Name],	Manufacturer, LightSpeedRate)
VALUES
	('Golf', 'VW', 3),
	('WakaWaka', 'Wakanda', 4),
	('Falcon9', 'SpaceX', 1),
	('Bed', 'Vidolov', 6)

--03. Update 

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--04. Delete
DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN(1,2,3)

--05. Select All Travel Cards 

SELECT 
	CardNumber, 
	JobDuringJourney 
FROM TravelCards 
ORDER BY CardNumber

--06. Select All Colonists 

SELECT 
	Id, 
	CONCAT(FirstName, ' ', LastName) AS FullName, 
	Ucn 
FROM Colonists
ORDER BY
	FirstName,
	LastName,
	Id

--07. Select All Military Journeys 

SELECT 
	Id,
	CONVERT(VARCHAR, JourneyStart, 103) AS JourneyStart,
	CONVERT(VARCHAR, JourneyEnd, 103) AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--08. Select All Pilots 

SELECT 
	c.Id, 
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName  
FROM Colonists AS c JOIN TravelCards AS tc ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

--09. Count Colonists 

SELECT COUNT(*) AS [Count]
FROM Colonists AS c 
JOIN TravelCards AS tc ON c.Id = tc.ColonistId 
JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

--10. Select The Fastest Spaceship 

SELECT TOP(1)
	s.[Name] AS SpaceshipName, 
	sp.[Name] AS SpaceportName
FROM Spaceships AS s 
JOIN Journeys AS j ON s.Id = j.SpaceshipId 
JOIN Spaceports AS sp ON j.DestinationSpaceportId = sp.Id
ORDER BY s.LightSpeedRate DESC

--11. Select Spaceships With Pilots 

SELECT 
	s.[Name], 
	s.Manufacturer
FROM Spaceships AS s 
JOIN Journeys AS j ON s.Id = j.SpaceshipId 
JOIN TravelCards AS tc ON j.Id = tc.JourneyId
JOIN Colonists AS c ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, c.BirthDate, '2019-01-01') < 30
ORDER BY s.[Name]

--12. Select All Educational Mission

SELECT 
	p.[Name], 
	s.[Name] 
FROM Planets AS p 
JOIN Spaceports AS s ON p.Id = s.PlanetId
JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
WHERE Purpose = 'Educational'
ORDER BY s.[Name] DESC

--13. Planets And Journeys 

SELECT 
	p.[Name], 
	COUNT(p.[Name]) AS JourneysCount
FROM Planets AS p 
JOIN Spaceports AS s ON p.Id = s.PlanetId
JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY JourneysCount DESC, p.[Name]

--14. Extract The Longest Journey 

SELECT TOP(1) 
	j.Id, 
	p.[Name] AS PlanetName, 
	s.[Name] AS SpaceportName, 
	j.Purpose AS JourneyPurpose
FROM Planets AS p 
JOIN Spaceports AS s ON p.Id = s.PlanetId
JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
ORDER BY DATEDIFF(MINUTE, j.JourneyStart, j.JourneyEnd)

--15. Select The Less Popular Job 

SELECT TOP(1) 
	j.Id AS JourneyId, 
	tc.JobDuringJourney AS JobName
FROM Journeys AS j 
JOIN TravelCards AS tc ON j.Id = tc.JourneyId
WHERE JourneyId = 7
GROUP BY j.Id, tc.JobDuringJourney
ORDER BY COUNT(tc.JobDuringJourney)

--16. Select Special Colonists 

SELECT 
	k.JobDuringJourney AS JobName,
	CONCAT(k.FirstName, ' ' ,k.LastName) AS [Name],
	k.[Rank]
FROM
	(SELECT
		tc.JobDuringJourney, 
		c.FirstName,
		c.LastName,
		RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate, c.Id) AS [Rank]
	FROM Colonists AS c 
	JOIN TravelCards AS tc ON c.Id = tc.ColonistId) AS k
WHERE k.[Rank] = 2

--17. Planets and Spaceports 

SELECT p.Name, COUNT(s.Name) AS Count
  FROM Planets AS p
  LEFT JOIN Spaceports AS s ON s.PlanetId = p.Id
GROUP BY p.Name
ORDER BY Count DESC, Name ASC

SELECT
	p.[Name],
	COUNT(s.[Name]) AS [Count]
FROM Planets AS p 
LEFT JOIN Spaceports AS s ON p.Id = s.PlanetId
GROUP BY p.[Name]
ORDER BY [Count] DESC, [Name]
GO

--18. Get Colonists Count 

CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT 
AS
BEGIN
	DECLARE @result INT = 
		(SELECT COUNT(*)
		FROM Planets AS p 
		JOIN Spaceports AS s ON p.Id = s.PlanetId
		JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
		JOIN TravelCards AS tc ON j.Id = tc.JourneyId
		JOIN Colonists AS c ON tc.ColonistId = c.Id
		WHERE p.[Name] = @PlanetName)

	RETURN @result
END
GO

--19. Change Journey Purpose 

CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
	BEGIN TRANSACTION

		DECLARE @currenId INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)
		
		IF @currenId IS NULL
		BEGIN
			RAISERROR('The journey does not exist!', 16, 1)
			ROLLBACK
			RETURN
		END

		DECLARE @currentPurpose VARCHAR(30) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

		IF @currentPurpose = @NewPurpose
		BEGIN
			RAISERROR('You cannot change the purpose!', 16, 2)
			ROLLBACK
			RETURN
		END

		UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId
	COMMIT
END

--20. Deleted Journeys 

CREATE TABLE DeletedJourneys
(
	Id INT PRIMARY KEY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) NOT NULL CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)
GO

CREATE TRIGGER tr_StoreDeletedJourneys ON Journeys FOR DELETE
AS
BEGIN
	INSERT INTO DeletedJourneys
	SELECT 
		d.Id,
		d.JourneyStart, 
		d.JourneyEnd, 
		d.Purpose, 
		d.DestinationSpaceportId, 
		d.SpaceshipId
	FROM deleted AS d
END
	



