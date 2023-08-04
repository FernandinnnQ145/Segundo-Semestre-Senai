USE Exercicio_1_4


INSERT INTO USUARIO(NomeUsuario,Email,Senha,Permissao)
VALUES('Veiga', 'Bestplayer@gmail.com', 'carac', 'Administrador'),('Henrique', 'Henriqu@gmail.com', 'doisd', 'Comum'), ('Dudu', 'Palmeiras@gmail.com', 'Palmeiras', 'Comum')


INSERT INTO ARTISTA(NomeArtista)
VALUES('Kyan'),('Rdrigao');


INSERT INTO ESTILO(EstiloMusical)
VALUES('forró'),('rock');


INSERT INTO ALBUNS( IdEstilo, IdArtista, Titulo, Localização, QuantosMinutos, DataLancamento)
VALUES(2, 1, 'Rock na veia','santiago','10min','2004'),(1, 2, 'TSS','eua','15min','1996' );


