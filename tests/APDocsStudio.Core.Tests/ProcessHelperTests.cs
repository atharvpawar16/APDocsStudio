using NAPS2.Util;

namespace APDocsStudio.Core.Tests;

public class ProcessHelperTests
{
    [Fact]
    public void ReturnsTrueForSuccessfulExit() => Assert.True(RunShell("exit 0"));

    [Fact]
    public void ReturnsFalseForFailedExit() => Assert.False(RunShell("exit 7"));

    [Fact]
    public void ReturnsFalseForMissingCommand() =>
        Assert.False(ProcessHelper.TryRun("apdocs-command-that-does-not-exist", "", 1000));

    [Fact]
    public void ReturnsFalseForInvalidTimeout() =>
        Assert.False(ProcessHelper.TryRun("apdocs-command-that-does-not-exist", "", -2));

    [Fact]
    public void AllowsInfiniteTimeout() => Assert.True(RunShell("exit 0", -1));

    [Fact]
    public void DrainsBothPipesWithoutDeadlock()
    {
        var script = OperatingSystem.IsWindows()
            ? "for /L %i in (1,1,12000) do @(echo output-line-%i & echo error-line-%i 1>&2)"
            : "i=0; while [ $i -lt 12000 ]; do echo output-line; echo error-line >&2; i=$((i+1)); done";
        Assert.True(RunShell(script, 15000));
    }

    [Fact]
    public void StopsLongRunningCommandAtTimeout()
    {
        var script = OperatingSystem.IsWindows()
            ? "for /L %i in (1,0,2) do @rem wait"
            : "while :; do :; done";
        var elapsed = Stopwatch.StartNew();
        Assert.False(RunShell(script, 200));
        Assert.True(elapsed.Elapsed < TimeSpan.FromSeconds(10));
    }

    private static bool RunShell(string script, int timeoutMs = 5000) =>
        OperatingSystem.IsWindows()
            ? ProcessHelper.TryRun("cmd.exe", $"/d /c \"{script}\"", timeoutMs)
            : ProcessHelper.TryRun("/bin/sh", $"-c \"{script}\"", timeoutMs);
}
