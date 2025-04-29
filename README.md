# Softline Teste Técnico

Este projeto foi desenvolvido como parte de um teste técnico solicitado pela empresa Softline.

## 🚀 Tecnologias utilizadas

- Backend: ASP.NET Core 8.0
- ORM: Entity Framework Core
- Banco de dados: SQL Server
- Frontend: HTML5, CSS3, JavaScript (Fetch API)

## 📦 Funcionalidades

- Autenticação de usuários (Login)
- CRUD completo de Produtos
- CRUD completo de Clientes
- Validação de dados via Data Annotations
- Comunicação Frontend → Backend via Fetch API
- Armazenamento de sessão com `sessionStorage`

## ⚙️ Como rodar o projeto

### 1. Backend

```bash
# Navegar até o diretório do backend
cd softlineApp

# Restaurar pacotes e compilar
dotnet restore
dotnet build

# Rodar o projeto
dotnet run
A API estará disponível em algo como: http://localhost:5204
```

###2. Frontend
Abrir o diretório frontend

Abrir index.html usando Live Server no VS Code ou outro servidor local

Acessar pelo navegador (ex: http://127.0.0.1:5500/frontend/index.html)

###3. Banco de Dados
Para gerar o script do banco:

```bash
# Dentro do diretório do backend
dotnet ef migrations script -o softline_database.sql
Isso gera um arquivo .sql com o script de criação do banco.
```
👤 Desenvolvedor
Igor Iseri
