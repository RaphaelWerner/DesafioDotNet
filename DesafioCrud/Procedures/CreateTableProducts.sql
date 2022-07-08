CREATE TABLE Products (
    id int primary key IDENTITY(1,1),
    name varchar(50),
    price decimal(2),
    brand varchar(50),
    updateAt datetime,
	createdAt datetime
);