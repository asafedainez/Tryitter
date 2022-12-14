# Tryitter

## Descrição
Esse é um projeto que foi passado como um desafio para criar um sistema de usuários e posts, parecido com o twitter, mas com algumas funcionalidades a menos.

Foi implementado um CRUD de usuários e posts, com autenticação e autorização.

## Como rodar o projeto

### Pré-requisitos
- Docker
- Docker Compose
- SDK .NET Core 6.0
- Entity Framework Core 6.0

### Rodando o projeto
1. Clone o repositório
2. Entre na pasta do projeto
3. Suba o banco de dados com o comando `docker-compose up -d`
4. Faça o build do projeto com o comando `dotnet build`
5. Rode as migrations para o banco de dados com o comando `dotnet ef database update`
6. Inicialize o projeto com o comando `dotnet run`
7. Acesse o link `https://localhost:5000/swagger/index.html` no seu navegador

### Autenticação
Usuários cadastrados:
1. Email: `usertest1@email.com` Senha: 123456
2. Email: `usertest2@email.com` Senha: 123456 


