CREATE DATABASE Filmes_tarde
USE Filmes_tarde

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

INSERT INTO Genero (Nome) VALUES ('A��o');
INSERT INTO Genero (Nome) VALUES ('Com�dia');
INSERT INTO Genero (Nome) VALUES ('Drama');
INSERT INTO Genero (Nome) VALUES ('Fic��o Cient�fica');


INSERT INTO Filme (IdGenero, Titulo) VALUES (1, 'Vingadores: Ultimato');
INSERT INTO Filme (IdGenero, Titulo) VALUES (1, 'Mad Max: Estrada da F�ria');
INSERT INTO Filme (IdGenero, Titulo) VALUES (2, 'Superbad');
INSERT INTO Filme (IdGenero, Titulo) VALUES (3, 'O Poderoso Chef�o');
INSERT INTO Filme (IdGenero, Titulo) VALUES (4, 'Blade Runner 2049');