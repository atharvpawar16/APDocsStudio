using System;
using System.IO;
using System.Runtime;
using NAPS2;
using NAPS2.EntryPoints;

namespace APDocsStudio;

static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var profilesPath = Path.Combine(Paths.AppData, "jit");
        Directory.CreateDirectory(profilesPath);
        ProfileOptimization.SetProfileRoot(profilesPath);
        ProfileOptimization.StartProfile("apdocsstudio.jit");

        WinFormsEntryPoint.Run(args);
    }
}
