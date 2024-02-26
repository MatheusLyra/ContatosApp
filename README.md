# FinancasApp

O ContatosApp é um projeto ASP.NET MVC desenvolvido com Dapper, Entity Framework Code First que permite o controle de contatos. O sistema permite que os usuários criem uma conta para acessar as funcionalidades oferecidas.

## Estrutura do Projeto

O projeto está organizado em três camadas principais:

1. **Apresentação:** Contém os controladores, modelos de visualização e arquivos de interface do usuário.

2. **Domínio:** Responsável pela lógica de negócios e pela definição das entidades do sistema.

3. **Infraestrutura:** Inclui a configuração do banco de dados, migrações e outros aspectos relacionados à infraestrutura do projeto.

## Configuração do Projeto

Para executar o projeto, siga os passos abaixo:

1. Altere a string de conexão na classe `DataContext` localizada na camada de Infraestrutura para refletir as configurações do seu banco de dados e `ConnectionSettings` para utilização do Dapper.

2. Execute o seguinte comando para aplicar as migrações e criar o banco de dados:
    ```bash
    update-database
    ```

## Pré-requisitos

Certifique-se de ter o Visual Studio 2022 instalado para executar o projeto.

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests para melhorar o projeto.



