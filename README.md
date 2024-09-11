# BMG Back

Este projeto é uma aplicação **.NET Core 8.0** que utiliza **MariaDB** como banco de dados e o **Entity Framework Core** para mapeamento objeto-relacional (ORM). O objetivo deste projeto é criar um crud para um teste do BMG Seguridade.

## Pré-requisitos

Para rodar o projeto, certifique-se de ter o seguinte instalado em sua máquina:

- **.NET Core SDK 8.0** ou superior. Você pode baixar a versão mais recente [aqui](https://dotnet.microsoft.com/download).
- **MySQL** ou **MariaDB** (versão 10.3 ou superior).
  - **MariaDB** deve estar rodando e acessível. Se ainda não estiver instalado, consulte [aqui](https://mariadb.org/download/) para obter instruções.

## Configuração do Banco de Dados

1. Crie um banco de dados no **MariaDB** ou **MySQL**:

    ```sql
    CREATE DATABASE BMG;

    -- BMG.tb_cliente definition
    CREATE TABLE `tb_cliente` (
      `idCliente` int(11) NOT NULL AUTO_INCREMENT,
      `nome` varchar(100) NOT NULL,
      `email` varchar(200) NOT NULL,
      `telefone` varchar(20) NOT NULL,
      `cep` varchar(8) DEFAULT NULL,
      `logradouro` varchar(100) DEFAULT NULL,
      `complemento` varchar(100) DEFAULT NULL,
      `bairro` varchar(100) DEFAULT NULL,
      `estado` varchar(100) DEFAULT NULL,
      `cidade` varchar(100) DEFAULT NULL,
      `numero` int(11) DEFAULT NULL,
      `UF` varchar(2) DEFAULT NULL,
      `status` bit(1) DEFAULT b'1',
      `data_criacao` datetime DEFAULT current_timestamp(),
      `data_exclusao` datetime DEFAULT NULL,
      PRIMARY KEY (`idCliente`)
    ) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8mb4;
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
