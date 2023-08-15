--DQL

-- Criar script para consulta exibindo os seguintes dados

/*Usar JOIN

Nome do usu�rio
Tipo do usu�rio
Data do evento
Local do evento (Institui��o)
Titulo do evento
Nome do evento
Descri��o do evento
Situa��o do evento
Coment�rio do evento
*/



SELECT U.Nome, TituloTipoUsuario, DataEvento, Endereco, E.Nome, E.Descricao, CASE WHEN PresencasEvento.Situacao = 1 THEN 'CONFIRMADO' ELSE 'NAO CONFIRMADO' END, C.Descricao
FROM Usuario U
INNER JOIN TiposDeUsuario 
ON U.IdTipoDeUsuario = TiposDeUsuario.IdTipoDeUsuario
INNER JOIN PresencasEvento
ON PresencasEvento.IdUsuario = U.IdUsuario
INNER JOIN Evento E
ON E.IdEvento = PresencasEvento.IdPresencasEvento
INNER JOIN Instituicao
ON E.IdInstituicao = Instituicao.IdInstituicao
LEFT JOIN ComentarioEvento C
ON C.IdUsuario = U.IdUsuario AND C.IdEvento = E.IdEvento



