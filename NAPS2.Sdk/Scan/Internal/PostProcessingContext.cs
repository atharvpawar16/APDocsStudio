namespace NAPS2.Scan.Internal;

internal class PostProcessingContext
{
    /// <summary>
    /// Stores the scan page number for determining whether we're scanning the front or back side of a page in a duplex
    /// scan.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Stores the path to an image file on disk with the scanned image (after some transformations) for use in
    /// post-scan OCR. This is an optimization to avoid having to immediately re-render the image.
    /// </summary>
    public string? TempPath { get; set; }
}