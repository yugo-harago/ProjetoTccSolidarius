USE TCCSolidario;

-- INSERT Categoria (CategoriaId, Titulo)  
--     VALUES (1, 'Higiene Pessoal');

-- INSERT Categoria (CategoriaId, Titulo)  
--     VALUES (2, 'Roupas');

-- INSERT Categoria (CategoriaId, Titulo)  
--     VALUES (3, 'Utensílio domestico');

-- INSERT Categoria (CategoriaId, Titulo)  
--     VALUES (4, 'Sapatos');

INSERT Pedido (Quantidade, Estado, PedidoId, Data_Criacao, Comentario, Data_Modificacao, Descricao)  
    VALUES (1, 10, 1, '2020-03-02 09:00:00', 'Muito Obrigado!!!', '2020-03-02 10:00:00', 'preiso de um shampoo, quero tomar banho');

INSERT Pedido (Quantidade, Estado, PedidoId, Data_Criacao, Comentario, Data_Modificacao, Descricao)  
    VALUES (2, 20, 2, '2020-02-01 12:00:00', '', '2020-02-01 16:00:00', 'Necessito de duas blusas de frio');

INSERT Pedido (Quantidade, Estado, PedidoId, Data_Criacao, Comentario, Data_Modificacao, Descricao)  
    VALUES (1, 30, 3, '2020-04-27 04:00:00', '', '2020-04-28 02:00:00', 'Aguem pode me doar um prato');

INSERT Pedido (Quantidade, Estado, PedidoId, Data_Criacao, Comentario, Data_Modificacao, Descricao)  
    VALUES (1, 10, 4, '2020-03-02 06:00:00', '', '2020-03-02 10:00:00', 'preciso de um tenis, para aula de educação fisica');

INSERT Item (foto, ItemId, Titulo, Data_Modificacao, Data_Criacao, Descricao, CategoriaId, PedidoId)  
    VALUES ('images\imgshampoo.png', 1, 'Shampoo', '2019-11-01 22:15:00', '2019-10-28 10:00:00', 'Shampoo para cabelos cacheados', 1, 1);

INSERT Item (foto, ItemId, Titulo, Data_Modificacao, Data_Criacao, Descricao, CategoriaId, PedidoId)  
    VALUES ('images\imgblusa.png', 2, 'Blusa de frio', '2020-02-01 12:00:00', '2020-02-01 16:00:00', 'blusa de algodão', 2, 2);

INSERT Item (foto, ItemId, Titulo, Data_Modificacao, Data_Criacao, Descricao, CategoriaId, PedidoId)  
    VALUES ('images\imgprato.png', 3, 'Prato', '2020-04-27 04:00:00', '2020-04-28 02:00:00', 'Prato de porcelana', 3, 3);

INSERT Item (foto, ItemId, Titulo, Data_Modificacao, Data_Criacao, Descricao, CategoriaId, PedidoId)  
    VALUES ('images\imgtenis.png', 4, 'Tenis', '2020-03-02 06:00:00', '2020-03-02 10:00:00', 'Tenis de corrida', 4, 3);

INSERT Usuario (Telefone, Documento, Email, Senha, Nome, UsuarioId, Data_Modificacao, Foto_usuario, Data_Criacao)  
    VALUES (1998100000, 
    'images\IMG01.PNG', 
    'exemplo@gmail.com', '1234', 'Filipe', 1, '2020-03-12 20:00:00', 
    'images\foto.png', 
    '2019-12-03 19:00:00');

INSERT Usuario (Telefone, Documento, Email, Senha, Nome, UsuarioId, Data_Modificacao, Foto_usuario, Data_Criacao)  
    VALUES (1998100000, 'images\IMG02.PNG', 'exemplo02@gmail.com', '1234', 'Matheus', 2, '2019-12-12 20:00:00', 'images\foto2.png', '2019-10-03 19:00:00');

INSERT Usuario (Telefone, Documento, Email, Senha, Nome, UsuarioId, Data_Modificacao, Foto_usuario, Data_Criacao)  
    VALUES (1957100000, 'images\IMG03.PNG', 'exemplo03@gmail.com', '1234', 'João', 3, '2020-02-11 20:00:00', 'images\foto3.png', '2019-11-10 19:00:00');

INSERT Usuario (Telefone, Documento, Email, Senha, Nome, UsuarioId, Data_Modificacao, Foto_usuario, Data_Criacao)  
    VALUES (1972100000, 'images\IMG04.PNG', 'exemplo04@gmail.com', '1234', 'Maria', 4, '2019-12-07 20:00:00', 'images\foto4.png', '2019-12-05 15:00:00');

INSERT Usuario (Telefone, Documento, Email, Senha, Nome, UsuarioId, Data_Modificacao, Foto_usuario, Data_Criacao)  
    VALUES (513210000, 'images\IMG05.PNG', 'exemplo05@gmail.com', '1234', 'Fernando', 5, '2019-12-17 05:00:00', 'images\foto5.png', '2019-12-17 04:00:00');

INSERT Usuario (Telefone, Documento, Email, Senha, Nome, UsuarioId, Data_Modificacao, Foto_usuario, Data_Criacao)  
    VALUES (489210000, 'images\IMG06.PNG', 'exemplo06@gmail.com', '1234', 'José', 6, '2019-12-20 21:00:00', 'images\foto5.png', '2019-12-19 17:00:00');

INSERT Beneficiario (Interno, RA, BeneficiadoId, UsuarioId)  
    VALUES (1, 59000, 1, 1);

INSERT Beneficiario (Interno, RA, BeneficiadoId, UsuarioId)  
    VALUES (0, 58900, 2, 4);

INSERT Beneficiario (Interno, RA, BeneficiadoId, UsuarioId)  
    VALUES (1, 57200, 3, 5);

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (1, 1)

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (1, 3)

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (4, 2)

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (5, 4)

-- INSERT Seleciona (ItemId, PedidoId)  
--     VALUES (1, 1)

-- INSERT Seleciona (ItemId, PedidoId)  
--     VALUES (2, 2)

-- INSERT Seleciona (ItemId, PedidoId)  
--     VALUES (3, 3)

-- INSERT Seleciona (ItemId, PedidoId)  
--     VALUES (4, 4)

INSERT Mediador (MediadorId, RA, UsuarioId)  
    VALUES (1, 58000, 2);

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (2, 1)

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (2, 2)

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (2, 3)

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (2, 4)

INSERT Doador (DoadorId, UsuarioId)  
    VALUES (1, 3);

INSERT Doador (DoadorId, UsuarioId)  
    VALUES (2, 6);

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (3, 1)

-- INSERT Acessa (UsuarioId, PedidoId)  
--     VALUES (6, 2)