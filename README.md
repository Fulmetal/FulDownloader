# 🎬 FulDownloader

**Your videos. Your server. Your rules.**

FulDownloader is a self-hosted web app that lets you download videos from YouTube — no ads, no telemetry, no tracking. Just you and your content.

---

## ✨ Why FulDownloader?

| Feature | Benefit |
|---------|---------|
| 🏠 **Self-hosted** | Full control over your data and downloads |
| 🔒 **Private** | No popups, no tracking, no telemetry — ever |
| ⚡ **Fast** | Optimized downloads with yt-dlp under the hood |
| 🎨 **Clean UI** | Simple, intuitive interface that just works |
| 🐳 **Docker-ready** | One command to deploy, zero headaches |
| 📂 **Flexible** | Pick your quality, framerate, and format |

---

## 🚀 Quick Start

### 1. Deploy with Docker

```bash
docker run -d \
  --name fuldownloader \
  -p 8080:8080 \
  ghcr.io/fulmetal/fuldownloader:latest
```

### 2. Open Your Browser

Navigate to `http://localhost:8080`

### 3. Start Downloading

1. Paste a YouTube URL
2. Choose your quality and format
3. Click download — done

---

## 📦 Docker Image

| Source | Link |
|--------|------|
| **GitHub Container Registry** | [ghcr.io/fulmetal/fuldownloader](https://ghcr.io/fulmetal/fuldownloader) |
| **Docker Hub** | [dockerhub.com/r/fulmetal/fuldownloader](https://hub.docker.com/r/fulmetal/fuldownloader) |

---

## 🛠️ Built With

- **.NET 10** — Blazor Server for the web UI
- **yt-dlp** — Powerful video extraction engine
- **FFmpeg** — Format conversion and processing
- **Serilog** — Structured logging
- **Docker** — Containerized deployment

---

## ⚠️ Legal Notice

Before using FulDownloader, please ensure that you have the permission of the content creators for the material you intend to download. This tool is designed to be used in accordance with fair use principles. Misuse may infringe on copyright laws and violate the rights of content owners. Always respect the rights of creators and ensure you are using this tool responsibly.

---

## 📄 License

Open source and free to use.

---

*Made with ❤️ by [Fulmetal](https://github.com/Fulmetal)*
