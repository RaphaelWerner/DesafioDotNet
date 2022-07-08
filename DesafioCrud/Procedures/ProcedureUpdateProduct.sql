Create PROCEDURE UpdateProduct
(
@id int,
@name varchar(50),
@price decimal(2),
@brand varchar(50),
@createdAt datetime,
@updateAt datetime
)
AS
BEGIN
 
update products set 
name = @name,
price = @price,
brand = @brand,
updateAt = @updateAt
where id = @id
 
SELECT SCOPE_IDENTITY()
 
END