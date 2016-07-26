using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> FindAll();
        T FindBy(object key);
        void Add(T item);
        T this[object key] { get; set; }
        void Remove(T item);
    }
}
