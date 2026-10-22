# Core regression tests

Run with the .NET 9 SDK on Windows or Linux:

```sh
dotnet test tests/APDocsStudio.Core.Tests/APDocsStudio.Core.Tests.csproj --configuration Release
```

The test project links the actual platform-neutral production files. It deliberately
does not reference the Windows executable, so utility regressions can be checked
without a Windows desktop or scanner. The app's explicit source includes keep the
test code out of the shipped executable.

Coverage includes child-process exit codes, timeouts, missing commands and verbose
stdout/stderr; selected-page order; interleave round trips; range replacement; and
selection equality/hash consistency. Shell-based process tests use `/bin/sh` on
Linux and `cmd.exe` on Windows, with no external test program required.

GitHub Actions runs the tests on both platforms and builds the complete application
on Windows. Existing CodeQL analysis remains separate. Tests are not substitutes for
manual Windows checks of scanning, Paint, OCR, PDF export or keyboard interaction.
