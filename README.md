# Cartão de Vacinação

Sistema de registro e consulta de vacinas com frontend Angular e backend C#.

---

## Backend

**Tecnologias:** C# · .NET 10 · MediatR · FluentValidation · Entity Framework

### Como rodar

```bash
# 1. Abra a solution no Visual Studio ou VS Code

# 2. Configure a connection string no appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "sua_connection_string_aqui"
}

# 3. Aplique as migrations
dotnet ef database update

# 4. Rode o projeto
dotnet run
```

> Por padrão sobe em `https://localhost:44347`

---

## Frontend

**Tecnologias:** Angular 17 · TypeScript · RxJS · Angular HttpClient

### Como rodar

```bash
# 1. Instale as dependências
npm install

# 2. Inicie o servidor de desenvolvimento
ng serve
```
