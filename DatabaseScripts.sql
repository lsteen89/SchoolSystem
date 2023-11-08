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
		Id INT IDENTITY (1, 1) PRIMARY KEY,
        FirstName nvarchar(30) NOT NULL,
		LastName nvarchar(30) NOT NULL,
		Persoid VARCHAR(20) NOT NULL UNIQUE,
		Century varchar(2) NOT NULL,
		DateOfBirth varchar(12) NOT NULL UNIQUE,
		Enrolldate datetime not null,
		ParentPhone varchar(50),
		ParentEmail varchar(100),
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ParentGuardians' and xtype='U')
BEGIN
	CREATE TABLE ParentGuardians (
		ParentId INT IDENTITY(1,1) PRIMARY KEY,
		StudentId INT NOT NULL,
		Name NVARCHAR(100) NOT NULL,
		Phone VARCHAR(50),
		Email VARCHAR(100),
		Relationship NVARCHAR(50),
	);
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Teachers' and xtype='U')
BEGIN
    CREATE TABLE Teachers (
        Id INT IDENTITY (1, 1) PRIMARY KEY,
        FirstName nvarchar(30) NOT NULL,
		LastName nvarchar(30) NOT NULL,
		Persoid VARCHAR(20) NOT NULL UNIQUE,
		Century VARCHAR(2) NOT NULL,
		DateOfBirth VARCHAR(12) NOT NULL UNIQUE,
		StartDate datetime NOT NULL,
		EndDate datetime,
		Phone varchar(50) NOT NULL,
		Email varchar(100) NOT NULL,
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='YearGrade' and xtype='U')
BEGIN
    CREATE TABLE YearGrade (
	    Id INT IDENTITY (1, 1) PRIMARY KEY,
        YearGradeName varchar(50) NOT NULL,
		YearGradeID varchar(10) NOT NULL,
		StartDate datetime NOT NULL,
		EndDate datetime NOT NULL,
		TeacherPersoid VARCHAR(20),
		Persoid varchar(20) NOT NULL,
		IsMainTeacher BIT,
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Subjects' and xtype='U')
BEGIN
    CREATE TABLE Subjects (
		SubjectName VARCHAR(50),
        YearGradeID VARCHAR(10) NOT NULL,
		StartDate datetime NOT NULL,
		EndDate datetime,
		TeacherPersoid VARCHAR(20),
		Persoid VARCHAR(20) NOT NULL,
		PRIMARY KEY(SubjectName, YearGradeID, EndDate)
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
        Id INT IDENTITY (1, 1) PRIMARY KEY	,
        Persoid VARCHAR(20) NOT NULL UNIQUE,
		LoginName varchar(50) NOT NULL UNIQUE,
		Password nvarchar(100) NOT NULL,
		Roles int NOT NULL,
		Regsign varchar(10) NOT NULL,
		Regtime datetime NOT NULL
		
    )
END
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='StudentImages' and xtype='U')
BEGIN
	CREATE TABLE StudentImages (
		ImageID INT IDENTITY(1,1) PRIMARY KEY,
		StudentPersoid VARCHAR(20) NOT NULL,
		ImagePath NVARCHAR(MAX) NOT NULL,
		Description NVARCHAR(255),
		DateAdded DATETIME NOT NULL DEFAULT GETDATE(),
		IsActive BIT NOT NULL DEFAULT 1,
		FOREIGN KEY (StudentPersoid) REFERENCES Students(Persoid)
	)
END


CREATE UNIQUE NONCLUSTERED INDEX idx_unique_main_teacher
ON YearGrade (TeacherPersoid, YearGradeID)
WHERE IsMainTeacher = 1;

/*
UTKAST FK
-- Adding FK from YearGrade to Teachers
ALTER TABLE YearGrade
ADD CONSTRAINT FK_YearGrade_Teachers
FOREIGN KEY (TeacherPersoid) REFERENCES Teachers(Persoid);

-- Adding FK from YearGrade to Students (if applicable)
ALTER TABLE YearGrade
ADD CONSTRAINT FK_YearGrade_Students
FOREIGN KEY (StudentPersoid) REFERENCES Students(Persoid);

-- Adding FK from Users to Students (if applicable)
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Students
FOREIGN KEY (Persoid) REFERENCES Students(Persoid);

-- Adding FK from Grade to Students
ALTER TABLE Grade
ADD CONSTRAINT FK_Grade_Students
FOREIGN KEY (Persoid) REFERENCES Students(Persoid);

-- Adding FK from Subjects to Teachers
ALTER TABLE Subjects
ADD CONSTRAINT FK_Subjects_Teachers
FOREIGN KEY (TeacherPersoid) REFERENCES Teachers(Persoid);
*/

/*
Roles;
1: Teacher
2: Student
3: Main teacher
*/
/*
-- Create a stored procedure to create a user and insert information into either the Teachers or Students table based on the role.
CREATE PROCEDURE CreateUser 
       @FirstName           NVARCHAR(30),
       @LastName            NVARCHAR(30),
       @Password			varchar(100),
	   @DateOfBirth			VARCHAR(12),
	   @StartDate			datetime,
       @Role                int,
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
          

	if(@Role in (1,3)) --Role 1 or 3 = Teacher
	BEGIN
	INSERT INTO Teachers
		SELECT
			@FirstName,
			@LastName,
			@persoid, 
			century = SUBSTRING(@DateOfBirth, 1, 2),
			DateOfBirth = CONCAT(SUBSTRING(@DateOfBirth,3,6),SUBSTRING(@DateOfBirth,10,4)), 
			@StartDate,
			NULL,
			@Phone,
			case when (@Email <> '' or @Email is null) then @Email else CONCAT(@FirstName, '.', @LastName, '@school.se') end	
	END

	ELSE -- ELSE STUDENT
	BEGIN
	INSERT INTO Students
		SELECT
			@FirstName,
			@LastName,
			@persoid,
			century = SUBSTRING(@DateOfBirth, 1, 2),
			DateOfBirth = CONCAT(SUBSTRING(@DateOfBirth,3,6),SUBSTRING(@DateOfBirth,10,4)), 
			@StartDate,
			@Phone,
			@Email
	END
		
		 
END 



exec CreateUser 'Linus', 'Möller', test123, '19750101-5556','20010401', 3, '', '070111111'
exec CreateUser 'Sonja', 'Ek', test123, '19750101-5466','20010401', 3, '', '08191919'
exec CreateUser 'Anton', 'Möller', test123, '19750101-8900','20220910', 1, '', '0702-444-555-4'
exec CreateUser 'Åke', 'Nordin', test123, '20090510-1213', '20210901', '2', 'a.nordin@telia.se' , '0521-221165'
exec CreateUser 'Torleif', 'Andersson', test123, '20091031-5433', '20210901', '2', 't.Andersson@telia.se' , '0521-221065'
exec CreateUser Bert, Ljung, test123, '20090103-5899', '20210901', '2', 'F.ljung@telia.se' , '0521-221265'
exec CreateUser Klimpen, Svensson, test123, '20090102-0001', '20210901', '2', '' , ''
exec CreateUser 'Nadja', 'Nilsson', test123, '20090102-1213', '20210901', '2', 'foraldrar@telia.se' , ''
exec CreateUser 'Jörgen', 'Karlsson', test123, '20090102-1312', '20210901', '2', '' , ''
exec CreateUser 'Dödgrävarn', 'N', test123, '20060402-1312', '20210901', '2', '' , '' 
exec CreateUser 'Rebecka', 'Molin', test123, '20090401-5678', '20210901', '2', '','F.Molin@skunk.se' 
exec CreateUser 'Lill-Erik', 'Linstett', test123, '20090401-1678', '20210901', '2', '','LillerikMamma@skunk.se' 
*/

/*
Random updates to fix ÅÄÖ in loginname. This should be handled in the backend, its not created yet.

update Users set LoginName = 'dodn'
where LoginName = 'dödn'

update Users set LoginName = 'jorkar'
where LoginName = 'jörkar'

update Users set LoginName = 'akenor'
where LoginName = 'åkenor'

update Users set LoginName = 'antmol'
where LoginName = 'antmöl'

update Teachers set Email = 'Anton.Moller@school.se'
where Email = 'Anton.Möller@school.se'

*/
/*
-- Create a stored procedure to add a new YearGrade entry.
CREATE PROCEDURE AddYearGrade 
    @YearGrade      NVARCHAR(30),
    @StartDate      DATETIME,
    @EndDate        DATETIME,
    @LoginName      VARCHAR(50)
AS 
BEGIN 
    SET NOCOUNT ON;

    -- Variable to hold the unique identifier for the year grade
    DECLARE @YearGradeID VARCHAR(10);

    -- Check if a YearGrade entry already exists with the same name and start date.
    IF NOT EXISTS (
        SELECT NULL
        FROM YearGrade
        WHERE LOWER(YearGradeName) = LOWER(@YearGrade)
        AND StartDate = @StartDate
    )
    BEGIN
        -- If it does not exist, create a new unique identifier.
        SET @YearGradeID = LEFT(CONVERT(VARCHAR(36), NEWID()), 10);

        -- Ensure that the generated YearGradeID is unique.
        WHILE EXISTS (
            SELECT NULL
            FROM YearGrade
            WHERE YearGradeID = @YearGradeID
        )
        BEGIN
            SET @YearGradeID = LEFT(CONVERT(VARCHAR(36), NEWID()), 10);
        END
    END
    ELSE
    BEGIN
        -- If it does exist, get the existing YearGradeID.
        SET @YearGradeID = (
            SELECT TOP 1 YearGradeID
            FROM YearGrade
            WHERE LOWER(YearGradeName) = LOWER(@YearGrade)
            AND StartDate = @StartDate
        );
    END

    -- Retrieve the role of the user attempting to add the YearGrade.
    DECLARE @roles INT = (
        SELECT roles
        FROM Users
        WHERE LOWER(LoginName) = LOWER(@LoginName)
    );

    -- Determine if the user is a main teacher based on their role.
    DECLARE @MainTeacher INT = CASE WHEN @roles = 3 THEN 1 ELSE 0 END;

    -- Get the Persoid of the teacher if the role is '2', indicating a main teacher for the YearGrade.
    DECLARE @TeacherPersoid VARCHAR(50) = CASE 
        WHEN @roles = '2' THEN (
            SELECT Persoid
            FROM YearGrade
            WHERE LOWER(YearGradeName) = LOWER(@YearGrade)
            AND StartDate = @StartDate
            AND IsMainTeacher = 1
        )
        ELSE NULL 
    END;

    -- Retrieve the Persoid of the user based on the provided login name.
    DECLARE @persoid VARCHAR(50) = (
        SELECT Persoid
        FROM Users
        WHERE LOWER(LoginName) = LOWER(@LoginName)
    );
    
    -- Insert the new YearGrade entry with the collected information.
    INSERT INTO YearGrade (YearGradeName, YearGradeID, StartDate, EndDate, TeacherPersoid, Persoid, IsMainTeacher)
    VALUES (
        UPPER(@YearGrade),
        @YearGradeID,
        @StartDate,
        @EndDate,
        @TeacherPersoid,
        @persoid,    
        @MainTeacher
    );
END;

GO

*/
--exec AddYearGrade '4A', '20230901', '20240601', 'sonek'
--exec AddYearGrade '4B', '20230901', '20240601', 'sonek'
--exec AddYearGrade '4A', '20230901', '20240601', 'antmol'
--exec AddYearGrade '4A', '20230901', '20240601', 'akenor'
--exec AddYearGrade '4A', '20230901', '20240601', 'torand'
--exec AddYearGrade '4A', '20230901', '20240601', 'BerLju'
--exec AddYearGrade '4A', '20230901', '20240601', 'nadnil'
--exec AddYearGrade '4b', '20230901', '20240601', 'klisve'
--exec AddYearGrade '4b', '20230901', '20240601', 'jorkar'
--exec AddYearGrade '4b', '20230901', '20240601', 'dodn'
--exec AddYearGrade '4b', '20230901', '20240601', 'rebmol'
--exec AddYearGrade '4b', '20230901', '20240601', 'lillin'
