# Simple EF 

Just to remind me how to bootstrap EF Core.

## Commands 

inside the folder here docker-compose.yml is located run to start postgres:

```shell
docker compose up 
```

to install dotnet-ef cli tool run:

```shell
dotnet tool install --global dotnet-ef
```

to check if it was installed run:

```shell
dotnet ef 
```

inside the folder here the SimpleEf.csproj is to add migrations run:

```shell
dotnet ef migrations add <migration name>
```

inside the folder here the SimpleEf.csproj is to update database run:

```shell
dotnet ef database update
```
