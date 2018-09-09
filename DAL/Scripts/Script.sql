CREATE DATABASE Biblia
GO
USE Biblia
GO

CREATE TABLE LibrosBiblia
(
  LibroId int primary key identity(1,1),
  Fecha datetime,
  Descripcion varchar(max),
  Siglas varchar(13),
  TipoID int
);