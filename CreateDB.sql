  IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'SchoolSystem')
  BEGIN
    CREATE DATABASE SchoolSystem


    END
    GO
       USE SchoolSystem
    GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Students' and xtype='U')
BEGIN
    CREATE TABLE Students (
		Id INT IDENTITY (1, 1),
        FirstName nvarchar(30) NOT NULL,
		LastName nvarchar(30) NOT NULL,
		Persoid VARCHAR(20) NOT NULL UNIQUE,
		DateOfBirth datetime NOT NULL,
		YearGrade int NOT NULL,
		PRIMARY KEY(Persoid, Id)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Teachers' and xtype='U')
BEGIN
    CREATE TABLE Teachers (
        Id INT IDENTITY (1, 1) NOT NULL,
        FirstName nvarchar(30) NOT NULL,
		LastName nvarchar(30) NOT NULL,
		Persoid VARCHAR(20) NOT NULL UNIQUE,
		DateOfBirth datetime NOT NULL,
		YearGrade varchar(10) NOT NULL,
		PRIMARY KEY (Id, Persoid)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='YearGrade' and xtype='U')
BEGIN
    CREATE TABLE YearGrade (
        YearGrade varchar(10) PRIMARY KEY,
		StudentsEnrolled int,
		StartDate datetime NOT NULL,
		EndDate datetime,
		Persoid VARCHAR(20) NOT NULL UNIQUE
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Subjects' and xtype='U')
BEGIN
    CREATE TABLE Subjects (
        Id INT IDENTITY (1, 1),
		SubjectName VARCHAR(50) UNIQUE,
        YearGrade VARCHAR(10) NOT NULL UNIQUE,
		StudentsEnrolled int,
		StartDate datetime NOT NULL,
		EndDate datetime,
		PRIMARY KEY(Id, YearGrade, SubjectName)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Grade' and xtype='U')
BEGIN
    CREATE TABLE Grade (
        Id INT IDENTITY (1, 1),
        Persoid VARCHAR(20) NOT NULL UNIQUE,
		SubjectName varchar(50) NOT NULL UNIQUE,
		Grade Varchar(5) NOT NULL,
		YearGrade varchar(10) NOT NULL,
		Comment nvarchar(100),
		Regsign varchar(10) NOT NULL,
		Regtime datetime  NOT NULL
		PRIMARY KEY(Id, Persoid, SubjectName)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')
BEGIN
    CREATE TABLE Users (
        Id INT IDENTITY (1, 1),
        Persoid VARCHAR(20) NOT NULL UNIQUE,
		LoginName varchar(50) NOT NULL,
		Password nvarchar(100) NOT NULL,
		Role int NOT NULL,
		Regsign varchar(10) NOT NULL,
		Regtime datetime NOT NULL
		PRIMARY KEY(Id, persoid)
    )
END

/*
ALTER TABLE Students ADD FOREIGN KEY (Persoid) REFERENCES YearGrade(Persoid)
ALTER TABLE Teachers ADD FOREIGN KEY (Persoid) REFERENCES YearGrade(Persoid)
ALTER TABLE Students ADD FOREIGN KEY (Persoid) REFERENCES Grade(Persoid)
ALTER TABLE YearGrade ADD FOREIGN KEY (YearGrade) REFERENCES Subjects(YearGrade)
ALTER TABLE Grade ADD FOREIGN KEY (SubjectName) REFERENCES Subjects(SubjectName)
ALTER TABLE Users ADD FOREIGN KEY (Persoid) REFERENCES Students(Persoid)
ALTER TABLE Users ADD FOREIGN KEY (Persoid) REFERENCES Teachers(Persoid)

*/
