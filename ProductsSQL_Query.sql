CREATE TABLE [dbo].[Products]
(
    [Product_ID] INT NOT NULL PRIMARY KEY, 
    [Manufacturer_Name] NVARCHAR(50) NULL, 
    [Product_Name] NVARCHAR(50) NULL, 
    [Price_Sold] MONEY NULL, 
    [Price_Paid] MONEY NULL, 
    [Supplier_ID] INT NULL, 
    [Stock] INT NULL 
)