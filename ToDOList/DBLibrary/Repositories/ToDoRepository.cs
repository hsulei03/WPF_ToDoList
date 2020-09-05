using DBLibrary.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Repositories
{

        public class ToDoRepository<T> where T : class
        {
            private ToDoModel _context;
            public ToDoRepository(ToDoModel context)
            {
                if (context == null)
                {
                    throw new ArgumentException();
                }
                _context = context;
            }

            public void Create(T entity)
            {
                _context.Entry(entity).State = EntityState.Added;
            }

            public void Update(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }

            public void Delete(T entity)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }

            public IQueryable<T> GetAll()
            {
                return _context.Set<T>();
            }
        }
    
}
