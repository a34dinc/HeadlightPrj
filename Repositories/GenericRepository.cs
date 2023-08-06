using HeadlightPrj.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HeadlightPrj.Repositories
{

    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();

        public List<T> TListele()
        {
            return c.Set<T>().ToList();
        }

        public void TAdd(T item)
        {
            c.Set<T>().Add(item);
            c.SaveChanges();
        }
        public void TDelete(T item)
        {
            c.Set<T>().Remove(item);
            c.SaveChanges();
        }
        public void TUpdate(T item)
        {
            c.Set<T>().Update(item);
            c.SaveChanges();
        }
        public T TGet(int id) 
        { 
            return c.Set<T>().Find(id); 
        }

        public List<T> TListele(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
    }
}
