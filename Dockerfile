# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos del proyecto y restaurar dependencias
COPY *.sln .
COPY API_PRACTICA3_MVC/*.csproj ./API_PRACTICA3_MVC/
RUN dotnet restore

# Copiar el resto de los archivos y compilar
COPY . .
WORKDIR /app/API_PRACTICA3_MVC
RUN dotnet publish -c Release -o out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/API_PRACTICA3_MVC/out ./

# Configurar la variable de entorno para el puerto
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "API_PRACTICA3_MVC.dll"]
