# Faturamento.Api

Projeto criado para exemplificar a utilização de Clean Architecture e CQRS utilizando MediatR.

## Índice

- [Visão Geral](#visão-geral)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Como Executar o Projeto](#como-executar-o-projeto)
- [Como Contribuir](#como-contribuir)
- [Licença](#licença)

## Visão Geral

Este projeto tem como objetivo demonstrar a implementação de uma API de faturamento seguindo os princípios da Clean Architecture e do CQRS (Command Query Responsibility Segregation), utilizando o MediatR para mediar as interações entre os componentes.

## Tecnologias Utilizadas

- **C#**
- **.NET 8**
- **MediatR**
- **Entity Framework Core**
- **SQL Server**

## Estrutura do Projeto

A estrutura do projeto segue os princípios da Clean Architecture, dividindo responsabilidades em diferentes camadas:

- **src/**: Contém o código-fonte do projeto.
  - **Application/**: Contém a lógica de negócio e as definições de interfaces.
  - **Domain/**: Contém as entidades e agregados do domínio.
  - **Infrastructure/**: Contém a implementação dos repositórios e a configuração do banco de dados.
  - **Presentation/**: Contém os controladores da API e a configuração do MediatR.

## Como Executar o Projeto

1. **Pré-requisitos**:
   - .NET 8 SDK instalado
   - SQL Server instalado e em execução

2. **Configuração do Banco de Dados**:
   - Atualize a string de conexão no arquivo `appsettings.json` na camada **Infrastructure** para apontar para o seu servidor SQL Server.

3. **Aplicar Migrações**:
   - No terminal, navegue até o diretório **Infrastructure** e execute:
     ```bash
     dotnet ef database update
     ```

4. **Executar a Aplicação**:
   - No terminal, navegue até o diretório **Presentation** e execute:
     ```bash
     dotnet run
     ```
   - A API estará disponível em `https://localhost:5001`.

## Como Contribuir

Contribuições são bem-vindas! Siga os passos abaixo para contribuir:

1. Faça um fork deste repositório.
2. Crie uma branch para sua feature ou correção:
   ```bash
   git checkout -b minha-feature
   ```
3. Faça commit das suas alterações:
   ```bash
   git commit -m 'Minha nova feature'
   ```
4. Envie para o repositório remoto:
   ```bash
   git push origin minha-feature
   ```
5. Abra um Pull Request.
