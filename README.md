# 📞 ContatoApi

API REST para gerenciamento de contatos
Permite cadastrar, editar, listar, inativar e excluir contatos, com validações como idade mínima e filtro de ativos.

---

## 🚀 Como executar o projeto

### Pré-requisitos

- Um banco de dados configurado (SQL Server recomendado)
- Ferramentas como Postman, Insomnia ou Swagger para testar as rotas

### Passos

```bash
git clone https://github.com/seu-usuario/ContatoApi.git
cd ContatoApi
dotnet restore
dotnet build
dotnet run
```
---

## 🔐 Regras de Negócio

- Contatos inativos não são exibidos nas listagens.
- A idade é calculada automaticamente com base na data de nascimento.
- Apenas contatos com **18 anos ou mais** podem ser cadastrados.
- Não é permitido cadastrar uma data de nascimento **no futuro**.

---

## 🔁 Endpoints disponíveis

### 🔹 `GET /api/contato`
Lista todos os contatos **ativos**.


### 🔹 `GET /api/contato/{id}`
Retorna um contato por ID (se for ativo).

### 🔸 `POST /api/contato`
Cria um novo contato.


- ⚠️ O campo `idade` será calculado automaticamente.
- ❌ Retorna erro se a pessoa for menor de 18 anos.

---

### 🔸 `PUT /api/contato/{id}`
Atualiza os dados de um contato existente.

---

### 🔸 `PATCH /api/contato/inativar/{id}`
Inativa um contato (soft delete).  
Ele será mantido no banco, mas não será mais listado.


### 🔻 `DELETE /api/contato/{id}`
Deleta um contato permanentemente.

---

## 🛠 Tecnologias utilizadas

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- Swagger 

---

## 📌 Observações

- A API utiliza uma camada de serviço e validações centralizadas.
- A idade não é armazenada no banco, mas calculada em tempo de execução.

