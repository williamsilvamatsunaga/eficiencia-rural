CREATE DATABASE eficienciarural;
USE eficienciarural;

CREATE TABLE IF NOT EXISTS categoria (
    id_categoria INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome_cat VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS insumo (
    id_insumo INT NOT NULL PRIMARY  KEY AUTO_INCREMENT,
    descricao_ins VARCHAR(100),
    und_medida_ins VARCHAR(50) NOT NULL,
    categoria_ins VARCHAR(50) NOT NULL,
    quantidade_ins DOUBLE NOT NULL,
    valor_unit_ins DOUBLE NOT NULL
);

CREATE TABLE IF NOT EXISTS propriedade (
    id_propriedade INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome_pro VARCHAR(100) NOT NULL,
    tamanho_pro DOUBLE NOT NULL,
    endereco_pro VARCHAR(300) NOT NULL
);

CREATE TABLE IF NOT EXISTS animal (
    id_animal INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    identificacao_ani VARCHAR(50) NOT NULL,
    dt_nascimento_ani DATE NOT NULL,
    peso_ani DOUBLE,
    fk_id_categoria INT NOT NULL,
    fk_id_propriedade INT NOT NULL,
    FOREIGN KEY (fk_id_categoria) REFERENCES categoria(id_categoria),
    FOREIGN KEY (fk_id_propriedade) REFERENCES propriedade(id_propriedade)
);

CREATE TABLE IF NOT EXISTS piquete (
    id_piquete INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome_piq VARCHAR(50) NOT NULL,
    tamanho_piq DOUBLE NOT NULL,
    tipo_pastagem_piq VARCHAR(50) NOT NULL,
    fk_id_propriedade INT NOT NULL,
    FOREIGN KEY (fk_id_propriedade) REFERENCES propriedade(id_propriedade)
);

CREATE TABLE IF NOT EXISTS producao (
    id_producao INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    valor_unitario_pro DOUBLE NOT NULL,
    data_hora_inicio_pro DATETIME NOT NULL,
    qtd_litros_pro DOUBLE NOT NULL,
    fk_id_animal INT NOT NULL,
    FOREIGN KEY (fk_id_animal) REFERENCES animal(id_animal)
); 

CREATE TABLE IF NOT EXISTS propriedade_insumo (
    id_propriedade_insumo INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    fk_id_propriedade INT NOT NULL,
    fk_id_insumo INT NOT NULL,
    FOREIGN KEY (fk_id_propriedade) REFERENCES propriedade(id_propriedade),
    FOREIGN KEY (fk_id_insumo) REFERENCES insumo(id_insumo)
);

INSERT INTO categoria(nome_cat) VALUES 
("bezerro"),
("bezerra"),
("novilha"),
("garrote"),
("vaca"),
("touro");






