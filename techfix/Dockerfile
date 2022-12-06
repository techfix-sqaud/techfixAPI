FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
ENV DOTNET_URLS=http://+:500
WORKDIR /app
EXPOSE 8080
# Copy csproj and restore as distinct layers
COPY techfix.csproj ./
RUN dotnet restore "techfix.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "techfix.dll"]