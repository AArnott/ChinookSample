DROP TABLE IF EXISTS [FileSystemEntity];

CREATE TABLE [FileSystemEntity]
(
    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL COLLATE NOCASE,
    [Parent_Id] INTEGER NULL, 
    [IsFile] BIT NOT NULL, 
    CONSTRAINT [FK_FileSystemEntity_ToFileSystemEntity] FOREIGN KEY ([Parent_Id]) REFERENCES [FileSystemEntity]([Id])
);

CREATE INDEX [FileSystemEntity_Name_Index]
  on [FileSystemEntity] ([Name] COLLATE NOCASE);

INSERT INTO [FileSystemEntity] (Id, Name, IsFile) VALUES (1, 'dir', 0);
INSERT INTO [FileSystemEntity] (Id, Name, IsFile, Parent_Id) VALUES (2, 'foo.txt', 1, 1);
