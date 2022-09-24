## PACKAGES

- dotnet add package Swashbuckle.AspNetCore --version 6.4.0
- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Pomelo.EntityFrameworkCore.MySql
- dotnet add package Flunt --version 2.0.5

## TOOLS

- dotnet tool install --global dotnet-ef
- (para atualizar as libs instaladas) dotnet tool install --global dotnet-outdated-tool (dotnet outdated --upgrade)

## MIGRATIONS

- create migration: dotnet ef migrations add create-product
- if any errors: dotnet ef migrations bundle --configuration Bundle
- apply migration: dotnet ef database update / dotnet ef migrations remove --force (--force is optional)
