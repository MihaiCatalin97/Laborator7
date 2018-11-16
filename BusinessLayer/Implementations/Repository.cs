using BusinessLayer.Abstractions;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Implementations
{
    public abstract class Repository : IRepository
    {
        protected readonly ApplicationContext _context;

        protected Repository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Update(entity);
        }

        public ICollection<T> GetAll<T>() where T : BaseEntity
        {
            return  _context.Set<T>().ToList();
        }

        public T GetById<T>(Guid Id) where T : BaseEntity
        {
            return  _context.Set<T>().SingleOrDefault(p => p.Id == Id);
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}