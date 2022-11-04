#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["gipfeliapp/gipfeliapp.csproj", "gipfeliapp/"]
RUN dotnet restore "gipfeliapp/gipfeliapp.csproj"
COPY . .
WORKDIR "/src/gipfeliapp"
RUN dotnet build "gipfeliapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gipfeliapp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gipfeliapp.dll"]