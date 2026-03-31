# APDocs Studio

> The most powerful photo and PDF editor for Windows — scan, edit with Paint, and export perfect documents in seconds.

APDocs Studio is a professional-grade photo and PDF editing suite for Windows. It combines high-quality document scanning, deep image editing, OCR text extraction, and seamless **Microsoft Paint integration** — so you can use Paint's familiar Select & Cut tools to precisely edit any photo or scanned page before saving as PDF.

---

## Why APDocs Studio?

Most PDF tools make you pay for basic editing. Most photo editors don't handle documents. APDocs Studio does both — and it's the only app that lets you **open any scanned image or PDF page directly in Paint**, edit it with full precision using Paint's selection tools, and bring it back as a polished PDF.

---

## Key Features

### Photo & PDF Editing
- **Open any image or PDF page** for editing — JPG, PNG, BMP, TIFF, multi-page PDF
- **Brightness, contrast, saturation, sharpness** — fine-tune every photo
- **Crop & rotate** — trim edges, fix orientation, straighten skewed scans
- **Deskew** — automatically straighten tilted document scans
- **Black & white / grayscale conversion** — clean up documents instantly
- **Hue & color correction** — fix color casts in photos
- **Blank page detection** — auto-remove empty pages from batches

### Paint Integration — Edit with Select & Cut
APDocs Studio lets you send any image directly to **Microsoft Paint** for precision editing:

1. Right-click any scanned page → **"Edit with Paint"**
2. In Paint, use the **Select tool** (dotted rectangle in the toolbar) to draw a box around the area you want to keep or remove
3. To **cut out** an unwanted section: select it → press `Ctrl + X` (Cut) — the area is removed and filled with white
4. To **keep only a region**: select it → `Ctrl + C` (Copy) → `Ctrl + N` (New) → `Ctrl + V` (Paste) → save
5. Use **Free-form Select** for irregular shapes — draw around any object to isolate it
6. Save in Paint (`Ctrl + S`) and APDocs Studio automatically reloads the edited image
7. Export the final result as PDF with one click

### PDF Tools
- **Export to searchable PDF** — with embedded OCR text layer
- **Import existing PDFs** — open, edit pages, re-export
- **Merge multiple scans** into a single PDF
- **Page reordering** — drag pages into any order before export
- **PDF compression settings** — balance quality vs file size

### Scanning
- **WIA, TWAIN, ESCL (AirScan)** scanner support
- **ADF batch scanning** — scan entire document stacks automatically
- **Network scanner sharing** — share a USB scanner over your local network
- **Scan profiles** — save settings per document type

### OCR
- **Tesseract OCR** — extract text from any scanned image
- **40+ languages** supported
- Creates **fully searchable PDFs** with invisible text layer

---

## How to Edit Photos Using Paint's Select & Cut

Paint is built into every Windows PC and is perfect for quick, precise photo edits. Here's how to use it with APDocs Studio:

### Rectangular Select & Cut
```
1. In APDocs Studio, right-click a page → Edit with Paint
2. Click the "Select" dropdown in Paint's toolbar (Home tab)
3. Choose "Rectangular selection"
4. Click and drag to draw a box around the area to remove
5. Press Delete or Ctrl+X to cut it out
6. Save with Ctrl+S — APDocs Studio reloads it automatically
```

### Free-form Select (cut any shape)
```
1. Click the "Select" dropdown → "Free-form selection"
2. Draw around the exact shape you want to isolate
3. Ctrl+C to copy, Ctrl+N for new canvas, Ctrl+V to paste
4. Save and return to APDocs Studio
```

### Remove a Watermark or Stamp
```
1. Open image in Paint via APDocs Studio
2. Use Rectangular Select to box around the watermark
3. Press Delete — it fills with the background color (set to white first)
4. Save → back in APDocs Studio, export as clean PDF
```

### Crop to a Specific Region
```
1. Open in Paint → Select the region you want to keep
2. Click Image → Crop (or press Ctrl+Shift+X in newer Paint)
3. Save → APDocs Studio picks up the cropped image
```

---

## Getting Started

### Requirements
- Windows 10 or later (64-bit)
- .NET 9 Runtime ([download here](https://dotnet.microsoft.com/en-us/download/dotnet/9.0))
- Microsoft Paint (pre-installed on all Windows PCs)

### Build from Source

```bash
git clone https://github.com/atharvpawar16/APDocsStudio.git
cd APDocsStudio
dotnet build APDocsStudio.sln
dotnet run --project APDocsStudio.csproj
```

---

## Keyboard Shortcuts

| Action              | Shortcut            |
|---------------------|---------------------|
| Scan                | `Ctrl + Enter`      |
| Save as PDF         | `Ctrl + S`          |
| Save as Image       | `Ctrl + I`          |
| Import file         | `Ctrl + O`          |
| Batch Scan          | `Ctrl + B`          |
| Run OCR             | `Ctrl + Alt + O`    |
| Rotate Left         | `Ctrl + Shift + ←`  |
| Rotate Right        | `Ctrl + Shift + →`  |
| Email PDF           | `Ctrl + E`          |
| Print               | `Ctrl + P`          |
| Zoom In             | `Ctrl + +`          |
| Zoom Out            | `Ctrl + -`          |

---

## Project Structure

```
APDocsStudio/
├── Program.cs                  # Entry point
├── APDocsStudio.csproj         # Main project file
├── NAPS2.Images/               # Core image processing & pixel ops
├── NAPS2.Images.Gdi/           # GDI+ (System.Drawing) image backend
├── NAPS2.Escl/                 # ESCL protocol client & models
├── NAPS2.Escl.Server/          # ESCL network scanner server
├── NAPS2.Internals/            # Shared utilities & threading
├── NAPS2.Sdk/                  # Core scanning SDK (WIA/TWAIN/ESCL)
├── NAPS2.Lib/                  # App logic, config, UI controllers
├── NAPS2.Lib.WinForms/         # WinForms-specific UI layer
├── NAPS2.Setup/                # App settings & installer config
└── Stubs/                      # Platform compatibility stubs
```

> This repository shares ~50% of the full source. The UI layer, email integration, remoting, and update system are not included.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Language | C# 12 / .NET 9 |
| UI | Eto.Forms + WinForms |
| DI | Autofac |
| Scanning | NAPS2 SDK (WIA, TWAIN, ESCL) |
| OCR | Tesseract via NAPS2.Tesseract.Binaries |
| PDF | PdfSharp + Pdfium |
| Image Processing | GDI+ / System.Drawing |
| Logging | NLog |
| Serialization | Newtonsoft.Json + Protobuf |

---

## License

Copyright © 2024 Atharv Pawar. All rights reserved.

Core scanning libraries are derived from the [NAPS2 project](https://github.com/cyanfish/naps2) and licensed under the GPL. See individual `LICENSE` files in each subfolder.

---

Made by **Atharv Pawar** · [GitHub](https://github.com/atharvpawar16)
