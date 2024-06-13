# ProjectPessoa

ProjectPessoa é uma aplicação CRUD simples desenvolvida em ASP.NET Core, que permite gerenciar dados de pessoas e endereços. A aplicação utiliza o Entity Framework Core para interagir com um banco de dados PostgreSQL.

## Funcionalidades

- **CRUD de Pessoas**: Criação, leitura, atualização e exclusão de registros de pessoas.
- **CRUD de Endereços**: Cada pessoa pode ter um endereço associado.

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Docker

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop)
- [PostgreSQL](https://www.postgresql.org/download/) (opcional, se não utilizar Docker)

## Configuração do Banco de Dados

### Usando Docker

1. **Inicie um contêiner Docker com PostgreSQL**:

    ```bash
    docker run --name some-postgres -e POSTGRES_PASSWORD=YourPassword -e POSTGRES_DB=YourDatabaseName -p 5432:5432 -d postgres
    ```

2. **Verifique se o contêiner está rodando**:

    ```bash
    docker ps
    ```

### Configuração da String de Conexão

1. **Abra o arquivo `appsettings.json` na raiz do projeto.**
2. **Atualize a string de conexão para apontar para o banco de dados PostgreSQL**:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=YourDatabaseName;Username=postgres;Password=YourPassword"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

    Certifique-se de substituir `YourDatabaseName` pelo nome do banco de dados que você configurou e `YourPassword` pela senha que você definiu.

## Migrações do Banco de Dados

Após configurar a string de conexão, você precisa aplicar as migrações do Entity Framework para criar as tabelas no banco de dados.

1. **Adicionar as migrações**:

    ```bash
    dotnet ef migrations add InitialCreate --project ./ProjectPessoa/ProjectPessoa.csproj
    ```

2. **Atualizar o banco de dados**:

    ```bash
    dotnet ef database update --project ./ProjectPessoa/ProjectPessoa.csproj
    ```

## Executando a Aplicação

1. **Navegue até a pasta do projeto**:

    ```bash
    cd ProjectPessoa
    ```

2. **Execute a aplicação**:

    ```bash
    dotnet run
    ```

A aplicação estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

## Acessando o PostgreSQL

### Usando pgAdmin

1. **Instale e inicie o pgAdmin**.
2. **Adicione um novo servidor no pgAdmin**:
    - **Name**: PostgreSQL Docker
    - **Host**: localhost
    - **Port**: 5432
    - **Username**: postgres
    - **Password**: YourPassword

### Usando a Linha de Comando do `psql`

1. **Acesse o contêiner Docker**:

    ```bash
    docker exec -it some-postgres bash
    ```

2. **Inicie o cliente `psql`**:

    ```bash
    psql -U postgres -d YourDatabaseName
    ```

3. **Execute consultas SQL**:

    ```sql
    SELECT * FROM "Pessoas";
    ```

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests para melhorias ou correções.

## Licença

Este projeto está licenciado sob a MIT License. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
