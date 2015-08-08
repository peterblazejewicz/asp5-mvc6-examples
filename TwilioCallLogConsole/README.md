# Twilio Call Log Console

[Twilio Blog](https://www.twilio.com/blog/2015/08/getting-started-with-asp-net-5-and-visual-studio-code-on-a-mac.html)
> How to get started with setting up your .NET development environment on a Mac running Yosemite and show you how to build a Console and an ASP.NET MVC 6 call log application using Visual Studio Code and ASP.NET 5.

## Description

The project contains some modification compared to original blog post source code:

* the project file is modified to not use `dnxcore50` as Twilio package dependencies does not yet support it
* the project is using `Configuration` to streamline application configuration: https://github.com/aspnet/Configuration
* some syntax is updated to C# v6 (like string interpolation)
* The `config.json` contains only template data. You could add your information there as per article information taking these bits from your Twilio dashboard. Instead of `config.json` keys th ectual code relies on `user-secret` tool.

```bash
➜  TwilioCallLogConsole git:(master) ✗ dnx . restore
➜  TwilioCallLogConsole git:(master) ✗ dnx . build
➜  TwilioCallLogConsole git:(master) ✗ dnx . run
From: +14157234000, Day: 8/6/2015 9:21:30 PM, Duration: 43s
From: +14157234000, Day: 8/6/2015 9:20:29 PM, Duration: 21s
From: +266696687, Day: 10/29/2014 8:29:39 AM, Duration: 1s
From: +48128811320, Day: 10/5/2014 2:32:11 PM, Duration: 8s
```

## User Secrets

https://github.com/aspnet/Home/wiki/DNX-Secret-Configuration

>  a user secrets configuration system which is designed to store development configuration values in a location that's outside of your projects source tree. The user secrets configuration system comes in two parts, a global tool and a ConfigurationSource. The global tool allows you to manage secrets (add, remove, list) whilst the ConfigurationSource adds the values stored into the configuration system so that you can pass them to whatever APIs require them.

When configuration for Twilio is moved outside of project the code in `Project.cs` does not require any change. If we don't provide secrets via `AddUserSecrets()`, the keys from `config.json` are used. You can also pass them as environment variables:

```
➜ dnu install SecretManager
➜ user-secret set AccountSid AC4e2c0434f43d9155ed52f1084xxxxxx
info: Successfully saved AccountSid = AC4e2c0434f43d9155ed52f1084xxxxxx to the secret store.
➜ user-secret set AuthToken 2b9374e10f5c70cae75478d7xxxxxx
info: Successfully saved AuthToken = 2b9374e10f5c70cae75478d7xxxxxx to the secret store.
➜ user-secret set MyOwnNumber +48fake75453
info: Successfully saved MyOwnNumber = 48fake75453 to the secret store.
➜ user-secret set MyTwilioNumber +48fake98098
info: Successfully saved MyTwilioNumber = +48fake98098 to the secret store.
```

```
➜  TwilioCallLogConsole git:(refactor/config) ✗ user-secret list
info: AccountSid = AC4e2c0434f43d9155ed52f1084xxxxxx
info: AuthToken = 2b9374e10f5c70cae75478d7xxxxxx
info: MyOwnNumber = +48fake75453
info: MyTwilioNumber = +48fake98098
```

## Author

* Marcos Placona
* https://www.twilio.com/blog/author/marcos
