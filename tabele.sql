create table People(
Id int identity(1,1) not null ,
FirstName varchar(255) not null,
LastName varchar(255),
Phone varchar(20) not null,
Email varchar(255),
Created datetime not null,
Updated datetime not null
)

--select
select ', '+COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME = 'People'
for xml path('')

select ', @'+lower(COLUMN_NAME) from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME = 'People'
for xml path('')

select * from People

select ', '+COLUMN_NAME+' = @'+lower(COLUMN_NAME) from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME = 'People'
for xml path('')