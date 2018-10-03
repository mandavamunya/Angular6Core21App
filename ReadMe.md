-- create migration (from Web folder CLI):

dotnet ef migrations add InitialModel --context blogcontext -p ../../Infrastructure/Infrastructure.csproj -s Web.csproj -o Data/Migrations

dotnet restore
