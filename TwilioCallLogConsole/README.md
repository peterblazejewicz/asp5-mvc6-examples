# Twilio Call Log Console

[Twilio Blog](https://www.twilio.com/blog/2015/08/getting-started-with-asp-net-5-and-visual-studio-code-on-a-mac.html)
> How to get started with setting up your .NET development environment on a Mac running Yosemite and show you how to build a Console and an ASP.NET MVC 6 call log application using Visual Studio Code and ASP.NET 5.

## Description

The project contains some modification compared to original blog post:

* the project file is modified to not use `dnxcore50`
* the project is using `Configuration` framework for file based JSON configuration
```csharp
var configuration = new ConfigurationBuilder(ApplicationEnvironment.ApplicationBasePath)
    .AddJsonFile("config.json", true)
    .Build().GetConfigurationSection("Twilio");
// Instantiate a new Twilio Rest Client
var client = new TwilioRestClient(
  configuration.Get("AccountSid"),
  configuration.Get("AuthToken")
);
```
* some syntax is updated to C# v6 (like string interpolation)
* the project configuration is not stored in repository - instead a default
configuration file is stored here. Copy this file as `config.json` and add your own information from Twilio dashboard.

```bash
➜  TwilioCallLogConsole git:(master) ✗ dnx . restore
➜  TwilioCallLogConsole git:(master) ✗ dnx . build
➜  TwilioCallLogConsole git:(master) ✗ dnx . run
From: +14157234000, Day: 8/6/2015 9:21:30 PM, Duration: 43s
From: +14157234000, Day: 8/6/2015 9:20:29 PM, Duration: 21s
From: +266696687, Day: 10/29/2014 8:29:39 AM, Duration: 1s
From: +48128811320, Day: 10/5/2014 2:32:11 PM, Duration: 8s
```

## Author

* Marcos Placona
* https://www.twilio.com/blog/author/marcos
