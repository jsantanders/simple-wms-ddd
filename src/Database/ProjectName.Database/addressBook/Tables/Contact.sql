CREATE TABLE [dbo].[Contact]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ContactLabelId] UNIQUEIDENTIFIER NULL, 
    [Birthday] DATETIME2 NULL, 
    [Notes] NVARCHAR(500) NULL, 
    [IsFavorite] BIT NOT NULL, 
    [Country] NVARCHAR(50) NULL, 
    [State] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [AddressLine1] NVARCHAR(50) NULL, 
    [AddressLine2] NCHAR(10) NULL, 
    [FirstName] NVARCHAR(50) NULL 
)
