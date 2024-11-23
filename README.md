
# CRUD Using ASP.NET and React

## Sobre o Projeto

Este projeto é uma aplicação de CRUD (Create, Read, Update, Delete) utilizando **ASP.NET** com **Entity Framework (EF)** no backend e **React** no frontend. O frontend usa **Ant Design (AntD)**, **Toastify** e **Axios**, enquanto o backend foi criado com **ASP.NET Web API**.

## Tecnologias Utilizadas

### Frontend
- **React**: Criado com `npx create-react-app front`.
- **Ant Design (AntD)**: Framework de UI.
- **Axios**: Para comunicação com o backend.
- **React Toastify**: Para notificações.

### Backend
- **ASP.NET Web API**: Criado com o comando `dotnet new webapi -o back`.
- **Entity Framework**: ORM para interação com o banco de dados SQL Server.
- **SQL Server**: Banco de dados usado, nomeado "teste".

### Pacotes e Ferramentas
- Backend:
  - **Microsoft.EntityFrameworkCore.Tools**
  - **Microsoft.EntityFrameworkCore.SqlServer**
  - **Microsoft.EntityFrameworkCore**
  - **Microsoft.AspNetCore.Mvc.Cors**
  - **Swashbuckle.AspNetCore** (para Swagger)
  - **dotnet-ef** (para comandos EF CLI)
  
- Frontend:
  - **antd**
  - **axios**
  - **toastify**

### Comandos Executados

#### No Backend:
1. Criar o Web API:
   ```bash
   dotnet new webapi -o back
   ```
2. Adicionar pacotes via NuGet:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.AspNetCore.Mvc.Cors
   dotnet add package Swashbuckle.AspNetCore
   ```
3. Rodar comandos EF:
   ```bash
   dotnet ef dbcontext info
   dotnet ef migrations add Initial
   dotnet ef database update
   dotnet ef migrations script -o script.sql
   ```

#### No Frontend:
1. Criar o projeto React:
   ```bash
   npx create-react-app front
   ```
2. Instalar pacotes:
   ```bash
   npm install antd
   npm install axios
   npm install react-toastify --save
   ```

## Funcionalidades
- **Cadastro de Produtos**: Adicionar novos produtos com nome, preço de custo, preço de venda e quantidade.
- **Leitura de Produtos**: Exibir todos os produtos cadastrados em uma tabela.
- **Edição de Produtos**: Editar produtos existentes.
- **Exclusão de Produtos**: Excluir produtos.

## Rodando o Projeto

### Backend (ASP.NET)
1. No terminal, entre na pasta do backend e execute:
   ```bash
   dotnet run
   ```
2. O backend estará disponível em `http://localhost:5192/`.

### Frontend (React)
1. No terminal, entre na pasta do frontend e execute:
   ```bash
   npm start
   ```
2. O frontend estará disponível em `http://localhost:3000/`.

### Banco de Dados
- O banco de dados **SQL Server** foi configurado e o script da tabela está localizado na pasta `back` com o nome `script.sql`.
