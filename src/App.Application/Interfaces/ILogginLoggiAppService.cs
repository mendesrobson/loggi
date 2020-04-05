using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface ILogginLoggiAppService
    {
        string EfetuarLogin(Login login);
    }
}
