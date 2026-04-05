# Getting Started

## Requirements

| Requirement | Details |
|---|---|
| OS | Windows 10 / 11 (64-bit) |
| Runtime | [.NET 9 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) |
| Paint | Pre-installed on all Windows PCs |
| RAM | 4 GB minimum, 8 GB recommended |
| Storage | ~50 MB |

---

## Installation

### Option 1 — Download EXE (Recommended)

1. Go to [Releases](https://github.com/atharvpawar16/APDocsStudio/releases/latest)
2. Download `APDocsStudio.exe`
3. Install [.NET 9 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) if prompted
4. Double-click `APDocsStudio.exe` to launch

### Option 2 — Download ZIP

1. Download `APDocsStudio-v1.0.0-win-x64.zip` from [Releases](https://github.com/atharvpawar16/APDocsStudio/releases/latest)
2. Extract the ZIP to any folder
3. Run `APDocsStudio.exe` from the extracted folder

### Option 3 — Build from Source

```bash
git clone https://github.com/atharvpawar16/APDocsStudio.git
cd APDocsStudio
dotnet build APDocsStudio.sln
dotnet run --project APDocsStudio.csproj
```

---

## First Launch

When you first open APDocs Studio:

1. A welcome message will appear — click OK
2. The main window opens with an empty document list
3. Use `Ctrl+O` to import your first image or PDF
4. Or drag and drop any file directly onto the window

---

## Next Steps

- [Features](Features) — explore what APDocs Studio can do
- [Paint Integration Guide](Paint-Integration-Guide) — learn how to edit with Paint
- [Keyboard Shortcuts](Keyboard-Shortcuts) — work faster with shortcuts
