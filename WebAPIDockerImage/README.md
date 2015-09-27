# WebAPI Application with Docker image

Based on: [Build ASPNET 5 (beta6) WEB API Docker image in less than 5 minutes](https://www.youtube.com/watch?v=LyCUKKwR5hY) by [Sokun Chorn](https://www.youtube.com/channel/UCBTY2FidEoAU9zeWVN_Tyuw)

The application source and Dockerfile updated for ASP.NET 5 `beta7`.

## Running example

Build an image:
```
docker build -t web-api-application .
Sending build context to Docker daemon 19.97 kB
Step 0 : FROM microsoft/aspnet:latest
 ---> 5d7513d98c09
Step 1 : COPY WebAPIApplication /app
 ---> 4cc201a4ad63
Removing intermediate container 9b20a80dde90
Step 2 : WORKDIR /app
 ---> Running in 6f4956ad6cca
 ---> 03d5088bf0b2
Removing intermediate container 6f4956ad6cca
Step 3 : ENV MONO_THREADS_PER_CPU 2000
 ---> Running in d7a9678392f4
 ---> d9848fd47b76
Removing intermediate container d7a9678392f4
Step 4 : RUN dnu restore
 ---> Running in 832ececb45ee
Microsoft .NET Development Utility Mono-x64-1.0.0-beta7-15532

  GET https://api.nuget.org/v3/index.json
  OK https://api.nuget.org/v3/index.json 1076ms
...
Writing lock file /app/project.lock.json
Restore complete, 253289ms elapsed

NuGet Config files used:
    /root/.config/NuGet/NuGet.Config

Feeds used:
    https://api.nuget.org/v3-flatcontainer/

Installed:
    187 package(s) to /root/.dnx/packages
 ---> 7b8458b0d7e5
Removing intermediate container 832ececb45ee
Step 5 : EXPOSE 5000
 ---> Running in 66513c2fd65e
 ---> dc178215b7f9
Removing intermediate container 66513c2fd65e
Step 6 : ENTRYPOINT dnx kestrel
 ---> Running in a79550756e01
 ---> 3e9e4c2bc1b2
Removing intermediate container a79550756e01
Successfully built 3e9e4c2bc1b2
```
Run application:
```
docker run -t -d -p 80:5000 web-api-application
```
The application address in container:
```
http://192.168.99.100/api/values
```

## Author
@peterblazejewicz
