USE [Users]
GO

/****** Oggetto: Table [dbo].[Users] Data script: 21/12/2021 17:21:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [USERNAME] NCHAR (40) NULL,
    [PASSWORD] NCHAR (40) NULL
);


