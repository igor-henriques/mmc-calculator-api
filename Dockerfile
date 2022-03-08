#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["math-operations-api/math-operations-api.csproj", "math-operations-api/"]
RUN dotnet restore "math-operations-api/math-operations-api.csproj"
COPY . .
WORKDIR "/src/math-operations-api"
RUN dotnet build "math-operations-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "math-operations-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet math-operations-api.dll