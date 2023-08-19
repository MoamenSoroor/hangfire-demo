using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestingHangfire.Jobs.Configurations
{
    public class MyJobActivator : JobActivator
    {
        private readonly IServiceProvider provider;
        private readonly ILogger _logger = Log.Logger.ForContext<MyJobActivator>();
        public MyJobActivator(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public override object ActivateJob(Type type)
        {
            try
            {
                using (var scope = provider.CreateScope())
                {
                    var result = scope.ServiceProvider.GetService(type);
                    if(result == null) {
                        _logger.Warning("dependnecy not found: {type}",type.FullName);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        
    }

    
}
