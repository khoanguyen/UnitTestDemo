CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(20) NOT NULL, 
    [Password] NVARCHAR(20) NOT NULL, 
    [Point] INT NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Users_UserName] ON [dbo].[Users] ([UserName])
