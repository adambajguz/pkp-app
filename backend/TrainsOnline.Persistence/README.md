# Persistence Layer

This layer contains all configuration to databases.

Add-Migration <name> -Context StageDbContext -OutputDir "Migrations/StageDb"
Add-Migration <name> -Context ProdDbContext -OutputDir "Migrations/StageDb"