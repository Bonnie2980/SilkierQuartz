using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Concurrent;

namespace SilkierQuartz.HostedService
{
    public class ServiceCollectionJobFactory(IServiceProvider container) : IJobFactory
    {
        protected readonly IServiceProvider Container = container;
        private ConcurrentDictionary<IJob, IServiceScope> _createdJob = new();

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var scoped = Container.CreateScope();
            var result = scoped.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
            if (result != null)
            {
                _createdJob.AddOrUpdate(result, scoped, (j, s) => scoped);
            }
            return result;
        }

        public void ReturnJob(IJob job)
        {
            if (_createdJob.TryRemove(job, out var scope))
            {
                scope.Dispose();
            }

            var disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }
}