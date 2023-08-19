using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestingHangfire.Jobs;
using TestingHangfire.Models;

namespace TestingHangfire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestHeavyLoadService jobsService;

        public HomeController(ILogger<HomeController> logger, ITestHeavyLoadService jobsService)
        {
            _logger = logger;
            this.jobsService = jobsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult TestFireAndForget(){

            string jobId = BackgroundJob.Enqueue(()=> jobsService.DoHeavyOperation1());
            
            return RedirectToAction("index");
        }
        public IActionResult TestDelayed(){

            string jobId = BackgroundJob.Schedule(() => jobsService.DoHeavyOperation2(), TimeSpan.FromMinutes(1));

            return RedirectToAction("index");
        }
        public IActionResult TestContinuations(){

            string argumentToJobMethod = "I am Argument from the home controller";

            string jobId = BackgroundJob.Schedule(() => jobsService.DoHeavyOperation1(), TimeSpan.FromMinutes(1));

            string jobId2 = BackgroundJob.ContinueJobWith(jobId,()=> jobsService.DoHeavyOperation2());
            string jobId3 = BackgroundJob.ContinueJobWith(jobId2,()=> jobsService.DoHeavyOperation3(argumentToJobMethod));

            return RedirectToAction("index");
        }
        public IActionResult TestRecurringJobs()
        {
            var request = new OperationRequest()
            {
                Description = " i am request object",
                ReqeustId = 1,
            };
            RecurringJob.AddOrUpdate("TestRecurringJobs", () => jobsService.DoHeavyOperation4(request), Cron.Minutely());
            return RedirectToAction("index");
        }

        public IActionResult TestClearRecurringJobs()
        {
            RecurringJob.RemoveIfExists("TestRecurringJobs");
            return RedirectToAction("index");
        }

        public IActionResult TestTriggerRecurringJobs()
        {
            RecurringJob.TriggerJob("TestRecurringJobs");
            return RedirectToAction("index");
        }



    }
}