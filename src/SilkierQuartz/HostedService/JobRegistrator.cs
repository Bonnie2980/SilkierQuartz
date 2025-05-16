using Microsoft.Extensions.DependencyInjection;

namespace SilkierQuartz.HostedService
{
    internal class JobRegistrator(IServiceCollection services) : IJobRegistrator
    {
        public IServiceCollection Services { get; } = services;
    }
}
