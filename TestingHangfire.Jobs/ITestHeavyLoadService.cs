namespace TestingHangfire.Jobs
{
    public interface ITestHeavyLoadService
    {
        void DoHeavyOperation1();
        void DoHeavyOperation2();
        void DoHeavyOperation3(string dummyValue);
        void DoHeavyOperation4(OperationRequest request);
    }
}