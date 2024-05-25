USE [master]
GO

DROP DATABASE IF EXISTS [CSFAssessment]
GO

CREATE DATABASE [CSFAssessment]
GO
USE [CSFAssessment]
GO
---------------------------------------
--------- Creating Tables -------------
---------------------------------------
DROP TABLE IF EXISTS [dbo].[Form]
GO
CREATE TABLE [dbo].[Form](
	[FormId][int] IDENTITY(1,1) NOT NULL,
	[Name][varchar](255) NOT NULL,
	[Owned][int] NOT NULL,
	[GoodPet][bit] NOT NULL,
	CONSTRAINT PK_Form PRIMARY KEY CLUSTERED (FormId),
)
GO 

---------------------------------------
--------- INSERTING DATA --------------
---------------------------------------
INSERT INTO [dbo].[Form]([Name],[Owned], [GoodPet])
VALUES 
	('Bird', 3, 1),
	('Dog', 2, 1),
	('Crocodile', 0, 0),
	('Snake', 1, 0)

GO
---------------------------------------
--------- Creating Stored Procs -------
---------------------------------------

CREATE OR ALTER PROCEDURE [dbo].[spRetrieveFormsAsync]
AS
BEGIN
	SELECT 
		FormId,
		[Name],
		Owned,
		GoodPet
	FROM Form
	ORDER BY Name ASC
END
GO

CREATE OR ALTER PROCEDURE [dbo].[spRetrieveFormAsync]
	@FormId int
AS
BEGIN
	SELECT 
		FormId,
		[Name],
		Owned,
		GoodPet
	FROM Form
		WHERE Form.FormId = @FormId
	ORDER BY Name ASC
END
GO

CREATE OR ALTER PROCEDURE [dbo].[spCreateFormAsync]
	@FormId int OUTPUT,
		@Name varchar(255),
		@Owned int,
		@GoodPet bit
AS
BEGIN
	BEGIN TRY

	INSERT INTO Form([Name],[Owned], [GoodPet])
		VALUES
		(@Name, @Owned, @GoodPet)
		
		SET @FormId = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END
GO

SELECT * FROM Form