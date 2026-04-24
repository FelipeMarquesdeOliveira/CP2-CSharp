-- =====================================================
-- Script de criação do banco de dados
-- Sistema de Estoque - Checkpoint 2
-- Disciplina: C# Software Development
-- Professor: Angel Antonio Gonzalez Martinez
--
-- Integrantes:
-- RM556319 - Felipe Marques de Oliveira
-- RM556309 - Gabriel Barros Cisoto
-- =====================================================

IF DB_ID('DB_Felipe_RM556319') IS NULL
BEGIN
    CREATE DATABASE DB_Felipe_RM556319;
END
GO

USE DB_Felipe_RM556319;
GO

-- =====================================================
-- Tabela de Produtos
-- =====================================================
IF OBJECT_ID('dbo.Produto', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Produto;
END
GO

CREATE TABLE dbo.Produto
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    Quantidade INT NOT NULL DEFAULT 0,
    Ativo BIT NOT NULL DEFAULT 1,
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- =====================================================
-- Inserir dados de exemplo
-- =====================================================
INSERT INTO dbo.Produto (Nome, Preco, Quantidade, Ativo, DataCadastro)
VALUES
    ('Mouse Logitech MX Master 3', 450.00, 15, 1, GETDATE()),
    ('Teclado Mecânico Razer Huntsman', 850.00, 8, 1, GETDATE()),
    ('Monitor Dell 27" 4K', 2200.00, 5, 1, GETDATE()),
    ('Notebook ThinkPad T490', 5500.00, 3, 1, GETDATE()),
    ('Webcam HD 1080p', 280.00, 20, 1, GETDATE()),
    ('Headset HyperX Cloud II', 380.00, 12, 1, GETDATE()),
    ('Mousepad Gamer XL', 89.90, 30, 1, GETDATE()),
    ('Hub USB-C 7 Portas', 150.00, 25, 1, GETDATE());
GO

-- =====================================================
-- Verificar dados
-- =====================================================
SELECT *
FROM dbo.Produto
WHERE Ativo = 1
ORDER BY Id;
GO
