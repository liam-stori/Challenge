FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["App.csproj", "./"]
RUN dotnet restore "App.csproj"

COPY . .
WORKDIR "/src"
RUN dotnet build "App.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "App.dll"]