# FAQ

## General

**Is APDocs Studio free?**
Yes. APDocs Studio is completely free and open source under the GPL-2.0 license.

**Does it work on Mac or Linux?**
No. APDocs Studio is built specifically for Windows 10 and Windows 11 (64-bit).

**Do I need to install anything?**
You need the [.NET 9 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (free, ~50 MB). The app itself requires no installation — just run the EXE.

---

## Features

**Does it support OCR?**
Yes. OCR is powered by Tesseract and supports 40+ languages. Press `Ctrl+Alt+O` to run OCR on any page.

**Can I edit existing PDFs?**
Yes. Use `Ctrl+O` to import any PDF. You can edit individual pages, reorder, merge, and re-export.

**How does Paint integration work?**
Right-click any page and select "Edit with Paint". Make your edits in Paint, press `Ctrl+S`, and APDocs Studio reloads the image automatically. See the [Paint Integration Guide](Paint-Integration-Guide).

**Can I send PDFs by email?**
Yes. APDocs Studio supports Gmail, Outlook, Thunderbird, and any MAPI-compatible email client. Press `Ctrl+E` to email.

---

## Troubleshooting

**The app won't start — what do I do?**
Make sure [.NET 9 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) is installed. If it still won't start, check the logs in `%AppData%\NAPS2\`.

**OCR is not working.**
OCR language data is downloaded on first use. Make sure you have an internet connection when running OCR for the first time.

**Paint doesn't open when I click "Edit with Paint".**
Make sure Microsoft Paint is installed. On Windows 11, Paint may need to be reinstalled from the Microsoft Store if it was removed.

**The app is slow on large PDFs.**
Large PDFs with many pages can be memory-intensive. Try processing in smaller batches or increasing available RAM.

---

## Contributing

**Can I contribute to the project?**
Yes. Fork the repo, make your changes on a branch, and open a pull request. See [Building from Source](Building-from-Source) to get started.

**How do I report a bug?**
Open an issue at [github.com/atharvpawar16/APDocsStudio/issues](https://github.com/atharvpawar16/APDocsStudio/issues).
