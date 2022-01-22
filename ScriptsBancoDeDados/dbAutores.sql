CREATE DATABASE Chapter
GO

USE Chapter
GO

CREATE TABLE Autores (
    Id INT PRIMARY KEY IDENTITY,
    NomeAutor VARCHAR(150) NOT NULL,
    LivrosPublicados INT,
)
GO

INSERT INTO Autores (NomeAutor, LivrosPublicados) 
VALUES ('Rick Chester A', 2)
GO

INSERT INTO Autores (NomeAutor, LivrosPublicados) 
VALUES ('Thiago Nigro', 1 )

GO
INSERT INTO Autores (NomeAutor, LivrosPublicados) 
VALUES ('J. K. Rowling', 36 )

