# Persistence Layer

This layer contains all configuration to databases.

dotnet tool install -g dotnet-ef
dotnet ef migrations add <name> --project TrainsOnline.Persistence
dotnet ef migrations add <name> --no-build -v -o "Migrations" --json --prefix-output

Add-Migration <name> -project TrainsOnline.Persistence
