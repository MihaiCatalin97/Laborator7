using DataLayer.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Abstractions
{
    public interface IRepository 
    {
        void Create<T>(T entity)
            where T : BaseEntity;

        void Update<T>(T entity)
            where T : BaseEntity;

        ICollection<T> GetAll<T>()
            where T : BaseEntity;

        T GetById<T>(Guid Id)
            where T : BaseEntity;

        void Delete<T>(T entity)
            where T : BaseEntity;

        void Save();
    }
}
