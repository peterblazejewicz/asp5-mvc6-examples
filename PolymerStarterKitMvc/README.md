# Polymer Starter Kit Mvc [WIP]

Welcome to Polymer Starter Kit Light!

TBD

## Description

The example is runnable already, but some details need to be worked out. The core of example source code is based on two projects:
* Polymer Starter Kit (Light version)
* Web Application Basic (part of `generator-aspnet`)

The combined sources have been changed slightly, to work nice with `beta6` ASP.NET 5 MVC6.

## Running example

```bash
dnu restore
[optional] dnu build
dnx . kestrel
```
Note: you would have to run:
```
export MONO_MANAGED_WATCHER=disabled
```
before `dnx . kestrel` on some \*nix machines due to issues with Mono 4.*.

## Author
@blazejewicz
