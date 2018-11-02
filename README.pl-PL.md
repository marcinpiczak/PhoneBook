# PhoneBook

PhoneBook jest prostą aplikacją służącą jako internetowa książka telefoniczna.

## Instalacja:

W celu uruchomienia aplikacji należy stworzyć nową bazę danych lub odtworzyć bazę z przykładowymi danymi.

### I. Nowa baza danych 

1. utworzenie nowej bazy danych PhoneBookDb korzystając ze skryptu ```create database PhoneBookDb```
1. stworzenie tabeli Peple po przez wykonanie skryptu **\scripts\People_table.sql** 
1. dodanie przykładowych danych po przez wykonanie skryptu **\scripts\Sample_data.sql** 

### II. SampleDB

1. odworzonie bazy z backupu znajdującego się w katalogu **SampleDB**

## Przykładowe dane:

Przykładowe dane zawierają:
1. zestaw przykładowy danych dla książki telefonicznej takich jak:
    * `imię`
    * `nazwisko`
    * `numer telefonu`
    * `e-mail`
    
## Dostępne moduły:

### główny moduł

Aplikacja pozwala na tworzenie, modyfikowani, usuwanie, filtorwanie i przeglądanie stworzonych wpisów. Każdy nowy wpis musi mieć uzupełnione przynajmniej imię i numer telefonu.

#### Dostępne funkcjonalności
* Tworzenie nowego wpisu do ksiązki
* Modyfikacja istniejącego wpisu
* Usuwanie istniejącego wpis
* Przeglądanie istniejących wpisów
* Filtorwanie danych po nazwisku

## Application:

Do skorzystania z aplikacji użytkownicy nie potrzebują żadnych specjalnych uprawnień. Wszyscy uzytkownicy posiadają dostęp do dostepnych funkcjonalności bez żadnych ograniczeń. 

##### cdn.