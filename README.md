# Desafio Thomas Greg
# Sistema de Identificação - API REST Clientes

## Descrição

API REST para gerenciar clientes e seus logradouros, com cadastro, atualização, visualização e remoção, além de autenticação e autorização via JWT.

O sistema permite:

- Cadastro de clientes com nome, e-mail (único), logotipo e múltiplos logradouros;
- Gerenciamento completo dos logradouros vinculados a clientes;
- Segurança via autenticação JWT;
- Usuário Admin criado automaticamente na inicialização, caso o banco esteja vazio. Apenas Admins podem registrar novos usuários.

## Tecnologias Utilizadas

- **.NET 8.0**
- Entity Framework Core
- SQL Server 2016+
- JWT (Json Web Token) para autenticação
- Swagger para documentação da API
- Validações com DataAnnotations
- Autenticação com Roles (Admin / Comum)

##  Segurança de Dados Sensíveis

Este projeto utiliza um arquivo separado chamado `appsettings.Secret.json` para armazenar informações sensíveis, como:

- Chave JWT (`Jwt:Key`)

- Credenciais do usuário Admin Default (`AdminDados`)

**Vantagens**

- Protege informações confidenciais

- Facilita a organização em ambientes de produção e desenvolvimento

## Informações Adicionais

### Logotipo e Armazenamento em Nuvem

Este projeto tem como ideia armazena o **logotipo do cliente** como uma URL no banco de dados, em vez de armazenar a imagem binária. 

- O campo `Logotipo` no modelo de `Cliente` é do tipo `string`, representando a **URL pública** da imagem.
> Esta funcionalidade é **apenas uma simulação**.  
> **Não há código implementado para envio, upload ou armazenamento da imagem em nuvem**.
- Em uma aplicação real, as imagens deveriam ser enviadas para um **provedor de armazenamento em nuvem**, como:
  - [Azure Blob Storage](https://azure.microsoft.com/pt-br/products/storage/blobs/)
  - [Amazon S3](https://aws.amazon.com/pt/s3/)
  - Ou outro serviço compatível com HTTP.

No código, há um comentário explicando:

```csharp
// Aqui seria onde a imagem seria salva em algum servidor em nuvem,
// seria gerado e salvo a URL de acesso
// Exemplo: https://meuservidor.com/logo_cliente_X.png
```

### Boas Práticas

O projeto foi estruturado seguindo boas práticas de arquitetura, separando claramente responsabilidades em diferentes camadas:

#### Camada de Controllers

Responsáveis por:

- Receber e responder requisições HTTP;
- Delegar a lógica de negócio para os serviços;

#### Camada de Services

Contém a lógica de negócio da aplicação:

- Validações como unicidade de e-mail;
- Regras específicas de atualização e remoção de dados;
- Encapsulamento do acesso ao `DbContext`;

Cada serviço foi implementado com base em uma interface específica, promovendo o princípio da injeção de dependência, favorecendo a organização e promovendo uma arquitetura escalável e de fácil manutenção.

#### Outros princípios aplicados

- Uso de DTOs para desacoplar entidades do banco de dados da API pública;
- Controle de erros e mensagens amigáveis;
- Autenticação e autorização via JWT com controle de cargos (Admin, Comum);


#### Sobre o uso de Procedures

Apesar da recomendação de uso de procedures para evitar SQL Injection e melhorar performance em alguns cenários, **neste projeto optou-se por não utilizá-las**, pois foi adotado o **Entity Framework Core** como ORM.

Com isso:

- Todas as consultas e comandos SQL são gerados de forma segura, protegendo naturalmente contra SQL Injection;
- A manutenção e leitura do código ficam mais simples, com menos dependência da lógica no banco de dados;
 
> Caso o sistema venha a demandar **consultas mais complexas, operações de alta performance**, o uso de procedures passa a ser uma excelente opção e pode ser facilmente integrado ao projeto.

## Como Rodar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/igorp2/Desafio-Thomas-Greg.git
cd '.\Desafio-Thomas-Greg\Sistema de Identificacao\Sistema de Identificacao\'
```

### 2. Branch do projeto

Certifique-se de estar na branch `main` executando:

```bash
git checkout main
```

### 3. Baixe o arquivo `appsettings.Secret.json`

Acesse o [link](https://drive.google.com/file/d/1Mn1RB9P-NBkEz2Yv3nXnUV9ftDVgpkqi/view?usp=sharing), baixe o arquivo `appsettings.Secret.json` e salve na pasta do projeto juntamente com os demais `appsettings` já presentes. Lá está presente os dados de login do Admin Default que é gerado ao iniciar o projeto por não ter nenhum usuário cadastrado e facilitar a utilização do sistema.

>Atenção: se esse arquivo não estiver presente, o projeto não irá compilar!

### 4. Configure o banco de dados

No arquivo `appsettings.json`, ajuste as configurações do banco de dados para o seu ambiente. Para meu ambiente de desenvolvimento utilizei a seguinte `ConnectionString`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=IGOR\\SQLEXPRESS;Initial Catalog=SistemaIdentificacao;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
}
```

Para ambientes de produção, é importante revisar opções como autenticação, certificados e segurança da conexão.

### 5. Execute as migrações e inicie o projeto

```bash
# (Opcional) Restaure os pacotes, caso seja a primeira vez ou após alterações no .csproj
dotnet restore

# Aplique as migrations no banco
dotnet ef database update

# Inicie o projeto
dotnet run
```

### 6. Acesse a documentação da API

Após iniciar o projeto pelo CMD, acesse a URL http://localhost:5000/swagger/index.html para visualizar a documentação da API via Swagger. Caso rode o projeto pelo Visual Studio em https a URL será https://localhost:5001/swagger/index.html.

Realize login via `/api/Autenticacao/login` e receba um token JWT.

Para testar a API via **Postman**, **Insomnia** ou qualquer cliente HTTP, lembre-se de adicionar o token JWT no cabeçalho das requisições:

```bash
Authorization: Bearer {seu_token}
```
No Swagger basta clicar no botão Authorize (ícone de cadeado), inserir o token e você poderá fazer requisições autenticadas diretamente pelo Swagger. Lembrando que:

- Apenas usuários com o cargo Admin podem acessar o endpoint de registro de novos usuários.
- Os demais endpoints estão disponíveis para todos os usuários que estejam autenticados no sistema.
