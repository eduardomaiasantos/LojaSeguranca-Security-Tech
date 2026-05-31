CREATE DATABASE LojaSeguranca;
USE LojaSeguranca;

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Usuario VARCHAR(50),
    Senha VARCHAR(50)
);

INSERT INTO Usuarios VALUES ('admin', '123');

CREATE TABLE Produtos (
    Id INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(100),
    Categoria VARCHAR(50),
    Preco DECIMAL(10,2),
    Quantidade INT
);



SELECT * FROM Usuarios;

INSERT INTO Produtos
VALUES
('Camera Intelbras', 'Camera', 350.00, 10);

SELECT * FROM Produtos;

CREATE TABLE Clientes
(
    Id INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(100),
    Telefone VARCHAR(20),
    Email VARCHAR(100),
    Endereco VARCHAR(200)
);


SELECT * FROM Clientes


