IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [article] (
    [ArticleId] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_article] PRIMARY KEY ([ArticleId])
);
GO

CREATE TABLE [Tags] (
    [TagId] nvarchar(20) NOT NULL,
    [Content] ntext NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206065746_InitWebDB', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [article] ADD [Content] ntext NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206071436_InitWebDB_V1', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [articletag] (
    [ArticleTagId] int NOT NULL IDENTITY,
    [ArticleId] int NOT NULL,
    [TagId] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_articletag] PRIMARY KEY ([ArticleTagId]),
    CONSTRAINT [FK_articletag_article_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [article] ([ArticleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_articletag_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([TagId]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_articletag_ArticleId_TagId] ON [articletag] ([ArticleId], [TagId]);
GO

CREATE INDEX [IX_articletag_TagId] ON [articletag] ([TagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206072736_InitWebDB_V2', N'6.0.26');
GO

COMMIT;
GO

