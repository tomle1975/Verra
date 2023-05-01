CREATE TABLE [dbo].[EmployeePosition]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [DateReceived] DATETIME NOT NULL, 
    [Title] VARCHAR(50) NOT NULL, 
    [Salary] DECIMAL NOT NULL, 
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_EmployeePosition_Employee foreign key(EmployeeId) references Employee(Id)
)
