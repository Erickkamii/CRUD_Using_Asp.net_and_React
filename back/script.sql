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
CREATE TABLE [Produtos] (
    [ID] int NOT NULL IDENTITY,
    [nome] nvarchar(max) NULL,
    [precoVenda] int NULL,
    [precoCusto] int NULL,
    [quantidade] int NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([ID])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241122004428_Initial', N'9.0.0');

COMMIT;
GO

