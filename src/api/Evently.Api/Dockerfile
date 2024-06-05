FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/api/Evently.Api/Evently.Api.csproj", "src/api/Evently.Api/"]
COPY ["modules/events/Evently.Modules.Event.Presentation/Evently.Modules.Event.Presentation.csproj", "modules/events/Evently.Modules.Event.Presentation/"]
COPY ["modules/events/Evently.Modules.Event.Application/Evently.Modules.Event.Application.csproj", "modules/events/Evently.Modules.Event.Application/"]
COPY ["modules/events/Evently.Modules.Event.Domain/Evently.Modules.Event.Domain.csproj", "modules/events/Evently.Modules.Event.Domain/"]
COPY ["modules/events/Evently.Modules.Event.Infrastructure/Evently.Modules.Event.Infrastructure.csproj", "modules/events/Evently.Modules.Event.Infrastructure/"]
RUN dotnet restore "src/api/Evently.Api/Evently.Api.csproj"
COPY . .
WORKDIR "/src/src/api/Evently.Api"
RUN dotnet build "Evently.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Evently.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Evently.Api.dll"]
