alter PROCEDURE AddProduct
(
@name varchar(50),
@price decimal(2),
@brand varchar(50),
@createdAt datetime,
@updateAt datetime
)
AS
BEGIN
 
INSERT INTO products (name, price, brand, createdAt, updateAt)
VALUES (@name, @price, @brand, @createdAt, @updateAt);
 
SELECT SCOPE_IDENTITY()
 
END