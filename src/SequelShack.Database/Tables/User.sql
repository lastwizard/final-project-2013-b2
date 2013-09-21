CREATE TABLE [dbo].[User] (
  [Id] INT IDENTITY NOT NULL,
  [Username] NVARCHAR (25) NOT NULL,
  [Email] NVARCHAR(256) NULL,
  CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
  CONSTRAINT [U_Username] UNIQUE ([Username])
)