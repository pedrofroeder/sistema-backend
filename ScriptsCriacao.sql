-- CRIAR O BANCO
CREATE DATABASE programacao_do_zero;

-- USAR O BANCO
USE programacao_do_zero;

-- CRIAR TABELA USUÁRIO
CREATE TABLE usuario (
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);

-- CRIAR TABELA ENDEREÇO
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
	cidade VARCHAR(250) NOT NULL,
	complemento VARCHAR(150) NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY (id)
);

-- ALTERAR TABELA ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- ADICIONAR CHAVE ESTRANGEIRA
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- INSERIR USUÁRIO
INSERT INTO usuario
(nome, sobrenome, telefone, email, genero, senha) 
VALUES 
('Pedro', 'Froeder', '(11) 97078-2387', 'pedrofroeder22@gmail.com', 'masculino', '123');

-- SELECIONAR TODOS USUÁRIOS
SELECT * FROM usuario;

-- SELECIONAR UM USUÁRIO ESPECÍFICO
SELECT * FROM usuario WHERE email = 'pedrofroeder22@gmail.com';

-- ALTERAR USUÁRIO
UPDATE usuario SET email = 'pedrofroeder22@gmail.com' WHERE id = 3;

-- EXCLUIR USUÁRIO
DELETE FROM usuario WHERE id = 2;

