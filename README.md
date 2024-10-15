# .NetCore 8 SuperHero Web API

## TechStack
 - .NETCORE 8
 - MS SQL

## Features
  - CRUD API End points
  - Code First EntityFramework Implementation
  - Database Migration

## Script for DB migration to SQL server
  - Run below script in console to create migration code file
  ```script
  Add-Migration initial
  ```
  After running above scripts a Migration folder is created with the migration code script and a DB context model snapshot.
  The migration initial file script has up and down methods for migration
  Up on update and down on rollback

  - Thenafter run below script to update the current data base on your local
  ```sql
  Update-Database
  ```
  This will execute the commands and create the schema in the database by name SuperHeroDb
  Now go to sql server using ssms verify the schem in the SQL Db
  __Note:__ Make sure the connection string is set properly in the appsetings.json file as given below:
  ```json
  "ConnectionStrings": {
    "DefaultConnection" : "Server=.\\SQLExpress;Database=SuperHeroDb;Trusted_Connection=true;TrustServerCertificate=true"
  }
  ```
  Just notice the Database name in the above connection string. Is it used by the Migration script? To know just investigate in the existing migration code.

## Swagger API with end points
  - Now run the application using visual studio and test the api in browser via swagger UI.
  
 
