# ðŸ§± DotnetBaseKit

> Projeto base com arquitetura em camadas para aplicaÃ§Ãµes .NET 8 pronto para escalar, seja para monolitos ou microsserviÃ§os.


[ðŸ‡ºðŸ‡¸ English Version](./README.md) 

Este repositÃ³rio serve como um **template reutilizÃ¡vel para aplicaÃ§Ãµes em .NET**, com separaÃ§Ã£o em camadas, seguindo boas prÃ¡ticas de Clean Architecture.

---

## ðŸ“ Estrutura do Projeto

```plaintext
â”œâ”€â”€ DotnetBaseKit.Api/                # Camada de apresentaÃ§Ã£o (Presentation)
â”œâ”€â”€ DotnetBaseKit.Application/        # Casos de uso, interfaces, DTOs
â”œâ”€â”€ DotnetBaseKit.Domain/             # Entidades e regras de negÃ³cio
â”œâ”€â”€ DotnetBaseKit.Infra/              # Infraestrutura (implementaÃ§Ãµes)
â”œâ”€â”€ DotnetBaseKit.Infra.CrossCutting/ # Middlewares, logging, configs, etc
â”œâ”€â”€ DotnetBaseKit.Infra.Shared/       # UtilitÃ¡rios e contratos comuns
â”œâ”€â”€ DotnetBaseKit.Infra.Tests/        # Testes automatizados (xUnit)
```
---

## ðŸ”§ Como usar

1. Clique em `Use this template` no canto superior direito
2. Renomeie seu repositÃ³rio
3. Clone:
  
```bash
git clone https://github.com/seu-usuario/seu-novo-repositorio.git
```
4. Rode:

```bash
cd DotnetBaseKit.Api
dotnet run
```

Ou simplesmente clone o repositÃ³rio:

```bash
git clone https://github.com/RafaelRodriguesFraga/DotnetBaseKit.git
```

Acesse em:
ðŸ“ http://localhost:5101/swagger

<br>

##### Feito com â¤ï¸ por Rafael Fraga
