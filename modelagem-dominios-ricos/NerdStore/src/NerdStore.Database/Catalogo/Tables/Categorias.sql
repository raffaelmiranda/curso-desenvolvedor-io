CREATE TABLE [Catalogo].[Categorias] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [Nome]   VARCHAR (250)    NOT NULL,
    [Codigo] INT              NOT NULL,
    [TesteCampo] NCHAR(10) NULL, 
    CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([Id] ASC)
);

