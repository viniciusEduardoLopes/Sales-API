
# Sales-API
SalesAPI - API em ASP.NET Core

### 📌 Sobre o Projeto

Este projeto consiste em uma API desenvolvida em C# com ASP.NET Core, projetada para atender às funcionalidades descritas no mockup fornecido. A API segue princípios de escalabilidade, manutenção e boas práticas.

### 🚀 Tecnologias Utilizadas

ASP.NET Core 9
Entity Framework Core
SQLite
Swagger para documentação da API
Arquitetura em camadas (Application, Domain, Infrastructure, WebAPI)

### 📂 Estrutura do Projeto

```plaintext
SalesAPI/
  │── SalesAPI.Application/     # Contém regras de negócio e serviços
  │── SalesAPI.Domain/          # Contém modelos e interfaces
  │── SalesAPI.Infrastructure/  # Responsável pela persistência (EF Core + SQLite/SQL Server)
  │── SalesAPI/                 # Contém os controllers e configurações da API
  │── SalesAPI.sln              # Arquivo da solução
└── README.md                   # Instruções do projeto
```

### 📦 Como Executar o Projeto

1️⃣ Clonar o repositório
```bash
git clone https://github.com/viniciusEduardoLopes/Sales-API.git
cd SalesAPI
```

2️⃣ Configurar o banco de dados

Caso utilize SQLite, o banco será criado automaticamente. Se optar por SQL Server, edite o appsettings.json com a string de conexão.

3️⃣ Aplicar Migrations e Atualizar o Banco
```bash
dotnet ef database update --project SalesAPI.Infrastructure --startup-project SalesAPI
```

4️⃣ Rodar a API
```bash
dotnet run --project SalesAPI
```
Acesse https://localhost:5001/swagger para visualizar a documentação.

### 📌 Endpoints Principais

A API expõe os seguintes endpoints:

Método

Rota

Descrição

GET

/api/entidade

Retorna todos os registros

GET

/api/entidade/{id}

Retorna um registro pelo ID

POST

/api/entidade

Cria um novo registro

PUT

/api/entidade/{id}

Atualiza um registro

DELETE

/api/entidade/{id}

Remove um registro

### 🔐 Autenticação e Segurança (Opcional)

Se implementado, a API usará JWT para autenticação. Para acessar endpoints protegidos, inclua um token JWT no cabeçalho da requisição.

### ✅ Testes Unitários (Opcional)

Rode os testes com:

dotnet test

### 📜 Licença

Este projeto está sob a licença [MIT License](https://mit-license.org/).

---
