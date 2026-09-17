# =========================
# Build Stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy project files
COPY ["KanhaDairyAPI/KanhaDairyAPI.csproj", "KanhaDairyAPI/"]
COPY ["KanhaDairy.BAL/KanhaDairy.BAL.csproj", "KanhaDairy.BAL/"]
COPY ["KanhaDairy.DAL/KanhaDairy.DAL.csproj", "KanhaDairy.DAL/"]
COPY ["KanhaDairy.MODEL/KanhaDairy.MODEL.csproj", "KanhaDairy.MODEL/"]
COPY ["KanhaDairy.UTILITY/KanhaDairy.UTILITY.csproj", "KanhaDairy.UTILITY/"]

# Restore dependencies
RUN dotnet restore "KanhaDairyAPI/KanhaDairyAPI.csproj"

# Copy source code
COPY . .

# Publish API
RUN dotnet publish "KanhaDairyAPI/KanhaDairyAPI.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# =========================
# Runtime Stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=8000

EXPOSE 8000

ENTRYPOINT ["dotnet", "KanhaDairyAPI.dll"]