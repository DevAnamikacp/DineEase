﻿CREATE TABLE USERS(ID INT PRIMARY KEY IDENTITY(1,1),USER_TYPE VARCHAR(30))

INSERT INTO USERS(USER_TYPE) VALUES ('ADMIN')
INSERT INTO USERS(USER_TYPE) VALUES ('SUPER USER')
INSERT INTO USERS(USER_TYPE) VALUES ('USER')
SELECT * FROM USERS

CREATE TABLE LOGIN(ID INT PRIMARY KEY IDENTITY(1,1),USER_NAME VARCHAR(30),PASSWORD VARCHAR(30),USERTYPE_ID INT FOREIGN KEY REFERENCES USERS(ID))
SELECT * FROM LOGIN
INSERT INTO LOGIN(USER_NAME,PASSWORD,USERTYPE_ID) VALUES ('Admin@gmail.com','1234@A',1)