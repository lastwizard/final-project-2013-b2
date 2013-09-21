CREATE TABLE [dbo].[Movie]
(
  [Id] NVARCHAR(75) NOT NULL,
  [Version] INT NOT NULL,
  [Title] NVARCHAR(256) NOT NULL,
  [Year] INT,
  [ProfilePosterUrl] NVARCHAR(256) NOT NULL,
  [DetailedPosterUrl] NVARCHAR(256) NOT NULL,
  [Synopsis] NVARCHAR(MAX),
  [InTheaters] BIT NOT NULL,
  [OnFrontPage] BIT NOT NULL,
  [RottenTomatoesUrl] NVARCHAR(256) NULL,
  CONSTRAINT [PK_Movie] PRIMARY KEY ([Id])
)
GO

CREATE INDEX [X_Title] ON [Movie] ([Title])
GO