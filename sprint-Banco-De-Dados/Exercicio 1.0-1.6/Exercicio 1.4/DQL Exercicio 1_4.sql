SELECT IdUsuario, NomeUsuario, Email, Permissao
FROM USUARIO
WHERE Permissao = 'Administrador';

SELECT IdAlbuns, IdEstilo, IdArtista, Titulo, Localização, QuantosMinutos, DataLancamento
From ALBUNS
WHERE DataLancamento < 2003

SELECT IdUsuario, NomeUsuario, Email, Senha, Permissao
FROM USUARIO
WHERE USUARIO.Email = 'BestPlayer@gmail.com' AND USUARIO.Senha = 'carac'

SELECT A.IdArtista, NomeArtista, EstiloMusical, Titulo, Localização, QuantosMinutos, DataLancamento
FROM ALBUNS 
INNER JOIN ARTISTA A
ON ALBUNS.IdArtista = A.IdArtista
INNER JOIN ESTILO
ON ALBUNS.IdEstilo = Estilo.IdEstilo;