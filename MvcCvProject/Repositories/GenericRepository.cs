﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().FirstOrDefault(filter);
        }
    }
}