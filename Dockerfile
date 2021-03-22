#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src/."
RUN dotnet build "QuietRssApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuietRssApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
EXPOSE 5001
ENTRYPOINT ["dotnet", "QuietRssApi.dll"]