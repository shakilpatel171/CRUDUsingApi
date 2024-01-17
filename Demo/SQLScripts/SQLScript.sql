create database Demo
go 
use Demo
go 
create table Customer
(
CustomerId int primary key identity,
Name varchar(Max),
City varchar(Max),
Age int
)
go 
insert into customer values('Happy', 'Pandharpur', 27)
go
select * from Customer