CREATE TABLE [dbo].[TaskEntries]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Titel] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NOT NULL, 
    [Priority] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [FinishedDate] DATETIME2 NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [DeadlineDate] DATETIME2 NOT NULL
)
