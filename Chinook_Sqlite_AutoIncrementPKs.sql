DROP TABLE IF EXISTS [FileSystemEntity];

CREATE TABLE [FileSystemEntity]
(
    [FileSystemEntityId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL COLLATE NOCASE,
    [ParentFileSystemEntityId] INTEGER NULL, 
    [IsFile] BIT NOT NULL, 
    CONSTRAINT [FK_FileSystemEntity_ToFileSystemEntity] FOREIGN KEY ([ParentFileSystemEntityId]) REFERENCES [FileSystemEntity]([FileSystemEntityId])
);

CREATE INDEX [FileSystemEntity_Name_Index]
  on [FileSystemEntity] ([Name] COLLATE NOCASE);

INSERT INTO [FileSystemEntity] ([FileSystemEntityId], Name, IsFile) VALUES (1, 'dir', 0);
INSERT INTO [FileSystemEntity] ([FileSystemEntityId], Name, IsFile, ParentFileSystemEntityId) VALUES (2, 'foo.txt', 1, 1);
