CREATE TABLE [dbo].[Orders]
(
    [Order_ID] INT NOT NULL PRIMARY KEY, 
    [Employee_ID] INT NULL, 
    [Date_Order_Placed] DATE NULL, 
    [Amount] NCHAR(10) NULL, 
    [Supplier_ID] INT NULL
)