CREATE TABLE [dbo].[EmpresaConfig] (
    [Id]                  INT             NOT NULL,
    [Cedula]              TEXT            NULL,
    [Direccion]           TEXT            NULL,
    [Telefono]            TEXT            NULL,
    [Fax]                 TEXT            NULL,
    [Email]               TEXT            NULL,
    [Utilidad]            DECIMAL (10, 2) NOT NULL,
    [ImpuestoVenta]       DECIMAL (5, 2)  NOT NULL,
    [PrecioMolde]         DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [PrecioTinta]         DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [PrecioPositivo]      DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [PrecioArte]          DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [PrecioSolvente]      DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [PrecioCorte]         DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [PrecioVelocidad]     DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [PrecioHoraImpresion] DECIMAL (15, 2) DEFAULT ((0)) NOT NULL,
    [Activo]              BIT             DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Empresa] ([Id])
);

