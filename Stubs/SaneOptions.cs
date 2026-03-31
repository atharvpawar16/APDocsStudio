using System.Threading;
using NAPS2.Scan.Internal;

namespace NAPS2.Scan
{
    // Stub: SaneOptions model — SANE (Scanner Access Now Easy) is a Linux/Mac scanner protocol.
    // Not supported in the Windows-only APDocs Studio build. Kept to satisfy SDK compilation.
    public class SaneOptions
    {
        public string? Backend { get; set; }
        public bool KeepInitialized { get; set; }
    }
}

namespace NAPS2.Scan.Internal.Sane
{
    // Stub: SANE scan driver — not supported on Windows. Returns empty/no-op results for all operations.
    internal class SaneScanDriver : IScanDriver
    {
        public SaneScanDriver(ScanningContext ctx) { }
        public static string GetBackend(ScanDevice device) => "";
        public Task GetDevices(ScanOptions options, CancellationToken cancelToken, Action<ScanDevice> callback)
            => Task.CompletedTask;
        public Task<ScanCaps> GetCaps(ScanOptions options, CancellationToken cancelToken)
            => Task.FromResult(new ScanCaps());
        public Task Scan(ScanOptions options, CancellationToken cancelToken, IScanEvents scanEvents, Action<IMemoryImage> callback)
            => Task.CompletedTask;
    }
}
