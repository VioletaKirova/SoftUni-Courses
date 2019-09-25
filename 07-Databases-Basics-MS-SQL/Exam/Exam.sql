CREATE DATABASE School

USE School

--01. DDL 

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK(Age BETWEEN 5 AND 100),
	[Address] NVARCHAR(50),
	Phone NVARCHAR(10) CHECK(LEN(Phone) = 10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)

CREATE TABLE StudentsExams
(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL,

	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)

CREATE TABLE StudentsTeachers
(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,

	CONSTRAINT PK_StudentsTeachers PRIMARY KEY(StudentId, TeacherId)
)

--02. Insert 

INSERT INTO Teachers (FirstName,	LastName,	[Address],	Phone,	SubjectId)
VALUES
('Ruthanne',	'Bamb',	'84948 Mesta Junction',	'3105500146',	6),
('Gerrard',	'Lowin',	'370 Talisman Plaza',	'3324874824',	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	'4373065154',	5),
('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4)

INSERT INTO Subjects([Name], Lessons)
VALUES
('Geometry',	12),
('Health',	10),
('Drama',	7),
('Sports',	9)

--03. Update 

UPDATE StudentsSubjects
SET Grade = 6
WHERE SubjectId IN(1, 2) AND Grade >= 5.5

--04. Delete 
DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE ('%72%'))

DELETE FROM Teachers 
WHERE Phone LIKE ('%72%')

--05. Teen Students 

SELECT 
	FirstName,
	LastName,
	Age
FROM Students
WHERE Age >= 12
ORDER BY
	FirstName,
	LastName
	
--06. Cool Addresses 

SELECT 
	CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name],
	[Address]
FROM Students
WHERE [Address] LIKE '%road%'
ORDER BY
	FirstName,
	LastName,
	[Address]

--07. 42 Phones 

SELECT 
	FirstName, 
	[Address], 
	Phone 
FROM Students
WHERE MiddleName IS NOT NULL AND Phone LIKE '42%'
ORDER BY FirstName

--08. Students Teachers 

SELECT 
	s.FirstName, 
	s.LastName,
	COUNT(t.Id)
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
JOIN Teachers AS t ON t.Id = st.TeacherId
GROUP BY 
	s.FirstName, 
	s.LastName

--09. Subjects with Students

SELECT 
	CONCAT(k.FirstName, ' ', k.LastName) AS FullName,
	CONCAT(k.SubjectName, '-',	k.LessonsCount) AS Subjects,
	COUNT(*) AS Students
FROM
	(SELECT
		t.Id,
		t.FirstName,
		t.LastName,
		su.[Name] AS SubjectName,
		SUM(Lessons) AS LessonsCount
	FROM Teachers AS t 
	JOIN Subjects AS su ON su.Id = t.SubjectId
	GROUP BY
		t.Id,
		t.FirstName,
		t.LastName,
		su.[Name]) AS k
JOIN StudentsTeachers AS st ON st.TeacherId = k.Id
GROUP BY 
	k.FirstName,
	k.LastName,
	k.SubjectName,
	k.LessonsCount
ORDER BY 
	Students DESC

--10. Students to Go 

SELECT CONCAT(FirstName, ' ', LastName) AS [FullName] 
FROM Students AS s 
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id 
LEFT JOIN Exams AS e ON e.Id = se.ExamId
LEFT JOIN Subjects AS su ON su.Id = e.SubjectId
WHERE se.StudentId IS NULL
ORDER BY FullName

--11. Busiest Teachers

SELECT TOP(10)
	k.FirstName,
	k.LastName,  
	COUNT(*) AS StudentsCount
FROM
	(SELECT
		t.Id,
		t.FirstName, 
		t.LastName
	FROM Teachers AS t 
	JOIN Subjects AS su ON su.Id = t.SubjectId
	GROUP BY
		t.Id,
		t.FirstName,
		t.LastName,
		su.[Name]) AS k
JOIN StudentsTeachers AS st ON st.TeacherId = k.Id
GROUP BY 
	k.FirstName,
	k.LastName 
ORDER BY 
	StudentsCount DESC,
	k.FirstName,
	k.LastName

--12. Top Students 

SELECT TOP(10)
	s.FirstName,
	s.LastName,
	FORMAT(AVG(se.Grade), 'N2') AS Grade
FROM Students AS s 
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id 
LEFT JOIN Exams AS e ON e.Id = se.ExamId
LEFT JOIN Subjects AS su ON su.Id = e.SubjectId
GROUP BY
	s.FirstName,
	s.LastName
ORDER BY
	Grade DESC,
	s.FirstName,
	s.LastName

--13. Second Highest Grade 

SELECT 
	k.FirstName, 
	k.LastName,
	k.Grade
FROM
	(SELECT 
		s.FirstName, 
		s.LastName,
		ss.Grade,
		ROW_NUMBER() OVER (PARTITION BY ss.StudentId ORDER BY ss.Grade DESC) AS [Rank]
	FROM Students AS s
	JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
	JOIN Subjects AS su ON su.Id = ss.SubjectId) AS k
WHERE [Rank] = 2
ORDER BY 
	k.FirstName, 
	k.LastName

--14. Not So In The Studying 

SELECT CONCAT(s.FirstName, ' ', ISNULL(s.MiddleName + ' ', ''), s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
LEFT JOIN Subjects AS su ON su.Id = ss.SubjectId
WHERE su.Id IS NULL
ORDER BY [Full Name]

--15. Top Student per Teacher 

SELECT 
	CONCAT(j.TeacherFN, ' ', j.TeacherLN) AS [Teacher Full Name],
	j.SubjectName AS [Subject Name],
	CONCAT(j.StudentFN, ' ', j.StudentLN) AS [Student Full Name],
	j.Grade
FROM
	(SELECT 
		k.FirstName AS TeacherFN,
		k.LastName AS TeacherLN,
		k.SubjectName,
		s.FirstName AS StudentFN,
		s.LastName AS StudentLN,
		FORMAT(AVG(ss.Grade), 'N2') AS Grade,
		ROW_NUMBER() OVER (PARTITION BY k.FirstName, k.LastName ORDER BY AVG(ss.Grade) DESC) AS [Rank]
	FROM
		(SELECT
			t.Id,
			t.FirstName,
			t.LastName,
			t.SubjectId,
			su.[Name] AS SubjectName
		FROM Teachers AS t 
		JOIN Subjects AS su ON su.Id = t.SubjectId
		GROUP BY
			t.Id,
			t.FirstName,
			t.LastName,
			t.SubjectId,
			su.[Name]) AS k
	JOIN Subjects AS su ON su.Id = k.SubjectId
	JOIN StudentsSubjects AS ss ON ss.SubjectId = su.Id
	JOIN Students AS s ON s.Id = ss.StudentId
	JOIN StudentsTeachers AS st ON st.StudentId = s.Id
	WHERE st.TeacherId = k.Id
	GROUP BY 
		k.FirstName,
		k.LastName,
		k.SubjectName,
		s.FirstName,
		s.LastName) AS j
WHERE j.[Rank] = 1
ORDER BY 
	j.SubjectName,
	[Teacher Full Name],
	j.Grade DESC

--16. Average Grade per Subject 

SELECT 
	s.[Name],
	AVG(ss.Grade) AS AverageGrade
FROM Subjects AS s 
JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
GROUP BY s.Id, s.[Name]
ORDER BY s.Id

--17. Exams Information 

SELECT
	k.[Quarter],
	k.SubjectName,
	SUM(k.StudentsCount) AS StudentsCount
FROM
	(SELECT 
		CASE
			WHEN DATEPART(MONTH, e.Date) IN (1,2,3) THEN 'Q1'
			WHEN DATEPART(MONTH, e.Date) IN (4,5,6) THEN 'Q2'
			WHEN DATEPART(MONTH, e.Date) IN (7,8,9) THEN 'Q3'
			WHEN DATEPART(MONTH, e.Date) IN (10,11,12) THEN 'Q4'
			ELSE 'TBA'
		END AS [Quarter],
		s.[Name] AS SubjectName,
		COUNT(*) AS StudentsCount
	FROM Exams AS e
	JOIN StudentsExams AS se ON se.ExamId = e.Id
	JOIN Subjects AS s ON s.Id = e.SubjectId
	WHERE se.Grade >= 4
	GROUP BY 
		s.[Name], 
		e.[Date]) AS k
GROUP BY 
	k.[Quarter],
	k.SubjectName
ORDER BY
	k.[Quarter]

--18. Exam Grades 
GO
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @result VARCHAR(MAX)
	DECLARE @targetStudentId INT = (SELECT Id FROM Students WHERE Id = @studentId)

	IF @targetStudentId IS NULL
	BEGIN
		SET @result = 'The student with provided id does not exist in the school!'
		RETURN @result
	END

	IF @grade > 6
	BEGIN
		SET @result = 'Grade cannot be above 6.00!'
		RETURN @result
	END

	DECLARE @maxGrade DECIMAL(15,2) = @grade + 0.5

	DECLARE @gradesCount INT = (SELECT COUNT(*) 
								FROM StudentsExams 
								WHERE StudentId = @studentId AND Grade BETWEEN @grade AND @maxGrade)

	DECLARE @studentFirstName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	SET @result = CONCAT('You have to update ', @gradesCount ,' grades for the student ', @studentFirstName)
	RETURN @result
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--19. Exclude From School 
GO
CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @targetStudentId INT = (SELECT Id FROM Students WHERE Id = @studentId)

		IF @targetStudentId IS NULL
		BEGIN
			ROLLBACK
			RAISERROR('This school has no student with the provided id!', 16,1)
			RETURN
		END

		DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId
		
		DELETE FROM StudentsExams
		WHERE StudentId = @StudentId
		
		DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId
		
		DELETE FROM Students 
		WHERE Id = @StudentId
	COMMIT
END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

--20. Deleted Students 

CREATE TABLE ExcludedStudents
(
	StudentId INT PRIMARY KEY, 
	StudentName VARCHAR(MAX)
)

GO
CREATE TRIGGER tr_ExcludingStudents ON Students FOR DELETE
AS
BEGIN
	INSERT INTO ExcludedStudents
	SELECT Id, CONCAT(FirstName, ' ', LastName)
	FROM deleted
END
