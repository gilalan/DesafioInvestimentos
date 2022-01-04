##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
##For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
#WORKDIR /src
#COPY ["DesafioInvestimentos.csproj", ""]
#RUN dotnet restore "./DesafioInvestimentos.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "DesafioInvestimentos.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "DesafioInvestimentos.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
##mudança para o heroku
##ENTRYPOINT ["dotnet", "DesafioInvestimentos.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet DesafioInvestimentos.dll
#

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
# Padrão de container ASP.NET
# ENTRYPOINT ["dotnet", "CarterAPI.dll"]
# Opção utilizada pelo Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet DesafioInvestimentos.dll
