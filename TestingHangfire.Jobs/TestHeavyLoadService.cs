using Serilog;
using TestingHangfire.Data;

namespace TestingHangfire.Jobs
{
    public class TestHeavyLoadService : ITestHeavyLoadService
    {
        private readonly ITestingRepo repo;
        private readonly ILogger logger;
        public TestHeavyLoadService(ITestingRepo repo)
        {
            this.repo = repo;
            logger = Log.Logger.ForContext<TestHeavyLoadService>();
        }

        public void DoHeavyOperation1()
        {
            try
            {
                logger.Information("do heavy Operation 1");
                Random random = new Random();
                Thread.Sleep(random.Next(1000, 6000));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                throw;
            }
        }

        public void DoHeavyOperation2()
        {
            try
            {
                logger.Information("do heavy Operation 2");
                Random random = new Random();
                Thread.Sleep(random.Next(1000, 6000));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                throw;
            }
        }

        public void DoHeavyOperation3(string dummyValue)
        {
            try
            {
                logger.Information("do heavy Operation 3");
                logger.Information($"Value: {dummyValue}");
                Random random = new Random();
                Thread.Sleep(random.Next(1000, 6000));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
        }

        public void DoHeavyOperation4(OperationRequest request)
        {
            try
            {
                logger.Information("do heavy Operation 4");
                logger.Information($"id: {request.ReqeustId}");
                logger.Information($"Desc: {request.Description}");
                Random random = new Random();
                Thread.Sleep(random.Next(1000, 6000));
                logger.Information($"End Of: {request.ReqeustId} - {request.Description}");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}