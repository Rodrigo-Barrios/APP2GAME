### Pasos para crear su proyecto

## 1. Crear Proyecto

dotnet new mvc --auth Individual

## 2. Git init

git init

## 3. add .ignore

obj/
bin/

## 4. git config

git config user.name "SU NOMBRE"
git config user.email "SU CORREO"

## 5. dotnet EF

dotnet tool install --global dotnet-ef

## 6. Indicando donde va la migracion

dotnet ef migrations add <PASO DE MIGRACION> --context <applicativo>.Data.ApplicationDbContext -o "<RUTA DEL APLICATIVO>\Data\Migrations"

eg.

dotnet ef migrations add MigracionInicial --context APP2GAME.Data.ApplicationDbContext -o "C:\NET\APP2GAME\Data\Migrations"

dotnet ef database update

## opcional para rollback

dotnet ef migrations remove

## migraciones con postgress

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.4

## opcional

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.8
