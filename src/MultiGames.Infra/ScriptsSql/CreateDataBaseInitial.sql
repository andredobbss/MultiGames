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

CREATE TABLE [Adresses] (
    [Id] uniqueidentifier NOT NULL,
    [Street] nvarchar(100) NULL,
    [StreetNumber] nvarchar(50) NULL,
    [City] nvarchar(100) NULL,
    [Country] nvarchar(50) NULL,
    [State] nvarchar(50) NULL,
    [PostalCode] nvarchar(20) NULL,
    [TelPhone] nvarchar(15) NULL,
    [CelPhone] nvarchar(15) NULL,
    [DateCriate] datetimeoffset NOT NULL,
    CONSTRAINT [PK_Adresses] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Brothers] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NULL,
    [Cpf] nvarchar(14) NULL,
    [Email] nvarchar(100) NULL,
    [AddressId] uniqueidentifier NULL,
    [DateCriate] datetimeoffset NOT NULL,
    CONSTRAINT [PK_Brothers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Brothers_Adresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Adresses] ([Id])
);
GO

CREATE TABLE [Games] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NULL,
    [VersionEdition] nvarchar(15) NULL,
    [Status] nvarchar(15) NULL,
    [DateOut] datetimeoffset NOT NULL,
    [BrotherId] uniqueidentifier NULL,
    [DateCriate] datetimeoffset NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Games_Brothers_BrotherId] FOREIGN KEY ([BrotherId]) REFERENCES [Brothers] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AddressId', N'Cpf', N'DateCriate', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Brothers]'))
    SET IDENTITY_INSERT [Brothers] ON;
INSERT INTO [Brothers] ([Id], [AddressId], [Cpf], [DateCriate], [Email], [Name])
VALUES ('55a3aa85-e761-4416-8ad8-27debc73d189', NULL, N'666.666.666-06', '2023-08-22T18:20:15.1577989+00:00', N'teste06@teste.com', N'Teste6'),
('8e3416d4-72f1-4496-9c15-8a26bcc49cec', NULL, N'111.111.111-01', '2023-08-22T18:20:15.1575916+00:00', N'teste01@teste.com', N'Teste1'),
('9d099970-9f18-4b00-861e-c9605d08ad14', NULL, N'333.333.333-03', '2023-08-22T18:20:15.1576938+00:00', N'teste03@teste.com', N'Teste3'),
('b01dd7ca-e545-4e45-966e-9707424ba9f1', NULL, N'555.555.555-05', '2023-08-22T18:20:15.1577642+00:00', N'teste05@teste.com', N'Teste5'),
('da6f26c9-f011-4806-8576-bd1b0f55658c', NULL, N'444.444.444-04', '2023-08-22T18:20:15.1577299+00:00', N'teste04@teste.com', N'Teste4'),
('fc602004-22f2-45d3-9a42-96e956cfaad4', NULL, N'222.222.222-02', '2023-08-22T18:20:15.1576548+00:00', N'teste02@teste.com', N'Teste2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AddressId', N'Cpf', N'DateCriate', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Brothers]'))
    SET IDENTITY_INSERT [Brothers] OFF;
GO

CREATE INDEX [IX_Brothers_AddressId] ON [Brothers] ([AddressId]);
GO

CREATE INDEX [IX_Games_BrotherId] ON [Games] ([BrotherId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230822182015_Inicial', N'7.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [Brothers]
WHERE [Id] = '55a3aa85-e761-4416-8ad8-27debc73d189';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Brothers]
WHERE [Id] = '8e3416d4-72f1-4496-9c15-8a26bcc49cec';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Brothers]
WHERE [Id] = '9d099970-9f18-4b00-861e-c9605d08ad14';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Brothers]
WHERE [Id] = 'b01dd7ca-e545-4e45-966e-9707424ba9f1';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Brothers]
WHERE [Id] = 'da6f26c9-f011-4806-8576-bd1b0f55658c';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Brothers]
WHERE [Id] = 'fc602004-22f2-45d3-9a42-96e956cfaad4';
SELECT @@ROWCOUNT;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Games]') AND [c].[name] = N'Title');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Games] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Games] ALTER COLUMN [Title] nvarchar(50) NULL;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AddressId', N'Cpf', N'DateCriate', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Brothers]'))
    SET IDENTITY_INSERT [Brothers] ON;
INSERT INTO [Brothers] ([Id], [AddressId], [Cpf], [DateCriate], [Email], [Name])
VALUES ('190c1de4-a925-413d-96d3-baa19c2853df', NULL, N'333.333.333-03', '2023-08-22T18:32:14.7378004+00:00', N'teste03@teste.com', N'Teste3'),
('409d9f74-5c0c-4c08-b201-23ef049b4903', NULL, N'555.555.555-05', '2023-08-22T18:32:14.7378686+00:00', N'teste05@teste.com', N'Teste5'),
('a08eac68-9024-458f-89bb-50bb9cb03c95', NULL, N'444.444.444-04', '2023-08-22T18:32:14.7378351+00:00', N'teste04@teste.com', N'Teste4'),
('a209dd59-e8d8-45c3-8fcb-2a7255bba7b7', NULL, N'666.666.666-06', '2023-08-22T18:32:14.7379015+00:00', N'teste06@teste.com', N'Teste6'),
('c47daeb3-e3c5-48a5-8590-428514b693cb', NULL, N'222.222.222-02', '2023-08-22T18:32:14.7377653+00:00', N'teste02@teste.com', N'Teste2'),
('c6efa0eb-4e9b-4227-a3fc-17a4e1431bcb', NULL, N'111.111.111-01', '2023-08-22T18:32:14.7377036+00:00', N'teste01@teste.com', N'Teste1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AddressId', N'Cpf', N'DateCriate', N'Email', N'Name') AND [object_id] = OBJECT_ID(N'[Brothers]'))
    SET IDENTITY_INSERT [Brothers] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230822183214_AlteraColuna-Title-TabelaGames', N'7.0.10');
GO

COMMIT;
GO

