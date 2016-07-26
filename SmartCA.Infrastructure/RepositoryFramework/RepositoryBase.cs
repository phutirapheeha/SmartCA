using System;
using System.Collections.Generic;
using System.Linq;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public abstract class RepositoryBase<T>
        : IRepository<T>, IUnitOfWorkRepository where T : EntityBase
    {
        private IUnitOfWork unitOfWork;

        protected RepositoryBase()
            : this(null)
        {
        }

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region IRepository<T> Members
        
        public abstract T FindBy(object key);
        public abstract IList<T> FindAll();

        public void Add(T item)
        {
            if (this.unitOfWork != null)
                this.unitOfWork.RegisterAdded(item, this);
        }

        public T this[object key]
        {
            get
            {
                return this.FindBy(key);
            }
            set
            {
                if(this.FindBy(key) == null)
                {
                    this.Add(value);
                }
                else
                {
                    this.unitOfWork.RegisterChanged(value, this);
                }
            }
        }

        public void Remove(T item)
        {
            if (this.unitOfWork != null)
                this.unitOfWork.RegisterRemoved(item, this);
        }
        #endregion

        #region IUnitOfWorkRepository Members

        public void PersistNewItem(EntityBase item)
        {
            this.PersistNewItem((T)item);
        }

        public void PersistUpdateItem(EntityBase item)
        {
            this.PersistUpdateItem((T)item);
        }

        public void PersistDeletedItem(EntityBase item)
        {
            this.PersistDeletedItem((T)item);
        }

        #endregion

        protected IUnitOfWork UnitOfWork
        {
            get { return this.unitOfWork; }
        }

        protected abstract void PersistNewItem(T item);
        protected abstract void PersistUpdatedItem(T item);
        protected abstract void PersistDeletedItem(T item);
    }
}
