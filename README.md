# Teste técnico - nível Pleno

Neste desafio, você será responsável por criar uma API RESTful para uma lista de
empregos. A API permitirá que os usuários visualizem, criem, atualizem e excluam anúncios
de emprego.

## Endpoints

### Jobs

- GET /jobs: retorna uma lista de todos os anúncios de emprego disponíveis;
- GET /jobs/{id}: retorna um único anúncio de emprego com o ID correspondente;
- POST /jobs: cria um novo anúncio de emprego;
- PUT /jobs/{id}: atualiza um anúncio de emprego existente com o ID correspondente;
- DELETE /jobs/{id}: exclui um anúncio de emprego existente com o ID correspondente;

### Users

- GET /users: retorna uma lista de todos os usuários disponíveis;
- GET /users/{id}: retorna um único anúncio de emprego com o ID correspondente;
- GET /users/filter-by-name: retorna uma lista de todos os anúncios de emprego disponíveis filtrada pelo nome;
- POST /users: cria um novo anúncio de emprego;
- PUT /users/{id}: atualiza um anúncio de emprego existente com o ID correspondente;
- PUT /users/inactive/{id}: inativa um usuário existente pelo o ID correspondente;
- PUT /users/active/{id}: ativa um usuário existente pelo o ID correspondente;
- DELETE /users/{id}: exclui um anúncio de emprego existente com o ID correspondente;

### Subscribers

- POST /subscribers: cria a inscrição de um usuário a um emprego;

### Profiles

- POST /profiles: cria um novo perfil;

## As entidades e seus atributos

- Job:
	- Id: int (gerado automaticamente pelo servidor);
	- Title: string (título do anúncio de emprego);
	- Description: string (descrição do anúncio de emprego);
	- Location: string (localização do trabalho);
	- Salary: decimal (salário oferecido);
	- Status: StatusJobEnum (status do emprego);

- Subscribe:
	- Date: Date (data da inscrição);	

- User:
	- Id: int (gerado automaticamente pelo servidor);
	- Name: string (nome do usuário);
	- Email: string (email do usuário);
	- Password: string (senha do usuário);

- Profile:
	- Name: ProfileUserEnum (nome do perfil);
	- Status: StatusUserEnum (status do perfil);

## Diagrama de Classes

![class-diagram](../Documentation/class-diagram.png)

## Regras Negociais

- [RN1] A API deve ser desenvolvida usando ASP.NET Core;
- [RN2] Deve ser usado o banco de dados Sql Server;
- [RN3] Deve ser usado o Micro ORM Dapper;
- [RN4] Deve suportar as operações CRUD básicas (Create, Read, Update, Delete);
- [RN5] A API deve retornar respostas HTTP apropriadas (ex: 200 OK, 404 Not Found, 400 Bad Request, etc.);
- [RN6] Os dados enviados e recebidos pela API devem ser formatados como JSON;
- [RN7] O projeto deve ser implementado com alguma arquitetura de software (limpa ou hexagonal);
- [RN8] Deve ser usado o design pattern mediator entre a camada de serviços com controller;

## Passo a Passo da Resolução

1. Criar as Actions do Controller e testar todas para garantir que estejam funcionando. Retornar NoContent para PUT e DELETE, e OK para todas as outras

2. Implementar entidade do domínio

3. Atualizar Actions do Controller com entidade do domínio (POST e PUT recebendo como parâmetro, e POST retornando CreatedAtAction) - BUILD

4. Adicionar Microsoft.EntityFrameworkCore.InMemory, criar DbContext, e configurar na Program.cs

5. Adicionar instância do DbContext no Controller, e usar ele em todas as operações com a sintaxe LINQ

6. Testar e garantir que funciona em memória.

[OPCIONAL]
7. Adicionar configuração de connection string do Banco de Dados no appsettings.json, atualizar
configuração no Program.cs, e gerar as migrations com:

Utilizei o Docker para o banco:

```shell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Admin@123" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name sqlserver --hostname sqlserver -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```

```shell
dotnet ef migrations add Initial -o Persistence/Migrations
dotnet ef database update
```

8. Testar novamente

