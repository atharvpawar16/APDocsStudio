using System.Security.Cryptography;

namespace NAPS2.Escl.Server;

internal static class PortFinder
{
    private const int MAX_PORT_TRIES = 5;
    private const int RANDOM_PORT_MIN = 10001;
    private const int RANDOM_PORT_MAX = 19999;

    public static async Task RunWithSpecifiedOrRandomPort(int defaultPort, Func<int, Task> portTaskFunc,
        CancellationToken cancelToken)
    {
        int port = defaultPort;
        int retries = 0;
        if (port == 0)
        {
            port = RandomPort();
        }
        while (true)
        {
            try
            {
                await portTaskFunc(port);
                break;
            }
            catch (Exception)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    break;
                }
                retries++;
                port = RandomPort();
                if (retries > MAX_PORT_TRIES)
                {
                    throw;
                }
            }
        }
    }

    private static int RandomPort()
    {
        var bytes = new byte[4];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        uint value = BitConverter.ToUInt32(bytes, 0);
        return RANDOM_PORT_MIN + (int) (value % (uint) (RANDOM_PORT_MAX - RANDOM_PORT_MIN + 1));
    }
}