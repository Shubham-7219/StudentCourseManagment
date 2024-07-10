﻿using System.Linq.Expressions;

namespace StudentCourseManagment.Repository.GeneralRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
       T Get(Expression<Func<T, bool>> filter);
       void Add(T entity);
       //void Update(T entity);
       void Remove(T entity);
       void RemoveRange(IEnumerable<T> entity);
       
    }
}
