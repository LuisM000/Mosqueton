﻿using System;
using System.Collections.Generic;

namespace Mosqueton.Data.Interfaces
{
    public interface IRepository<T> where T : IBaseEntity
    {
        T GetById(int id);
        IReadOnlyList<T> ListAll();
        IReadOnlyList<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(ISpecification<T> spec);
    }
}
