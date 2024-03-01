using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Interfaces
{
    public interface IGenericRepository<TContext,TEntity>
        where TContext:DbContext, new() // TContext dediğimiz şey bir DbContext'tir 
        where TEntity : class, new() // TEntity dediğimiz ise bir classtır 
    {
        
        List<TEntity> GetAll(TContext context,Expression<Func<TEntity,bool>> filter=null,params string[] tbl); // filtre null gelirse tüm listeyi getir.Filtrele
        TEntity GetByFilter(TContext context,Expression<Func<TEntity,bool>> filter, params string[] tbl); // tek kayıt getirir.
        TEntity GetById(TContext context,int? id); //int? null değerde gelebilir demek

        void InsertorUpdate(TContext context,TEntity entity);
        void Delete(TContext context, Expression<Func<TEntity,bool>> filter);
        void Save(TContext context);


    }
}
