drop schema TCCSolidario;
CREATE DATABASE TCCSolidario;
USE TCCSolidario;

-- CREATE TABLE Categoria (
-- CategoriaId int(11) PRIMARY KEY AUTO_INCREMENT,
-- Titulo varchar(50)
-- );

CREATE TABLE Pedido (
PedidoId int(11) PRIMARY KEY AUTO_INCREMENT,
Quantidade int(11),
Estado int(11),
Data_Criacao datetime,
Comentario varchar(250),
Data_Modificacao datetime,
Descricao varchar(500)
);

CREATE TABLE Usuario (
UsuarioId int(11) PRIMARY KEY AUTO_INCREMENT,
Telefone int(11),
Documento varchar(1000),
Email varchar(50),
Senha varchar(50),
Nome varchar(50),
Data_Modificacao datetime,
Foto_usuario varchar(1000),
Data_Criacao datetime  
);

CREATE TABLE Beneficiario (
BeneficiadoId int(11) PRIMARY KEY AUTO_INCREMENT,
Interno boolean,
RA int(11),
UsuarioId int(11),
FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId)
);

CREATE TABLE Mediador (
MediadorId int(11) PRIMARY KEY AUTO_INCREMENT,
RA int(11),
UsuarioId int(11),
FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId)
);

CREATE TABLE Doador (
DoadorId int(11) PRIMARY KEY AUTO_INCREMENT,
UsuarioId int(11),
FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId)
);

CREATE TABLE Item (
ItemId int(11) PRIMARY KEY AUTO_INCREMENT,
Foto Text,
Titulo varchar(50),
Data_Modificacao datetime,
Data_Criacao datetime,
Descricao varchar(500),
CategoriaId int(11),
PedidoId int(11),
-- FOREIGN KEY(CategoriaId) REFERENCES Categoria (CategoriaId),
FOREIGN KEY(PedidoId) REFERENCES Pedido (PedidoId)
);

-- CREATE TABLE Acessa (
-- UsuarioId int(11),
-- PedidoId int(11),
-- FOREIGN KEY(UsuarioId) REFERENCES Usuario (UsuarioId),
-- FOREIGN KEY(PedidoId) REFERENCES Pedido (PedidoId);
-- );

-- CREATE TABLE Seleciona (
-- ItemId int(11),
-- PedidoId int(11),
-- FOREIGN KEY(PedidoId) REFERENCES Pedido (PedidoId),
-- FOREIGN KEY(ItemId) REFERENCES Item (ItemId);
-- );
CREATE TABLE Sessions (
SessionId int(11) PRIMARY KEY AUTO_INCREMENT,
UserId int(11),
UserType int(11)
);

