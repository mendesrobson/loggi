using System;

namespace App.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
