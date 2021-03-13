CREATE DATABASE MVC_CRUD

USE MVC_CRUD

CREATE TABLE tbl_students (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(50),
	Email nvarchar(50),
	Grade INT,
	Section nvarchar(20)
)


SELECT 
	Id AS 'Identity',
	Name AS 'Student Name',
	Email AS 'Student Email',
	Grade AS 'Class',
	Section AS 'Section'
	FROM tbl_students

INSERT INTO tbl_students VALUES ('Alpha', 'alpha@test.com', 8, 'A')