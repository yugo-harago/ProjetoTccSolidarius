BEGIN TRANSACTION;

INSERT INTO Usuario VALUES(1,97372836,'4238273984','estudante1@email.com','1234','Estudante 1','2020-04-23 00:00:00','person-02.png','2020-04-23 00:00:00');
INSERT INTO Usuario VALUES(2,980934382,'0394209328','doador1@email.com','1234','Doador1','2020-04-23 00:00:00','person-03.png','2020-04-23 00:00:00');      
INSERT INTO Usuario VALUES(3,980934382,'0394209328','mediador@email.com','1234','Mediador','2020-04-23 00:00:00','person-04.png','2020-04-23 00:00:00');      

INSERT INTO Mediador VALUES(1,38947,3);

INSERT INTO Beneficiario VALUES(1,0,1234,1);

INSERT INTO Doador VALUES(1,2);

INSERT INTO Item VALUES(1,NULL,NULL,'2020-04-23 00:00:00','2020-04-23 00:00:00','Agasalho',1,1);
INSERT INTO Pedido VALUES(1,0,10,'2020-04-23 20:00:33.2127483',NULL,'2020-04-23 20:00:33.2128659','Olá, o inverno está chegando e gostaria de pedir um agasalho para não passar frino dentro do internato.','Pedido de agasalho',NULL,1,NULL);

COMMIT;