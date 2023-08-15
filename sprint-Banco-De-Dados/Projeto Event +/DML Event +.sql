--DML

INSERT INTO TiposDeUsuario(TituloTipoUsuario) VALUES ('Administrador', 'Comum');

INSERT INTO TiposDeEvento(TituloTipoEvento) VALUES ('SQL Server');

INSERT INTO Instituicao(CNPJ, Endereco, NomeFantasia) VALUES ('83094672000130', 'Rua Niteroi, 180 São Caetano do Sul', 'DevSchool')

INSERT INTO Usuario(IdTipoDeUsuario, Nome, Email, Senha) VALUES (1, 'Rony', 'Rustico@gmail.com', 'Palmeiras')

INSERT INTO Evento(IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento, HorarioEvento) VALUES (1, 1, 'Libertadores', 'Palmeiras', '2023-08-09', '21:30:00')

INSERT INTO PresencasEvento(IdUsuario, IdEvento, Situacao) VALUES (1, 1, 0)

INSERT INTO ComentarioEvento(IdUsuario, IdEvento, Descricao, Exibe) VALUES (1, 1, 'AAAAA QUE LEGAL', 1)



