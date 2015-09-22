# Startup Conventions in ASP.NET 5

## Configuration by Conventions

The default environment configuration in ASP.NET 5 is `Production`. One can set
environment configuration using `ASPNET_ENV` environment variable.

The easy way is to add that variable to `projects.json`, for example:

```
kestrel-staging": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.Kestrel --config hosting.ini ASPNET_ENV=Staging"
```

You could use multiple `Startup.cs` files with naming based on conventions - or just use a single `Startup.cs` (like in this project) with multiple configuration methods based on naming conventions:

```
public void ConfigureDevelopment(IApplicationBuilder app)
{
}

public void ConfigureStaging(IApplicationBuilder app)
{
}

public void ConfigureProduction(IApplicationBuilder app)
{
}
```

## Author

@blazejewicz
