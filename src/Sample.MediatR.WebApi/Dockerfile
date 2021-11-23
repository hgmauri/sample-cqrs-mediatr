FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Sample.MediatR.WebApi/Sample.MediatR.WebApi.csproj", "src/Sample.MediatR.WebApi/"]
COPY ["src/Sample.MediatR.WebApi.Core/Sample.MediatR.WebApi.Core.csproj", "src/Sample.MediatR.WebApi.Core/"]
COPY ["src/Sample.MediatR.Application/Sample.MediatR.Application.csproj", "src/Sample.MediatR.Application/"]
RUN dotnet restore "src/Sample.MediatR.WebApi/Sample.MediatR.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Sample.MediatR.WebApi"
RUN dotnet build "Sample.MediatR.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.MediatR.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.MediatR.WebApi.dll"]
