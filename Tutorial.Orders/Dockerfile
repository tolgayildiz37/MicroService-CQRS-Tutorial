#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Tutorial.Orders/Tutorial.Orders.csproj", "Tutorial.Orders/"]
COPY ["Tutorial.Orders.Application/Tutorial.Orders.Application.csproj", "Tutorial.Orders.Application/"]
COPY ["Tutorial.Orders.Domain/Tutorial.Orders.Domain.csproj", "Tutorial.Orders.Domain/"]
COPY ["Tutorial.Orders.Infrastructure/Tutorial.Orders.Infrastructure.csproj", "Tutorial.Orders.Infrastructure/"]
COPY ["Tutorial.EventBusRabbitMQ/Tutorial.EventBusRabbitMQ.csproj", "Tutorial.EventBusRabbitMQ/"]
RUN dotnet restore "Tutorial.Orders/Tutorial.Orders.csproj"
COPY . .
WORKDIR "/src/Tutorial.Orders"
RUN dotnet build "Tutorial.Orders.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tutorial.Orders.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tutorial.Orders.dll"]
