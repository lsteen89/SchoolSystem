
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
		YearGrade VARCHAR(10) NOT NULL,
		TeacherPersoid VARCHAR(20) NOT NULL
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
        YearGrade varchar(10),
		Role int,
		StartDate datetime NOT NULL,
		EndDate datetime,
		Persoid VARCHAR(20) NOT NULL PRIMARY KEY
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
		LoginName varchar(50) NOT NULL UNIQUE,
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

/*
CREATE PROCEDURE CreateUser 
       @FirstName           NVARCHAR(30),
       @LastName            NVARCHAR(30),
       @Password			varchar(100),
	   @DateOfBirth			datetime,
	   @YearGrade			Varchar(10),
       @Role                int,
	   @Teacher				Varchar(20)

AS 
BEGIN 
     SET NOCOUNT ON 
	 
	 
	 declare @persoid varchar(10) = LEFT(CONVERT(VARCHAR(36), NEWID()), 10)
	 while exists ((select NULL from Users where LoginName = @persoid))
	 BEGIN
		SET @persoid = LEFT(CONVERT(VARCHAR(36), NEWID()), 10)
	 END

     INSERT INTO Users
	 SELECT
		@persoid,
        CONCAT(SUBSTRING(@FirstName, 1, 3), (SUBSTRING(@LastName, 1, 3))), --LOGINNAME
        @Password,
        @Role,
		'Admin', --REGSIGN
		getdate() --TIME
          

	if(@Role = 1) --Role 1 = Teacher
	BEGIN
	INSERT INTO Teachers
		SELECT
			@FirstName,
			@LastName,
			@persoid,
			@DateOfBirth,
			@YearGrade

	INSERT INTO YearGrade
		SELECT
			@YearGrade,
			@Role,
			GETDATE(),
			NULL,
			@persoid
	END

	ELSE -- ELSE STUDENT
	BEGIN
	INSERT INTO Students
		SELECT
			@FirstName,
			@LastName,
			@persoid,
			@DateOfBirth,
			@YearGrade,
			@Teacher

	INSERT INTO YearGrade
		SELECT
			@YearGrade,
			@Role,
			GETDATE(),
			NULL,
			@persoid
	END
		
		 
END 

GO
*/

--exec CreateUser Linus, 'moller', test123, '20090101', 1, 1, null
--exec CreateUser Karl, 'moller', test123, '20090101', 1, 2, 'F168A1EE-0'

