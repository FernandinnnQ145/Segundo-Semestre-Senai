INSERT INTO Pessoa(Nome, CNH)
Values('Carlos', '123456'), ('Eduardo', '12345');

INSERT INTO Email (IdPessoa, Endereco)
VALUES(1, 'Carlos@gmail.com'), (2, 'arroz@gmail.com');

INSERT INTO Telefone (IdPessoa, Numero)
VALUES(1, '99980908'), (2, '235333');

SELECT 

p.Nome as batata,
Telefone.Numero as TELEFONE,
e.Endereco as Email,
p.CNH
FROM
Pessoa as p,
Email as e,
Telefone 
WHERE 
p.IdPessoa = e.IdPessoa 
AND p.IdPessoa = Telefone.IdPessoa

ORDER BY 
Nome DESC

INSERT INTO Pessoa(Nome, CNH)
Values('Cicinho', '43'), ('Marcos', '21'), ('MarcosAssuncao', '54');

SELECT * FROM Pessoa

