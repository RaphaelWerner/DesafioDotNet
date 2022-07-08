create PROCEDURE DeleteProduct
(
@id int
)
AS
BEGIN
 
delete from Products where id = @id
 
END