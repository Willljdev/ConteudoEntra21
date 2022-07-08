CREATE TABLE trabalhos(
	id INTEGER PRIMARY KEY IDENTITY(1,1),
	titulo VARCHAR (100),
	subtitulo VARCHAR (50),
	descricao TEXT, --ARMAZENR TEXTOS GRANDES
	data_publicacao DATETIME2, --DATA E HORA
	tipo VARCHAR (15)
);

INSERT INTO trabalhos
	(titulo, subtitulo, descricao, data_publicacao, tipo)
	VALUES ('A melhor pizza do mundo', 'Como degustar uma pizza de calabresa', 'Grande descrição aqui', '1994-06-04', 'Receita');

INSERT INTO trabalhos
	(titulo, subtitulo, descricao, data_publicacao, tipo)
	VALUES ('Clean code', 'Como trabalhar melhor no seu dia a dia', 'Utilizar var  no lugar de tipos primitivos, Identar seu código, Utilizar constantes', '2000-03-20', 'Leitura técnica');

INSERT INTO trabalhos
	(titulo, subtitulo, descricao, data_publicacao, tipo)
	VALUES ('Pudim com ovo', 'Aprenda oque não fazer na sua vida', 'Jogue o pudim no lixo e faça um ovo', '2022-07-06', 'Receita');

INSERT INTO trabalhos
	(titulo, subtitulo, descricao, data_publicacao, tipo)
	VALUES ('Estrutura de dados', 'como sofrer sem saber, porém é necessário', 'Importante para aprender fifo, lifo e fefo, listas encadeadas', '1980-05-11', 'Leitura técnica');

INSERT INTO trabalhos
	(titulo, subtitulo, descricao, data_publicacao, tipo)
	VALUES ('Strogonoff de frango', 'a vitória da batata palha', 'Compre frango e batata palha, jogue na panela, acenda o fogao, espere 5 minutinhos e ta plonto o sorvetinho', '2000-09-10', 'Receita');

SELECT id, titulo, subtitulo, descricao, data_publicacao, tipo
	FROM trabalhos;

--Concatenar informação de duas colunas
SELECT 
	CONCAT(titulo,' - ', descricao) AS 'Título completo'
	FROM trabalhos;

-- COnsultar a descrição limitando a quantidade de caracteres
SELECT
	titulo AS 'Titulo',
	CONCAT(SUBSTRING(descricao, 0, 30), '...') AS 'Descrição'
	FROM trabalhos;

-- Consultar trabalhos filtrando o ano da publicacao entre 1990 até 2010
SELECT id, titulo, data_publicacao
	FROM trabalhos
	WHERE 
		YEAR(data_publicacao) >= 1990 AND
		YEAR(data_publicacao) <= 2010;

-- Consultar data publicação formato BR huehue dia/mês/ano
SELECT id, titulo, 
	CONCAT(
		DAY(data_publicacao), '/',
		MONTH(data_publicacao), '/',
		YEAR(data_publicacao))
	FROM trabalhos;
	
-- Consultar data publicação formatando no padrão BR, utlizando a função para isso
SELECT id, titulo, FORMAT(data_publicacao, 'dd/MM/yyyy')
	FROM trabalhos;

SELECT id, titulo FROM trabalhos;

--Limitar a consulta para dois registros
SELECT TOP(2) id, titulo FROM trabalhos;

--Apresentar o código, nome, preço, se está favoritado
--filtrando por placa mãe u placa de video em ordem descrecente do preço
--SELECT TOP(20) id, nome, preco, favoritado
--FROM produtos
--WHERE categoria = 'placa mãe' OR categoria = 'Placa de vídeo'
--ORDER BY preco DESC

--Consulta com paginação apresentando 2 registros da pagina 1
SELECT id, titulo
	FROM trabalhos
	ORDER BY id
	OFFSET 0 ROWS FETCH NEXT 2 ROWS ONLY;

--Consulta com paginação apresentando 2 registros da pagina 2
SELECT id, titulo
	FROM trabalhos
	ORDER BY id
	OFFSET 2 ROWS FETCH NEXT 2 ROWS ONLY;

--Consulta com paginação apresentando 2 registros da pagina 3
SELECT id, titulo
	FROM trabalhos
	ORDER BY id
	OFFSET 4 ROWS FETCH NEXT 2 ROWS ONLY;



