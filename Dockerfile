#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pet.Project.Profile.Api/Pet.Project.Profile.Api.csproj", "Pet.Project.Profile.Api/"]
COPY ["Pet.Project.Profile.Domain/Pet.Project.Profile.Domain.csproj", "Pet.Project.Profile.Domain/"]
COPY ["Pet.Project.Profile.Infraestructure/Pet.Project.Profile.Infrastructure.csproj", "Pet.Project.Profile.Infraestructure/"]
RUN dotnet restore "Pet.Project.Profile.Api/Pet.Project.Profile.Api.csproj"
COPY . .
WORKDIR "/src/Pet.Project.Profile.Api"
RUN dotnet build "Pet.Project.Profile.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pet.Project.Profile.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pet.Project.Profile.Api.dll"]