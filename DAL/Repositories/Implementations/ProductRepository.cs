using Core.Entities;
using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class ProductRepository: IProductRepository
    {
        readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public DbSet<Product> Table => _context.Set<Product>();

        public async Task<Product> Create(Product entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public void Delete(Product entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<Product> FindAll(Expression<Func<Product, bool>> expression)
        {

            return expression != null ? Table.Where(expression) : Table;
        }

        public IQueryable<Product> GetAll()
        {
            return Table;
        }

        public async Task<Product> GetbyId(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Product entity)
        {
            Table.Update(entity);
        }
        public async Task<bool> IsExsist(Expression<Func<Product, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public void SoftDelete(Product entity)
        {
            entity.IsDeleted = true;
            Table.Update(entity);
        }
    }
}
