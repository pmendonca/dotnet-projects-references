# Modelo

Este é um modelo básico para organizar um projeto .NET que mescla os padrões de arquitetura
(DDD + MediatR + EF Core)

## Building Blocks

### Application

### Domain

#### Domain Event

Fato ocorrido no domínio, ex.: `OrderCreated` sempre no passado. Serve para propagar regras/políticas
internas e disparar reações (atualizar projeções) sem acoplar os módulos entre si.

Características importantes:
- Imutável, com timestamp e (idealmente) correlation/causation ID
- Carrega IDs e dados mínimos (evite passar a entidade inteira)
- Nome no passado: `OrderCreated`, `PaymentAuthorized`

1. A estrutura agrega eventos via `Raise(new OrderCreated(id))`.
2. Quem reage são `INotificationHandler<TEvent>` através do `OnOrderCreatedHandler` por exemplo.
3. Tudo isso roda dentro da pipeline `ValidationBehavior` → `LoggingBehavior` → `TransactionBehavior`.

### Infrastructure

## Modules

Cada Módulo esta organizado em três níveis: Application, Domain e Infrastructure.

Dentro a Application estão os Commands e as Qu

### Orders

#### Application

#### Domain

#### Infrastructure

