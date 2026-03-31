using NAPS2.Remoting.Worker;

namespace NAPS2.Pdf;

internal class PdfiumWorkerCoordinator : IPdfRenderer
{
    private readonly WorkerPool _workerPool;

    public PdfiumWorkerCoordinator(WorkerPool workerPool)
    {
        _workerPool = workerPool;
    }

    public IEnumerable<IMemoryImage> Render(ImageContext imageContext, string path, PdfRenderSize renderSize,
        string? password = null)
    {
        if (password != null)
        {
            throw new NotSupportedException("Password-protected PDF rendering is not supported in worker mode.");
        }
        var image = _workerPool.Use(
            WorkerType.Native,
            worker =>
            {
                var imageStream = new MemoryStream(worker.Service.RenderPdf(path, renderSize.Dpi ?? 300));
                return imageContext.Load(imageStream);
            });
        return new[] { image };
    }

    public IEnumerable<IMemoryImage> Render(ImageContext imageContext, byte[] buffer, int length,
        PdfRenderSize renderSize, string? password = null)
    {
        if (password != null)
        {
            throw new NotSupportedException("Password-protected PDF rendering is not supported in worker mode.");
        }
        var tempPath = Path.GetTempFileName() + ".pdf";
        try
        {
            File.WriteAllBytes(tempPath, buffer[..length]);
            return Render(imageContext, tempPath, renderSize);
        }
        finally
        {
            File.Delete(tempPath);
        }
    }

    public IMemoryImage RenderPage(ImageContext imageContext, string path, PdfRenderSize renderSize, int pageIndex,
        string? password = null)
    {
        return Render(imageContext, path, renderSize, password).ElementAt(pageIndex);
    }

    public IMemoryImage RenderPage(ImageContext imageContext, byte[] buffer, int length, PdfRenderSize renderSize,
        int pageIndex, string? password = null)
    {
        return Render(imageContext, buffer, length, renderSize, password).ElementAt(pageIndex);
    }
}