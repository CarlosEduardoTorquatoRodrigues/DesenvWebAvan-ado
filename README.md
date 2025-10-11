# DesenvWebAvan-ado

cd /workspaces/DesenvWebAvan-ado/SorveteriaApp/SorveteriaApp.Web
rm -rf Migrations
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run