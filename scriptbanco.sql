CREATE DATABASE TestRommanel;
GO

-- Usar o banco de dados recém-criado
USE TestRommanel;
GO

-- Criar a tabela de Clientes
CREATE TABLE Clientes (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    NomeRazaoSocial NVARCHAR(255) NOT NULL,
    CPF_CNPJ NVARCHAR(14) NOT NULL UNIQUE,
    DataNascimento DATE NULL,
    Telefone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    TipoPessoa CHAR(1) NOT NULL CHECK (TipoPessoa IN ('F', 'J')), -- 'F' = Física, 'J' = Jurídica
    InscricaoEstadual NVARCHAR(20) NULL, -- Apenas para Pessoa Jurídica
    IsentoIE BIT NULL, -- Indica se a empresa é isenta de IE
    DataCadastro DATETIME DEFAULT GETDATE()
);
GO

-- Criar a tabela de Endereços
CREATE TABLE Enderecos (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ClienteId UNIQUEIDENTIFIER NOT NULL,
    CEP NVARCHAR(10) NOT NULL,
    Endereco NVARCHAR(255) NOT NULL,
    Numero NVARCHAR(10) NOT NULL,
    Bairro NVARCHAR(100) NOT NULL,
    Cidade NVARCHAR(100) NOT NULL,
    Estado NVARCHAR(2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id) ON DELETE CASCADE
);
GO