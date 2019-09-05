CREATE TABLE [dbo].[Suppliers]
(
    [Supplier_ID] INT NOT NULL PRIMARY KEY, 
    [Phone_Number] CHAR(10) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Website] NVARCHAR(50) NULL, 
    [Supplier_Name] NVARCHAR(50) NULL
)