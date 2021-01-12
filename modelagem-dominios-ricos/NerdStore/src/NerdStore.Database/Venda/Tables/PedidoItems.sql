CREATE TABLE [Venda].[PedidoItems] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [PedidoId]      UNIQUEIDENTIFIER NOT NULL,
    [ProdutoId]     UNIQUEIDENTIFIER NOT NULL,
    [ProdutoNome]   VARCHAR (250)    NOT NULL,
    [Quantidade]    INT              NOT NULL,
    [ValorUnitario] DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [PK_PedidoItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PedidoItems_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Venda].[Pedidos] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PedidoItems_PedidoId]
    ON [Venda].[PedidoItems]([PedidoId] ASC);

