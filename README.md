# FulDownloader

**Download YouTube videos. On your server. Zero tracking. Zero ads. Zero excuses.**

![FulDownloader](./fuldownloader_image.jpg)

FulDownloader is a self-hosted web app that turns any YouTube link into a clean download. It runs on your pc or server. No telemetry. No middleman. No ads or popups.

---

## ✨ What can it do?

- 🎥 **Download videos** — any public YouTube video, any quality your hardware supports
- 📊 **Choose your quality** — depending on the video, pick from 144p to 4K

---

## ⚙️ How it works

```
              You paste a URL
                     │
                     ▼
         Pick your format & quality
                     │
                     ▼
               Wait for magic
                     │
                     ▼
         Choose download location
                     │
                     ▼
                   Done
```

That's it. No more broken websites with popups or paywalls. Everything runs locally on your server.

---

## 🚀 Quick Start

### Docker (recommended)

```bash
docker run -d \
  --name fuldownloader \
  -p 8080:8080 \
  -v ~/fuldownloader/downloads:/app/downloads \
  ghcr.io/fulmetal/fuldownloader:latest
```

Open `http://localhost:8080` in your browser. Paste a link. Hit download.

### From source

```bash
git clone https://github.com/Fulmetal/FulDownloader.git
cd FulDownloader
dotnet restore
dotnet run --project FulDownloader
```

---

## ❓ FAQ

**Do I need a YouTube Premium account?**
No. FulDownloader works with any public video.

**Can I download playlists?**
This will be a future feature.

**What about other sites?**
Currently only implemented for YouTube, but support for more platforms is on the roadmap.

**How do I update?**
`docker pull ghcr.io/fulmetal/fuldownloader:latest && docker restart fuldownloader`

---

## ⚠️ Legal stuff

FulDownloader is a tool. How you use it is on you. Please only download content you have permission to copy — respect creators, respect copyright, respect the law.

---

## 📄 License

GNU GPL v3. You can use, modify, and distribute it — but any distributed derivative must also be open source.

---

*Built by [Fulmetal](https://github.com/Fulmetal). No telemetry. Ever.*
