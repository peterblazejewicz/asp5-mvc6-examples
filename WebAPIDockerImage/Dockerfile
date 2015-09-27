FROM microsoft/aspnet:latest

COPY WebAPIApplication /app
WORKDIR /app

ENV MONO_THREADS_PER_CPU=2000
RUN ["dnu", "restore"]

EXPOSE 5000
ENTRYPOINT ["dnx", "kestrel"]
