# Building from Source

## Prerequisites

- Windows 10 / 11 (64-bit)
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Git
- Visual Studio 2022 or VS Code (optional)

---

## Clone the Repository

```bash
git clone https://github.com/atharvpawar16/APDocsStudio.git
cd APDocsStudio
```

---

## Build

```bash
dotnet build APDocsStudio.sln --configuration Release
```

---

## Run

```bash
dotnet run --project APDocsStudio.csproj
```

---

## Publish (Self-contained EXE)

```bash
dotnet publish APDocsStudio.csproj --configuration Release --runtime win-x64 --self-contained false --output ./publish
```

The output will be in the `./publish` folder. Run `APDocsStudio.exe` from there.

---

## Project Structure

```
APDocsStudio/
├── Program.cs                  # Entry point
├── APDocsStudio.csproj         # Main project file
├── NAPS2.Images/               # Core image processing
├── NAPS2.Images.Gdi/           # GDI+ image backend
├── NAPS2.Internals/            # Shared utilities
├── NAPS2.Sdk/                  # Core document SDK
├── NAPS2.Lib/                  # App logic and UI controllers
├── NAPS2.Setup/                # App settings and installer config
└── landing/                    # Landing page (HTML)
```

---

## Contributing

1. Fork the repository
2. Create a branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "feat: add your feature"`
4. Push: `git push origin feature/your-feature`
5. Open a Pull Request on GitHub
