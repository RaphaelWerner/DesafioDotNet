create PROCEDURE GetProductById
(
@id int
)
AS
BEGIN
 
Select * from Products where id = @id
 
END