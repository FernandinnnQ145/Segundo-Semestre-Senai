

USE inlock_games_codeFirst_tarde

INSERT INTO Estudio
VALUES (NEWID(),'SENAI'),(NEWID(),'SESI'),(NEWID(),'SEBRAE')

SELECT * FROM Estudio

INSERT INTO Jogo
VALUES (NEWID(),'PING PONG','JOGO LEGAL','2023-01-01',12.34, 'D4F0E03F-4A6D-48D8-A45C-89400C1D0DCA'), 
	   (NEWID(),'JUCAMOM','CA�A POKEMOM','2022-03-23',2.99, 'D4F0E03F-4A6D-48D8-A45C-89400C1D0DCA')

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES (NEWID(),'administrador'),(NEWID(),'comum')

SELECT * FROM TiposUsuario

 

INSERT INTO Usuario
VALUES   (NEWID(), 'comum@comum','comumm', '767AB53E-3B73-4E5A-89B5-4E21D8219C5B')   

	   
SELECT * FROM Usuario

