-- drop schema TCCSolidario;
--CREATE DATABASE TCCSolidario;
--USE TCCSolidario;

-- CREATE TABLE Categoria (
-- CategoriaId integer(11) PRIMARY KEY AUTOINCREMENT,
-- Titulo varchar(50)
-- );

CREATE TABLE Pedido (
PedidoId integer PRIMARY KEY AUTOINCREMENT,
Quantidade integer(11),
Estado integer(11),
Data_Criacao datetime,
Comentario varchar(250),
Data_Modificacao datetime,
Descricao varchar(500),
Titulo varchar(10),
Agradecimento varchar(1000),
FeitoPor integer(11),
AceitoPor integer(11),
FOREIGN KEY(FeitoPor) REFERENCES Usuario (UsuarioId),
FOREIGN KEY(AceitoPor) REFERENCES Usuario (UsuarioId)
);

CREATE TABLE Usuario (
UsuarioId integer PRIMARY KEY AUTOINCREMENT,
Telefone integer(11),
Documento varchar(1000),
Email varchar(50),
Senha varchar(50),
Nome varchar(50),
Data_Modificacao datetime,
Foto_usuario varchar(1000),
Data_Criacao datetime  
);

CREATE TABLE Beneficiario (
BeneficiadoId integer PRIMARY KEY AUTOINCREMENT,
Interno boolean,
RA integer(11),
UsuarioId integer(11),
FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId)
);

CREATE TABLE Mediador (
MediadorId integer PRIMARY KEY AUTOINCREMENT,
RA integer(11),
UsuarioId integer(11),
FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId)
);

CREATE TABLE Doador (
DoadorId integer PRIMARY KEY AUTOINCREMENT,
UsuarioId integer(11),
FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId)
);

CREATE TABLE Notificacao (
NotificacaoId integer PRIMARY KEY AUTOINCREMENT,
Para integer(11),
Por integer(11),
Descricao varchar(1000),
Visto boolean,
Confirmado boolean,
Pedido integer(11),
FOREIGN KEY(Para) REFERENCES Usuario (UsuarioId),
FOREIGN KEY(Por) REFERENCES Usuario (UsuarioId),
FOREIGN KEY(Pedido) REFERENCES Pedido (PedidoId)
);

CREATE TABLE Item (
ItemId integer PRIMARY KEY AUTOINCREMENT,
Foto Text,
Titulo varchar(50),
Data_Modificacao datetime,
Data_Criacao datetime,
Descricao varchar(500),
CategoriaId integer(11),
PedidoId integer(11),
FOREIGN KEY(PedidoId) REFERENCES Pedido (PedidoId)
);

-- CREATE TABLE Acessa (
-- UsuarioId integer(11),
-- PedidoId integer(11),
-- FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId),
-- FOREIGN KEY(PedidoId) REFERENCES Pedido (PedidoId);
-- );

-- CREATE TABLE Seleciona (
-- ItemId integer(11),
-- PedidoId integer(11),
-- FOREIGN KEY(PedidoId) REFERENCES Pedido (PedidoId),
-- FOREIGN KEY(ItemId) REFERENCES Item (ItemId);
-- );
CREATE TABLE Sessions (
SessionId integer PRIMARY KEY AUTOINCREMENT,
UserId integer(11),
UserType integer(11)
);

