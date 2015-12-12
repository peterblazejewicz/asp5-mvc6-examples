# Building ASP.NET MVC 6 & Entity Framework 7 application using ASP.NET 5 RC

The original article by [Mahesh Sabnis](http://www.dotnetcurry.com/author/mahesh-sabnis):

> ASP.NET 5 is a significant redesign of ASP.NET. This article shows you how to build a web application in ASP.NET MVC 6 & Entity Framework 7 using ASP.NET 5 RC1.  

[http://www.dotnetcurry.com/aspnet-mvc/1215/building-aspnet-mvc-6-entity-framework-7-app-using-aspnet-5](http://www.dotnetcurry.com/aspnet-mvc/1215/building-aspnet-mvc-6-entity-framework-7-app-using-aspnet-5)

This example modifies original article implementation by using SQLite as underlying database.

## Documentation

Open DB created by migration:
```
sqlite> .open ProductsCategories.db 
```

Show tables created by migration:
```
sqlite> .tables
```

Show tables schemas created by migration:
```
sqlite> .schema
CREATE TABLE "Category" (
    "CategoryId" INTEGER NOT NULL CONSTRAINT "PK_Category" PRIMARY KEY AUTOINCREMENT,
    "CategoryName" TEXT
);
CREATE TABLE "Product" (
    "ProductId" INTEGER NOT NULL CONSTRAINT "PK_Product" PRIMARY KEY AUTOINCREMENT,
    "CategoryId" INTEGER NOT NULL,
    "Price" INTEGER NOT NULL,
    "ProductName" TEXT,
    CONSTRAINT "FK_Product_Category_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Category" ("CategoryId") ON DELETE CASCADE
);
CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK_HistoryRow" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
```
 
## Author

@peterblazejewicz