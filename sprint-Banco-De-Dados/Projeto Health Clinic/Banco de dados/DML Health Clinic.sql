USE HealthClinic_Tarde

INSERT INTO Clinica(NomeFantasia,Endereco,HorarioFuncionamento,CNPJ,RazaoSocial,Convenio)
VALUES('Clinica palmeiras', 'Barra funda - Av palestra italia', '7:00 as 22:00', '12345678900000', 'Sociedade esportiva palmeiras', 'Alianz parque' )

INSERT INTO TipoUsuario(NomeTipoUsuario)
VALUES('ADMINISTRADOR'),('COMUM')

INSERT INTO Especialidade(NomeEspecialidade)
VALUES('Nutricionista'), ('Pediatra'),('Neurologista')

INSERT INTO Usuario (IdTipoUsuario, Email, DataDeNascimento, Nome, Senha)
VALUES (2, 'Rustico@gmail.com', '21/08/1995', 'Rony', '1'), (2, 'Aviao@gmail.com', '14/02/1903', 'Aviao', 'a')

INSERT INTO Paciente (IdUsuario, CPF, Convenio)
VALUES(1, '12345678900', 'Notredame')

INSERT INTO Medico(IdUsuario, IdEspecialidade, IdClinica, CRM)
VALUES(2,3,1,'123456')

INSERT INTO Consulta (IdPaciente, IdMedico, [Data], Horario)
VALUES (1,1,'20/08', '17:00')

INSERT INTO Consulta (IdPaciente, IdMedico, [Data], Horario,  Prontuario)
VALUES (1,1,'14/08','14:00', 'Paciente veio para o medico alegando fortes dores na cabeca passei alguns remedios para ele tomar, retornara 6 dias')

INSERT INTO Comentario(IdPaciente,IdConsulta,Descricao)
VALUES (1,1,'Otimo medico muito educado')

