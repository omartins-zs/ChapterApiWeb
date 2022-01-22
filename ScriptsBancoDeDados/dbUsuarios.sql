CREATE DATABASE Chapter
GO

USE Chapter

GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(120) NOT NULL,
    -- Adicionado Tipo na Video Aula do Encontro Remoto 3 - 21/01
    Tipo INT NOT NULL
)

GO

INSERT INTO Usuarios VALUES ('email@email.br', '4321', 1)

INSERT INTO Usuarios VALUES ('teste@teste.br', '6789', 0)

