create migration (from Web folder CLI):

dotnet ef migrations add InitialModel --context blogcontext -p ../../Infrastructure/Infrastructure.csproj -s Web.csproj -o Data/Migrations

dotnet restore

Configuring and Installing the application:

More information is given in the article foun don the following link:

https://www.linkedin.com/pulse/software-architecture-containerizing-deploying-part-mandava/?published=t
