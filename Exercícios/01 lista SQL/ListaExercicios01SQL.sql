CREATE TABLE pessoas(
	id INTEGER PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR (100),
	cpf VARCHAR (14),
	rg VARCHAR (12),
	data_nascimento DATETIME2,
	idade INT
	);

INSERT INTO pessoas 
	(nome, cpf, rg, data_nascimento, idade)
	VALUES ('Erick Bryan', '699.734.958-70', '90.745.276-0', '05-28-1989', '29');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas 
	(nome, cpf, rg, data_nascimento, idade)
	VALUES ('Samuel Ruan', '802.790.194-40', '55.318.691-7', '02-08-1988', '30');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES ('Fábio Souza', '522.445.349-60', '54.715.232-2', '03-22-1970', '48');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES ('Elias Miguel', '293.928.821-65', '12.680.444-8', '06-07-1986', '32');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Alexandre Gustavo', '617.408.878', '8.888.574-4', '04-15-2003', '15');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Kauê Duarte', '943.163.990-47', '46.977.509-9', '06-15-1965', '53');

SELECT id, nome, cpf, rg, data_nascimento
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Marcos Bryan', '955.129.235-95', '84.050.077-4', '02-06-2015', '3');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Benedito Pedro', '510.505.472-50', '43.588.124-3', '04-19-1981', '37');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Luis Igor', '370.570.311-06', '40.651.407-0', '05-06-2013', '5');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('José Ramos', '675.624.925-81', '83.962.258-2', '04-11-1965', '53');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Luca Tiago', '788.124.508-57', '3.293.335-6', '06-17-1977', '41');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES ('Tiago Oliveira', '389.969.352-39', '8.198.446-9', '06-09-1977', '41');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Enrico Julio', '529.078.166-83', '99.886.242-3', '03-11-2017', '1');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Oliver Mota', '798.556.805-02', '5.103.578-9', '03-27-1985', '33');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;

INSERT INTO pessoas
	(nome, cpf, rg, data_nascimento, idade)
	VALUES('Bryan Caio', '213.217.201-30', '12.494.454-9', '06-18-1970', '48');

SELECT id, nome, cpf, rg, data_nascimento, idade
	FROM pessoas;


-- ULTIMO SELECT DO EXERCÍCIO 01, CONFIGURANDO A DATA DE NASCIMENTO
SELECT id, nome, cpf, rg, idade,
	CONCAT(
		DAY(data_nascimento), '/',
		MONTH(data_nascimento), '/',
		YEAR(data_nascimento)) AS 'Data de nascimento'
		FROM pessoas;



--EXERCÍCIO NÚMERO 2 VVVV
--DROP TABLE enderecos;
CREATE TABLE enderecos(
	id INTEGER PRIMARY KEY IDENTITY(1,1),
	estado VARCHAR(2),
	cidade VARCHAR(140),
	bairro VARCHAR(120),
	cep VARCHAR(10),
	logradouro VARCHAR(250),
	numero INT,
	complemento text
	);

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES ('AC', 'Rio Branco', 'Ayrton Senna', '69.911-866', 'Estrada Deputado José Rui Da Silveira Lino', '282', 'casa');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('SC', 'Biguaçu', 'Fundos', '88.161-400', '', '995', '');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES ('MG', 'Santa Luzia', 'Padre Miguel', '33.082-050', 'Rua Buenos Aires', '371', 'Apartamento');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('BA', '', 'São Tomé de Paripe', '40.800-361', 'Travessa Luis Hage', '685', '');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('MG', 'Ipatinga', 'Vila Celeste', '', 'Rua Antonio Boa Ventura Batista', '645', '');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('RS', 'Passo Fundo', 'Nenê Graef', '99.030-250', '', '154', '');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('AM', 'Manaus', 'Petrópolis', '69.079-300', 'Rua Coronel Ferreira Sobrinho', '264', 'Fundos');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('TO', 'Gurupi', 'Muniz Santana', '77.402-130', 'Rua Adelmo Aires Negri', '794', '');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('AC', '', 'Preventório', '', 'Beco da ligação II', '212', 'Bloco B');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('AP', 'Santana', 'Comercial', '68.925-073', 'Rua Calçoene', '648', '');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

INSERT INTO enderecos
	(estado, cidade, bairro, cep, logradouro, numero, complemento)
	VALUES('PB', 'Cabedelo', 'Camalaú', '58.103-052', 'Rua Siqueira Campos', '249', '');

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET logradouro = 'Rua Julio Teodoro Martins'
	WHERE id = 2;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET complemento = 'Fundos'
	WHERE id = 2;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET cidade = 'Salvador'
	WHERE id = 4;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	 FROM enderecos;

UPDATE enderecos SET complemento = 'Casa'
	WHERE id = 4;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET cep = '35.162-484'
	WHERE id = 5;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET complemento = 'Apartamento'
	WHERE id = 5;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET logradouro = 'Rua Itu'
	WHERE id = 6;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET complemento = 'Casa'
	WHERE id = 6;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET complemento = 'Apartamento'
	WHERE id = 8;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET cidade = 'Rio Branco'
	WHERE id = 9;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET cep = '699.001-62'
	WHERE id = 9;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET complemento = 'Casa'
	WHERE id = 10;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

UPDATE enderecos SET complemento = 'Fundos'
	WHERE id = 11;

SELECT id, estado, cidade, bairro, cep, logradouro, numero, complemento
	FROM enderecos;

-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3
-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3-- EXERCÍCIO NÚMERO 3

CREATE TABLE champions(
	id INTEGER PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR (10),
	descricao VARCHAR (30),
	habilidade1 VARCHAR (50),
	habilidade2 VARCHAR (50),
	habilidade3 VARCHAR (50),
	habilidade4 VARCHAR (50),
	habilidade5 VARCHAR (50)
	);

