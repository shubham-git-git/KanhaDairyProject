
using KanhaDairy.DAL.Data;
using KanhaDairy.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly KanhaDairyDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(KanhaDairyDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Adds a new entity to the data source asynchronously
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// Updates an existing entity in the data source asynchronously
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask; // Simulate async behavior, since we're not actually saving changes to the database here  
        }

        /// <summary>
        /// Delete/Soft delete an existing entity from the data source asynchronously
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);  // Soft delete by updating the entity's status or a specific property to indicate it's deleted             
            await Task.CompletedTask; // Simulate async behavior, since we're not actually removing the entity from the database
        }
        /// <summary>
        /// Retrieves a single entity by its unique identifier (ID)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }

        /// <summary>
        /// Retrieves all entities from the data source
        /// </summary>      
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Checks if any entity matches the given condition (predicate)
        /// Returns true if at least one match is found, otherwise false
        /// </summary>      
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        /// <summary>
        /// Returns the first entity that matches the condition
        /// Returns null if no match is found
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Finds and returns a list of entities that match the given condition
        /// </summary>    
        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Returns a single entity that matches the condition
        /// Returns null if no match is found
        /// Throws an exception if more than one match is found
        /// </summary>       
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Saves all pending changes to the data source asynchronously
        /// </summary>       
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
