FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["API_IA_DB.csproj", "./"]
RUN dotnet restore "API_IA_DB.csproj"
COPY . .
RUN dotnet build "API_IA_DB.csproj" -c Release -o /app/build
RUN dotnet publish "API_IA_DB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API_IA_DB.dll"]