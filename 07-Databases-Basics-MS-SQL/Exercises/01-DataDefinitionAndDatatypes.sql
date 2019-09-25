CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

SET IDENTITY_INSERT Towns ON

INSERT INTO Towns(Id, [Name])
VALUES (1, 'Sofia'), 
(2, 'Plovdiv'), 
(3, 'Varna')

SET IDENTITY_INSERT Towns OFF

SET IDENTITY_INSERT Minions ON

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES (1, 'Kevin', 22, 1), 
(2, 'Bob', 15, 3), 
(3, 'Steward', NULL, 2)

TRUNCATE TABLE Minions

DROP TABLE Minions

DROP TABLE Towns

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height FLOAT(2),
[Weight] FLOAT(2),
Gender VARCHAR(1) NOT NULL CHECK (Gender IN ('m', 'f')),
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES ('Sasho', NULL, NULL, NULL, 'm', '10-DEC-05', NULL),
('Pesho', NULL, NULL, NULL, 'm', '10-DEC-05', NULL),
('Gosho', NULL, NULL, NULL, 'm', '10-DEC-05', NULL),
('Misho', NULL, NULL, NULL, 'm', '10-DEC-05', NULL),
('Tosho', NULL, NULL, NULL, 'm', '10-DEC-05', NULL)

CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL UNIQUE,
[Password] VARCHAR(26) NOT NULL,
Picture VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted VARCHAR(5) NOT NULL CHECK (IsDeleted IN ('true', 'false')),
)

INSERT INTO Users(Username, [Password], Picture, LastLoginTime, IsDeleted)
VALUES ('Sasho', 'pass123', NULL, NULL, 'false'),
('Gosho', 'pass123', NULL, NULL, 'false'),
('Misho', 'pass123', NULL, NULL, 'false'),
('Tosho', 'pass123', NULL, NULL, 'false'),
('Pesho', 'pass123', NULL, NULL, 'false')

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC074AFEE0CD

ALTER TABLE Users
ADD PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CHECK (len([Password])>=5)

ALTER TABLE Users 
ADD DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, [Password], Picture, IsDeleted)
VALUES ('Tisho', 'pass123', NULL, 'false')

ALTER TABLE Users
DROP CONSTRAINT PK__Users__77222459A2DF3BD0

ALTER TABLE Users
ADD CONSTRAINT PK_UserId PRIMARY KEY(Id)

ALTER TABLE Users
ADD CHECK (len(Username)>=3)

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(100) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes)
VALUES ('Aaa Aaa', 'Note1'),
('Bbb Bbb', 'Note2'),
('Ccc Ccc', 'Note3'),
('Ddd Ddd', 'Note4'),
('Eee Eee', 'Note5')

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(100) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Genres(GenreName, Notes)
VALUES ('Drama', 'Note1'),
('Comedy', 'Note2'),
('Horror', 'Note3'),
('Romantic', 'Note4'),
('Romantic Comedy', 'Note5')

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(100) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, Notes)
VALUES ('Category1', 'Note1'),
('Category2', 'Note2'),
('Category3', 'Note3'),
('Category4', 'Note4'),
('Category5', 'Note5')

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(100) NOT NULL,
DirectorId INT NOT NULL FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear DATE NOT NULL,
[Length] INT NOT NULL,
GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
Rating FLOAT(1),
Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES ('Title1', 1, '10-DEC-05', 100, 1, 1, 5.5, 'Note1'),
('Title2', 2, '10-DEC-05', 100, 2, 2, 5.5, 'Note2'),
('Title3', 3, '10-DEC-05', 100, 3, 3, 5.5, 'Note3'),
('Title4', 4, '10-DEC-05', 100, 4, 4, 5.5, 'Note4'),
('Title5', 5, '10-DEC-05', 100, 5, 5, 5.5, 'Note5')

CREATE DATABASE CarRental

USE CarRental

--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(100) NOT NULL,
DailyRate FLOAT(2),
WeeklyRate FLOAT(2),
MonthlyRate FLOAT(2),
WeekendRate FLOAT(2)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('Name1', NULL, NULL, NULL, NULL),
('Name2', NULL, NULL, NULL, NULL),
('Name3', NULL, NULL, NULL, NULL)

--Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber INT NOT NULL,
Manufacturer NVARCHAR(100) NOT NULL,
Model NVARCHAR(100) NOT NULL,
CarYear CHAR(4) NOT NULL,
CategoryId INT NOT NULL,
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(100) NOT NULL,
Available BINARY(1)
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES (1, 'BMW', 'e92', '2015', 123, 5, NULL, 'New', 1),
(2, 'Fiat', 'Punto', '200', 456, 3, NULL, 'Used', 0),
(3, 'VW', '2', '1990', 789, 5, NULL, 'Used', 1)

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
Title NVARCHAR(100) NOT NULL,
Notes NVARCHAR(MAX),
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Pesho', 'Georgiev', 'Shefa', NULL),
('Tosho', 'Stamov', 'Roba', NULL),
('Misho', 'Mishev', 'Bosa Na Kokosa', NULL)

--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(100) NOT NULL,
[Address] NVARCHAR(200) NOT NULL,
City NVARCHAR(100) NOT NULL,
ZIPCode CHAR(4) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES (123, 'Sasho', 'Sofeto', 'Sofia', '1000', NULL),
(456, 'Prakash', 'Pomorie', 'Pm Ve', '9999', NULL),
(789, 'Stanio', 'BsKs', 'Burgas', '5555', NULL)

/*RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, 
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, 
TaxRate, OrderStatus, Notes)*/
CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
CarId INT NOT NULL FOREIGN KEY REFERENCES Cars(Id),
TankLevel INT NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays INT NOT NULL,
RateApplied FLOAT(2) NOT NULL,
TaxRate FLOAT(2) NOT NULL,
OrderStatus NVARCHAR(100) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart,KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES (1, 1, 1, 10, 10, 10, 10, '10-DEC-05', '10-DEC-06', 365, 1.12, 1.34, 'Ordered', NULL),
(2, 2, 2, 20, 20, 20, 10, '10-DEC-05', '10-DEC-06', 365, 1.78, 1.45, 'NotOrdered', NULL),
(3, 3, 3, 30, 30, 30, 10, '10-DEC-05', '10-DEC-06', 365, 1.56, 1.89, 'Ordered', NULL)

CREATE DATABASE Hotel

USE Hotel

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
Title NVARCHAR(100) NOT NULL,
Notes NVARCHAR(MAX),
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Simbata', 'Toshev', 'DiBoss', NULL),
('Conio', 'Conev', 'Rabotqga', NULL),
('Sasho-Shefa', 'Draganov', 'BigBrother', NULL)

--Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
PhoneNumber INT NOT NULL,
EmergencyName NVARCHAR(100) NOT NULL,
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES ('Marcheto', 'Georgieva', '0878453945', 'Mimkata', '112', NULL),
('Ankata', 'Ilieva', '0888963245', 'AnkataEi', '456', NULL),
('Iliqnkata', 'IvanovTuning', '0876737666', 'Iliqn', '69', NULL)

--RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(100) NOT NULL PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES ('Clean', NULL),
('Dirty', NULL),
('Other', NULL)

--RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes(
RoomType NVARCHAR(100) NOT NULL PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType, Notes)
VALUES ('Big', NULL),
('Small', NULL),
('Semi', NULL)

--BedTypes (BedType, Notes)
CREATE TABLE BedTypes(
BedType NVARCHAR(100) NOT NULL PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType, Notes)
VALUES ('KingSize', NULL),
('Huge', NULL),
('Tiny', NULL)

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES BedTypes(BedType),
Rate FLOAT(1),
RoomStatus NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes)
VALUES ('Big', 'KingSize', NULL, 'Clean', NULL),
('Small', 'Huge', NULL, 'Dirty', NULL),
('Semi', 'Tiny', NULL, 'Other', NULL)

/*Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, 
LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)*/
CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE NOT NULL,
AccountNumber INT NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays INT NOT NULL,
AmountCharged INT NOT NULL,
TaxRate FLOAT(2),
TaxAmount INT NOT NULL,
PaymentTotal INT NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES (1, '10-DEC-05', 123, '11-DEC-05','15-DEC-05', 5, 2000, 3.22, 665, 2665, NULL),
(1, '12-DEC-05', 123, '13-DEC-05','14-DEC-05', 1, 200, 3.11, 120, 320, NULL),
(1, '5-DEC-05', 123, '10-DEC-05','13-DEC-05', 3, 1000, 3.33, 200, 1200, NULL)

/*Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, 
RateApplied, PhoneCharge, Notes)*/
CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE NOT NULL,
AccountNumber INT NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied FLOAT(1),
PhoneCharge INT NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES (1, '11-DEC-05', 123, 1, 1.2, 20, NULL),
(2, '12-DEC-05', 456, 2, 1.3, 30, NULL),
(3, '13-DEC-05', 789, 3, 1.4, 40, NULL)

CREATE DATABASE SoftUni

USE SoftUni

--Towns (Id, Name)
CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL
)

--Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText VARCHAR(100) NOT NULL,
TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

--Departments (Id, Name)
CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL
)

--Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(100) NOT NULL,
MiddleName VARCHAR(100),
LastName VARCHAR(100),
JobTitle VARCHAR(100) NOT NULL,
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id),
HireDate DATETIME NOT NULL,
Salary FLOAT(2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--Towns: Sofia, Plovdiv, Varna, Burgas
INSERT INTO Towns([Name])
VALUES ('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

--Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
INSERT INTO Departments([Name])
VALUES ('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

--Ivan Ivanov Ivanov	.NET Developer	Software Development	01/02/2013	3500.00
--Petar Petrov Petrov	Senior Engineer	Engineering	02/03/2004	4000.00
--Maria Petrova Ivanova	Intern	Quality Assurance	28/08/2016	525.25
--Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
--Peter Pan Pan	Intern	Marketing	28/08/2016	599.88
INSERT INTO Employees(FirstName, JobTitle, DepartmentId, HireDate, Salary)
VALUES ('Ivan Ivanov Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00),
('Petar Petrov Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00),
('Maria Petrova Ivanova', 'Intern', 5, '2016/08/28', 525.25),
('Georgi Teziev Ivanov', 'CEO', 2, '2007/12/09', 3000.00),
('Peter Pan Pan', 'Intern', 3, '2016/08/28', 599.88)

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

SELECT * FROM Towns
ORDER BY [Name]
SELECT * FROM Departments
ORDER BY [Name]
SELECT * FROM Employees
ORDER BY Salary DESC

SELECT [Name] FROM Towns
ORDER BY [Name]
SELECT [Name] FROM Departments
ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary += Salary * 0.1
SELECT Salary FROM Employees

USE Hotel

UPDATE Payments
SET TaxRate -= TaxRate * 0.03
SELECT TaxRate FROM Payments

TRUNCATE TABLE Occupancies
