using AppDDD.Core.DomainObjects;
using System;

namespace AppDDD.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}