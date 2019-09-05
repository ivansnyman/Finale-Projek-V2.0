CREATE TABLE [dbo].[Employees]
(
    [Employee_ID] INT NOT NULL PRIMARY KEY, 
    [First_Name] NVARCHAR(50) NULL, 
    [Last_Name] NVARCHAR(50) NULL, 
    [Phone_Number] CHAR(10) NULL, 
    [Email] NVARCHAR(50) NULL
)