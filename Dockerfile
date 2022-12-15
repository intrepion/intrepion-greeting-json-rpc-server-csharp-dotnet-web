FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /source

COPY *.sln .
COPY greeting/*.csproj ./greeting/
RUN dotnet restore

COPY greeting/. ./greeting/
WORKDIR /source/greeting
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "greeting.dll"]
