# First Decision Tech Test

## Descrição

Este projeto é uma API RESTful para gerenciamento de pessoas, permitindo operações de CRUD (Criação, Leitura, Atualização e Exclusão) em um banco de dados de pessoas.

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** .NET 5
- **ORM:** Entity Framework Core
- **Banco de Dados:** SQL Server
- **Testes:** NUnit
- **Validação:** FluentValidation
- **Documentação da API:** Swagger

## Instalação e Execução

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/Botelhoww/FirstDecision.git

# Navegue até o diretório do projeto:
cd seuprojeto

# Restaure os pacotes NuGet:
dotnet restore

# Compile o projeto:
dotnet build

# Execute o projeto:
dotnet run


## Endpoints da API
- GET /pessoas: Retorna uma lista de todas as pessoas.
- GET /pessoas/{id}: Retorna uma pessoa específica pelo ID.
- POST /pessoas: Cadastra uma nova pessoa.
- PUT /pessoas: Atualiza os dados de uma pessoa.
- DELETE /pessoas/{id}: Exclui uma pessoa pelo ID.


## Testes 
Para executar os testes, use o comando:
dotnet test
