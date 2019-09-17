using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contract.Repositories;
using Project.Domain.Entities;
using Project.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project.Infra.Repositories
{
	public class BaseRepository<TEntity> : 
		IBaseRepositories<TEntity> where TEntity: class
	{
		private readonly DataContext context;

		public BaseRepository(DataContext context)
		{
			this.context = context;
		}

		public virtual void Insert(TEntity obj)
		{
			context.Entry(obj).State = EntityState.Added;
			context.SaveChanges();
		}

		public virtual void Update(TEntity obj)
		{
			context.Entry(obj).State = EntityState.Modified;
			context.SaveChanges();
		}

		public virtual void Delete(TEntity obj)
		{
			context.Entry(obj).State = EntityState.Deleted;
			context.SaveChanges();
		}

		public virtual List<TEntity> SelectAll()
		{
			return context.Set<TEntity>().ToList();
		}

		public virtual List<TEntity> SelectAll(DateTime of, DateTime to)
		{
			return context.Set<TEntity>().ToList();
		}

		public virtual List<TEntity> SelectAllDate(DateTime obj)
		{
			return context.Set<TEntity>().ToList();
		}

		public virtual TEntity SelectOne(int id)
		{
			return context.Set<TEntity>().Find(id);
		}

		public virtual TEntity SelectOne(DateTime obj)
		{
			return context.Set<TEntity>().Find(obj);
		}

		public virtual int Count()
		{
			return context.Set<TEntity>().Count();
		}

		public virtual int Count(DateTime obj)
		{
			return context.Set<TEntity>().Count();
		}

		public virtual void Dispose()
		{
			context.Dispose();
		}
	}
}
