using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcCv.Repository
{
    public class GenericRepository<T> where T : class ,new()
    {
        CvDbEntities db=new CvDbEntities();
        //her tabloya ayrı ayrı control sınıflarında veri çekmektense
        //generic yapısını kullanıp oratk kullanımlık veri çekmek
        //sınıfı yapıyoruz.
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
           
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();

        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)// whereden gelen şarta göre ilk değeri döndür
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}