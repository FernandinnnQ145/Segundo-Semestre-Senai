/*Criar script que exiba os seguintes dados:

- Id Consulta
- Data da Consulta
- Horario da Consulta
- Nome da Clinica
- Nome do Paciente
- Nome do Medico
- Especialidade do Medico
- CRM
- Prontuário ou Descricao
- FeedBack(Comentario da consulta)

Criar função para retornar os médicos de uma determinada especialidade

*Criar procedure para retornar a idade de um determinado usuário específico
*/

USE HealthClinic_Tarde

SELECT C.IdConsulta, [Data], Horario, NomeFantasia, UP.Nome, UM.Nome, NomeEspecialidade, CRM, Prontuario, Descricao
FROM Consulta C
LEFT JOIN Paciente P
ON C.IdPaciente = P.IdPaciente
LEFT JOIN Medico M
ON C.IdMedico = M.IdMedico
LEFT JOIN Usuario UP 
ON P.IdUsuario = UP.IdUsuario 
LEFT JOIN Usuario UM
ON M.IdUsuario = UM.IdUsuario
LEFT JOIN Especialidade 
ON Especialidade.IdEspecialidade = M.IdEspecialidade
LEFT JOIN Clinica
ON Clinica.IdClinica = M.IdClinica
LEFT JOIN Comentario
ON Comentario.IdConsulta = C.IdConsulta AND Comentario.IdPaciente = P.IdPaciente