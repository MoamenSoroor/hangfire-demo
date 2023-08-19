
using Hangfire;

internal partial class Program
{
    public class HangfireRunningService
    {
        private BackgroundJobServer _server;

        public void Start()
        {
            //BackgroundJobServerOptions options = new BackgroundJobServerOptions()
            //{
            //    Queues = new string[] {"default","HighPriority"}
            //};
            _server = new BackgroundJobServer();
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}