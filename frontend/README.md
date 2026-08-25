# Cartão de Vacinação — Angular 17 !

Projeto Angular standalone (sem NgModules) convertido a partir do HTML/AngularJS original.

## Pré-requisitos

- **Node.js** 18+ → https://nodejs.org
- **Angular CLI** → `npm install -g @angular/cli`

## Como rodar

```bash
# 1. Instalar dependências
npm install

# 2. Iniciar o servidor de desenvolvimento
ng serve

# 3. Abrir no navegador
# http://localhost:4200
```

## Estrutura do projeto

```
src/
└── app/
    ├── app.component.ts/html     # Shell principal (nav, sidebar, modal)
    ├── app.config.ts             # Providers (Router, HttpClient)
    ├── app.routes.ts             # Rotas (expansível)
    ├── auth/                     # Tela de login / cadastro
    ├── dashboard/                # Página de visão geral
    ├── cartao/                   # Listagem de vacinações
    ├── registrar/                # Registrar nova vacinação
    ├── vacinas/                  # Cadastrar vacinas (admin)
    ├── conta/                    # Dados da conta + config da API
    └── shared/
        ├── models/models.ts      # Interfaces TypeScript
        └── services/api.service.ts  # Toda comunicação HTTP
```

## Configurar a URL da API

Após fazer login, vá em **Minha Conta → Configuração da API** e altere a URL base.  
O padrão é `https://localhost:44347`.
