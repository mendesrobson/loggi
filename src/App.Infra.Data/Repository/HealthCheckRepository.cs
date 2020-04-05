using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App.Infra.Data.Repository
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        public HealthCheckRepository()
        {
        }

        public string GetAllDataBase()
        {
            try
            {
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
