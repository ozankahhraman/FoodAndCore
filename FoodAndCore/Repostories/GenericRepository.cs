using FoodAndCore.Data.Context;
using FoodAndCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodAndCore.Repostories
{
    public class GenericRepository<T> where T : class,new()
    {
        Context db = new Context();

        public List<T> TList()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TRemove(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public void TUpdate(T p)
        {

            db.Set<T>().Update(p);
            db.SaveChanges();
        }

        public T GetT(int id)
        {
           return db.Set<T>().Find(id);
        }

        public List<T> GetList(string p)
        {
            return db.Set<T>().Include(p).ToList();
        }
    }
}
