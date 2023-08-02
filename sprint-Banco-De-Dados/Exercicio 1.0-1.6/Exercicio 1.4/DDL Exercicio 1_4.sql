CREATE DATABASE Exercicio_1_4;


USE Exercicio_1_4;


CREATE TABLE ARTISTA (
 IdArtista INT PRIMARY KEY  IDENTITY,
 NomeArtista VARCHAR(20) NOT NULL,
);
GO 

CREATE TABLE ESTILO (
 IdEstilo TINYINT PRIMARY KEY  IDENTITY,
 EstiloMusical VARCHAR(20) NOT NULL,
);
GO 

CREATE TABLE USUARIO(
IdUsuario INT PRIMARY KEY  IDENTITY,
NomeUsuario VARCHAR(20) NOT NULL,
Email VARCHAR(256) NOT NULL,
Senha VARCHAR(100) NOT NULL,
Permissao VARCHAR(300) NOT NULL 
);
GO

CREATE TABLE ALBUNS(
IdAlbuns INT PRIMARY KEY  IDENTITY,
IdEstilo INT FOREIGN KEY REFERENCES ESTILO(IdEstilo),
idArtista INT FOREIGN KEY REFERENCES ARTISTA(IdArtista),
Titulo VARCHAR(15) NOT NULL, 
Localização VARCHAR(15) NOT NULL,
QuantosMinutos VARCHAR(6) NOT NULL,
DataLancamento CHAR(8) NOT NULL,
);
GO