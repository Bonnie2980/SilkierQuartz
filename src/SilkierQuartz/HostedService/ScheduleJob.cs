using Quartz;
using System.Collections.Generic;

namespace SilkierQuartz.HostedService
{
    internal class ScheduleJob(IJobDetail jobDetail, IEnumerable<ITrigger> triggers) : IScheduleJob
    {
        public IJobDetail JobDetail { get; set; } = jobDetail;
        public IEnumerable<ITrigger> Triggers { get; set; } = triggers;
    }
}
