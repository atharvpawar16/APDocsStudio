namespace NAPS2.Util;

public static class ProcessHelper
{
    public static void OpenUrl(string url)
    {
        // Only allow http/https URLs to prevent shell injection via other URI schemes
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            return;
        }
        Process.Start(new ProcessStartInfo(uri.AbsoluteUri) { UseShellExecute = true });
    }

    public static void OpenFile(string file)
    {
        Process.Start(new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = file,
            Verb = "open"
        });
    }

    public static void OpenFolder(string folder) => OpenFile(folder);

    /// <summary>
    /// Runs a command without shell execution and reports whether it exits successfully within the timeout.
    /// Output is discarded, but both redirected pipes must be drained to avoid blocking verbose commands.
    /// </summary>
    public static bool TryRun(string command, string args, int timeoutMs)
    {
        // Match Process.WaitForExit's timeout range without starting a process we cannot wait for.
        if (timeoutMs < -1)
        {
            return false;
        }

        try
        {
            using var process = Process.Start(new ProcessStartInfo(command, args)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            });
            if (process == null)
            {
                return false;
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            if (!process.WaitForExit(timeoutMs))
            {
                process.Kill();
                return false;
            }

            return process.ExitCode == 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
