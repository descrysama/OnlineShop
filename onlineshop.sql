CREATE DATABASE IF NOT EXISTS onlineshop; 
USE onlineshop;

CREATE TABLE address (
  id int(11) PRIMARY KEY AUTO_INCREMENT NOT NULL,
  street varchar(128) NOT NULL,
  city varchar(64) NOT NULL,
  country varchar(64) NOT NULL
);

CREATE TABLE users (
  id int(11) PRIMARY KEY AUTO_INCREMENT NOT NULL,
  email varchar(64)  NOT NULL,
  password varchar(128)  NOT NULL,
  address_id int(11) NOT NULL,
  FOREIGN KEY (address_id) REFERENCES address(id)
);

CREATE TABLE orders (
  id int(11) PRIMARY KEY AUTO_INCREMENT NOT NULL,
  total float,
  user_id int,
  FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE products (
  id int(11) PRIMARY KEY AUTO_INCREMENT NOT NULL,
  price float,
  image varchar(128),
  description varchar(128),
  quantity int
);

CREATE TABLE order_product (
  id int(11) PRIMARY KEY AUTO_INCREMENT NOT NULL,
  order_id int,
  product_id int,
  FOREIGN KEY (order_id) REFERENCES orders(id),
  FOREIGN KEY (product_id) REFERENCES products(id)
);


