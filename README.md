# 📚 BiblioTech API

Uma API robusta e eficiente desenvolvida em **.NET 10** para o gerenciamento de acervo de livros (BiblioTech). O projeto foi construído alinhado às boas práticas de arquitetura para garantir escalabilidade, manutenção facilitada e separação de responsabilidades. Essa API é preparada para comunicação com o módulo Frontend desenvolvido em Angular.

## 🚀 Funcionalidades

A API fornece todos os endpoints necessários para o gerenciamento de **Livros**:

- **[POST]** `api/Livro`: Cadastra um novo livro no sistema informando seus dados completos (Nome, Editora, Autor, Quantidade de páginas, Ano de Edição, Tipo, Gênero e Status).
- **[GET]** `api/Livro`: Retorna uma lista otimizada com todos os livros contendo apenas as informações essenciais (Id, Nome, Editora, Autor, Status).
- **[GET]** `api/Livro/{id}`: Busca, sob demanda, todos os detalhes profundos de um livro específico através do seu ID.
- **[PUT]** `api/Livro/{id}`: Atualiza todos os dados de um livro já existente com base em seu ID.
- **[DELETE]** `api/Livro/{id}`: Exclui um livro do sistema.

## 🛠️ Tecnologias e Ferramentas

O projeto utiliza um stack focado em alta performance e simplicidade:

- **[.NET 10.0](https://dotnet.microsoft.com/)** - Framework principal da aplicação.
- **[C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)** - Linguagem de programação moderna.
- **[Dapper](https://github.com/DapperLib/Dapper)** - Micro-ORM de extrema performance utilizado para manipulação explícita dos dados no BD.
- **[PostgreSQL](https://www.postgresql.org/)** - Banco de dados relacional (operado via provider `Npgsql`).
- **[Docker](https://www.docker.com/)** - Utilizado para conteinerização rápida do banco de dados (orquestrado pelo `docker-compose.yml`).
- **[Swagger](https://swagger.io/) / [Scalar](https://github.com/scalar/scalar)** - Documentação e execução da API com interface temática estéticamente agradável (`Deep Space`).
- **Cors**: Já pré-configurado permitindo a comunicação local de aplicações Frontenses na porta `http://localhost:4200`.

## 📁 Estrutura do Projeto

A solução foi estruturada para desacoplar a lógica de negócios, da interface de apresentação e infraestrutura de banco de dados, em 3 projetos/camadas isoladas:

```text
BiblioTech/
├── BiblioTech.API          # Apresentação: Endpoints/Controllers, Injeção de Dependências, Configurações do app e Regras de Negócio (Services).
├── BiblioTech.Domain       # Domínio: Entidades estritas do negócio (Livro), Enums (Status, GeneroLivro, TipoLivro) e Interfaces estruturais.
├── BiblioTech.Infra.Data   # Dados: Ferramentas de banco, Repositórios (LivroRepository c/ Dapper) e comunicação com PostgreSQL.
└── docker-compose.yml      # Base manifesta do Docker para subida rápida da instância local num Banco de Dados vazio.
```

## ⚙️ Como executar o projeto localmente

### 1. Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalado no seu computador.
- [Docker](https://www.docker.com/products/docker-desktop) instalado e rodando em modo background.

### 2. Rodando o Banco de Dados
A raiz do projeto providencia um arquivo `docker-compose.yml`. Apenas abra um terminal na raiz e digite:
```bash
docker-compose up -d
```
O comando iniciará um container PostgreSQL automaticamente mapeando para a porta `5432` da sua máquina instanciando as chaves necessárias base para uso no appsettings.

### 3. Rodando a API
Navegue via terminal até o diretório principal da API `BiblioTech.API` e rode a aplicação:
```bash
cd BiblioTech.API
dotnet run
```
A API será inicializada. O sistema indicará no terminal a porta sendo utilizada. Acesse por um navegador usando a indicação para visualizar a interface interativa de testes do Scalar ou Swagger (que submeterá as requisições em Dev)!
