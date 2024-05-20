# ValeTransporteAPI

Este é o backend da aplicação de controle de gastos com vale transporte para funcionários, desenvolvido em ASP.NET Core e utilizando SQL Server como banco de dados.

## Funcionalidades

- Cadastro de funcionários
- Atualização, inativação e remoção de funcionários
- Cálculo do custo mensal com vale transporte, desconsiderando feriados

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server

## Configuração do Ambiente

1. **Clone o repositório:**

    ```bash
    git clone https://github.com/seu-usuario/ValeTransporteAPI.git
    cd ValeTransporteAPI
    ```

2. **Configurar a conexão com o banco de dados:**

   Atualize a string de conexão no arquivo `appsettings.json`:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ValeTransporteDB;Trusted_Connection=True;"
    }
    ```

3. **Restaurar pacotes NuGet:**

    ```bash
    dotnet restore
    ```

4. **Aplicar migrações e criar o banco de dados:**

    ```bash
    dotnet ef database update
    ```

5. **Executar a aplicação:**

    ```bash
    dotnet run
    ```

A API estará disponível em `https://localhost:5001`.

## Endpoints

- **GET /funcionarios:** Lista todos os funcionários
- **GET /funcionarios/{funcionarioId:int}:** Obter detalhes de um funcionário pelo ID
- **POST /funcionarios:** Adicionar um novo funcionário
- **PUT /funcionarios/{funcionarioId:int}:** Atualizar informações de um funcionário
- **PUT /funcionarios/{funcionarioId:int}/inativar:** Inativar um funcionário
- **DELETE /funcionarios/{funcionarioId:int}:** Remover um funcionário
- **GET /gastos-mensais/{funcionarioId:int}:** Calcular os gastos mensais de um funcionário

## Contribuição

Sinta-se à vontade para contribuir com o projeto. Faça um fork do repositório e envie um pull request com suas melhorias.

## Licença

Este projeto está licenciado sob a MIT License. Veja o arquivo `LICENSE` para mais detalhes.
