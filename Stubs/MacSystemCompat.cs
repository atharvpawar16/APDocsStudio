namespace NAPS2.Platform
{
    // Stub: Mac/Linux platform compatibility — not supported in the Windows-only APDocs Studio build.
    // This satisfies the ISystemCompat interface contract without pulling in Mac-specific dependencies.
    internal class MacSystemCompat : ISystemCompat
    {
        public bool IsWiaDriverSupported => false;
        public bool IsTwainDriverSupported => false;
        public bool IsAppleDriverSupported => false;
        public bool IsSaneDriverSupported => false;
        public bool IsEsclDriverSupported => true;
        public bool SupportsTheme => false;
        public bool SupportsShowPageNumbers => true;
        public bool SupportsProfilesToolbar => true;
        public bool SupportsButtonActions => false;
        public bool SupportsKeyboardShortcuts => true;
        public bool SupportsSingleInstance => true;
        public bool CanUseWin32 => false;
        public bool CanEmail => false;
        public bool CanPrint => false;
        public bool CombinedPdfAndImageSaving => false;
        public bool ShouldRememberBackgroundOperations => false;
        public bool RenderInWorker => false;
        public bool SupportsWinX86Worker => false;
        public string? NativeWorkerAlias => null;
        public string? WinX86WorkerAlias => null;
        public string WorkerCrashMessage => "";
        public string[] ExeSearchPaths => Array.Empty<string>();
        public string[] LibrarySearchPaths => Array.Empty<string>();
        public string TesseractExecutableName => "tesseract";
        public string PdfiumLibraryName => "pdfium";
        public string[]? SaneLibraryDeps => null;
        public string SaneLibraryName => "";
        public bool IsLibUsbReliable => false;
        public IntPtr LoadLibrary(string path) => IntPtr.Zero;
        public IntPtr LoadSymbol(IntPtr libraryHandle, string symbol) => IntPtr.Zero;
        public string GetLoadError() => "";
        public IDisposable? FileReadLock(string path) => null;
        public IDisposable? FileWriteLock(string path) => null;
        public void SetEnv(string name, string value) { }
    }
}
