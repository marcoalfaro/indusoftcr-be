FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 80
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet service.dll