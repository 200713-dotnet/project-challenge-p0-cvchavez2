-- data manipulation language
use [PizzaStoreDB]
GO

--insert
insert into Pizza.Size(SizeId, Name, Price, Active)
values (1,'S', 5.0, 'true');

insert into Pizza.Size(SizeId, Name, Price, Active)
values 
  (2,'M', 7.0, 'true'), 
  (3,'L', 9, 'true'),
  (4,'XL',11,'true');

select *
from Pizza.Size
go

insert into Pizza.Crust(CrustId, Name, Price, Active)
VALUES
  (1, 'regular', 0.0, 'true'),
  (2, 'stuffed', 1.0, 'true'),
  (3, 'flatbread', 0.5, 'true')
go 

insert into Pizza.Name(NameId, Name, Active)
values 
  (1, 'Cheese', 'true'),
  (2, 'Pepperoni', 'true'),
  (3, 'Hawaiian', 'true'),
  (4, 'Custom', 'true')
go

delete from Pizza.Pizza
where PizzaId = 3;
go

update Pizza.Crust
set Price = 0.0
where CrustId = 3;
go

update Pizza.Size
set Price = 7
where SizeId = 3;
go