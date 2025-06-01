# Use official .NET 9 SDK image as build environment
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project files (from solution root)
COPY . . 

# Restore dependencies (solution-level)
RUN dotnet restore

# Build the API project (specify relative path to .csproj)
RUN dotnet publish APIFinalLibrary/APIFinalLibrary.csproj -c Release -o /app/out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy build output
COPY --from=build /app/out .

# Expose ports
EXPOSE 5000

# Entry point
ENTRYPOINT ["dotnet", "APIFinalLibrary.dll"]
