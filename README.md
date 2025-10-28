# DesenvWebAvan-ado

# Verificar se o container está rodando
docker ps

# Se aparecer o container do SQL Server, só executar a aplicação:
cd /workspaces/DesenvWebAvan-ado/SorveteriaApp/SorveteriaApp.Web
dotnet run

# Iniciar o container existente
docker start sqlserver

# Ou se não souber o nome:
docker ps -a  # lista todos os containers
docker start <container_id>

# Depois executar a aplicação
cd /workspaces/DesenvWebAvan-ado/SorveteriaApp/SorveteriaApp.Web
dotnet run


# 1. Criar container (COM volume para dados persistentes)
docker run -e "ACCEPT_EULA=Y" \
  -e "SA_PASSWORD=SenhaForte@123" \
  -p 1433:1433 \
  -v sqlserver_data:/var/opt/mssql \
  --name sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest

# 2. Aplicar migrations (recriar tabelas)
cd /workspaces/DesenvWebAvan-ado/SorveteriaApp/SorveteriaApp.Web
dotnet ef database update --project ../SorveteriaApp.Infrastructure --startup-project .

# 3. Executar
dotnet run


# FLUXO RAPIDO
# 1. Garantir que o SQL Server está rodando
docker start sqlserver

# 2. Ir para a pasta e executar
cd /workspaces/DesenvWebAvan-ado/SorveteriaApp/SorveteriaApp.Web
dotnet run