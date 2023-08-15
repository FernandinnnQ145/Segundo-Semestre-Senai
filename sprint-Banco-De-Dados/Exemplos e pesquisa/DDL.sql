CREATE DATABASE BancoTarde

USE BancoTarde;


CREATE TABLE Funcionarios 
(
IdFuncionario INT PRIMARY KEY IDENTITY,
Nome VARCHAR(10) 
);

CREATE TABLE Empresas
(
IdEmpresa INT PRIMARY KEY IDENTITY,
IdFuncionario INT FOREIGN KEY REFERENCES Funcionarios(IdFuncionario),
Nome VARCHAR(20)
);


----------------------------
--Alter table
ALTER TABLE Funcionarios
ADD Cpf VARCHAR(11) 

ALTER TABLE Funcionarios
DROP COLUMN Cpf



