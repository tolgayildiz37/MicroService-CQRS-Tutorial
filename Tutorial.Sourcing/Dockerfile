#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Tutorial.Sourcing/Tutorial.Sourcing.csproj", "Tutorial.Sourcing/"]
COPY ["Tutorial.EventBusRabbitMQ/Tutorial.EventBusRabbitMQ.csproj", "Tutorial.EventBusRabbitMQ/"]
RUN dotnet restore "Tutorial.Sourcing/Tutorial.Sourcing.csproj"
COPY . .
WORKDIR "/src/Tutorial.Sourcing"
RUN dotnet build "Tutorial.Sourcing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tutorial.Sourcing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tutorial.Sourcing.dll"]