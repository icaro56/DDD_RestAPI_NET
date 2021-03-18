using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using RestAPIModeloDDD.Domain.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIModeloDDD.Infraestructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        //private readonly SqlContext sqlContext;
        protected readonly DbContextOptions<SqlContext> OptionsBuilder;

        public RepositoryBase(/*SqlContext sqlContext*/)
        {
            //this.sqlContext = sqlContext;
            OptionsBuilder = new DbContextOptions<SqlContext>();
        }

        public async Task Add(TEntity obj)
        {
            using (var data = new SqlContext(OptionsBuilder))
            {
                await data.Set<TEntity>().AddAsync(obj);
                await data.SaveChangesAsync();
            }

            /*try
            {
                await sqlContext.Set<TEntity>().AddAsync(obj);
                await sqlContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }*/
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var data = new SqlContext(OptionsBuilder))
            {
                return await data.Set<TEntity>().AsNoTracking().ToListAsync();
            }

            //return sqlContext.Set<TEntity>().ToList();
        }

        public async Task<TEntity> GetById(int id)
        {
            using (var data = new SqlContext(OptionsBuilder))
            {
                return await data.Set<TEntity>().FindAsync(id);
            }

            //return sqlContext.Set<TEntity>().Find(id);
        }

        public async Task Remove(TEntity obj)
        {
            using (var data = new SqlContext(OptionsBuilder))
            {
                data.Set<TEntity>().Remove(obj);
                await data.SaveChangesAsync();
            }

            /*try
            {
                sqlContext.Set<TEntity>().Remove(obj);
                await sqlContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }*/
        }

        public async Task Update(TEntity obj)
        {
            using (var data = new SqlContext(OptionsBuilder))
            {
                data.Set<TEntity>().Update(obj);
                await data.SaveChangesAsync();
            }

            /*try
            {
                sqlContext.Entry(obj).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }*/
        }

        #region Disposed

        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }

        #endregion
    }
}
