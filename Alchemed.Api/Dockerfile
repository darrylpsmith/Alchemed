FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Alchemed.Api/Alchemed.Api.csproj Alchemed.Api/
COPY Alchemed.DataModel/Alchemed.DataModel.csproj Alchemed.DataModel/
RUN dotnet restore Alchemed.Api/Alchemed.Api.csproj
COPY . .
WORKDIR /src/Alchemed.Api
RUN dotnet build Alchemed.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Alchemed.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Alchemed.Api.dll"]
