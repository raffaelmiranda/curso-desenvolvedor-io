CREATE TABLE [Venda].[Vouchers] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [Codigo]              VARCHAR (100)    NOT NULL,
    [Percentual]          DECIMAL (18, 2)  NULL,
    [ValorDesconto]       DECIMAL (18, 2)  NULL,
    [Quantidade]          INT              NOT NULL,
    [TipoDescontoVoucher] INT              NOT NULL,
    [DataCriacao]         DATETIME2 (7)    NOT NULL,
    [DataUtilizacao]      DATETIME2 (7)    NULL,
    [DataValidade]        DATETIME2 (7)    NOT NULL,
    [Ativo]               BIT              NOT NULL,
    [Utilizado]           BIT              NOT NULL,
    CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

