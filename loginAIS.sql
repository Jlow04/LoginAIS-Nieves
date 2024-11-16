CREATE DATABASE loginDB;

USE loginDB;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50),
    password VARCHAR(255)
);

ALTER TABLE users
ADD COLUMN login_attempts INT DEFAULT 0,

ALTER TABLE users
ADD COLUMN access_code VARCHAR(4);

ALTER TABLE users ADD COLUMN role VARCHAR(10);

ALTER TABLE users ADD COLUMN status VARCHAR(10) DEFAULT 'Pending';
INSERT INTO users (username, password, role, status) VALUES ('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin','active');

CREATE TABLE action_logs (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    action VARCHAR(255) NOT NULL,
    details TEXT,
    timestamp DATETIME NOT NULL
);

ALTER TABLE users
ADD COLUMN idle_timeout INT DEFAULT 60000;


