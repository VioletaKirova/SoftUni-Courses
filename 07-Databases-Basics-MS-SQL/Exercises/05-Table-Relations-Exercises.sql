--Task 1--
CREATE DATABASE Relations

USE Relations

CREATE TABLE 
	Persons(
		PersonID INT NOT NULL,
		FirstName VARCHAR(50),
		Salary MONEY,
		PassportID INT UNIQUE)

ALTER TABLE Persons
ALTER COLUMN Salary DECIMAL

INSERT INTO 
	Persons (PersonID, FirstName, Salary, PassportID)
VALUES 
	(1, 'Roberto', 43300.00, 102),
	(2, 'Tom', 56100.00, 103),
	(3,'Yana', 60200.00, 101)

CREATE TABLE 
	Passports(
		PassportID INT NOT NULL,
		PassportNumber VARCHAR(50) NOT NULL)

INSERT INTO 
	Passports (PassportID, PassportNumber)
VALUES 
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103,'ZE657QP2')

ALTER TABLE 
	Persons
ADD CONSTRAINT 
	PK_Person PRIMARY KEY (PersonID)

ALTER TABLE 
	Passports
ADD CONSTRAINT PK_Passport PRIMARY KEY (PassportID)

ALTER TABLE
	Passports
ADD UNIQUE (PassportNumber)

ALTER TABLE 
	Persons
ADD CONSTRAINT 
	FK_PersonPassport FOREIGN KEY (PassportID) 
REFERENCES 
	Passports(PassportID)

--Task 2--
CREATE TABLE 
	Models (
		ModelID	INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL,	
		ManufacturerID INT NOT NULL)

INSERT INTO  
	Models(ModelID, [Name], ManufacturerID)
VALUES 
	(101, 'X1', 1),
	(102, 'i6', 1),
	(103, 'Model S', 2),
	(104, 'Model X', 2),
	(105, 'Model 3', 2),
	(106, 'Nova', 3)

CREATE TABLE 
	Manufacturers (
		ManufacturerID	INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL,	
		EstablishedOn DATETIME NOT NULL)

INSERT INTO 
	Manufacturers(ManufacturerID, [Name], EstablishedOn)
VALUES 
	(1, 'BMW', '07/03/1916'),
	(2, 'Tesla', '01/01/2003'),
	(3, 'Lada', '01/05/1966')

ALTER TABLE 
	Models
ADD CONSTRAINT 
	FK_ModelManufacturer FOREIGN KEY (ManufacturerID) 
REFERENCES 
	Manufacturers(ManufacturerID)

--Task 3--
CREATE TABLE 
	Students(
		StudentID  INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL)

INSERT INTO 
	Students
VALUES 
	(1, 'Mila'),
	(2, 'Toni'),
	(3, 'Ron')

CREATE TABLE 
	Exams(
		ExamID  INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL)

INSERT INTO 
	Exams
VALUES 
	(101, 'SpringMVC'),
	(102, 'Neo4j'),
	(103, 'Oracle 11g')

CREATE TABLE 
	StudentsExams(
	StudentID INT NOT NULL, 
	ExamID INT NOT NULL,
	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID))

INSERT INTO 
	StudentsExams(StudentID, ExamID)
VALUES 
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--Task 4--
CREATE TABLE 
	Teachers(
		TeacherID INT PRIMARY KEY,	
		[Name] VARCHAR(50),
		ManagerID INT
		CONSTRAINT FK_TeacherManager FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID))

INSERT INTO 
	Teachers(TeacherID, [Name], ManagerID)
VALUES 
	(101, 'John', NULL),
	(102, 'Maya', 106),
	(103, 'Silvia', 106),
	(104, 'Ted', 105),
	(105, 'Mark', 101),
	(106, 'Greta', 101)

--Task 5--
CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE 
	ItemTypes(
		ItemTypeID INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL,)

CREATE TABLE 
	Items(
		ItemID INT PRIMARY KEY,
		[Name] VARCHAR (50) NOT NULL,
		ItemTypeID INT NOT NULL,
		CONSTRAINT FK_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID))

CREATE TABLE 
	Cities(
		CityID INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL)

CREATE TABLE 
	Customers(
		CustomerID INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL,
		Birthday DATE,
		CityID INT NOT NULL,
		CONSTRAINT FK_Cities FOREIGN KEY (CityID) REFERENCES Cities(CityID))

CREATE TABLE 
	Orders(
		OrderID INT PRIMARY KEY,
		CustomerID INT NOT NULL,
		CONSTRAINT FK_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID))

CREATE TABLE 
	OrderItems(
		OrderID INT NOT NULL,
		ItemID INT NOT NULL,
		CONSTRAINT PK_OrdersItems PRIMARY KEY (OrderID, ItemID),
		CONSTRAINT FK_OrdersItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
		CONSTRAINT FK_OrdersItems_Items FOREIGN KEY (ItemID) REFERENCES Items(ItemID))

--Task 6--
CREATE DATABASE University 

USE University

CREATE TABLE 
	Subjects(
		SubjectID INT PRIMARY KEY,
		SubjectName VARCHAR(50) NOT NULL)

CREATE TABLE 
	Students(
		StudentID INT PRIMARY KEY,
		StudentNumber INT NOT NULL,
		StudentName VARCHAR(50) NOT NULL,
		MajorID INT NOT NULL)

CREATE TABLE 
	Majors(
		MajorID INT PRIMARY KEY,
		[Name] VARCHAR(50) NOT NULL)

ALTER TABLE 
	Students
ADD CONSTRAINT 
	FK_Majors FOREIGN KEY (MajorID) 
REFERENCES 
	Majors(MajorID)

CREATE TABLE 
	Payments(
		PaymentID INT PRIMARY KEY,
		PaymentDate DATE NOT NULL,
		PaymentAmount MONEY NOT NULL,
		StudentID INT NOT NULL,
		CONSTRAINT FK_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID))

CREATE TABLE 
	Agenda(
		StudentID INT NOT NULL,
		SubjectID INT NOT NULL,
		CONSTRAINT PK_StudentsSubjects PRIMARY KEY (StudentID, SubjectID),
		CONSTRAINT FK_StudentsSubjects_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
		CONSTRAINT FK_StudentsSubjects_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID))

--Task 9--
--First Solution:
SELECT 
	MountainRange, 
	PeakName, 
	Elevation 
FROM
	Mountains,
	Peaks
WHERE
	MountainRange = 'Rila' AND MountainID = 17
ORDER BY 
	Elevation DESC

--Second solution:
SELECT 
	MountainRange,
	PeakName,
	Elevation
FROM 
	Mountains JOIN Peaks ON Mountains.Id = Peaks.MountainId
WHERE
	MountainRange = 'Rila'
ORDER BY 
	Elevation DESC


