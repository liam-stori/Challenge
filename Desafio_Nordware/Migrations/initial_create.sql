CREATE TABLE customer (
	id SERIAL PRIMARY KEY, 
	name VARCHAR(150) NOT NULL,
	email VARCHAR(100) NOT NULL, 
	document VARCHAR(25) NOT NULL, 
	address VARCHAR(250) NOT null
);

CREATE TABLE product_status (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE product (
	id SERIAL PRIMARY KEY,
	name VARCHAR(75) NOT NULL,
    category VARCHAR(100) NOT NULL,
    description VARCHAR(250) NOT NULL,
    price NUMERIC(10, 2) NOT NULL,
    quantity INT NOT NULL,
    id_status INT NOT null,
    CONSTRAINT P_FK_id_status FOREIGN KEY (id_status) REFERENCES product_status(id)
);

CREATE TABLE reservation_status (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE reservation (
	id SERIAL PRIMARY KEY,
	quantity INT NOT NULL,
    reserved_at TIMESTAMP NOT NULL,
    expired_at TIMESTAMP,
    canceled_at TIMESTAMP,
    id_status INT NOT NULL,
    id_customer INT NOT NULL REFERENCES customer(id) ON DELETE CASCADE,
    id_product INT NOT null,
    CONSTRAINT R_FK_id_status FOREIGN KEY (id_status) REFERENCES reservation_status(id),
    CONSTRAINT cr_fk_id_customer FOREIGN KEY (id_customer)
        REFERENCES customer (id) ON DELETE cascade,
    CONSTRAINT r_customer_product UNIQUE (id_customer, id_product)
);

ALTER TABLE reservation
ADD CONSTRAINT r_fk_id_customer
FOREIGN KEY (id_customer) REFERENCES customer (id) ON DELETE CASCADE;

ALTER TABLE reservation
ADD CONSTRAINT r_fk_id_product
FOREIGN KEY (id_product) REFERENCES product (id) ON DELETE CASCADE;

CREATE INDEX idx_r_id_customer ON reservation (id_customer);
CREATE INDEX idx_r_id_product ON reservation (id_product);

INSERT INTO customer (
	name, 
	email, 
	document, 
	address) 
VALUES (
	'Harry', 
	'harry@email.com', 
	'123.456.798-12', 
	'Rua dos Alfeneiros, 4'),
	('Hermione Granger', 
	'hermione@email.com', 
	'987.654.321-00', 
	'Avenida dos Livros, 13'),
	('Ron Weasley', 
	'ron@email.com', 
	'456.123.789-11', 
	'Travessa do Trote, 7'),
	('Albus Dumbledore', 
	'dumbledore@email.com', 
	'789.456.123-22', 
	'Castelo de Hogwarts, Sala do Diretor'),
	('Severus Snape', 
	'snape@email.com', 
	'321.654.987-33', 
	'Calabouço, Corredor Norte'),
	('Draco Malfoy', 
	'draco@email.com', 
	'159.753.486-44', 
	'Mansão Malfoy, 10'),
	('Luna Lovegood', 
	'luna@email.com', 
	'852.963.741-55', 
	'Rua dos Narguilés, 3'),
	('Minerva McGonagall', 
	'minerva@email.com', 
	'741.852.963-66', 
	'Castelo de Hogwarts, Torre Norte'),
	('Rubeus Hagrid', 
	'hagrid@email.com', 
	'963.852.741-77', 
	'Cabana ao lado da Floresta Proibida'),
	('Neville Longbottom', 
	'neville@email.com', 
	'654.987.321-88', 
	'Rua das Plantas, 8'),
	('Ginny Weasley', 
	'ginny@email.com', 
	'321.987.654-99', 
	'Toca dos Weasleys, Quarto 3');

INSERT INTO product_status (
	id,
	name)
VALUES (
	1,
	'Avaliable'
);

INSERT INTO product_status (
	id,
	name)
VALUES (
	2,
	'Out of Stock'
);

INSERT INTO product_status (
	id,
	name)
VALUES (
	3,
	'Temporarily Unavailable'
);

INSERT INTO product_status (
	id,
	name)
VALUES (
	4,
	'High Demand'
);

INSERT INTO product (
	name, 
	category, 
	description, 
	price, 
	quantity, 
	id_status) 
VALUES (
	'TV', 
	'Eletrodomésticos', 
	'TV Ultra HD 4K com design moderno, imagens nítidas e som envolvente. Perfeita para sua diversão!', 
	2139.99, 
	5, 
	4),
	('Geladeira', 
	'Eletrodomésticos', 
	'Geladeira Frost Free com alta capacidade e design moderno.', 
	3299.90, 
	10, 
	1),
	('Notebook', 
	'Informática', 
	'Notebook com processador Intel i7, 16GB de RAM e SSD de 512GB.', 
	4999.99, 
	7, 
	1),
	('Smartphone', 
	'Eletrônicos', 
	'Smartphone com tela AMOLED, 128GB de armazenamento e câmera tripla.', 
	2599.00, 
	0, 
	3),
	('Fone de Ouvido', 
	'Eletrônicos', 
	'Fone Bluetooth com cancelamento de ruído e som de alta qualidade.', 
	399.90, 
	0, 
	2),
	('Micro-ondas', 
	'Eletrodomésticos', 
	'Micro-ondas com painel digital e funções pré-programadas.', 
	899.90, 
	12, 
	4),
	('Smartwatch', 
	'Eletrônicos', 
	'Relógio inteligente com monitoramento de saúde e notificações.', 
	1199.99, 
	8, 
	4),
	('Cadeira Gamer', 
	'Móveis', 
	'Cadeira ergonômica com ajustes e estofado confortável.', 
	699.90, 
	5, 
	1),
	('Aspirador de Pó', 
	'Eletrodomésticos', 
	'Aspirador potente e compacto para facilitar a limpeza.', 
	349.99, 
	0, 
	3),
	('Monitor', 
	'Informática', 
	'Monitor LED Full HD com taxa de atualização de 75Hz.', 
	899.00, 
	0, 
	2);

INSERT INTO reservation_status (
	id,
	name)
VALUES (
	1,
	'Reserved'
);

INSERT INTO reservation_status (
	id,
	name)
VALUES (
	2,
	'Expired'
);

INSERT INTO reservation_status (
	id,
	name)
VALUES (
	3,
	'Canceled'
);

INSERT INTO reservation (
	id_product, 
	id_customer, 
	quantity, 
	reserved_at, 
	expired_at, 
	canceled_at, 
	id_status) 
VALUES 
	(1, 1, 2, now(), null, null, 1),
	(2, 2, 3, now() - interval '2 days', null, null, 1),
	(3, 3, 2, now() - interval '23 hours', null, null, 1),
	(4, 4, 1, '2023-11-30 10:00:00', '2023-12-01 10:00:00', null, 2),
	(5, 5, 2, now() - interval '5 days', now() - interval '2 days', null, 2),
	(6, 6, 1, now() - interval '4 days', now() - interval '1 day', null, 2),
	(7, 7, 1, now() - interval '15 days', null, now() - interval '13 days', 3),
	(8, 8, 4, now() - interval '2 hours', null, now() - interval '1 hour', 3),
	(9, 9, 2, now() - interval '5 days', null, now() - interval '2 days', 3),
	(4, 10, 1, '2022-11-30 08:00:00', null, null, 1),
	(10, 11, 2, '2022-10-15 15:00:00', '2022-10-20 15:00:00', null, 2);
