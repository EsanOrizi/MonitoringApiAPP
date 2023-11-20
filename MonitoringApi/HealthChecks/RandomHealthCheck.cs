using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MonitoringApi.HealthChecks
{
    public class RandomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            int responseTimeInMs = Random.Shared.Next(3000);
            
            if (responseTimeInMs < 1000)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy($"response was excellent ({responseTimeInMs})"));
            }
            else if (responseTimeInMs < 2000)
            {
                return Task.FromResult(
                    HealthCheckResult.Degraded($"response was more than expected ({responseTimeInMs})"));
            }
            else 
            {   return Task.FromResult(
                    HealthCheckResult.Unhealthy($"response was bad ({responseTimeInMs})"));
            }

        }
    }
}
