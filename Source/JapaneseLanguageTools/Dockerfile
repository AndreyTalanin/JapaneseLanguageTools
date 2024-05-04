# See https://aka.ms/customizecontainer to learn how to customize your debug container
# and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR "/source"

COPY ["JapaneseLanguageTools/JapaneseLanguageTools.csproj", "JapaneseLanguageTools/"]

RUN dotnet restore "JapaneseLanguageTools/JapaneseLanguageTools.csproj"

COPY "." "."

RUN dotnet build "JapaneseLanguageTools/JapaneseLanguageTools.csproj" -o "/application/build" -c $BUILD_CONFIGURATION --no-restore

FROM build AS publish

ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "JapaneseLanguageTools/JapaneseLanguageTools.csproj" -o "/application/publish" -c $BUILD_CONFIGURATION --no-restore /p:UseAppHost=false

FROM base AS final

WORKDIR "/application"

COPY --from=publish "/application/publish" "."

ENTRYPOINT ["dotnet", "JapaneseLanguageTools.dll"]
