# C# Corner ASP.NET MVC 6, Part 1: Tag Helpers

[ASP.NET MVC 6, Part 1: Tag Helpers](https://visualstudiomagazine.com/articles/2015/08/04/asp-net-mvc-6-part-1-tag-helpers.aspx)

## How to run this project

```shell
dnu restore
dnu build
dnx . kestrel
```

## Changes in implementation compared to original article

* The project is based on 'Web Application Basic' template available both in Visual Studio and in `generator-aspnet` - instead using more simpler and not commonly used samples from ASP.NET home project repository.
To scaffold the same type of application using `generator-aspnet` choose `Web Application Basic ...` template:
```bash
yo aspnet
```
* `beta6` - not `beta7` as project base
* client side dependencies managment is changed to Gulp and dnx tasks based
* code is a little cleaner on the HTML markup

## Author

Eric Vogel
> Eric Vogel is President and Lead Software Architect at Avant-Garde Labs, LLC. In DeWitt, Michigan. He is the president of the Greater Lansing User Group for .NET. Eric enjoys learning about software architecture and craftsmanship, and is always looking for ways to create more robust and testable applications.

https://visualstudiomagazine.com/Articles/2015/08/04/ASP-NET-MVC-6-Part-1-Tag-Helpers.aspx?Page=2
