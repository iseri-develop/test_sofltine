# 🧪 Softline - Teste Técnico

Este projeto foi desenvolvido como parte de um teste técnico solicitado pela empresa Softline.  
Consiste em uma aplicação com backend em ASP.NET Core e frontend simples em HTML/JS para gerenciar usuários, produtos e clientes.

---

## 🚀 Tecnologias Utilizadas

- Backend: ASP.NET Core 8.0
- ORM: Entity Framework Core
- Banco de dados: SQL Server
- Frontend: HTML5, CSS3, JavaScript (Fetch API)
- Ferramentas: Visual Studio Code + Live Server

---

## 📦 Requisitos e Dependências

### 🛠️ Backend (ASP.NET Core)

- [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express ou Developer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- (Opcional) [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)

**Pacotes NuGet utilizados no backend:**

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore
- Microsoft.AspNetCore.Cors

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
```

### 🌐 Frontend
Visual Studio Code

Extensão recomendada: Live Server

Navegador moderno (Chrome, Edge ou Firefox)

## ⚙️ Como Rodar o Projeto
🔧 Backend

```bash
cd softlineApp

# Restaurar pacotes e compilar
dotnet restore
dotnet build

# Rodar o backend
dotnet run
```

A API estará disponível em algo como: http://localhost:5204 (verifique a porta no terminal).

### 🖥️ Frontend
Abrir o diretório frontend

Clique com o botão direito em index.html → "Open with Live Server"

Acesse via navegador: http://127.0.0.1:5500/frontend/index.html

### 🗃️ Banco de Dados
Após criar suas entidades e aplicar as migrations, você pode gerar o script SQL do banco com:

```bash
dotnet ef migrations script -o softline_database.sql
O banco é criado automaticamente ao rodar dotnet ef database update caso use Migrations.
```

## 📋 Funcionalidades
✅ Autenticação de usuário (Login)

✅ CRUD de Produtos

✅ CRUD de Clientes

✅ Validação de dados via Data Annotations

✅ Armazenamento de sessão via sessionStorage

✅ API documentada com Swagger

## 🧠 Observações Técnicas
Estrutura baseada em camadas: Controller → Service → Repository

Separação entre DTO e Model

Validação automática de dados no backend

Comunicação segura via fetch() no frontend com CORS ativado

## 👤 Desenvolvedor
Igor Iseri
