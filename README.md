# PhoneBook

*Read this in other languages: [Polish](README.pl-PL.md)

### Technologies
ASP.NET Core 2.1 MVC, C#, JQuery, CSS, MS SQL Server

### Libraries/Frameworks
EntityFarmework Core, Identity, Bootstrap

## Installation:

In order to run the application, a MS SQL database is required. New database can be created or can be restored from provided backup with sample data.

### I. New database 

1. create new database PhoneBookDb using following script ```create database PhoneBookDb```
1. create table People by running script **\scripts\People_table.sql**
1. add sample data by running script **\scripts\Sample_data.sql**

### II. SampleDB

1. restore database backup with sample data. Backup can be found in folder **SampleDB**

## Sample data:

Sample data contains:
1. collection of samples of phone book data such as:
    * `first name`
    * `last name`
    * `phone number`
    * `e-mail`
    
## Available modules:

### Main module

Application allows for creation, modification, deletion, filtering and browsing all entries in phone book. New entry must contain at least first name and phone number.

#### Functionalities
* Creation of new entry/person 
* Modification of created entry/person
* Deletion of created entry/person 
* Browsing available persons
* Filtering data by person last name

## Application:

Application does not require from user any specific persmissions to create, modifiy and delete new entries. All users have access to all functionalities without any restrictions. 

##### to be continued.
