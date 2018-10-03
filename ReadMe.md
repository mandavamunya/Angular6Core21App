-- create migration (from Web folder CLI)
dotnet ef migrations add InitialModel --context blogcontext -p ../../Infrastructure/Infrastructure.csproj -s Web.csproj -o Data/Migrations

dotnet restore
dotnet ef database update -c blogcontext -p ../../Infrastructure/Infrastructure.csproj -s Web.csproj

    "DefaultConnection": "Server=db; Database=BlogDb; user=SA; password=Password123; MultipleActiveResultSets=true"