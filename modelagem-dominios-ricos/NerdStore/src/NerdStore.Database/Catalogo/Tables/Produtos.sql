CREATE TABLE [Catalogo].[Produtos] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [CategoriaId]       UNIQUEIDENTIFIER NOT NULL,
    [Nome]              VARCHAR (250)    NOT NULL,
    [Descricao]         VARCHAR (500)    NOT NULL,
    [Ativo]             BIT              NOT NULL,
    [Valor]             DECIMAL (18, 2)  NOT NULL,
    [DataCadastro]      DATETIME2 (7)    NOT NULL,
    [Imagem]            VARCHAR (250)    NOT NULL,
    [QuantidadeEstoque] INT              NOT NULL,
    [Altura]            INT              NULL,
    [Largura]           INT              NULL,
    [Profundidade]      INT              NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Produtos_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Catalogo].[Categorias] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Produtos_CategoriaId]
    ON [Catalogo].[Produtos]([CategoriaId] ASC);

