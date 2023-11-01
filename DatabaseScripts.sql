
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
		DateOfBirth varchar(12) NOT NULL UNIQUE,
		Enrolldate datetime not null,
		ParentPhone varchar(50) NOT NULL,
		ParentEmail varchar(100) NOT NULL,
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
		StartDate datetime NOT NULL,
		EndDate datetime,
		Phone varchar(50) NOT NULL,
		Email varchar(100) NOT NULL,
		PRIMARY KEY (Id, Persoid)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='YearGrade' and xtype='U')
BEGIN
    CREATE TABLE YearGrade (
        YearGrade varchar(10),
		YearGradeID varchar(10),
		StartDate datetime NOT NULL,
		EndDate datetime NOT NULL,
		TeacherPersoid VARCHAR(20),
		Persoid VARCHAR(20) NOT NULL,
		MainTeacher INT,
		PRIMARY KEY(YearGradeID, EndDate, Persoid)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Subjects' and xtype='U')
BEGIN
    CREATE TABLE Subjects (
		SubjectName VARCHAR(50),
        YearGrade VARCHAR(10) NOT NULL,
		StartDate datetime NOT NULL,
		EndDate datetime,
		TeacherPersoid VARCHAR(20),
		Persoid VARCHAR(20) NOT NULL,
		PRIMARY KEY(SubjectName, YearGrade, EndDate)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Grade' and xtype='U')
BEGIN
    CREATE TABLE Grade (
        Id INT IDENTITY (1, 1),
        Persoid VARCHAR(20) NOT NULL UNIQUE,
		SubjectId INT NOT NULL,
		Grade Varchar(5) NOT NULL,
		YearGrade varchar(10) NOT NULL,
		Comment nvarchar(100),
		Regsign varchar(10) NOT NULL,
		Regtime datetime  NOT NULL
		PRIMARY KEY(Id, Persoid, SubjectId)
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')
BEGIN
    CREATE TABLE Users (
        Id INT IDENTITY (1, 1),
        Persoid VARCHAR(20) NOT NULL UNIQUE,
		LoginName varchar(50) NOT NULL UNIQUE,
		Password nvarchar(100) NOT NULL,
		Roles varchar(50) NOT NULL,
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
Roles;
1: Teacher
2: Student
3: Main teacher
*/
/*
CREATE PROCEDURE CreateUser 
       @FirstName           NVARCHAR(30),
       @LastName            NVARCHAR(30),
       @Password			varchar(100),
	   @DateOfBirth			datetime,
	   @StartDate			datetime,
       @Role                Varchar(50),
	   @Email				Varchar(100),
	   @Phone				Varchar(100)
	   
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
        lower(CONCAT(SUBSTRING(@FirstName, 1, 3), (SUBSTRING(@LastName, 1, 3)))), --LOGINNAME
        @Password,
        @Role,
		'Admin', --REGSIGN
		getdate() --TIME
          

	if(@Role like '%1%') --Role 1 = Teacher
	BEGIN
	INSERT INTO Teachers
		SELECT
			@FirstName,
			@LastName,
			@persoid,
			@DateOfBirth,
			@StartDate,
			NULL,
			@Phone,
			case when (@Email <> '' or @Email is null) then @Email else CONCAT(@FirstName, '.', @LastName, '@scool.se') end,
			case when @Role like '%3%' then 1 else 0 end
	END

	ELSE -- ELSE STUDENT
	BEGIN
	INSERT INTO Students
		SELECT
			@FirstName,
			@LastName,
			@persoid,
			@DateOfBirth,
			@StartDate,
			@Phone,
			@Email
	END
		
		 
END 

GO

exec CreateUser Linus, 'moller', test123, '7501015767','20200401', '1,3', '', '070-555 55 442'
exec CreateUser Karl, Andersson, test123, '0901012341', '20210901', '2', 'a.Andersson@telia.se' , '0521-221065'
exec CreateUser Mathilda, Iscasson, test123, '0901024567', '20210901', '2', 'a.Andersson@telia.se' , '0521-221065'
exec CreateUser Bert, Ljung, test123, '0901034399', '20210901', '2', 'a.Andersson@telia.se' , '0521-221065'
exec CreateUser Klimpen, Svensson, test123, '0901024390	', '20210901', '2', 'a.Andersson@telia.se' , '0521-221065'
*/

/*
CREATE PROCEDURE AddYearGrade 
	@YearGrade          NVARCHAR(30),
	@StartDate			DateTime,
	@EndDate			DateTime,
	@LoginName			varchar(50)
AS 
BEGIN 
     SET NOCOUNT ON 
	 declare @YearGradeID varchar(10)
	 if not exists(select null from YearGrade where lower(YearGrade) = lower(@YearGrade) and StartDate = @StartDate)
	 BEGIN
		  set @YearGradeID= LEFT(CONVERT(VARCHAR(36), NEWID()), 10)
		 while exists ((select NULL from YearGrade where YearGrade = @YearGradeID))
		 BEGIN
			SET @YearGradeID = (select distinct YearGradeid from YearGrade where lower(YearGrade) = lower(@YearGrade) and StartDate = @StartDate)
		 END
	 END
	 ELSE
		 set @YearGradeID = (select YearGradeID from YearGrade where lower(YearGrade) = lower(@YearGrade) and StartDate = @StartDate) 
	
	 declare @roles varchar(50) = (select roles from Users where lower(LoginName) = lower(@LoginName))
	 declare @MainTeacher int = case when @roles like '%3%' then 1 else 0 end	 
	 declare @TeacherPersoid varchar(50) = case when @roles = '2' then (select persoid from YearGrade where lower(YearGrade) = lower(@YearGrade) and StartDate = @StartDate and MainTeacher = 1) else null end
	 declare @persoid varchar(50) = (select Persoid from Users where lower(LoginName) = lower(@LoginName))
	       
	INSERT INTO YearGrade
		SELECT
			UPPER(@YearGrade),
			@YearGradeID,
			@StartDate,
			@EndDate,
			@TeacherPersoid,
			@persoid,	
			@MainTeacher
		 
END 

GO
*/
--exec AddYearGrade '4A', '20230901', '20240601', 'Linmol'
--exec AddYearGrade '4B', '20230901', '20240601', 'Linmol'
--exec AddYearGrade '4A', '20230901', '20240601', 'KarAnd'
--exec AddYearGrade '4b', '20230901', '20240601', 'MatIsc'
--exec AddYearGrade '4b', '20230901', '20240601', 'BerLju'
--exec AddYearGrade '4b', '20230901', '20240601', 'KliSve'

