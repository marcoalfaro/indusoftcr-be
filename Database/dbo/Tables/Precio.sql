CREATE TABLE [dbo].[Precio] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [EmpresaId]     INT             NOT NULL,
    [Molde]         DECIMAL (15, 2) NOT NULL,
    [Tinta]         DECIMAL (15, 2) NOT NULL,
    [Positivo]      DECIMAL (15, 2) NOT NULL,
    [Arte]          DECIMAL (15, 2) NOT NULL,
    [Solvente]      DECIMAL (15, 2) NOT NULL,
    [Corte]         DECIMAL (15, 2) NOT NULL,
    [Velocidad]     DECIMAL (15, 2) NOT NULL,
    [HoraImpresion] DECIMAL (15, 2) NOT NULL,
    [Activo]        BIT             DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
);

