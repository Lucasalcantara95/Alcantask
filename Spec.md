# Especificação do Projeto: AlcanTasks

## Visão Geral

AlcanTasks é um sistema de gerenciamento de tarefas projetado para ajudar usuários a organizar suas atividades diárias com foco em prioridade e simplicidade. O projeto segue a abordagem de Clean Architecture, separando as responsabilidades em camadas de Domínio, Aplicação, Infraestrutura e API.

## Arquitetura

- **AlcanTasks.Domain**: Contém as entidades e a lógica de negócio central.
- **AlcanTasks.Application**: Contém a lógica da aplicação, incluindo Comandos, Consultas (Queries) e DTOs (utilizando MediatR e FluentValidation).
- **AlcanTasks.Infrastructure**: Lida com a persistência de dados (Entity Framework Core) e integrações externas.
- **AlcanTasks.Api**: O ponto de entrada da aplicação, fornecendo endpoints REST.

## Modelo de Domínio Principal

### TaskItem

- `Id` (Guid): Identificador único.
- `Name` (string): Nome da tarefa (máx. 200 caracteres).
- `Priority` (int): Nível de prioridade (1 a 3).
- `IsCompleted` (bool): Status de conclusão.
- `CreatedAt` (DateTime): Data e hora de criação.
- `CompletedAt` (DateTime?): Data e hora de conclusão.

## Funcionalidades Atuais

- **Criação de Tarefas**: Criar novas tarefas com nome e prioridade.
- **Gestão de Tarefas**: Atualizar o status da tarefa (conclusão).
- **Visão Diária**: Recuperar tarefas para uma data específica.

## Stack Técnica

- **Framework**: .NET 10.0
- **Banco de Dados**: Entity Framework Core
- **Padrão**: CQRS (Command Query Responsibility Segregation) via MediatR
- **Validação**: FluentValidation
- **API**: ASP.NET Core Web API

## Diretrizes para Melhorias Futuras

Ao utilizar agentes de IA para melhorar o sistema, por favor considere:

1. **Manter a Clean Architecture**: Mantenha a lógica de domínio na camada de Domain e a orquestração na camada de Application.
2. **Validação**: Garanta que todos os comandos possuam validadores correspondentes.
3. **Consistência**: Siga as convenções de nomenclatura e a estrutura de projeto existentes.
4. **Testes**: Adicione testes unitários para novas lógicas de negócio na pasta `test/`.
