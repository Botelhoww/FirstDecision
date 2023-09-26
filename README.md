# First Decision Tech Test

## Descrição

Este projeto é uma API RESTful para gerenciamento de pessoas, permitindo operações de CRUD (Criação, Leitura, Atualização e Exclusão).

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** .NET 7
- **ORM:** Entity Framework Core
- **Banco de Dados:** SQL Server
- **Testes:** NUnit
- **Validação:** FluentValidation
- **Documentação da API:** Swagger

## Instalação e Execução

1. **Clone o Repositório:**
   Abra o seu navegador e acesse o link do repositório:
   ```plaintext
   https://github.com/Botelhoww/FirstDecision.git

## Endpoints da API
- GET /pessoas: Retorna uma lista de todas as pessoas.
- GET /pessoas/{id}: Retorna uma pessoa específica pelo ID.
- POST /pessoas: Cadastra uma nova pessoa.
- PUT /pessoas: Atualiza os dados de uma pessoa.
- DELETE /pessoas/{id}: Exclui uma pessoa pelo ID.

## Testes 
Para executar os testes, use o comando:
   ```bash
   dotnet test
