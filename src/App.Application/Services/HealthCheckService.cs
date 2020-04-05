
using App.Application.Interfaces;
using App.Domain.Interfaces;

namespace App.Application.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository _healthCheckRepository;

        public HealthCheckService(IHealthCheckRepository healthCheckRepository)
        {
            _healthCheckRepository = healthCheckRepository;
        }
        public string Readings()
        {
            return _healthCheckRepository.GetAllDataBase();
        }
    }
}
