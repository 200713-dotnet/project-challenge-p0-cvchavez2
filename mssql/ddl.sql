-- data definition language

use master;
go

drop database [PizzaStoreDB]
go 

create database PizzaStoreDB;
go -- project

use [PizzaStoreDB]
go

create schema Pizza;
go -- namespace

drop schema Pizza
go

create table Pizza.Pizza
(
  PizzaId int not null identity(1,1),
  [Name] nvarchar(200) not null,
  NameId int null,
  CrustId int not null,
  SizeId int not null,
  [Price] float not null,
  constraint PK_PizzaId primary key (PizzaId),
  constraint FK_CrustId foreign key (CrustId) references Pizza.Crust(CrustId),
  constraint FK_SizeId foreign key (SizeId) references Pizza.Size(SizeId)
);

drop table Pizza.Pizza
go

create table Pizza.[Name]
(
  NameId int not null identity(1,1),
  [Name] nvarchar(200) null,
  -- Active bit not null,
  -- constraint Active default 1,
  constraint PK_NameId primary key (NameId),
)
create table Pizza.[Crust] 
(
  CrustId int not null identity(1,1),
  [Name] nvarchar(100) not null,
  [Price] float null,
  -- Active bit not null,
  -- constraint Active default 1,
  constraint PK_CrustId primary key (CrustId)
);

create table Pizza.[Size]
(
  SizeId int not null identity(1,1),
  [Name] nvarchar(100) not null,
  [Price] float null,
  -- Active bit not null,
  constraint PK_SizeId primary key (SizeId)
);

create table Pizza.Topping
(
  ToppingId int not null identity(1,1),
  [Name] nvarchar(100) not null,
  [Price] float null
  -- Active bit not null,
  constraint PK_ToppingId primary key (ToppingId)
);

-- junction table
create table Pizza.PizzaTopping
(
  PizzaToppingId int not null identity(1,1),
  PizzaId int not null,
  ToppingId int not null
  constraint FK_PizzaTopping_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId),
  constraint FK_PizzaTopping_ToppingId foreign key (ToppingId) references Pizza.Topping(ToppingId)
)

-- alter

alter table Pizza.PizzaTopping
  add constraint PK_PizzaTopping_PizzaToppingId primary key (PizzaToppingId)

alter table Pizza.Pizza
  add constraint FK_Pizza_NameId foreign key (NameId) references Pizza.Name(NameId)

drop table Pizza.PizzaTopping
go
---------------------------------------------------------------

drop schema [User]
go

create schema [User]
go

create table [User].[User]
(
  UserId int not null identity(1,1),
  [Name] nvarchar(200) not null,
  constraint PK_UserId primary key (UserId),
  -- OrderId int null foreign key references Order.[Order](OrderId),
)

create table [User].[Order]
(
  OrderId int not null identity(1,1),
  [DateTime] datetime2(0) not null, -- not sure about this
  UserId int not null,
  constraint PK_OrderId primary key (OrderId),
  constraint FK_Order_UserId foreign key (UserId) references [User].[User](UserId),
)

-- junction table for orders and pizzas
create table [User].[OrderPizza]
(
  OrderPizzaId int not null identity(1,1),
  OrderId int not null,
  PizzaId int not null,
  constraint PK_OrderPizzaId primary key (OrderPizzaId),
  constraint FK_OrderPizza_OrderId foreign key (OrderId) references [User].[Order](OrderId),
  constraint FK_OrderPizza_PizzaId foreign key (PizzaId) references [Pizza].[Pizza](PizzaId),
)
-- junction table for users and their orders
create table [User].[UserOrders]
(
  UserOrderId int not null identity(1,1),
  UserId int not null,
  OrderId int not null,
  constraint PK_UserOrders_UserOrderId primary key (UserOrderId),
  constraint FK_UserOrders_UserId foreign key (UserId) references [User].[User](UserId),
  constraint FK_UserOrders_OrderId foreign key (OrderId) references [User].[Order](OrderId),
)

-- ----------------------------------------------------------------
-- create schema [Order]
-- go

-- drop schema Order;
-- GO

-- create table [Order].[Order]
-- (
--   OrderId int not null primary key,
--   [OrderTotal] float null,
  -- [TimeOrdered] datetime2(0) null,  -- do I provide c# date ordered or save as a string
-- )