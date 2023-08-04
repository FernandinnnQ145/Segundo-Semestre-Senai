USE Exercicio_1_3


INSERT INTO CLINICA(NomeClinica, EnderecoClinica)
VALUES('Harryporco', 'rua porco'),('Palmeiras','rua palmeiras');



INSERT INTO TIPOPET(Tipo)
VALUES('Porco'),('Peixe'),('Sapo'),('Cachorro');



INSERT INTO DONO(NomeDono)
VALUES('Rony'),('Abel');




INSERT INTO VETERINARIO(IdClinica, Nomevet)
VALUES(2, 'Dudu'),(1, 'Valdivia');



INSERT INTO RACAS(IdTipopet, QualRaca)
VALUES( 3, 'SAPINHO'),( 1, 'PORQUINHO'), ( 2, 'BETA'),( 1, 'PORCAO'),( 4, 'SHIH-TZU'),( 3, 'SAPAO');


INSERT INTO PET(IdRacas, IdDono, NomePet)
VALUES(3,2,'Endrick'), (2,1, 'Gomez')



INSERT INTO ATENDIMENTO(IdVeterinario, IdPet, Horario_Atendimento)
VALUES(2, 2, '10.30H'),(1, 1, '10H');


