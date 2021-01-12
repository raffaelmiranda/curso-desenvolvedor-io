CREATE TABLE [Venda].[Pedidos] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Codigo]           INT              DEFAULT (NEXT VALUE FOR [MinhaSequencia]) NOT NULL,
    [ClienteId]        UNIQUEIDENTIFIER NOT NULL,
    [VoucherId]        UNIQUEIDENTIFIER NULL,
    [VoucherUtilizado] BIT              NOT NULL,
    [Desconto]         DECIMAL (18, 2)  NOT NULL,
    [ValorTotal]       DECIMAL (18, 2)  NOT NULL,
    [DataCadastro]     DATETIME2 (7)    NOT NULL,
    [PedidoStatus]     INT              NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pedidos_Vouchers_VoucherId] FOREIGN KEY ([VoucherId]) REFERENCES [Venda].[Vouchers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Pedidos_VoucherId]
    ON [Venda].[Pedidos]([VoucherId] ASC);

