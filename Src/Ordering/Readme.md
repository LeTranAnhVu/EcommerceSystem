#### Migrations:
```
 dotnet ef -s .\Api\ -p .\Infrastructure\  migrations add InitialDb -o Migrations
 
 dotnet ef database update -c OrderDbContext -s .\Api\ -p .\Infrastructure\

```