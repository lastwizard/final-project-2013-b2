CREATE TABLE [dbo].[Character]
(
  [Id] INT IDENTITY NOT NULL,
  [MovieId] NVARCHAR(75) NOT NULL,
  [ActorId] NVARCHAR(75) NOT NULL,
  [Name] NVARCHAR(256), 
  CONSTRAINT [PK_Character] PRIMARY KEY ([Id]),
  CONSTRAINT [U_MovieId_ActorID_Name] UNIQUE ([MovieId], [ActorId], [Name]),
  CONSTRAINT [FK_Character_Movie] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE,
  CONSTRAINT [FK_Character_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actor] ([Id]) ON DELETE CASCADE
)