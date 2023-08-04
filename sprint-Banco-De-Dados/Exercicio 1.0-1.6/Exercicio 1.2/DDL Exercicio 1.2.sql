CREATE DATABASE Exercicio_1_2;


USE Exercicio_1_2;


CREATE TABLE EMPRESA (
 IdEmpresa INT PRIMARY KEY  IDENTITY,
 NomeEmpresa VARCHAR(20) NOT NULL
);
 

CREATE TABLE CLIENTE (
 IdCliente INT PRIMARY KEY  IDENTITY,
 NomeCliente VARCHAR(20) NOT NULL,
 CpfCliente CHAR(11) NOT NULL UNIQUE
);


CREATE TABLE MARCA(
 IdMarca INT PRIMARY KEY  IDENTITY,
 NomeMarca VARCHAR(20) NOT NULL,
);


CREATE TABLE MODELO(
IdModelo INT PRIMARY KEY  IDENTITY,
IdMarca INT FOREIGN KEY REFERENCES MARCA(IdMarca),
NomeModelo VARCHAR(20) NOT NULL
);


CREATE TABLE VEICULO(
IdVeiculo INT PRIMARY KEY  IDENTITY,
IdEmpresa INT FOREIGN KEY REFERENCES EMPRESA(IdEmpresa),
IdModelo INT FOREIGN KEY REFERENCES MODELO(IdModelo),
PlacaVeiculo CHAR(7) NOT NULL UNIQUE
);


CREATE TABLE ALUGUEL(
IdAluguel INT PRIMARY KEY  IDENTITY(1,1),
IdVeiculo INT FOREIGN KEY REFERENCES VEICULO(IdVeiculo),
IdCliente INT FOREIGN KEY REFERENCES CLIENTE(IdCliente),
IdModelo INT FOREIGN KEY REFERENCES Modelo(IdModelo),
DataDeInicio VARCHAR(15) NOT NULL,
DataDeTermino VARCHAR(15) NOT NULL,

);


