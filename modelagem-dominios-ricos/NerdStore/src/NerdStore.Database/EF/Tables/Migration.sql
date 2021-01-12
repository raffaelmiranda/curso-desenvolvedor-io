CREATE TABLE [EF].[Migration] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK_Migration] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);

