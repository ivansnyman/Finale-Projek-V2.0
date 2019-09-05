CREATE TABLE [dbo].[Transactions]
(
    [Transaction_ID] INT NOT NULL PRIMARY KEY, 
    [Amount] MONEY NULL, 
    [Date_of_Transaction] DATE NULL, 
    [Customer_ID] INT NULL, 
    [Employee_ID] INT NULL
)