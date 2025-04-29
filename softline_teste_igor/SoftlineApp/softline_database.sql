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
CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Fantasia] nvarchar(max) NOT NULL,
    [Documento] nvarchar(max) NOT NULL,
    [Endereco] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    [CodigoDeBarras] nvarchar(max) NOT NULL,
    [ValorVenda] decimal(18,2) NOT NULL,
    [PesoBruto] decimal(18,2) NOT NULL,
    [PesoLiquido] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Login] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250423131233_InitialCreate', N'9.0.4');

COMMIT;
GO

