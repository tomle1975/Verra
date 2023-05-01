CREATE TABLE [dbo].[Employee]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(15) NOT NULL, 
    [LastName] VARCHAR(15) NOT NULL, 
    [Department] VARCHAR(50) NOT NULL, 
    [ProjectId] UNIQUEIDENTIFIER NOT NULL, 
    [StreetLine1] VARCHAR(50) NOT NULL, 
    [StreetLine2] VARCHAR(50) NULL, 
    [City] VARCHAR(150) NOT NULL, 
    [State] VARCHAR(2) NOT NULL, 
    [ZipCode] VARCHAR(15) NOT NULL, 
    [Country] VARCHAR(15) NOT NULL, 
    [Dob] DATETIME NOT NULL, 
    [Gender] VARCHAR(10) NOT NULL
)
