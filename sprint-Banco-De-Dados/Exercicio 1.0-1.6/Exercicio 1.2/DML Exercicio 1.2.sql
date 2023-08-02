USE Exercicio_1_2


INSERT INTO EMPRESA(nomeEmpresa)
VALUES('Motinhas') ,('Carrinhos');




INSERT INTO CLIENTE(NomeCliente, CpfCliente)
VALUES('Raimundo', 2345),('Joaozinho',4589);



INSERT INTO MARCA(NomeMarca)
VALUES('BMW'),('Chevrolet');



INSERT INTO MODELO(NomeModelo, IdMarca)
VALUES('Gol', 1),('Corsa',2),('jetta',2);



INSERT INTO VEICULO(IdEmpresa, IdModelo, PlacaVeiculo)
VALUES(2, 1,2213),(1,2,45678),(1,1,4545),(2,3,6873);




INSERT INTO ALUGUEL(IdVeiculo, IdCliente, Descricao)
VALUES(2, 2, '12.12.21 A 15.12.21'),(3,1, '15.02.21 A 16.02.21');
