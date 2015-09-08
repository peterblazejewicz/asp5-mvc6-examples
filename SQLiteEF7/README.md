# SQLite EntityFramework 7 example

The example is based on the [ASP.NET 5 WITH SQLITE AND ENTITY FRAMEWORK 7](https://damienbod.wordpress.com/2015/08/30/asp-net-5-with-sqlite-and-entity-framework-7/) by [Damien Bod](https://damienbod.wordpress.com/author/damienbod/)

> This article shows how to use SQLite with ASP.NET 5 using Entity Framework 7. EF7 can now create SQLite databases using Entity Framework migrations which was not possible in previous versions.

## Project

```
dnu restore

dnu build

dnx kestrel
```

The project is mixed content project type. It uses WebAPI 2.0 (ASP .NET 5) with static files middleware enabled on server to serve AngularJS SPA application.

The backend is implemented in SQLite using EntityFramework 7 - which is new to recent version of ASP NET.

Please note that you have to use specif version of SQLite, see:
> Requires SQLite >= 3.7.15.

https://github.com/aspnet/Microsoft.Data.Sqlite

## Author

@blazejewicz
