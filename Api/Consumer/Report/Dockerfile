FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/Consumer/Report/Api.Consumer.Report.csproj", "Api/Consumer/Report/"]
RUN dotnet restore "Api/Consumer/Report/Api.Consumer.Report.csproj"
COPY . .
WORKDIR "/src/Api/Consumer/Report"
RUN dotnet build "Api.Consumer.Report.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Consumer.Report.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Consumer.Report.dll"]
