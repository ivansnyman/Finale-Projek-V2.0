DROP TABLE Employees CREATE TABLE [dbo].[Employees]
(
    [Employee_ID] INT NOT NULL PRIMARY KEY, 
    [First_Name] NVARCHAR(50) NULL, 
    [Last_Name] NVARCHAR(50) NULL, 
    [Phone_Number] CHAR(10) NULL, 
    [Email] NVARCHAR(50) NULL,
	[Password] NVARCHAR(20) NOT NULL
)
 DROP TABLE Customers CREATE TABLE [dbo].[Customers]
(
    [Customer_ID] INT NOT NULL PRIMARY KEY, 
    [First_Name] NVARCHAR(50) NULL, 
    [Last_Name] NVARCHAR(50) NULL, 
    [Phone_Number] CHAR(10) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Gender] NVARCHAR(6) NULL, 
    [Date_of_Birth] DATE NULL
)
DROP TABLE Transactions CREATE TABLE [dbo].[Transactions]
(
    [Transaction_ID] INT NOT NULL PRIMARY KEY, 
    [Amount] MONEY NULL, 
    [Date_of_Transaction] DATE NULL, 
    [Customer_ID] INT NULL, 
    [Employee_ID] INT NULL
)
DROP TABLE Products CREATE TABLE [dbo].[Products]
(
    [Product_ID] INT NOT NULL PRIMARY KEY, 
    [Manufacturer_Name] NVARCHAR(50) NULL, 
    [Product_Name] NVARCHAR(50) NULL, 
    [Price_Sold] MONEY NULL, 
    [Price_Paid] MONEY NULL, 
    [Supplier_ID] INT NULL, 
    [Stock] INT NULL 
)
DROP TABLE Poduct_Transaction CREATE TABLE [dbo].[Product_Transaction]
(
    [Product_ID] INT NOT NULL PRIMARY KEY, 
    [Transaction_ID] INT NOT NULL
)
DROP TABLE Suppliers CREATE TABLE [dbo].[Suppliers]
(
    [Supplier_ID] INT NOT NULL PRIMARY KEY, 
    [Phone_Number] CHAR(10) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Website] NVARCHAR(50) NULL, 
    [Supplier_Name] NVARCHAR(50) NULL
)
DROP TABLE Orders CREATE TABLE [dbo].[Orders]
(
    [Order_ID] INT NOT NULL PRIMARY KEY, 
    [Employee_ID] INT NULL, 
    [Date_Order_Placed] DATE NULL, 
    [Amount] NCHAR(10) NULL, 
    [Supplier_ID] INT NULL
)
DROP TABLE Products_Order CREATE TABLE [dbo].[Products_Order]
(
    [Product_ID] INT NOT NULL PRIMARY KEY, 
    [Order_ID] INT NOT NULL, 
    [Quantity] INT NULL
)