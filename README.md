# Nome do Projeto

Este projeto é uma aplicação **.NET Core 8.0** que utiliza **MariaDB** como banco de dados e o **Entity Framework Core** para mapeamento objeto-relacional (ORM). O objetivo deste projeto é criar um crud para um teste do BMG Seguridade.

## Pré-requisitos

Para rodar o projeto, certifique-se de ter o seguinte instalado em sua máquina:

- **.NET Core SDK 8.0** ou superior. Você pode baixar a versão mais recente [aqui](https://dotnet.microsoft.com/download).
- **MySQL** ou **MariaDB** (versão 10.3 ou superior).
  - **MariaDB** deve estar rodando e acessível. Se ainda não estiver instalado, consulte [aqui](https://mariadb.org/download/) para obter instruções.

## Configuração do Banco de Dados

1. Crie um banco de dados no **MariaDB** ou **MySQL**:

    ```sql
    CREATE DATABASE NomeDoBanco;
    ```

2. Atualize a string de conexão no arquivo `appsettings.json` com as credenciais corretas para acessar o banco de dados:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=NomeDoBanco;User=seu_usuario;Password=sua_senha;"
      }
    }
    ```

## Configuração do Projeto

### 1. Clonando o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/cryty13/BMG-Teste-back.git
