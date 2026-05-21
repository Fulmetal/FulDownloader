# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
ARG TARGETARCH
WORKDIR /source

USER root

# Copy project file and restore as distinct layers
COPY FulDownloader/*.csproj ./FulDownloader/
COPY Infrastructure/*.csproj ./Infrastructure/
RUN dotnet restore ./FulDownloader/FulDownloader.csproj -a $TARGETARCH 

# Copy source code and publish app
COPY FulDownloader/. ./FulDownloader/
COPY Infrastructure/. ./Infrastructure/
WORKDIR /source/FulDownloader
RUN dotnet publish -c Release -o /app -a $TARGETARCH

# Enable globalization and time zones:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/enable-globalization.md
# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine
EXPOSE 8080
WORKDIR /app

USER root
RUN apk update \
    && apk upgrade \
    && apk add python3 wget ffmpeg deno \
    && wget https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp -O /bin/yt-dlp \
    && chmod a+rx /bin/yt-dlp \
    && rm -rf /var/cache/apk/* \
    && chown -R $APP_UID:$APP_UID /app

USER $APP_UID

COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["./FulDownloader"]
