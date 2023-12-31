CREATE DATABASE [Event+_Tarde]

USE [Event+_Tarde]

CREATE TABLE TiposDeUsuario
(
IdTipoDeUsuario INT PRIMARY KEY IDENTITY(1, 1),
TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE TiposDeEvento
(
IdTipoDeEvento INT PRIMARY KEY IDENTITY(1, 1),
TituloTipoEvento VARCHAR(50) NOT NULL UNIQUE
)

Create TABLE Instituicao
(
IdInstituicao INT PRIMARY KEY IDENTITY(1, 1),
CNPJ CHAR(14) NOT NULL UNIQUE,
Endereco VARCHAR(200) NOT NULL,
NomeFantasia VARCHAR(200) NOT NULL
)

CREATE TABLE Usuario
(
IdUsuario INT PRIMARY KEY IDENTITY(1, 1),
IdTipoDeUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTipoDeUsuario)NOT NULL,
Nome VARCHAR(50) NOT NULL,
Email VARCHAR(50) NOT NULL UNIQUE,
Senha VARCHAR(50) NOT NULL
)

CREATE TABLE Evento
(
IdEvento INT PRIMARY KEY IDENTITY(1, 1),
IdTipoDeEvento INT FOREIGN KEY REFERENCES TiposDeEvento(IdTipoDeEvento)NOT NULL,
IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao)NOT NULL,
Nome VARCHAR(50) NOT NULL,
Descricao VARCHAR(200) NOT NULL,
DataEvento DATE NOT NULL,
HorarioEvento TIME NOT NULL
)

CREATE TABLE PresencasEvento
(
IdPresencasEvento INT PRIMARY KEY IDENTITY(1, 1),
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)NOT NULL,
IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento)NOT NULL,
Situacao BIT DEFAULT(0)
)

CREATE TABLE ComentarioEvento
(
IdComentarioEvento INT PRIMARY KEY IDENTITY(1, 1),
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)NOT NULL,
IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento)NOT NULL,
Descricao VARCHAR(200) NOT NULL,
Exibe BIT DEFAULT(0)
)
